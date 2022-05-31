
namespace StudyLog.Client
{
    partial class ClientForm
    {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.접속Ip설정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeBtn = new System.Windows.Forms.Button();
            this.backGroundPanel = new CustomControls_dll.ShadowPanel();
            this.nameLbl = new System.Windows.Forms.Label();
            this.nameTB = new System.Windows.Forms.TextBox();
            this.writeMsgLbl = new System.Windows.Forms.Label();
            this.writeMsgTB = new System.Windows.Forms.TextBox();
            this.changeIPBtn = new CustomControls_dll.ShadowPanel();
            this.clientMsgLbl = new System.Windows.Forms.Label();
            this.serverMsgLbl = new System.Windows.Forms.Label();
            this.connectPN = new CustomControls_dll.ShadowPanel();
            this.contextMenuStrip1.SuspendLayout();
            this.backGroundPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.접속Ip설정ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 26);
            // 
            // 접속Ip설정ToolStripMenuItem
            // 
            this.접속Ip설정ToolStripMenuItem.Name = "접속Ip설정ToolStripMenuItem";
            this.접속Ip설정ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.접속Ip설정ToolStripMenuItem.Text = "접속 ip설정";
            this.접속Ip설정ToolStripMenuItem.Click += new System.EventHandler(this.접속Ip설정ToolStripMenuItem_Click);
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
            this.backGroundPanel.Controls.Add(this.nameLbl);
            this.backGroundPanel.Controls.Add(this.nameTB);
            this.backGroundPanel.Controls.Add(this.writeMsgLbl);
            this.backGroundPanel.Controls.Add(this.writeMsgTB);
            this.backGroundPanel.Controls.Add(this.changeIPBtn);
            this.backGroundPanel.Controls.Add(this.clientMsgLbl);
            this.backGroundPanel.Controls.Add(this.serverMsgLbl);
            this.backGroundPanel.Controls.Add(this.closeBtn);
            this.backGroundPanel.Controls.Add(this.connectPN);
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
            this.backGroundPanel.Size = new System.Drawing.Size(434, 411);
            this.backGroundPanel.StartColor = System.Drawing.Color.White;
            this.backGroundPanel.Style = CustomControls_dll.BevelStyle.Flat;
            this.backGroundPanel.TabIndex = 5;
            this.backGroundPanel.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
            this.backGroundPanel.TextString = "";
            // 
            // nameLbl
            // 
            this.nameLbl.AutoSize = true;
            this.nameLbl.BackColor = System.Drawing.Color.Transparent;
            this.nameLbl.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.75F);
            this.nameLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(147)))), ((int)(((byte)(184)))));
            this.nameLbl.Location = new System.Drawing.Point(293, 12);
            this.nameLbl.Name = "nameLbl";
            this.nameLbl.Size = new System.Drawing.Size(129, 17);
            this.nameLbl.TabIndex = 14;
            this.nameLbl.Text = "이름을 입력해 주세요.";
            // 
            // nameTB
            // 
            this.nameTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(52)))), ((int)(((byte)(86)))));
            this.nameTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nameTB.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16.25F);
            this.nameTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(231)))), ((int)(((byte)(232)))));
            this.nameTB.Location = new System.Drawing.Point(290, 32);
            this.nameTB.Multiline = true;
            this.nameTB.Name = "nameTB";
            this.nameTB.Size = new System.Drawing.Size(132, 33);
            this.nameTB.TabIndex = 13;
            // 
            // writeMsgLbl
            // 
            this.writeMsgLbl.AutoSize = true;
            this.writeMsgLbl.BackColor = System.Drawing.Color.Transparent;
            this.writeMsgLbl.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.75F);
            this.writeMsgLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(147)))), ((int)(((byte)(184)))));
            this.writeMsgLbl.Location = new System.Drawing.Point(29, 334);
            this.writeMsgLbl.Name = "writeMsgLbl";
            this.writeMsgLbl.Size = new System.Drawing.Size(157, 17);
            this.writeMsgLbl.TabIndex = 12;
            this.writeMsgLbl.Text = "보낼 문자를 입력해 주세요.";
            // 
            // writeMsgTB
            // 
            this.writeMsgTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(52)))), ((int)(((byte)(86)))));
            this.writeMsgTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.writeMsgTB.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16.25F);
            this.writeMsgTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(231)))), ((int)(((byte)(232)))));
            this.writeMsgTB.Location = new System.Drawing.Point(26, 354);
            this.writeMsgTB.Multiline = true;
            this.writeMsgTB.Name = "writeMsgTB";
            this.writeMsgTB.Size = new System.Drawing.Size(379, 33);
            this.writeMsgTB.TabIndex = 11;
            this.writeMsgTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.writeMsgTB_KeyDown);
            // 
            // changeIPBtn
            // 
            this.changeIPBtn.BackColor = System.Drawing.Color.Transparent;
            this.changeIPBtn.BackgroundGradientMode = CustomControls_dll.PanelGradientMode.Vertical;
            this.changeIPBtn.EdgeWidth = 2;
            this.changeIPBtn.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(179)))), ((int)(((byte)(171)))));
            this.changeIPBtn.FlatBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(159)))), ((int)(((byte)(151)))));
            this.changeIPBtn.FocusScaleHeight = 0.85F;
            this.changeIPBtn.FocusScaleWidth = 0.95F;
            this.changeIPBtn.Font = new System.Drawing.Font("굴림", 12F);
            this.changeIPBtn.Location = new System.Drawing.Point(179, 12);
            this.changeIPBtn.Name = "changeIPBtn";
            this.changeIPBtn.NeonColor = System.Drawing.Color.Pink;
            this.changeIPBtn.RectRadius = 10;
            this.changeIPBtn.ShadowColor = System.Drawing.Color.DimGray;
            this.changeIPBtn.ShadowShift = 0;
            this.changeIPBtn.ShadowStyle = CustomControls_dll.ShadowMode.ForwardDiagonal;
            this.changeIPBtn.Size = new System.Drawing.Size(90, 28);
            this.changeIPBtn.StartColor = System.Drawing.Color.White;
            this.changeIPBtn.Style = CustomControls_dll.BevelStyle.Flat;
            this.changeIPBtn.TabIndex = 10;
            this.changeIPBtn.TextColor = System.Drawing.Color.Black;
            this.changeIPBtn.TextString = "IP 변경";
            this.changeIPBtn.Click += new System.EventHandler(this.changeIPBtn_Click);
            // 
            // clientMsgLbl
            // 
            this.clientMsgLbl.AutoSize = true;
            this.clientMsgLbl.BackColor = System.Drawing.Color.Transparent;
            this.clientMsgLbl.Font = new System.Drawing.Font("굴림", 14F);
            this.clientMsgLbl.Location = new System.Drawing.Point(228, 127);
            this.clientMsgLbl.Name = "clientMsgLbl";
            this.clientMsgLbl.Size = new System.Drawing.Size(0, 19);
            this.clientMsgLbl.TabIndex = 3;
            // 
            // serverMsgLbl
            // 
            this.serverMsgLbl.AutoSize = true;
            this.serverMsgLbl.BackColor = System.Drawing.Color.Transparent;
            this.serverMsgLbl.Font = new System.Drawing.Font("굴림", 14F);
            this.serverMsgLbl.Location = new System.Drawing.Point(22, 127);
            this.serverMsgLbl.Name = "serverMsgLbl";
            this.serverMsgLbl.Size = new System.Drawing.Size(118, 19);
            this.serverMsgLbl.TabIndex = 2;
            this.serverMsgLbl.Text = "serverMsgLbl";
            // 
            // connectPN
            // 
            this.connectPN.BackColor = System.Drawing.Color.Transparent;
            this.connectPN.BackgroundGradientMode = CustomControls_dll.PanelGradientMode.Vertical;
            this.connectPN.ContextMenuStrip = this.contextMenuStrip1;
            this.connectPN.EdgeWidth = 5;
            this.connectPN.EndColor = System.Drawing.Color.Transparent;
            this.connectPN.FlatBorderColor = System.Drawing.Color.White;
            this.connectPN.FocusScaleHeight = 0.85F;
            this.connectPN.FocusScaleWidth = 0.95F;
            this.connectPN.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.connectPN.Location = new System.Drawing.Point(12, 12);
            this.connectPN.Name = "connectPN";
            this.connectPN.NeonColor = System.Drawing.Color.Transparent;
            this.connectPN.RectRadius = 20;
            this.connectPN.ShadowColor = System.Drawing.Color.DimGray;
            this.connectPN.ShadowShift = 20;
            this.connectPN.ShadowStyle = CustomControls_dll.ShadowMode.ForwardDiagonal;
            this.connectPN.Size = new System.Drawing.Size(151, 90);
            this.connectPN.StartColor = System.Drawing.Color.White;
            this.connectPN.Style = CustomControls_dll.BevelStyle.Raised;
            this.connectPN.TabIndex = 0;
            this.connectPN.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
            this.connectPN.TextString = "호스트\r\n접속";
            this.connectPN.Click += new System.EventHandler(this.connectPN_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeBtn;
            this.ClientSize = new System.Drawing.Size(434, 411);
            this.Controls.Add(this.backGroundPanel);
            this.Name = "ClientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ClientForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientForm_FormClosing);
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.backGroundPanel.ResumeLayout(false);
            this.backGroundPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomControls_dll.ShadowPanel backGroundPanel;
        private System.Windows.Forms.Label clientMsgLbl;
        private System.Windows.Forms.Label serverMsgLbl;
        private System.Windows.Forms.Button closeBtn;
        private CustomControls_dll.ShadowPanel connectPN;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 접속Ip설정ToolStripMenuItem;
        private CustomControls_dll.ShadowPanel changeIPBtn;
        private System.Windows.Forms.TextBox writeMsgTB;
        private System.Windows.Forms.Label writeMsgLbl;
        private System.Windows.Forms.Label nameLbl;
        private System.Windows.Forms.TextBox nameTB;
    }
}