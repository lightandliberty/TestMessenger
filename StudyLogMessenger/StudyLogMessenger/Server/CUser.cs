using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FreeNet;

namespace StudyLog
{
    using StudyLog.Server;

    /// <summary>
    /// 하나의 session객체를 나타낸다.
    /// token하나 IPeer메서드5개
    /// </summary>
    public class CUser : IPeer
    {
        // Server폼에 있는 컨트롤을 바꾸기 위한 대리자
        public delegate void OnMessageHandler(string str);
        public OnMessageHandler OnMessage;


        CUserToken token;

        // 매개변수의 token을 설정하고, IPeer객체에 메서드를 등록
        public CUser(CUserToken token)
        {
            this.token = token;
            this.token.Set_Peer(this);
        }

        void IPeer.On_Message(Const<byte[]> buffer)
        {
            // ex)
            CPacket msg = new CPacket(buffer.Value, this);
            PROTOCOL protocol = (PROTOCOL)msg.Pop_Protocol_ID();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Protocol Id " + protocol);
            switch (protocol)
            {
                case PROTOCOL.CHAT_MSG_REQ:
                    {
                        string text = msg.Pop_String();
                        Console.WriteLine(string.Format("text {0}", text));

                        //CPacket response = CPacket.Create((short)PROTOCOL.CHAT_MSG_ACK);
                        //response.Push(text);
                        //Send(response);

                        // 서버에 있는 컨트롤에도 받은 문자열을 표시하기 위해
                        if (OnMessage != null)
                            OnMessage(text);    // 추가로 실행하고 싶은 메서드를 등록.
                    }
                    break;
            }
        }

        void IPeer.On_Removed()
        {
            Console.WriteLine("The client disconnected.");
            HostForm.RemoveUser(this);
        }

        public void Send(CPacket msg)
        {
            this.token.Send(msg);
        }

        void IPeer.Disconnect()
        {
            this.token.socket.Disconnect(false);
        }

        void IPeer.Process_User_Operation(CPacket msg)
        {
        }

    }


}
