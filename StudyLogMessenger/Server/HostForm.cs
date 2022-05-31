using System;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FreeNet;
using System.Net.Sockets;

namespace StudyLog.Server
{
    public partial class HostForm : Form
    {
        static List<CUser> userList;
        public bool isHost = false;
        CNetworkService service;
        string ipAddress;
        int port = 7979;

        delegate void CUserOnMessageHandler(string str);
        CUserOnMessageHandler cOnMessage;

        public HostForm()
        {
            InitializeComponent();
        }

        private void HostForm_Load(object sender, EventArgs e)
        {
            client1MsgLbl.Text = "";
            HostInit();
//            ipAddress = GetIPAddress();
            ipAddress = GetIPAddress_FromUDPEndpoint();         // 호스트의 IP는 설정할 수 없고, 접속해 오는 IP만 설정가능하므로, ipAddress는 그냥 버튼에 호스트 IP표시용

            // OnMessage에 메서드를 추가하기 위해 (확장성을 위해 만들어 둠)
            // 스레드 오류가 나면, this.InvokeRequired로 확인하고, 대리자에 담아 실행해야 하는데, 그 때를 대비하여 만들어 둠.
            cOnMessage = new CUserOnMessageHandler(CUserOnMessage);

        }

        private void hostPN_Click(object sender, EventArgs e)
        {
            isHost = !isHost;
            if (isHost)
                HostOn();
            else
                HostOff();
        }

        private string GetIPAddress()
        {
            IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());
            for(int i = 0; i < hostEntry.AddressList.Length; i++)
            {
                if (hostEntry.AddressList[i].AddressFamily != System.Net.Sockets.AddressFamily.InterNetwork)  // ipv6는 System.Net.Sockets.AddressFamily.InterNetworkV6 사용
                    continue;
                else
                    return hostEntry.AddressList[i].ToString();
            }
            return "";
        }

        private string GetIPAddress_FromUDPEndpoint()
        {
            string localIP = string.Empty;
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.IP))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                localIP = endPoint.Address.ToString();
            }
            return localIP;
        }

        private void HostInit()
        {
            CPacketBufferManager.Initialize(2000);
            userList = new List<CUser>();
            service = new CNetworkService();
            // 콜백 메서드 호출
            service.session_created_callback += OnSessionCreated;
            // 초기화
            service.Initialize();
        }

        private void HostOn()
        {
            // IPAddress.Any와 7979포트로 접속 받아들임.
            service.Listen("0.0.0.0", port, 100);
            this.hostPN.TextString = "호스트\r\n" + ipAddress + ", " + port.ToString();

        }

        private void HostOff()
        {
                service.ListenStop();
                lock (userList)
                {
                    userList.ForEach(user => userList.Remove(user));
                }
                this.hostPN.TextString = "호스트\r\n접속 받기";
                this.hostPN.Refresh();
        }

        /// <summary>
        /// 클라이언트가 접속 완료하였을 때 호출됨.
        /// n개의 워커 스레드에서 호출될 수 있으므로, 공유 자원(유저 리스트) 접근시 동기화 처리해야 함.
        /// </summary>
        /// <param name="token"></param>
        //static void OnSessionCreated(CUserToken token)
        // 원본은 static이지만, CUserMessage를 추가하기 위해, 바꿈.
        public void OnSessionCreated(CUserToken token)
        {
            // token.peer에 CUser메서드들을 묶고, token을 CUser에 저장.
            CUser user = new CUser(token);
            user.OnMessage += CUserOnMessage;   // 수신된 메시지가 전송되어 실행될 때, 등록된 IPeer메서드 외에, CUser.OnMessage의 메서드도 실행된다.
            // CUser를 userList에 추가.
            lock(userList)
            {
                userList.Add(user);
            }
        }

        public static void RemoveUser(CUser user)
        {
            lock(userList)
            {
                userList.Remove(user);
            }
        }

        // CUser의 OnMessage에서 (서버로부터 메시지를 받았을 때의 처리)
        // 현재는 모든 접속 상태에 있는 token에 ACK로 메시지를 보내고 있음.
        public void CUserOnMessage(string str)
        {
            // 스레드 오류가 난다면,
            if (this.InvokeRequired)
            {
                this.BeginInvoke(cOnMessage, new object[] { str });
            }
            else
            {
                this.client1MsgLbl.Text = str;

                // 서버에서 받은 메시지를 모든 접속자들에게 전달
                CPacket receivedMsg = CPacket.Create((short)PROTOCOL.CHAT_MSG_ACK);
                receivedMsg.Push(str);

                // 모든 유저에게 받은 메시지를 전달.
                lock (userList)
                {
                    for (int i = 0; i < userList.Count; i++)
                        userList[i].Send(receivedMsg);

                    //userList.ForEach(user => user.Send(receivedMsg));
                }
            }
        }


        private void HostForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isHost) // 호스트를 연 상태면, 닫음.
                HostOff();
            //lock(userList)
            //{
            //    userList.ForEach(user => userList.Remove(user));
            //}
        }
    }
}
