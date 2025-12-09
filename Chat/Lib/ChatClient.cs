using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

using ChattingAppTeam6.Chat.Lib;
using ChatMessage;

namespace ChattingAppTeam6.Chat.Lib
{
    public class ChattingClient
    {
        private static ChattingClient instance = new();

        private int userId = 0;

        public Dictionary<string, Action<Packet>> commands = new()
        {
            ["ALL"] = (packet) => { },
        };

        private TcpClient client;
        NetworkStream stream;
        private readonly object sendLock = new();

        private ChattingClient() { }

        public static ChattingClient GetInstance() { return instance; }

        public void Connect()
        {
            try
            {
                client = new TcpClient("52.79.132.107", 9000);
                stream = client.GetStream();

                Thread t = new Thread(Recive);
                t.IsBackground = true;
                t.Start();

                MessageBox.Show("Connected");
            }
            catch (Exception e)
            {
                Debug.WriteLine("Connect error: " + e.Message);
            }
        }

        private static bool ReadExact(NetworkStream s, byte[] buf, int count)
        {
            int off = 0;
            while (off < count)
            {
                int n = s.Read(buf, off, count - off);
                if (n <= 0) return false;
                off += n;
            }
            return true;
        }

        private void Recive()
        {
            try
            {
                while (true)
                {
                    byte[] lengthBytes = new byte[4];
                    if (!ReadExact(stream, lengthBytes, 4)) break;

                    int msgLength = BitConverter.ToInt32(lengthBytes, 0);
                    if (msgLength <= 0 || msgLength > 1_048_576) break;

                    byte[] data = new byte[msgLength];
                    if (!ReadExact(stream, data, msgLength)) break;

                    var packet = Packet.Parser.ParseFrom(data);

                    if (commands.TryGetValue("ALL", out var all)) all?.Invoke(packet);
                    if (commands.TryGetValue(packet.Command, out var cmd)) cmd?.Invoke(packet);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Receive error: " + e.Message);
            }
        }

        private void Send(byte[] msgBytes)
        {
            byte[] lenBytes = BitConverter.GetBytes(msgBytes.Length);

            try
            {
                lock (sendLock)
                {
                    stream.Write(lenBytes, 0, 4);
                    stream.Write(msgBytes, 0, msgBytes.Length);
                    stream.Flush();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Send error: " + ex.Message);
            }
        }

        public void Login(int _userId)
        {
            userId = _userId;
            Send(new Packet
            {
                Command = "LOGIN",
                ChatId = 0,
                UserId = userId,
                ProfileId = 0,
                Timestamp = Timestamp.FromDateTime(DateTime.UtcNow),

                Login = new LoginInfo { }
            }.ToByteArray());
        }

        public void Logout()
        {
            Send(new Packet
            {
                Command = "LOGOUT",
                ChatId = 0,
                UserId = userId,
                ProfileId = 0,
                Timestamp = Timestamp.FromDateTime(DateTime.UtcNow),

                Logout = new LogoutInfo { }
            }.ToByteArray());
            userId = 0;
        }

        public void CreateChat(string name, int otherId)
        {
            Send(new Packet
            {
                Command = "CREATE_CHAT",
                ChatId = 0,
                UserId = userId,
                ProfileId = 0,
                Timestamp = Timestamp.FromDateTime(DateTime.UtcNow),

                CreateChat = new CreateChatInfo
                {
                    ChatName = name,
                    OtherId = otherId
                }
            }.ToByteArray());
        }

        public void DeleteChat(int chatId)
        {
            Send(new Packet
            {
                Command = "DELETE_CHAT",
                ChatId = chatId,
                UserId = userId,
                ProfileId = 0,
                Timestamp = Timestamp.FromDateTime(DateTime.UtcNow),

                DeleteChat = new DeleteChatInfo { }
            }.ToByteArray());
        }

        public void JoinChat(int chatId)
        {
            Send(new Packet
            {
                Command = "JOIN_CHAT",
                ChatId = chatId,
                UserId = userId,
                ProfileId = 0,
                Timestamp = Timestamp.FromDateTime(DateTime.UtcNow),

                JoinChat = new JoinChatInfo { }
            }.ToByteArray());
        }

        public void ExitChat(int chatId)
        {
            Send(new Packet
            {
                Command = "EXIT_CHAT",
                ChatId = chatId,
                UserId = userId,
                ProfileId = 0,
                Timestamp = Timestamp.FromDateTime(DateTime.UtcNow),

                ExitChat = new ExitChatInfo { }
            }.ToByteArray());
        }

        public void SendMessage(int chatId, int profileId, string content)
        {
            Send(new Packet
            {
                Command = "SEND_MESSAGE",
                ChatId = chatId,
                UserId = userId,
                ProfileId = profileId,
                Timestamp = Timestamp.FromDateTimeOffset(DateTime.Now),

                SendMessage = new SendMessageInfo
                {
                    MessageId = -1,
                    Content = content
                }
            }.ToByteArray());
        }

        public void DeleteMessage(int chatId, int messageId)
        {
            Send(new Packet
            {
                Command = "DELETE_MESSAGE",
                ChatId = chatId,
                UserId = userId,
                ProfileId = 0,
                Timestamp = Timestamp.FromDateTimeOffset(DateTime.Now),

                DeleteMessage = new DeleteMessageInfo
                {
                    MessageId = messageId
                }
            }.ToByteArray());
        }

        public void SendFile(int chatId, int profileId, string fileName, ByteString fileContent)
        {
            Send(new Packet
            {
                Command = "SEND_FILE",
                ChatId = chatId,
                UserId = userId,
                ProfileId = profileId,
                Timestamp = Timestamp.FromDateTimeOffset(DateTime.Now),

                SendFile = new SendFileInfo
                {
                    MessageId = -1,
                    FileName = fileName,
                    FileContent = fileContent
                }
            }.ToByteArray());
        }

        public void EditBanner(int chatId, string content)
        {
            Send(new Packet
            {
                Command = "EDIT_BANNER",
                ChatId = chatId,
                UserId = userId,
                ProfileId = 0,
                Timestamp = Timestamp.FromDateTimeOffset(DateTime.Now),

                EditBanner = new EditBannerInfo
                {
                    Content = content
                }
            }.ToByteArray());
        }
    }
}
