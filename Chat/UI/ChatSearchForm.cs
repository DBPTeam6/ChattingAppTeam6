using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ChattingAppTeam6.Chat.Entity;
using ChattingAppTeam6.Chat.Lib;

namespace ChattingAppTeam6.Chat.UI
{
    public partial class ChatSearchForm : Form
    {
        private readonly ChatFormViewModel viewModel;
        private List<SearchResult> searchResults;

        public ChatSearchForm(ChatFormViewModel viewModel)
        {
            InitializeComponent();

            this.viewModel = viewModel;
            this.searchResults = new List<SearchResult>();
        }

        /// <summary>
        /// 검색 버튼 클릭 이벤트
        /// </summary>
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }

        /// <summary>
        /// 검색 텍스트박스 엔터키 이벤트
        /// </summary>
        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                PerformSearch();
            }
        }

        /// <summary>
        /// 검색 결과 더블클릭 이벤트
        /// </summary>
        private void ListViewResults_DoubleClick(object sender, EventArgs e)
        {
            if (listViewResults.SelectedItems.Count > 0)
            {
                var selectedItem = listViewResults.SelectedItems[0];
                int index = selectedItem.Index;

                if (index >= 0 && index < searchResults.Count)
                {
                    var result = searchResults[index];
                    MessageBox.Show(
                        $"발신자: {result.SenderName}\n시간: {result.Timestamp}\n\n메시지:\n{result.Message}",
                        "메시지 상세",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
        }

        /// <summary>
        /// 검색 수행
        /// </summary>
        private void PerformSearch()
        {
            string searchText = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("검색어를 입력해주세요.", "알림",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // 기존 결과 초기화
                listViewResults.Items.Clear();
                searchResults.Clear();

                // 데이터베이스에서 검색
                DB db = DB.GetInstance();

                // chat_message 테이블에서 현재 채팅방의 메시지 검색
                string query = @"
                SELECT cm.id, cm.chat_id, cm.user_id, cm.content, cm.timestamp, p.nickname
                FROM message_log cm
                INNER JOIN profile p ON cm.user_id = p.user_id
                WHERE cm.chat_id = @chatId 
                AND cm.content LIKE @searchText
                ORDER BY cm.timestamp DESC
                LIMIT 100";

                var parameters = new ParameterBuilder()
                .Add("@chatId", viewModel.room.id)
                .Add("@searchText", $"%{searchText}%")
                .Build();

                DataTable results = db.ReadQuery(query, parameters);

                // 결과를 ListView에 추가
                foreach (DataRow row in results.Rows)
                {
                    string senderName = row["nickname"].ToString();
                    string message = row["content"].ToString();
                    DateTime timestamp = Convert.ToDateTime(row["timestamp"]);
                    int messageId = Convert.ToInt32(row["id"]);
                    int userId = Convert.ToInt32(row["user_id"]);

                    // 검색어 하이라이트를 위한 정보 저장
                    searchResults.Add(new SearchResult
                    {
                        MessageId = messageId,
                        UserId = userId,
                        SenderName = senderName,
                        Message = message,
                        Timestamp = timestamp
                    });

                    // ListView에 아이템 추가
                    ListViewItem item = new ListViewItem(senderName);
                    item.SubItems.Add(message);
                    item.SubItems.Add(timestamp.ToString("yyyy-MM-dd HH:mm:ss"));

                    // 내가 보낸 메시지는 다른 색으로 표시
                    if (userId == viewModel.room.me.user_id)
                    {
                        item.BackColor = Color.FromArgb(230, 240, 255);
                    }

                    listViewResults.Items.Add(item);
                }

                // 결과 개수 표시
                lblResultCount.Text = $"검색 결과: {results.Rows.Count}개";

                if (results.Rows.Count == 0)
                {
                    MessageBox.Show("검색 결과가 없습니다.", "알림",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"검색 중 오류가 발생했습니다: {ex.Message}", "오류",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 검색 결과 데이터 클래스
        /// </summary>
        private class SearchResult
        {
            public int MessageId { get; set; }
            public int UserId { get; set; }
            public string SenderName { get; set; }
            public string Message { get; set; }
            public DateTime Timestamp { get; set; }
        }
    }
}
