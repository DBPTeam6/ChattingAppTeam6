using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChattingAppTeam6.Auth
{
    internal class ConfigManager
    {
        private static ConfigManager instance = new ConfigManager();
        private bool _autoLoginChecked;
        private bool _rememberInfoChecked;
        private string _Id = string.Empty;
        private string _Password = string.Empty;

        private ConfigManager()
        {
            LoadSettings();
        }

        public static ConfigManager GetInstance()
        {
            return instance;
        }
        
        public bool AutoLoginChecked()
        {
            return _autoLoginChecked;
        }
        public bool RememeberInfoChecked()
        {
            return _rememberInfoChecked;
        }
        public string Id()
        {
            return _Id;
        }
        public string Password()
        {
            return _Password;
        }

        // 설정값을 읽어와 내부 필드에 저장
        public void LoadSettings()
        {
            _autoLoginChecked = Properties.Settings.Default.AutoLoginChecked;
            _rememberInfoChecked = Properties.Settings.Default.RememberInfoChecked;
            _Id = Properties.Settings.Default.Id;
            _Password = Properties.Settings.Default.Password;
        }

        // === UI 상태를 받아 기록 ===

        // 체크박스 저장
        public void SaveFlags(bool autoLogin, bool rememberInfo)
        {
            // 내부 필드 업데이트
            _autoLoginChecked = autoLogin;
            _rememberInfoChecked = rememberInfo;;

            // 저장
            Properties.Settings.Default.AutoLoginChecked = autoLogin;
            Properties.Settings.Default.RememberInfoChecked = rememberInfo;
            Properties.Settings.Default.Save();
        }
        
        // 아이디, 비밀번호 저장
        public void SaveUser(string id, string pw)
        {
            _Id = id;
            _Password = pw;

            Properties.Settings.Default.Id = id;
            Properties.Settings.Default.Password = pw;
            Properties.Settings.Default.Save();
        }

        // 아이디, 비밀번호 삭제
        public void ClearUser()
        {
            _Id = "";
            _Password = "";

            Properties.Settings.Default.Id = "";
            Properties.Settings.Default.Password = "";
            Properties.Settings.Default.Save();
        }
    }
}
