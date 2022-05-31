using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace StudyLog.Library
{
    public class CustomMessageBox : System.Windows.Forms.Form
    {
        #region Windows Form Designer generated code
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.shadowPanel1 = new CustomControls_dll.ShadowPanel();
            this.shadowPanel7 = new CustomControls_dll.ShadowPanel();
            this.noBtn = new CustomControls_dll.ShadowPanel();
            this.noLbl = new System.Windows.Forms.Label();
            this.yesBtn = new CustomControls_dll.ShadowPanel();
            this.yesLbl = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.closeBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.shadowPanel1.SuspendLayout();
            this.shadowPanel7.SuspendLayout();
            this.noBtn.SuspendLayout();
            this.yesBtn.SuspendLayout();
            this.SuspendLayout();
            // 
            // shadowPanel1
            // 
            this.shadowPanel1.BackgroundGradientMode = CustomControls_dll.PanelGradientMode.Vertical;
            this.shadowPanel1.Controls.Add(this.shadowPanel7);
            this.shadowPanel1.Controls.Add(this.closeBtn);
            this.shadowPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shadowPanel1.EdgeWidth = 2;
            this.shadowPanel1.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(50)))), ((int)(((byte)(82)))));
            this.shadowPanel1.FlatBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.shadowPanel1.FocusScaleHeight = 0.85F;
            this.shadowPanel1.FocusScaleWidth = 0.95F;
            this.shadowPanel1.Location = new System.Drawing.Point(0, 0);
            this.shadowPanel1.Name = "shadowPanel1";
            this.shadowPanel1.NeonColor = System.Drawing.Color.Pink;
            this.shadowPanel1.RectRadius = 0;
            this.shadowPanel1.ShadowColor = System.Drawing.Color.DimGray;
            this.shadowPanel1.ShadowShift = 0;
            this.shadowPanel1.ShadowStyle = CustomControls_dll.ShadowMode.ForwardDiagonal;
            this.shadowPanel1.Size = new System.Drawing.Size(459, 166);
            this.shadowPanel1.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(50)))), ((int)(((byte)(82)))));
            this.shadowPanel1.Style = CustomControls_dll.BevelStyle.Flat;
            this.shadowPanel1.TabIndex = 2;
            this.shadowPanel1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
            this.shadowPanel1.TextString = "";
            // 
            // shadowPanel7
            // 
            this.shadowPanel7.BackColor = System.Drawing.Color.Transparent;
            this.shadowPanel7.BackgroundGradientMode = CustomControls_dll.PanelGradientMode.Vertical;
            this.shadowPanel7.Controls.Add(this.label1);
            this.shadowPanel7.Controls.Add(this.noBtn);
            this.shadowPanel7.Controls.Add(this.yesBtn);
            this.shadowPanel7.Controls.Add(this.label20);
            this.shadowPanel7.EdgeWidth = 2;
            this.shadowPanel7.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(52)))), ((int)(((byte)(86)))));
            this.shadowPanel7.FlatBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(52)))), ((int)(((byte)(86)))));
            this.shadowPanel7.FocusScaleHeight = 0.85F;
            this.shadowPanel7.FocusScaleWidth = 0.95F;
            this.shadowPanel7.Location = new System.Drawing.Point(12, 12);
            this.shadowPanel7.Name = "shadowPanel7";
            this.shadowPanel7.NeonColor = System.Drawing.Color.Pink;
            this.shadowPanel7.RectRadius = 20;
            this.shadowPanel7.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(15)))), ((int)(((byte)(45)))));
            this.shadowPanel7.ShadowShift = 10;
            this.shadowPanel7.ShadowStyle = CustomControls_dll.ShadowMode.Surrounded;
            this.shadowPanel7.Size = new System.Drawing.Size(433, 140);
            this.shadowPanel7.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(52)))), ((int)(((byte)(86)))));
            this.shadowPanel7.Style = CustomControls_dll.BevelStyle.Flat;
            this.shadowPanel7.TabIndex = 7;
            this.shadowPanel7.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
            this.shadowPanel7.TextString = "";
            this.shadowPanel7.MouseMove += new System.Windows.Forms.MouseEventHandler(this.shadowPanel7_MouseMove);
            // 
            // noBtn
            // 
            this.noBtn.BackColor = System.Drawing.Color.Transparent;
            this.noBtn.BackgroundGradientMode = CustomControls_dll.PanelGradientMode.Vertical;
            this.noBtn.Controls.Add(this.noLbl);
            this.noBtn.EdgeWidth = 2;
            this.noBtn.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(100)))), ((int)(((byte)(253)))));
            this.noBtn.FlatBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(100)))), ((int)(((byte)(253)))));
            this.noBtn.FocusScaleHeight = 0.85F;
            this.noBtn.FocusScaleWidth = 0.95F;
            this.noBtn.Font = new System.Drawing.Font("굴림", 12F);
            this.noBtn.Location = new System.Drawing.Point(227, 58);
            this.noBtn.Name = "noBtn";
            this.noBtn.NeonColor = System.Drawing.Color.Pink;
            this.noBtn.RectRadius = 10;
            this.noBtn.ShadowColor = System.Drawing.Color.DimGray;
            this.noBtn.ShadowShift = 0;
            this.noBtn.ShadowStyle = CustomControls_dll.ShadowMode.ForwardDiagonal;
            this.noBtn.Size = new System.Drawing.Size(84, 35);
            this.noBtn.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(100)))), ((int)(((byte)(253)))));
            this.noBtn.Style = CustomControls_dll.BevelStyle.Flat;
            this.noBtn.TabIndex = 11;
            this.noBtn.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(231)))), ((int)(((byte)(232)))));
            this.noBtn.TextString = "";
            this.noBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.noBtn_MouseDown);
            this.noBtn.MouseEnter += new System.EventHandler(this.noBtn_MouseEnter);
            this.noBtn.MouseLeave += new System.EventHandler(this.noBtn_MouseLeave);
            this.noBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.noBtn_MouseUp);
            // 
            // noLbl
            // 
            this.noLbl.AutoSize = true;
            this.noLbl.BackColor = System.Drawing.Color.Transparent;
            this.noLbl.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(231)))), ((int)(((byte)(232)))));
            this.noLbl.Location = new System.Drawing.Point(13, 6);
            this.noLbl.Name = "noLbl";
            this.noLbl.Size = new System.Drawing.Size(58, 22);
            this.noLbl.TabIndex = 10;
            this.noLbl.Text = "아니오";
            this.noLbl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.noLbl_MouseDown);
            this.noLbl.MouseEnter += new System.EventHandler(this.noLbl_MouseEnter);
            this.noLbl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.noBtn_MouseUp);
            // 
            // yesBtn
            // 
            this.yesBtn.BackColor = System.Drawing.Color.Transparent;
            this.yesBtn.BackgroundGradientMode = CustomControls_dll.PanelGradientMode.Vertical;
            this.yesBtn.Controls.Add(this.yesLbl);
            this.yesBtn.EdgeWidth = 2;
            this.yesBtn.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(100)))), ((int)(((byte)(253)))));
            this.yesBtn.FlatBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(100)))), ((int)(((byte)(253)))));
            this.yesBtn.FocusScaleHeight = 0.85F;
            this.yesBtn.FocusScaleWidth = 0.95F;
            this.yesBtn.Font = new System.Drawing.Font("굴림", 12F);
            this.yesBtn.Location = new System.Drawing.Point(109, 58);
            this.yesBtn.Name = "yesBtn";
            this.yesBtn.NeonColor = System.Drawing.Color.Pink;
            this.yesBtn.RectRadius = 10;
            this.yesBtn.ShadowColor = System.Drawing.Color.DimGray;
            this.yesBtn.ShadowShift = 0;
            this.yesBtn.ShadowStyle = CustomControls_dll.ShadowMode.ForwardDiagonal;
            this.yesBtn.Size = new System.Drawing.Size(84, 35);
            this.yesBtn.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(100)))), ((int)(((byte)(253)))));
            this.yesBtn.Style = CustomControls_dll.BevelStyle.Flat;
            this.yesBtn.TabIndex = 9;
            this.yesBtn.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(231)))), ((int)(((byte)(232)))));
            this.yesBtn.TextString = "";
            this.yesBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.yesBtn_MouseDown);
            this.yesBtn.MouseEnter += new System.EventHandler(this.yesBtn_MouseEnter);
            this.yesBtn.MouseLeave += new System.EventHandler(this.yesBtn_MouseLeave);
            this.yesBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.yesBtn_MouseUp);
            // 
            // yesLbl
            // 
            this.yesLbl.AutoSize = true;
            this.yesLbl.BackColor = System.Drawing.Color.Transparent;
            this.yesLbl.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yesLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(231)))), ((int)(((byte)(232)))));
            this.yesLbl.Location = new System.Drawing.Point(32, 6);
            this.yesLbl.Name = "yesLbl";
            this.yesLbl.Size = new System.Drawing.Size(26, 22);
            this.yesLbl.TabIndex = 10;
            this.yesLbl.Text = "예";
            this.yesLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.yesLbl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.yesLbl_MouseDown);
            this.yesLbl.MouseEnter += new System.EventHandler(this.yesLbl_MouseEnter);
            this.yesLbl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.yesBtn_MouseUp);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(231)))), ((int)(((byte)(232)))));
            this.label20.Location = new System.Drawing.Point(74, 22);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(287, 22);
            this.label20.TabIndex = 6;
            this.label20.Text = "시간 기록 후, 프로그램을 종료할까요?";
            // 
            // closeBtn
            // 
            this.closeBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeBtn.Location = new System.Drawing.Point(26, 108);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(0, 0);
            this.closeBtn.TabIndex = 1;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.75F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(147)))), ((int)(((byte)(184)))));
            this.label1.Location = new System.Drawing.Point(128, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "예: 종료             아니오 : 최소화";
            // 
            // CustomMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeBtn;
            this.ClientSize = new System.Drawing.Size(459, 166);
            this.Controls.Add(this.shadowPanel1);
            this.Name = "CustomMessageBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "기록후 창 닫을지 여부";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CustomMessageBox_FormClosing);
            this.shadowPanel1.ResumeLayout(false);
            this.shadowPanel7.ResumeLayout(false);
            this.shadowPanel7.PerformLayout();
            this.noBtn.ResumeLayout(false);
            this.noBtn.PerformLayout();
            this.yesBtn.ResumeLayout(false);
            this.yesBtn.PerformLayout();
            this.ResumeLayout(false);

        }

        private CustomControls_dll.ShadowPanel shadowPanel1;
        private CustomControls_dll.ShadowPanel shadowPanel7;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button closeBtn;
        private CustomControls_dll.ShadowPanel yesBtn;
        private CustomControls_dll.ShadowPanel noBtn;
        private Label noLbl;
        private Label label1;
        private System.Windows.Forms.Label yesLbl;

        #endregion  Windows Form Designer generated code. 끝.


        // 생성자
        public CustomMessageBox()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        // 객체 초기화

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // delegate 파일 문자열 리턴.
            }
        }


        private void CustomMessageBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 폼을 닫을 때, 객체에 정보를 반영
        }


        public Color originalPurple = Color.FromArgb(120, 102, 254);
        public Color darkPurple = ControlPaint.Dark(Color.FromArgb(120, 102, 254));
        public Color lightPurple = ControlPaint.Light(Color.FromArgb(120, 102, 254));
        private void yesLbl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                SetBtnDown(SelectBtnType.Yes);
            }
        }


        private void yesBtn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                SetBtnDown(SelectBtnType.Yes);
            }
        }

        private void noLbl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                SetBtnDown(SelectBtnType.No);
            }
        }


        private void noBtn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                SetBtnDown(SelectBtnType.No);
            }
        }
        private void SetBtnDown(SelectBtnType btnType)
        {
            if (btnType == SelectBtnType.Yes)
            {
                this.yesBtn.StartColor = darkPurple;
                this.yesBtn.EndColor = lightPurple;
            }
            else if (btnType == SelectBtnType.No)
            {
                this.noBtn.StartColor = darkPurple;
                this.noBtn.EndColor = lightPurple;
            }
        }

        #region 선택 이벤트
        private void yesBtn_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Properties.Settings.Default.ExitAfterWrite = true;
                Properties.Settings.Default.Save();
                this.Close();
//                this.yesBtn.EndColor = this.yesBtn.StartColor = originalPurple;
            }
        }

        private void noBtn_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Properties.Settings.Default.ExitAfterWrite = false;
                Properties.Settings.Default.Save();
                this.Close();
//                this.noBtn.EndColor = this.noBtn.StartColor = originalPurple;
            }
        }



        #endregion 폴더 설정 이벤트. 끝.

        public bool isYesBtnBorderDarkPurple = false;
        public bool isNoBtnBorderDarkPurple = false;
        private void yesBtn_MouseEnter(object sender, EventArgs e)
        {
            SetBtnEnter(SelectBtnType.Yes);
        }
        private void yesLbl_MouseEnter(object sender, EventArgs e)
        {
            SetBtnEnter(SelectBtnType.Yes);
        }

        private void yesBtn_MouseLeave(object sender, EventArgs e)
        {
            SetBtnLeave(SelectBtnType.Yes);
        }
        private void noBtn_MouseEnter(object sender, EventArgs e)
        {
            SetBtnEnter(SelectBtnType.No);
        }
        private void noLbl_MouseEnter(object sender, EventArgs e)
        {
            SetBtnEnter(SelectBtnType.No);
        }

        private void noBtn_MouseLeave(object sender, EventArgs e)
        {
            SetBtnLeave(SelectBtnType.No);
        }

        // 버튼을 벗어나서, 배경에 마우스가 움직이면, 버튼을 강조했던 효과를 지움.
        private void shadowPanel7_MouseMove(object sender, MouseEventArgs e)
        {
            if (isYesBtnBorderDarkPurple)
            {
                this.yesBtn.FlatBorderColor = originalPurple;
                isYesBtnBorderDarkPurple = false;
            }
            else if (isNoBtnBorderDarkPurple)
            {
                this.noBtn.FlatBorderColor = originalPurple;
                isNoBtnBorderDarkPurple = false;
            }
        }

        private void SetBtnEnter(SelectBtnType btnType)
        {
            if (btnType == SelectBtnType.Yes)
            {
                this.yesBtn.FlatBorderColor = ControlPaint.Dark(Color.FromArgb(119, 100, 253));
                isYesBtnBorderDarkPurple = true;
            }
            else if (btnType == SelectBtnType.No)
            {
                this.noBtn.FlatBorderColor = ControlPaint.Dark(Color.FromArgb(119, 100, 253));
                isNoBtnBorderDarkPurple = true;
            }
        }

        private void SetBtnLeave(SelectBtnType btnType)
        {
            if (btnType == SelectBtnType.Yes)
            {
                this.yesBtn.FlatBorderColor = this.yesBtn.EndColor = this.yesBtn.StartColor = originalPurple;
            }
            else if (btnType == SelectBtnType.No)
            {
                this.noBtn.FlatBorderColor = this.yesBtn.EndColor = this.yesBtn.StartColor = originalPurple;
            }
        }


        enum SelectBtnType : int
        {
            Yes,
            No,
        }

    }
}