using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StudyLog
{

    public partial class MessengerMain : Form
    {
        public Point downPoint = Point.Empty;       // 누른 마우스의 좌표
        public MessengerMain()
        {
            InitializeComponent();

            #region 호스트 열기를 눌렀을 경우, 클라이언트 폼을 하나 더 실행하도록 함.
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1)  // args[0]은 파일 이름
            {
                this.WindowState = FormWindowState.Minimized;
                OpenClientForm();
                this.Close();   // 추가로 실행된 클라이언트 폼을 닫으면 프로그램 종료됨.
            }
            #endregion 호스트 열기를 눌렀을 경우, 클라이언트 폼을 하나 더 실행하도록 함. 끝.
        }
        private void MessengerMain_Load(object sender, EventArgs e)
        {
            // 폼이 로드될 때 구역(region)을 다시 설정.
            SetClientRegion();
        }

        // controlBox를 false로 했을 경우, 위에 흰 줄이 나오는 걸 삭제
        void SetClientRegion()
        {
            // FormBorderStyle속성이 None으로 설정되어 있다고 가정한다.
            Rectangle rect = this.ClientRectangle;
            using (System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath())
            {
                path.AddRectangle(rect);  // 현재 경로에 타원을 추가합니다.
                this.Region = new Region(path);     // 타원 영역을 구역으로 직접 설정
            }
        }

        private void studyBtnAndPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return; // 왼쪽 버튼을 누른 게 아니면, 종료
            downPoint = new Point(e.X, e.Y); // 현재 마우스의 X, Y좌표를 downPoint에 설정함.
        }



        public bool isMoving = false;
        private void isBtn_MouseUp(object sender, MouseEventArgs e)
        {
            downPoint = Point.Empty;
            if (isMoving)   // 이동 명령중일 땐, 클릭 처리를 하지 않음.
            {
                isMoving = false;
                return;
            }

            // 왼쪽 버튼을 누른 거면,
            if (e.Button == MouseButtons.Left)
            {
                string clickedBtnName = (sender as CustomControls_dll.ShadowPanel).Name;
                if(clickedBtnName == OpenHostBtn.Name)
                {
                    // 클라이언트 프로그램을 띄움
                    if (showForm == null)
                        InitShowFormDelegate();
                    this.BeginInvoke(showForm, new object[] { });
                    // 호스트 창 띄움.
                    OpenHostForm();
                }
                else if(clickedBtnName == connectHostBtn.Name)
                {
                    OpenClientForm();

                }
            }
        }

        private void isBtn_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (downPoint == Point.Empty) return;
                isMoving = true;
                // 마우스의 현재 좌표e.X - 이전 좌표downPoint.X = 이동한 X좌표
                // 이동한 좌표위치를 반영한 후엔, 현재 좌표의 위치가 이전 좌표의 위치가 되고, 현재 좌표의 위치가 다시 현재 좌표의 위치가 되서, 전체 위치는 변하지 않음.
                // 이동한 후의 위치 = 이동한 포인터의 위치 + 폼의 왼쪽 경계선 위치.(이동한 거리 + 폼의 왼쪽 위 좌표)
                Point location = new Point(this.Left + e.X - downPoint.X, this.Top + e.Y - downPoint.Y);
                this.Location = location;
            }
            else
                isMoving = false;
        }

        private void OpenHostBtn_MouseUp(object sender, MouseEventArgs e)
        {
            isBtn_MouseUp(sender, e);   // 드래그로 창 이동
        }

        private void connectHostBtn_MouseUp(object sender, MouseEventArgs e)
        {
            isBtn_MouseUp(sender, e);   // 드래그로 창 이동
        }

        private void OpenClientForm()
        {
            (new StudyLog.Client.ClientForm()).ShowDialog();
        }

        #region 호스트 창을 띄우고, Main프로그램은 최소화. 호스트 창을 닫으면, Main프로그램 다시 정상화
        private void OpenHostForm()
        {
            // 메인 창을 최소화하고, 호스트 열기 창을 정상크기로 해서, 실행.
            this.WindowState = FormWindowState.Minimized;
            StudyLog.Server.HostForm hostForm = new StudyLog.Server.HostForm();
            hostForm.StartPosition = FormStartPosition.WindowsDefaultLocation;  // 새로 연 클라이언트와 겹치면 헷갈릴 수 있으므로,
            hostForm.WindowState = FormWindowState.Normal;
            hostForm.TopMost = true;
            hostForm.BringToFront();
            hostForm.ShowDialog();
            //(new StudyLog.Server.HostForm()).ShowDialog();
            // 메인 창을 다시 복구.
            this.WindowState = FormWindowState.Normal;
            this.BringToFront();
        }

        #endregion 호스트 창을 띄우고, Main프로그램은 최소화. 호스트 창을 닫으면, Main프로그램 다시 정상화. 끝.

        #region 클라이언트 창을 띄우기 위한 부분. 확장성을 위해, 커스텀 대리자로 스레드 실행
        delegate void ShowFormHandler();
        ShowFormHandler showForm;

        // 커스텀 대리자 메모리 할당
        private void InitShowFormDelegate()
        {
            showForm = new ShowFormHandler(RunClientForm);

        }

        // 클라이언트모드로 프로그램 하나 더 실행
        private void RunClientForm()
        {
            string currentFileFullPath = System.Windows.Forms.Application.ExecutablePath;
            System.Diagnostics.Process clientProgram = new System.Diagnostics.Process();
            clientProgram.StartInfo.FileName = currentFileFullPath;
            clientProgram.StartInfo.Arguments = "ClientOn";
            clientProgram.Start();
        }
        #endregion 클라이언트 창을 띄우기 위한 부분. 확장성을 위해, 커스텀 대리자로 스레드 실행. 끝.

        private void backGroundPanel_MouseUp(object sender, MouseEventArgs e)
        {
            isBtn_MouseUp(sender, e);   // 드래그로 창 이동

        }

        private void OpenHostBtn_MouseDown(object sender, MouseEventArgs e)
        {
            studyBtnAndPanel_MouseDown(sender, e);  // 드래그로 창 이동
        }

        private void connectHostBtn_MouseDown(object sender, MouseEventArgs e)
        {
            studyBtnAndPanel_MouseDown(sender, e);  // 드래그로 창 이동

        }

        private void backGroundPanel_MouseDown(object sender, MouseEventArgs e)
        {
            studyBtnAndPanel_MouseDown(sender, e);  // 드래그로 창 이동

        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 최소화ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void MessengerMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }







    }
}
