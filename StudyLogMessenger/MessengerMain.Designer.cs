
namespace StudyLog
{
    partial class MessengerMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.최소화ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeBtn = new System.Windows.Forms.Button();
            this.backGroundPanel = new CustomControls_dll.ShadowPanel();
            this.connectHostBtn = new CustomControls_dll.ShadowPanel();
            this.OpenHostBtn = new CustomControls_dll.ShadowPanel();
            this.contextMenuStrip1.SuspendLayout();
            this.backGroundPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.최소화ToolStripMenuItem,
            this.종료ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(111, 48);
            // 
            // 최소화ToolStripMenuItem
            // 
            this.최소화ToolStripMenuItem.Name = "최소화ToolStripMenuItem";
            this.최소화ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.최소화ToolStripMenuItem.Text = "최소화";
            this.최소화ToolStripMenuItem.Click += new System.EventHandler(this.최소화ToolStripMenuItem_Click);
            // 
            // 종료ToolStripMenuItem
            // 
            this.종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
            this.종료ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.종료ToolStripMenuItem.Text = "종료";
            this.종료ToolStripMenuItem.Click += new System.EventHandler(this.종료ToolStripMenuItem_Click);
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
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // backGroundPanel
            // 
            this.backGroundPanel.BackgroundGradientMode = CustomControls_dll.PanelGradientMode.Vertical;
            this.backGroundPanel.ContextMenuStrip = this.contextMenuStrip1;
            this.backGroundPanel.Controls.Add(this.connectHostBtn);
            this.backGroundPanel.Controls.Add(this.closeBtn);
            this.backGroundPanel.Controls.Add(this.OpenHostBtn);
            this.backGroundPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backGroundPanel.EdgeWidth = 2;
            this.backGroundPanel.EndColor = System.Drawing.Color.Pink;
            this.backGroundPanel.FlatBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.backGroundPanel.FocusScaleHeight = 0.85F;
            this.backGroundPanel.FocusScaleWidth = 0.95F;
            this.backGroundPanel.Location = new System.Drawing.Point(0, 0);
            this.backGroundPanel.Name = "backGroundPanel";
            this.backGroundPanel.NeonColor = System.Drawing.Color.Pink;
            this.backGroundPanel.RectRadius = 0;
            this.backGroundPanel.ShadowColor = System.Drawing.Color.DimGray;
            this.backGroundPanel.ShadowShift = 0;
            this.backGroundPanel.ShadowStyle = CustomControls_dll.ShadowMode.ForwardDiagonal;
            this.backGroundPanel.Size = new System.Drawing.Size(339, 117);
            this.backGroundPanel.StartColor = System.Drawing.Color.White;
            this.backGroundPanel.Style = CustomControls_dll.BevelStyle.Flat;
            this.backGroundPanel.TabIndex = 1;
            this.backGroundPanel.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
            this.backGroundPanel.TextString = "";
            this.backGroundPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.backGroundPanel_MouseDown);
            this.backGroundPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OpenHostBtn_MouseMove);
            this.backGroundPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.backGroundPanel_MouseUp);
            // 
            // connectHostBtn
            // 
            this.connectHostBtn.BackColor = System.Drawing.Color.Transparent;
            this.connectHostBtn.BackgroundGradientMode = CustomControls_dll.PanelGradientMode.Vertical;
            this.connectHostBtn.ContextMenuStrip = this.contextMenuStrip1;
            this.connectHostBtn.EdgeWidth = 5;
            this.connectHostBtn.EndColor = System.Drawing.Color.Transparent;
            this.connectHostBtn.FlatBorderColor = System.Drawing.Color.White;
            this.connectHostBtn.FocusScaleHeight = 0.85F;
            this.connectHostBtn.FocusScaleWidth = 0.95F;
            this.connectHostBtn.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.connectHostBtn.Location = new System.Drawing.Point(169, 12);
            this.connectHostBtn.Name = "connectHostBtn";
            this.connectHostBtn.NeonColor = System.Drawing.Color.Transparent;
            this.connectHostBtn.RectRadius = 20;
            this.connectHostBtn.ShadowColor = System.Drawing.Color.DimGray;
            this.connectHostBtn.ShadowShift = 20;
            this.connectHostBtn.ShadowStyle = CustomControls_dll.ShadowMode.ForwardDiagonal;
            this.connectHostBtn.Size = new System.Drawing.Size(151, 90);
            this.connectHostBtn.StartColor = System.Drawing.Color.White;
            this.connectHostBtn.Style = CustomControls_dll.BevelStyle.Raised;
            this.connectHostBtn.TabIndex = 1;
            this.connectHostBtn.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
            this.connectHostBtn.TextString = "호스트에\r\n접속";
            this.connectHostBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.connectHostBtn_MouseDown);
            this.connectHostBtn.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OpenHostBtn_MouseMove);
            this.connectHostBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.connectHostBtn_MouseUp);
            // 
            // OpenHostBtn
            // 
            this.OpenHostBtn.BackColor = System.Drawing.Color.Transparent;
            this.OpenHostBtn.BackgroundGradientMode = CustomControls_dll.PanelGradientMode.Vertical;
            this.OpenHostBtn.ContextMenuStrip = this.contextMenuStrip1;
            this.OpenHostBtn.EdgeWidth = 5;
            this.OpenHostBtn.EndColor = System.Drawing.Color.Transparent;
            this.OpenHostBtn.FlatBorderColor = System.Drawing.Color.White;
            this.OpenHostBtn.FocusScaleHeight = 0.85F;
            this.OpenHostBtn.FocusScaleWidth = 0.95F;
            this.OpenHostBtn.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.OpenHostBtn.Location = new System.Drawing.Point(12, 12);
            this.OpenHostBtn.Name = "OpenHostBtn";
            this.OpenHostBtn.NeonColor = System.Drawing.Color.Transparent;
            this.OpenHostBtn.RectRadius = 20;
            this.OpenHostBtn.ShadowColor = System.Drawing.Color.DimGray;
            this.OpenHostBtn.ShadowShift = 20;
            this.OpenHostBtn.ShadowStyle = CustomControls_dll.ShadowMode.ForwardDiagonal;
            this.OpenHostBtn.Size = new System.Drawing.Size(151, 90);
            this.OpenHostBtn.StartColor = System.Drawing.Color.White;
            this.OpenHostBtn.Style = CustomControls_dll.BevelStyle.Raised;
            this.OpenHostBtn.TabIndex = 0;
            this.OpenHostBtn.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
            this.OpenHostBtn.TextString = "호스트\r\n열기";
            this.OpenHostBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OpenHostBtn_MouseDown);
            this.OpenHostBtn.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OpenHostBtn_MouseMove);
            this.OpenHostBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OpenHostBtn_MouseUp);
            // 
            // MessengerMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeBtn;
            this.ClientSize = new System.Drawing.Size(339, 117);
            this.ControlBox = false;
            this.Controls.Add(this.backGroundPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MessengerMain";
            this.Text = "Study Messenger";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MessengerMain_FormClosing);
            this.Load += new System.EventHandler(this.MessengerMain_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.backGroundPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CustomControls_dll.ShadowPanel backGroundPanel;
        private CustomControls_dll.ShadowPanel connectHostBtn;
        private System.Windows.Forms.Button closeBtn;
        private CustomControls_dll.ShadowPanel OpenHostBtn;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 최소화ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 종료ToolStripMenuItem;
    }
}

