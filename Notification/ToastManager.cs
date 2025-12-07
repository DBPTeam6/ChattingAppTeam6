using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ChattingAppTeam6.Notification
{
    internal static class ToastManager
    {
        private static readonly List<NotifyForm> ActiveToasts = new List<NotifyForm>();
        private const int MaxToasts = 3;
        private const int MarginRight = 20;
        private const int MarginBottom = 40;
        private const int Gap = 5;

        public static void ShowToast(string senderName, DateTime timestamp, string previewText, int chatId)
        {
            // Ensure call on UI thread
            var target = Application.OpenForms.Cast<Form>().FirstOrDefault();
            if (target != null && target.InvokeRequired)
            {
                target.BeginInvoke(new Action(() => ShowToast(senderName, timestamp, previewText, chatId)));
                return;
            }

            CleanupDisposed();

            var toast = new NotifyForm(senderName, timestamp, previewText, chatId);
            ActiveToasts.Add(toast);

            if (ActiveToasts.Count > MaxToasts)
            {
                var oldest = ActiveToasts.First();
                try { oldest.Close(); } catch { }
                ActiveToasts.RemoveAt(0);
            }

            Reposition();
            toast.Show();
        }

        public static void Remove(NotifyForm toast)
        {
            CleanupDisposed();
            if (toast == null) return;
            ActiveToasts.Remove(toast);
            Reposition();
        }

        private static void CleanupDisposed()
        {
            for (int i = ActiveToasts.Count - 1; i >= 0; i--)
            {
                if (ActiveToasts[i].IsDisposed)
                {
                    ActiveToasts.RemoveAt(i);
                }
            }
        }

        private static void Reposition()
        {
            if (ActiveToasts.Count == 0) return;

            var screen = Screen.PrimaryScreen.WorkingArea;
            for (int i = 0; i < ActiveToasts.Count; i++)
            {
                var toast = ActiveToasts[ActiveToasts.Count - 1 - i]; // newest at bottom
                var x = screen.Width - toast.Width - MarginRight;
                var y = screen.Height - ((toast.Height + Gap) * (i + 1)) - 0; // bottom stacking
                toast.StartPosition = FormStartPosition.Manual;
                toast.Location = new Point(x, y);
            }
        }
    }
}
