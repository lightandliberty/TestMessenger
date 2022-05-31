using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FreeNet;

namespace StudyLog.Client
{
    public class CRemoteServerPeer : IPeer
    {
        public delegate void OnMessageHandler(string str);
        public OnMessageHandler OnMessage;

        public CUserToken token { get; private set; }   // private set이므로, 생성할 때, 또는 메서드를 통해서만 설정 가능.

        public CRemoteServerPeer(CUserToken token)  // 이러면, 매개변수 token에도 CRemoteServerPeer의 메서드가 등록됨.
        {
            this.token = token;
            this.token.Set_Peer(this);  // On_Message(), On_Removed, Send(), Disconnect(), Process_User_Operation(CPacket)을 token에 등록한다.
        }

        // 수신받은 메시지를 buffer에 담아, 클라이언트에 On_Message메서드에 보내주는데, 헤더 다음 부분이 ACK면 내용을 문자열로 표시하는 걸로 처리
        void IPeer.On_Message(Const<byte[]> buffer)
        {
            CPacket msg = new CPacket(buffer.Value, this);
            StudyLog.Server.PROTOCOL protocol_id = (StudyLog.Server.PROTOCOL)msg.Pop_Protocol_ID();
            switch(protocol_id)
            {
                case Server.PROTOCOL.CHAT_MSG_ACK:
                    {
                        string text = msg.Pop_String();
                        Console.WriteLine(string.Format("text {0}", text));
                        if (OnMessage != null)
                            OnMessage(text);    // 추가로 실행하고 싶은 메서드를 등록.
                    }
                    break;
            }
        }

        void IPeer.On_Removed()
        {
            Console.WriteLine("Server removed.");
        }

        void IPeer.Send(CPacket msg)
        {
            this.token.Send(msg);
        }

        /// <summary>
        /// token.On_Removed()에서 비워지고,
        /// IPeer.On_Removed() 도 호출되는데, IPeer.Disconnect()는 호출이 안되네? 오륜가?
        /// 
        /// </summary>
        
        // 현재 token.Disconnect()에서(전송중이던 거 보내고,소켓닫기_큐랑 상관 없음.) 로 token.Disconnect()에서 처리됨.
        void IPeer.Disconnect()
        {
            
            this.token.socket.Disconnect(false);    // 이건 연결이 되어 있을 경우가 아니면, 오류나는 듯하다.
        }

        void IPeer.Process_User_Operation(CPacket msg)
        {

        }

    }
}
