using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ChattingAppTeam6.Chat.Lib
{
    #region 이벤트 인자 클래스
    public class MessageReceivedEventArgs : EventArgs
    {
        public string Message { get; set; }
        public string SenderName { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public class ClientConnectedEventArgs : EventArgs
    {
        public string ClientName { get; set; }
        public TcpClient Client { get; set; }
    }

    public class ClientDisconnectedEventArgs : EventArgs
    {
        public string ClientName { get; set; }
    }
    #endregion

    #region 채팅 클라이언트
    public class ChatClient : IDisposable
    {
        private TcpClient client;
        private NetworkStream stream;
        private StreamReader reader;
        private StreamWriter writer;
        private Thread receiveThread;
        private bool isConnected;
        private string username;

        public event EventHandler<MessageReceivedEventArgs> MessageReceived;
        public event EventHandler Connected;
        public event EventHandler Disconnected;
        public event EventHandler<string> ErrorOccurred;

        public bool IsConnected => isConnected;
        public string Username => username;

        public ChatClient(string username)
        {
            this.username = username;
        }

        public bool Connect(string serverIp, int port)
        {
            try
            {
                client = new TcpClient();
                client.Connect(serverIp, port);
                stream = client.GetStream();
                reader = new StreamReader(stream, Encoding.UTF8);
                writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true };

                isConnected = true;

                // 사용자 이름 전송
                writer.WriteLine(username);

                // 메시지 수신 스레드 시작
                receiveThread = new Thread(ReceiveLoop);
                receiveThread.IsBackground = true;
                receiveThread.Start();

                Connected?.Invoke(this, EventArgs.Empty);
                return true;
            }
            catch (Exception ex)
            {
                ErrorOccurred?.Invoke(this, $"연결 실패: {ex.Message}");
                return false;
            }
        }

        private void ReceiveLoop()
        {
            try
            {
                while (isConnected)
                {
                    string message = reader.ReadLine();
                    if (message != null)
                    {
                        MessageReceived?.Invoke(this, new MessageReceivedEventArgs
                        {
                            Message = message,
                            Timestamp = DateTime.Now
                        });
                    }
                    else
                    {
                        break;
                    }
                }
            }
            catch (Exception)
            {
                // 연결 종료 시 예외 발생
            }
            finally
            {
                if (isConnected)
                {
                    isConnected = false;
                    Disconnected?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public bool SendMessage(string message)
        {
            if (!isConnected || string.IsNullOrEmpty(message))
                return false;

            try
            {
                writer.WriteLine(message);
                return true;
            }
            catch (Exception ex)
            {
                ErrorOccurred?.Invoke(this, $"메시지 전송 실패: {ex.Message}");
                return false;
            }
        }

        public void Disconnect()
        {
            isConnected = false;

            try
            {
                writer?.Close();
                reader?.Close();
                stream?.Close();
                client?.Close();
            }
            catch { }

            Disconnected?.Invoke(this, EventArgs.Empty);
        }

        public void Dispose()
        {
            Disconnect();
        }
    }
    #endregion

    #region 채팅 서버
    public class ChatServer : IDisposable
    {
        private TcpListener listener;
        private Dictionary<string, ClientHandler> clients;
        private Thread listenThread;
        private bool isRunning;
        private int port;

        public event EventHandler<ClientConnectedEventArgs> ClientConnected;
        public event EventHandler<ClientDisconnectedEventArgs> ClientDisconnected;
        public event EventHandler<MessageReceivedEventArgs> MessageReceived;
        public event EventHandler<string> ErrorOccurred;

        public bool IsRunning => isRunning;
        public int ClientCount => clients.Count;

        public ChatServer(int port)
        {
            this.port = port;
            clients = new Dictionary<string, ClientHandler>();
        }

        public bool Start()
        {
            try
            {
                listener = new TcpListener(IPAddress.Any, port);
                listener.Start();
                isRunning = true;

                listenThread = new Thread(ListenLoop);
                listenThread.IsBackground = true;
                listenThread.Start();

                return true;
            }
            catch (Exception ex)
            {
                ErrorOccurred?.Invoke(this, $"서버 시작 실패: {ex.Message}");
                return false;
            }
        }

        private void ListenLoop()
        {
            try
            {
                while (isRunning)
                {
                    TcpClient tcpClient = listener.AcceptTcpClient();
                    Thread clientThread = new Thread(() => HandleClient(tcpClient));
                    clientThread.IsBackground = true;
                    clientThread.Start();
                }
            }
            catch (SocketException)
            {
                // 서버 종료 시 예외 발생
            }
        }

        private void HandleClient(TcpClient tcpClient)
        {
            ClientHandler handler = null;
            string clientName = null;

            try
            {
                handler = new ClientHandler(tcpClient);
                clientName = handler.Reader.ReadLine();

                if (string.IsNullOrEmpty(clientName))
                {
                    handler.Dispose();
                    return;
                }

                lock (clients)
                {
                    // 중복 이름 처리
                    if (clients.ContainsKey(clientName))
                    {
                        clientName = $"{clientName}_{DateTime.Now.Ticks}";
                    }
                    clients[clientName] = handler;
                }

                ClientConnected?.Invoke(this, new ClientConnectedEventArgs
                {
                    ClientName = clientName,
                    Client = tcpClient
                });

                BroadcastMessage($"[시스템] {clientName}님이 입장하셨습니다.", null);

                // 메시지 수신 루프
                while (isRunning && tcpClient.Connected)
                {
                    string message = handler.Reader.ReadLine();
                    if (message == null) break;

                    MessageReceived?.Invoke(this, new MessageReceivedEventArgs
                    {
                        Message = message,
                        SenderName = clientName,
                        Timestamp = DateTime.Now
                    });

                    BroadcastMessage($"{clientName}: {message}", clientName);
                }
            }
            catch (Exception)
            {
                // 클라이언트 연결 종료
            }
            finally
            {
                if (clientName != null)
                {
                    lock (clients)
                    {
                        clients.Remove(clientName);
                    }

                    ClientDisconnected?.Invoke(this, new ClientDisconnectedEventArgs
                    {
                        ClientName = clientName
                    });

                    BroadcastMessage($"[시스템] {clientName}님이 퇴장하셨습니다.", null);
                }

                handler?.Dispose();
            }
        }

        public void BroadcastMessage(string message, string excludeClient = null)
        {
            lock (clients)
            {
                foreach (var kvp in clients)
                {
                    if (kvp.Key != excludeClient)
                    {
                        try
                        {
                            kvp.Value.Writer.WriteLine(message);
                        }
                        catch { }
                    }
                }
            }
        }

        public void SendToClient(string clientName, string message)
        {
            lock (clients)
            {
                if (clients.TryGetValue(clientName, out ClientHandler handler))
                {
                    try
                    {
                        handler.Writer.WriteLine(message);
                    }
                    catch { }
                }
            }
        }

        public List<string> GetConnectedClients()
        {
            lock (clients)
            {
                return new List<string>(clients.Keys);
            }
        }

        public void Stop()
        {
            isRunning = false;

            lock (clients)
            {
                foreach (var handler in clients.Values)
                {
                    handler.Dispose();
                }
                clients.Clear();
            }

            try
            {
                listener?.Stop();
            }
            catch { }
        }

        public void Dispose()
        {
            Stop();
        }
    }
    #endregion

    #region 클라이언트 핸들러
    internal class ClientHandler : IDisposable
    {
        public TcpClient Client { get; private set; }
        public NetworkStream Stream { get; private set; }
        public StreamReader Reader { get; private set; }
        public StreamWriter Writer { get; private set; }

        public ClientHandler(TcpClient client)
        {
            Client = client;
            Stream = client.GetStream();
            Reader = new StreamReader(Stream, Encoding.UTF8);
            Writer = new StreamWriter(Stream, Encoding.UTF8) { AutoFlush = true };
        }

        public void Dispose()
        {
            try
            {
                Writer?.Close();
                Reader?.Close();
                Stream?.Close();
                Client?.Close();
            }
            catch { }
        }
    }
    #endregion
}