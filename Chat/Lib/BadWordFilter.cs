using ChattingAppTeam6.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChattingAppTeam6.Chat.Lib
{
    public class BadWordFilter
    {
        private static BadWordFilter instance = new BadWordFilter();
        private static string[] badWords;
        private static bool isLoaded = false;

        public static BadWordFilter GetInstance()
        {
            if (!isLoaded)
            {
                instance.Load();
                isLoaded = true;
            }
            return instance;
        }

        private void Load()
        {
            badWords = Resources.fword_list.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
        }

        public string FilteredText(string origin)
        {
            string filteredText = origin;
            foreach (var badWord in badWords)
            {
                string replacement = new string('*', badWord.Length);
                filteredText = filteredText.Replace(badWord, replacement);
            }
            return filteredText;
        }
    }
}
