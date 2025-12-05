using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using ChattingAppTeam6.Home.Models;
using ChattingAppTeam6.Home.Service;
using ChattingAppTeam6.Home.Utils;

namespace ChattingAppTeam6.Home
{
    public partial class HomeMain : Form
    {
        private readonly DBconnector _db = DBconnector.GetInstance();
        private readonly AuthService _auth;
        private readonly ChatService _chatService;
        private readonly OrgService _orgService;
        private readonly ProfileService _profileService;

        private int MeId => _auth.CurrentUserId ?? 0;

        private int? _selectedUserIdInTree = null;

        public HomeMain()
        {
            InitializeComponent();

            _db.InitServer(
                host: "223.130.151.111",
                port: 3306,
                database: "s5819937",
                username: "s5819937",
                password: "s5819937"
            );

            _auth = new AuthService(_db);
            _chatService = new ChatService(_db);
            _orgService = new OrgService(_db);
            _profileService = new ProfileService(_db);

            // 로그아웃 라벨을 클릭 가능해 보이게 커서 변경함 (필요없으면 삭제 가능)
            LogoutLabel.Cursor = Cursors.Hand;

            // 처음에는 즐겨찾기 버튼을 숨겨뒀어요 깔끔해보이게!!
            favoriteInsertButton.Visible = false;
            favoriteDeleteButton.Visible = false;

            MemberSearch.KeyDown += MemberSearch_KeyDown;
            TeamMemberTreeView.AfterSelect += TeamMemberTreeView_AfterSelect_1;
            TeamMemberTreeView.NodeMouseDoubleClick += TeamMemberTreeView_NodeMouseDoubleClick;
        }

        // 트리뷰 더블클릭 시 그 사람과의 채팅방 켜짐!
        private void TeamMemberTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag is ValueTuple<string, int> tag)
            {
                string type = tag.Item1;
                int id = tag.Item2;

                if (type == "user")
                {
                    int targetUserId = id;

                    if (targetUserId == MeId)
                    {
                        MessageBox.Show("본인과는 채팅할 수 없습니다...?");
                        return;
                    }

                    // 트리에서 선택한 사용자와의 1:1 채팅방 열기 (있으면 기존, 없으면 새로)
                    OpenChatWithUser(targetUserId);
                }
            }
        }

        // ===================== 폼 로드 =====================
        private void HomeMain_Load_1(object sender, EventArgs e)
        {
            if (!_db.ConnectionTest())
            {
                return;
            }

            // 트리
            LoadTeamDepartmentTree();
            TeamMemberTreeView.ExpandAll();

            // UI
            UpdateLoginUiState();

            // 이미 로그인된 상태? (로그인 담당이 다른 분이라 어떻게 될진 모르겠네요)
            if (_auth.IsAuthenticated)
            {
                RefreshChatList();
                RefreshFavoriteList();
            }
        }
        

        // ===================== 로그인 / 로그아웃 =====================

        // 나중에 지워야됨 쓸모없음
        private void DoLogin()
        {
            var id = IDText.Text.Trim();
            var pw = PWText.Text;

            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(pw))
            {
                return;
            }

            if (_auth.Login(id, pw, out var error))
            {
                UpdateLoginUiState();

                LoadTeamDepartmentTree();
                TeamMemberTreeView.ExpandAll();

                // 관리자계정 로그인은 새빈이쪽에서 연결하는??
                RefreshChatList();
                RefreshFavoriteList();
            }
            else
            {
                MessageBox.Show(error ?? "로그인 실패");
            }
        }

        // 로그인하고넘어올때 쓰려고 만들긴했는데
        public void InitializeAfterLogin()
        {
            // UI
            UpdateLoginUiState();

            // 트리
            LoadTeamDepartmentTree();
            TeamMemberTreeView.ExpandAll();

            // 채팅/즐찾
            if (_auth.IsAuthenticated)
            {
                RefreshChatList();
                RefreshFavoriteList();
            }
        }

        // 로그아웃
        private void DoLogout()
        {
            if (!_auth.IsAuthenticated) return;

            _auth.Logout();
            UpdateLoginUiState();
            MessageBox.Show("로그아웃 되었습니다.");

            // 채팅리스트 텅
            flpChats.Controls.Clear();

            // 즐찾 텅
            if (FAVMemberList != null)
            {
                FAVMemberList.Items.Clear();
            }
            favoriteInsertButton.Visible = false;
            favoriteDeleteButton.Visible = false;

            // 트리 텅
            if (TeamMemberTreeView != null)
            {
                TeamMemberTreeView.Nodes.Clear();
            }

            // 트리텍스트박스 텅
            if (MemberSearch != null)
            {
                MemberSearch.Text = string.Empty;
            }

            _selectedUserIdInTree = null;

            // 다시 로그인 폼으로 이동시켜야됨
        }

        // 로그인 정보
        private void UpdateLoginUiState()
        {
            bool authed = _auth.IsAuthenticated;

            // 아이디,비밀번호 치는 창은 나중에 없앨거니까 딱히 필요한 코드는 아님
            IDText.Enabled = !authed;
            PWText.Enabled = !authed;
            LoginButton.Enabled = !authed;

            LogoutLabel.Enabled = authed;
            LogoutLabel.ForeColor = authed ? Color.Blue : Color.Gray;

            // Label 변경함
            if (authed)
            {
                var name = _auth.CurrentUserName ?? "";
                var nickname = !string.IsNullOrWhiteSpace(_auth.CurrentUserNickname)
                    ? _auth.CurrentUserNickname
                    : name;

                UserNicknameLabel.Text = nickname;
                UserNameLabel.Text = name;

                LoadCurrentUserProfileImage();
            }
            else
            {
                UserNicknameLabel.Text = "";
                UserNameLabel.Text = "";

                var old = UserPIC.Image;
                UserPIC.Image = null;
                old?.Dispose();
            }
        }

        // 프사
        private void LoadCurrentUserProfileImage()
        {
            if (!_auth.IsAuthenticated || !_auth.CurrentUserId.HasValue)
            {
                var old2 = UserPIC.Image;
                UserPIC.Image = null;
                old2?.Dispose();
                return;
            }

            byte[] imgBytes = _auth.CurrentUserImageBytes;
            string fallbackName = _auth.CurrentUserNickname ?? _auth.CurrentUserName ?? "";

            try
            {
                var old = UserPIC.Image;
                UserPIC.SizeMode = PictureBoxSizeMode.Zoom;

                if (imgBytes != null && imgBytes.Length > 0)
                {
                    // DB에 이미지가 있으면 그걸 사용!!
                    UserPIC.Image = ImageUtils.BytesToImage(imgBytes);
                }
                else
                {
                    // 없으면 이름 이니셜로 간단한 아바타 생성 (저도잘모르는코드)
                    UserPIC.Image = ImageUtils.CreateInitialsAvatar(fallbackName);
                }

                old?.Dispose();
            }
            catch (Exception ex)
            {
                // 깨지면 이니셜프사
                System.Diagnostics.Debug.WriteLine("[UserPIC] decode failed: " + ex);
                var old = UserPIC.Image;
                UserPIC.Image = ImageUtils.CreateInitialsAvatar(fallbackName);
                old?.Dispose();
            }
        }

        // ===================== 부서/팀/직원 트리 =====================

        // 부서/팀/유저를 전부 읽어서 TreeView 구성
        private void LoadTeamDepartmentTree()
        {
            int currentUserId = MeId;

            // 숨김처리한거 적용!!
            var hiddenDeptIds = new HashSet<int>();
            var hiddenUserIds = new HashSet<int>();

            var relDt = _db.Query(@"
        SELECT target_user_id, relation_type
        FROM user_relation
        WHERE user_id = @uid
          AND relation_type IN ('HIDE_DEPT', 'HIDE_USER');
    ", ("@uid", currentUserId));

            foreach (DataRow row in relDt.Rows)
            {
                string relType = Convert.ToString(row["relation_type"]);
                int targetId = Convert.ToInt32(row["target_user_id"]);
                if (relType == "HIDE_DEPT")
                {
                    hiddenDeptIds.Add(targetId);
                }
                else if (relType == "HIDE_USER")
                {
                    hiddenUserIds.Add(targetId);
                }
            }


            // 부서 목록
            var deptDt = _db.Query("SELECT id, name FROM department ORDER BY name;");
            // 팀 목록
            var teamDt = _db.Query("SELECT id, department_id, name FROM team ORDER BY name;");
            // 유저 목록 (숨겨진거 빼고)
            var userDt = _db.Query(@"
                SELECT u.id, u.name, u.team_id, t.department_id
                FROM `user` u
                LEFT JOIN team t ON t.id = u.team_id
                ORDER BY u.name;
            ");     

            TeamMemberTreeView.BeginUpdate();
            TeamMemberTreeView.Nodes.Clear();

            // 부서 노드
            var deptNodes = new Dictionary<int, TreeNode>();
            foreach (DataRow d in deptDt.Rows)
            {
                int deptId = Convert.ToInt32(d["id"]);

                // 숨겨진 부서(HIDE_DEPT)면 통째로 건너뜀
                if (hiddenDeptIds.Contains(deptId))
                    continue;

                string deptName = Convert.ToString(d["name"]) ?? $"Dept {deptId}";
                var node = new TreeNode(deptName) { Tag = ("dept", deptId) };
                TeamMemberTreeView.Nodes.Add(node);
                deptNodes[deptId] = node;
            }

            // 팀 노드
            var teamNodes = new Dictionary<int, TreeNode>();
            foreach (DataRow t in teamDt.Rows)
            {
                int teamId = Convert.ToInt32(t["id"]);
                int deptId = Convert.ToInt32(t["department_id"]);

                // 소속 부서가 숨김이면 이 팀도 안 보이게
                if (hiddenDeptIds.Contains(deptId))
                    continue;

                if (!deptNodes.TryGetValue(deptId, out var deptNode))
                    continue;

                string teamName = Convert.ToString(t["name"]) ?? $"Team {teamId}";
                var teamNode = new TreeNode(teamName) { Tag = ("team", teamId) };
                deptNode.Nodes.Add(teamNode);
                teamNodes[teamId] = teamNode;
            }

            // 유저 노드
            foreach (DataRow u in userDt.Rows)
            {
                int userId = Convert.ToInt32(u["id"]);
                int teamId = u.IsNull("team_id") ? -1 : Convert.ToInt32(u["team_id"]);
                int deptId = u.IsNull("department_id") ? -1 : Convert.ToInt32(u["department_id"]);
                string userName = Convert.ToString(u["name"]) ?? $"User {userId}";

                // HIDE_DEPT: 해당 부서 통째로 숨김
                if (deptId != -1 && hiddenDeptIds.Contains(deptId))
                    continue;

                // HIDE_USER: 해당 유저 숨김
                if (hiddenUserIds.Contains(userId))
                    continue;

                if (teamNodes.TryGetValue(teamId, out var teamNode))
                {
                    var userNode = new TreeNode(userName) { Tag = ("user", userId) };
                    teamNode.Nodes.Add(userNode);
                }
            }

            TeamMemberTreeView.EndUpdate();
            TeamMemberTreeView.ExpandAll();
        }

        // 검색
        private void DoSearch(string keyword)
        {
            // 검색어 없으면 전체 로드
            if (string.IsNullOrWhiteSpace(keyword))
            {
                LoadTeamDepartmentTree();
                TeamMemberTreeView.ExpandAll();
                return;
            }

            int currentUserId = MeId;

            var result = _orgService.SearchMembers(currentUserId, keyword);

            TeamMemberTreeView.BeginUpdate();
            TeamMemberTreeView.Nodes.Clear();

            var deptGroups = result.AsEnumerable()
                .GroupBy(r => new
                {
                    DeptId = r.IsNull("dept_id") ? -1 : Convert.ToInt32(r["dept_id"]),
                    DeptName = r.IsNull("dept_name") ? "(부서없음)" : Convert.ToString(r["dept_name"])
                });

            foreach (var dept in deptGroups)
            {
                var deptNode = new TreeNode(dept.Key.DeptName ?? "(부서없음)")
                {
                    Tag = ("dept", dept.Key.DeptId)
                };

                var teamGroups = dept.GroupBy(r => new
                {
                    TeamId = r.IsNull("team_id") ? -1 : Convert.ToInt32(r["team_id"]),
                    TeamName = r.IsNull("team_name") ? "(팀없음)" : Convert.ToString(r["team_name"])
                });

                foreach (var team in teamGroups)
                {
                    var teamNode = new TreeNode(team.Key.TeamName ?? "(팀없음)")
                    {
                        Tag = ("team", team.Key.TeamId)
                    };

                    foreach (var r in team)
                    {
                        if (r.IsNull("user_id")) continue;

                        int uid = Convert.ToInt32(r["user_id"]);
                        string uname = Convert.ToString(r["user_name"]) ?? $"User {uid}";

                        string displayText = uname;

                        var userNode = new TreeNode(displayText)
                        {
                            Tag = ("user", uid)
                        };
                        teamNode.Nodes.Add(userNode);
                    }

                    deptNode.Nodes.Add(teamNode);
                }

                TeamMemberTreeView.Nodes.Add(deptNode);
            }

            TeamMemberTreeView.ExpandAll();
            TeamMemberTreeView.EndUpdate();
        }

        // ===================== 즐겨찾기 관련  =====================

        // 즐찾 체크
        private bool IsFavorite(int meId, int targetUserId)
        {
            string sql = @"
                SELECT 1
                FROM favorite
                WHERE user_id = @uid AND target_user_id = @tid
                LIMIT 1;
            ";

            var dt = _db.Query(sql,
                ("@uid", meId),
                ("@tid", targetUserId)
            );

            return dt.Rows.Count > 0;
        }

        // 즐겨찾기 추가
        private void AddFavorite(int meId, int targetUserId)
        {
            string sql = @"
                INSERT IGNORE INTO favorite (user_id, target_user_id)
                VALUES (@uid, @tid);
            ";

            _db.ExecuteNonQuery(sql,
                ("@uid", meId),
                ("@tid", targetUserId)
            );
        }

        // 즐겨찾기 삭제
        private void RemoveFavorite(int meId, int targetUserId)
        {
            string sql = @"
                DELETE FROM favorite
                WHERE user_id = @uid AND target_user_id = @tid;
            ";

            _db.ExecuteNonQuery(sql,
                ("@uid", meId),
                ("@tid", targetUserId)
            );
        }

        // 현재 로그인 유저 기준 즐겨찾기 대상 ID 목록 조회
        private HashSet<int> LoadMyFavoriteUserIds()
        {
            var set = new HashSet<int>();

            if (!_auth.IsAuthenticated || !_auth.CurrentUserId.HasValue)
                return set;

            string sql = @"
                SELECT target_user_id
                FROM favorite
                WHERE user_id = @uid;
            ";

            var dt = _db.Query(sql, ("@uid", MeId));

            foreach (DataRow row in dt.Rows)
            {
                int tid = Convert.ToInt32(row["target_user_id"]);
                set.Add(tid);
            }

            return set;
        }

        // 즐찾리스트 갱신
        private void RefreshFavoriteList()
        {
            if (!_auth.IsAuthenticated || !_auth.CurrentUserId.HasValue)
            {
                if (FAVMemberList != null)
                    FAVMemberList.Items.Clear();
                return;
            }

            string sql = @"
                SELECT u.id, u.name
                FROM favorite f
                JOIN `user` u ON u.id = f.target_user_id
                WHERE f.user_id = @uid
                ORDER BY u.name;
            ";

            var dt = _db.Query(sql, ("@uid", MeId));

            if (FAVMemberList == null) return;

            FAVMemberList.View = View.List;
            FAVMemberList.Items.Clear();

            foreach (DataRow row in dt.Rows)
            {
                int userId = Convert.ToInt32(row["id"]);
                string userName = Convert.ToString(row["name"]) ?? $"User {userId}";

                var item = new ListViewItem(userName)
                {
                    Tag = userId
                };

                FAVMemberList.Items.Add(item);
            }
        }

        // 트리뷰 선택하면 버튼나옴
        private void TeamMemberTreeView_AfterSelect_1(object sender, TreeViewEventArgs e)
        {
            _selectedUserIdInTree = null;

            if (e.Node.Tag is ValueTuple<string, int> tag)
            {
                string type = tag.Item1;
                int id = tag.Item2;

                if (type == "user")
                {
                    _selectedUserIdInTree = id;

                    // 본인즐찾 ㄴㄴ
                    if (id == MeId)
                    {
                        favoriteInsertButton.Visible = false;
                        favoriteDeleteButton.Visible = false;
                        return;
                    }

                    bool isFav = IsFavorite(MeId, id);

                    // 트리누르면 추가버튼만
                    favoriteInsertButton.Visible = !isFav;
                    favoriteDeleteButton.Visible = false;
                    return;
                }
            }

            // 유저노드아니면 버튼ㄴㄴ
            favoriteInsertButton.Visible = false;
            favoriteDeleteButton.Visible = false;
        }

        // ===================== 채팅 리스트 (즐겨찾기 우선 정렬) =====================

        // 채팅불러옴(즐찾은위로)
        private void RefreshChatList()
        {
            if (!_auth.IsAuthenticated || !_auth.CurrentUserId.HasValue)
            {
                flpChats.Controls.Clear();
                return;
            }

            var chats = _chatService.LoadMyChats(MeId);

            // 즐겨찾기
            var favUserIds = LoadMyFavoriteUserIds();
            var orderedChats = chats
                .OrderByDescending(chat => favUserIds.Contains(chat.OtherUserId))
                .ToList();

            flpChats.SuspendLayout();
            flpChats.Controls.Clear();

            foreach (var item in orderedChats)
            {
                // 멀프불러옴
                var profileRow = _profileService.GetVisibleProfileFor(MeId, item.OtherUserId);

                
                if (profileRow == null)
                {
                    
                    item.DisplayName = item.OriginalUserName;
                    item.AvatarBytes = null;
                }
                else
                {
                    string nickDbg = profileRow.IsNull("nickname")
                        ? "(null)"
                        : Convert.ToString(profileRow["nickname"]);

                    bool hasImgDbg = !profileRow.IsNull("image");

                    System.Diagnostics.Debug.WriteLine(
                        $"[VisibleProfile] other={item.OtherUserId} -> nickname={nickDbg}, hasImg={hasImgDbg}"
                    );

                    string nickname = profileRow.IsNull("nickname")
                        ? null
                        : Convert.ToString(profileRow["nickname"]);

                    byte[] imgBytes = profileRow.IsNull("image")
                        ? null
                        : (byte[])profileRow["image"];

                    // 닉네임이 있으면 쓰고 없으면 원래이름
                    item.DisplayName = !string.IsNullOrWhiteSpace(nickname)
                        ? nickname
                        : item.OriginalUserName;

                    item.AvatarBytes = imgBytes;
                }

                

                var ctrl = new ChatListItemControl
                {
                    Width = flpChats.ClientSize.Width - 20
                };

                ctrl.Bind(item);
                ctrl.ChatClicked += ChatListItemControl_ChatClicked;

                flpChats.Controls.Add(ctrl);
            }

            flpChats.ResumeLayout();

        }

        // 채팅 리스트에서 채팅 누르면
        private void ChatListItemControl_ChatClicked(object sender, ChatListItem chat)
        {
            if (chat == null)
                return;

            // 채팅 리스트도 동일하게 userId만 넘겨서 처리
            OpenChatWithUser(chat.OtherUserId);
        }

        // 채팅방 열기
        private void OpenChatWithUser(int targetUserId)
        {
            

            int meId = MeId;

            if (targetUserId == meId)
            {
                MessageBox.Show("본인과는 채팅을 시작할 수 없습니다.?");
                return;
            }

            // 차단당했는지 확인
            var blockDt = _db.Query(@"
        SELECT 1
        FROM user_relation
        WHERE user_id = @uid
          AND target_user_id = @tid
          AND relation_type = 'BLOCK_CHAT'
        LIMIT 1;
    ",
        ("@uid", meId),
        ("@tid", targetUserId)
    );

            if (blockDt.Rows.Count > 0)
            {
                MessageBox.Show("대화창을 불러오는데 실패했습니다.");
                return;
            }

            // 1ㄷ1채팅방 가져오곤나 새로만듦
            var chatRow = _chatService.GetOrCreateOneToOneChat(meId, targetUserId);

            if (chatRow == null)
            {
                MessageBox.Show("열기 실패.");
                return;
            }

            int chatId = Convert.ToInt32(chatRow["id"]);
            string chatName = Convert.ToString(chatRow["name"]) ?? "";

            RefreshChatList();

            // 밑에 메세지박스 없애고 채팅방 폼으로 연결시키면 되는데 
            MessageBox.Show($"[DEBUG] 채팅방 열기: ChatId={chatId}, Name={chatName}, 상대={targetUserId}");
        }

        // ===================== UI 이벤트 핸들러 =====================
        private void LoginButton_Click_1(object sender, EventArgs e)
        {
            DoLogin();
        }

        private void LogoutLabel_Click_1(object sender, EventArgs e)
        {
            DoLogout();
        }

        private void MemberSearch_KeyDown(object sender, KeyEventArgs e)
        {
            // 엔터 누르면 유저 검색됨
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                DoSearch(MemberSearch.Text.Trim());
            }
        }

        // 즐찾버튼 누름
        private void favoriteInsertButton_Click_1(object sender, EventArgs e)
        {
            if (!_auth.IsAuthenticated || !_auth.CurrentUserId.HasValue)
            {
                MessageBox.Show("로그인 후 사용 가능합니다.");
                return;
            }

            if (_selectedUserIdInTree == null)
                return;

            int targetUserId = _selectedUserIdInTree.Value;

            if (targetUserId == MeId)
            {
                MessageBox.Show("본인은 즐겨찾기 할 수 없습니다.");
                return;
            }

            // 이미 즐겨찾기면 버튼만 숨기고 끝
            if (IsFavorite(MeId, targetUserId))
            {
                favoriteInsertButton.Visible = false;
                return;
            }

            AddFavorite(MeId, targetUserId);

            // 즐겨찾기/채팅 목록 갱신
            RefreshFavoriteList();
            RefreshChatList();

            favoriteInsertButton.Visible = false;
        }

        // 즐겨찾기 삭제 버튼 클릭
        private void favoriteDeleteButton_Click_1(object sender, EventArgs e)
        {
            if (!_auth.IsAuthenticated || !_auth.CurrentUserId.HasValue)
            {
                return;
            }

            if (FAVMemberList.SelectedItems.Count == 0)
            {
                return;
            }

            var selectedItem = FAVMemberList.SelectedItems[0];

            if (selectedItem.Tag is int targetUserId)
            {
                RemoveFavorite(MeId, targetUserId);

                RefreshFavoriteList();
                RefreshChatList();

                FAVMemberList.SelectedItems.Clear();

                favoriteDeleteButton.Enabled = false;
                favoriteDeleteButton.Visible = false;
            }
        }

        // 즐겨찾기 리스트에서 항목 선택/해제될 때
        private void FAVMemberList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FAVMemberList.SelectedItems.Count > 0)
            {
                favoriteDeleteButton.Enabled = true;
                favoriteDeleteButton.Visible = true;
            }
            else
            {
                favoriteDeleteButton.Enabled = false;
            }
        }

        private void settingLabel_Click(object sender, EventArgs e)
        {
            // 새빈이꺼 회원정보변경 페이지로 연결
        }

    }
}