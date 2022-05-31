using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudyLog.Library;

namespace StudyLog.Client
{
    /// <summary>
    /// appsetting.config 파일을 이용해 저장하므로, 대리자 객체를 쓰지 않아도 되지만, 
    /// 그냥, 연습삼아,
    /// 처음 로딩할 때는 appsettinig.config파일에서 얻어오고,
    /// ip를 입력하거나 설정 버튼을 누르면 appsetting.config파일에 저장 후, 대리자 객체를 실행하여,
    /// settingFormArgs를 전달한다.
    /// </summary>
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
        }

        public delegate void GetArgs(SettingFormArgs e);
        public GetArgs GetSettingFormArgs;  // 대리자 객체 설정
        public SettingFormArgs settingFormArgs;



        private void SettingForm_Load(object sender, EventArgs e)
        {
            if(settingFormArgs == null)
                settingFormArgs = new SettingFormArgs();
            this.currentHostIPTB.Text = settingFormArgs.hostIP;
        }

        private void currentHostIPTB_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                SaveSettings();
            }
            else if(e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void SaveSettings()
        {
            StudyLog.Properties.Settings.Default.hostIP = settingFormArgs.hostIP = this.currentHostIPTB.Text;
            Properties.Settings.Default.Save();
            if (GetSettingFormArgs != null)
                GetSettingFormArgs(settingFormArgs);

            this.Close();
        }

        private void confirmLbl_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void cancelLbl_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
