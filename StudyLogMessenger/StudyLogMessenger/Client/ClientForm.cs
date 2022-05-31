using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StudyLog.Library;
using FreeNet;
using System.Net;

namespace StudyLog.Client
{

    // 에러나다가 gameserver[0]의 접속 끊기는 부분에서, Clear해줬더니 잘 됨.

    //CUserToken의 sending_queue를 비워줘야 하는 듯하다.

    //token.On_Removed()에서 비워지고,
    //IPeer.On_Removed()도 호출되는데, 딱히 뭘 하진 않음.

    //접속 끊기 버튼을 눌러 끊을 때,
    //token.Disconnect()가 호출되는데,
    //IPeer.Disconnect()는 호출되지 않으므로,
    //혹시 token.Disconnect()에서(전송중이던 거 보내고, 소켓닫기_큐랑 상관 없음.)
    // IPeer.Disconnect(){
    //    token.소켓.disconnect(false)_다시 사용 안 함)
    //를 호출해야 하는데
    //누락된 건 아닌지 확인해 봐야 할 듯

    // 서버에 클라이언트가 접속해 있을 때, 종료하면, 예외 발생함. 경고메시지 띄우고, 종료하도록 수정 예정.
    public partial class ClientForm : Form
    {
        public SettingFormArgs settingFormArgs;     // 접속 ip 설정 관련
        int port = 7979;
        bool isConnected = false;

        delegate void CremoteServerPeerOnMessageHandler(string str);
        CremoteServerPeerOnMessageHandler cOnMessage;
        public ClientForm()
        {
            InitializeComponent();
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            serverMsgLbl.Text = "";
            InitSettingFormArgs();
            InitBeforeConnect();
            // OnMessage에 메서드를 추가하기 위해
            // 스레드 오류가 나면, this.InvokeRequired로 확인하고, 대리자에 담아 실행해야 하는데, 그 때를 대비하여 만들어 둠.
            cOnMessage = new CremoteServerPeerOnMessageHandler(CRemoteServerPeerOnMessage);
            DisableControls();
        }

        // 접속 버튼
        private void connectPN_Click(object sender, EventArgs e)
        {
            isConnected = !isConnected;
            if (isConnected)
                ConnectHost();
            else
                DisconnectHost();
        }


        static List<IPeer> gameServers = new List<IPeer>();
        CNetworkService service;
        CConnector connector;
        IPEndPoint endPoint;

        /// <summary>
        /// CPacket 리스트 생성
        /// connector는 소켓. ConnectAsync(접속객체)로 접속하고, 콜백으로 CNetworkService에 소켓을 전달해 서버로부터 수신을 받고, IPeer메서드를 등록함.
        /// </summary>
        private void InitBeforeConnect()
        {
            CPacketBufferManager.Initialize(2000);
            service = new CNetworkService();
            connector = new CConnector(service);
            connector.connected_callback += OnConnectedServer;
        }

        private void ConnectHost()
        {
            try
            {
                endPoint = new IPEndPoint(IPAddress.Parse(settingFormArgs.hostIP), port);
            }
            catch (Exception ex)
            {
                isConnected = false;
                MessageBox.Show("IP주소 설정이 잘못되었습니다. 다시 설정해 주세요.^^");
                return;
            }
            // connector는 소켓. ConnectAsync(접속객체)로 접속하고, 콜백으로 CNetworkService에 소켓을 전달해 서버로부터 수신을 받고, IPeer메서드를 등록함.
            connector.Connect(endPoint);    // 서버로부터 수신 시작.
            
            connectPN.TextString = "종료";
        }

        private void DisconnectHost()
        {
            connectPN.TextString = "호스트\r\n접속"; ;
            if (gameServers.Count > 0)   // 연결된 서버가 있는 경우,
            {

                ((CRemoteServerPeer)gameServers[0]).token.Disconnect();
                gameServers.Clear();
            }
            DisableControls();
            isConnected = false;
        }

        delegate void InvokeDelegate();

        private void EnableControls()
        {
            if (this.InvokeRequired == true)
                this.Invoke(new InvokeDelegate(EnableControls));
            else
            {
                this.writeMsgTB.Enabled = true;
                writeMsgLbl.Text = "접속되었습니다. 보낼 메시지를 입력해 주세요.";
            }
        }

        private void DisableControls()
        {
            if (this.InvokeRequired == true)
                this.Invoke(new InvokeDelegate(DisableControls));
            else
            {
                this.writeMsgTB.Enabled = false;
                writeMsgLbl.Text = "접속되지 않았습니다.(ip설정 후, 접속버튼을 눌러 주세요)";
            }
        }




        // 접속 후 콜백 메서드
        // 원본은 static이지만, CRemoteServerPeerOnMessage를 추가하기 위해, 바꿈.
        // static void OnConnectedServer(CUserToken serverToken)
        private void OnConnectedServer(CUserToken serverToken)
        {
            lock(gameServers)
            {
                // serverToken.peer에 IPeer메서드들을 저장, CRemoteServerPeer을 server에 저장. (포인터는 IPeer이지만, CRemoteServerPeer객체가 저장되는 듯하다.)
                CRemoteServerPeer crsp= new CRemoteServerPeer(serverToken);
                crsp.OnMessage += CRemoteServerPeerOnMessage;

                IPeer server = crsp;
                //IPeer server = new CRemoteServerPeer(serverToken);
                
                gameServers.Add(server);
                Console.WriteLine("접속되었습니다.");
                EnableControls();
                isConnected = true;
            }
        }






        #region 접속ip 설정 관련
        private void InitSettingFormArgs()
        {
            settingFormArgs = new SettingFormArgs();
            this.connectPN.TextString = settingFormArgs.hostIP + "\r\n접속";
        }

        private void 접속Ip설정ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenIPSettingForm();

        }

        private void GetArgs(SettingFormArgs e)
        {
            this.settingFormArgs = e;
        }


        private void changeIPBtn_Click(object sender, EventArgs e)
        {
            OpenIPSettingForm();
        }

        private void OpenIPSettingForm()
        {
            SettingForm settingForm = new SettingForm();
            settingForm.GetSettingFormArgs += GetArgs;
            settingForm.ShowDialog();

            this.connectPN.TextString = settingFormArgs.hostIP + "\r\n접속";


            // (new SettingForm()).ShowDialog(); 어차피 appsetting.config에 저장하여 로드하므로, 이렇게 해도 된다.
            //  settingFormArgs.hostIP = StudyLog.Properties.Settings.Default.hostIP; // 어차피 appsetting.config에 저장하여 로드하므로, 이렇게 해도 된다.

        }
        #endregion 접속ip 설정 관련. 끝.

        #region Form 종료 관련
        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isConnected)
                DisconnectHost();
        }
        #endregion Form 종료 관련. 끝.


        private void writeMsgTB_KeyDown(object sender, KeyEventArgs e)
        {

            if(e.KeyCode == Keys.Enter)
            {
                if (!isConnected)
                {
                    MessageBox.Show("접속을 먼저 해야 합니다.", "접속 안 됨", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    return;
                }

                string msg = writeMsgTB.Text;
                writeMsgTB.Text = "";
                SendLine(msg);      // 패킷을 보냄.
            }
        }

        private void SendLine(string txt)
        {
            // 연결 상태가 아니면, 종료
            if (isConnected == false)
            {
                return;
            }

            // 헤더 다음에 프로토콜 종류를 넣음.
            CPacket msg = CPacket.Create((short)StudyLog.Server.PROTOCOL.CHAT_MSG_REQ);
            // 앞에 이름을 붙여서, 전송
            txt = nameTB.Text + " " + txt;
            msg.Push(txt);
            try
            {
                gameServers[0].Send(msg);   // 패킷을 전송함.
            }
            catch(Exception ex)
            {
                MessageBox.Show("SendLine(txt)의 인덱스 오류입니다. 접속이 되어 있는지 확인 바랍니다."+ex.ToString());
                return;
            }
        }

        int msgLine = 0;
        // 메시지를 받았을 때 호출 됨. (스레드가 아니면 반복되므로, 결국 else{} 부분이 실행됨)
        public void CRemoteServerPeerOnMessage(string str)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(cOnMessage, new object[] { str });     // cOnMessage는 대리자로, CRemoteServerPeerOnMessage를 실행한다.
            }
            else
            {
                string allMessage = this.serverMsgLbl.Text + str + "\r\n";
                msgLine += 1;
                msgLine %= 7;
                if (msgLine > 5)  // 0~9줄까지는 그대로 두고, 넘어갈 때마다, 위에서 한 줄씩 없앰.
                    allMessage = allMessage.Substring(allMessage.IndexOf("\r\n")+4);    // \r\n의 위치를 찾아, 그 위치 다음(+4)을 자름.
                this.serverMsgLbl.Text = allMessage;

            }
        }

        private void writeMsgTB_Click(object sender, EventArgs e)
        {
            if(this.writeMsgTB.Enabled == false)
                writeMsgLbl.Text = "접속되지 않았습니다. IP설정등 연결을 확인해 주세요.";
            else
                writeMsgLbl.Text = "접속되었습니다. 보낼 메시지를 입력해 주세요.";
        }

        private void nameTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                e.SuppressKeyPress = true;
        }
    }
}
