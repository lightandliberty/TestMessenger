
namespace StudyLog.Server
{
    partial class HostForm
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
            this.closeBtn = new System.Windows.Forms.Button();
            this.shadowPanel1 = new CustomControls_dll.ShadowPanel();
            this.client2MsgLbl = new System.Windows.Forms.Label();
            this.client1MsgLbl = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.hostPN = new CustomControls_dll.ShadowPanel();
            this.shadowPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // closeBtn
            // 
            this.closeBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeBtn.Location = new System.Drawing.Point(78, 147);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(0, 0);
            this.closeBtn.TabIndex = 3;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = true;
            // 
            // shadowPanel1
            // 
            this.shadowPanel1.BackgroundGradientMode = CustomControls_dll.PanelGradientMode.Vertical;
            this.shadowPanel1.Controls.Add(this.client2MsgLbl);
            this.shadowPanel1.Controls.Add(this.client1MsgLbl);
            this.shadowPanel1.Controls.Add(this.button1);
            this.shadowPanel1.Controls.Add(this.hostPN);
            this.shadowPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shadowPanel1.EdgeWidth = 2;
            this.shadowPanel1.EndColor = System.Drawing.Color.Pink;
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
            this.shadowPanel1.Size = new System.Drawing.Size(434, 411);
            this.shadowPanel1.StartColor = System.Drawing.Color.White;
            this.shadowPanel1.Style = CustomControls_dll.BevelStyle.Flat;
            this.shadowPanel1.TabIndex = 4;
            this.shadowPanel1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
            this.shadowPanel1.TextString = "";
            // 
            // client2MsgLbl
            // 
            this.client2MsgLbl.AutoSize = true;
            this.client2MsgLbl.BackColor = System.Drawing.Color.Transparent;
            this.client2MsgLbl.Font = new System.Drawing.Font("굴림", 14F);
            this.client2MsgLbl.Location = new System.Drawing.Point(247, 125);
            this.client2MsgLbl.Name = "client2MsgLbl";
            this.client2MsgLbl.Size = new System.Drawing.Size(117, 19);
            this.client2MsgLbl.TabIndex = 3;
            this.client2MsgLbl.Text = "client2MsgLbl";
            // 
            // client1MsgLbl
            // 
            this.client1MsgLbl.AutoSize = true;
            this.client1MsgLbl.BackColor = System.Drawing.Color.Transparent;
            this.client1MsgLbl.Font = new System.Drawing.Font("굴림", 14F);
            this.client1MsgLbl.Location = new System.Drawing.Point(32, 125);
            this.client1MsgLbl.Name = "client1MsgLbl";
            this.client1MsgLbl.Size = new System.Drawing.Size(117, 19);
            this.client1MsgLbl.TabIndex = 2;
            this.client1MsgLbl.Text = "client1MsgLbl";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(26, 108);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(0, 0);
            this.button1.TabIndex = 1;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // hostPN
            // 
            this.hostPN.BackColor = System.Drawing.Color.Transparent;
            this.hostPN.BackgroundGradientMode = CustomControls_dll.PanelGradientMode.Vertical;
            this.hostPN.EdgeWidth = 5;
            this.hostPN.EndColor = System.Drawing.Color.Transparent;
            this.hostPN.FlatBorderColor = System.Drawing.Color.White;
            this.hostPN.FocusScaleHeight = 0.85F;
            this.hostPN.FocusScaleWidth = 0.95F;
            this.hostPN.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.hostPN.Location = new System.Drawing.Point(12, 12);
            this.hostPN.Name = "hostPN";
            this.hostPN.NeonColor = System.Drawing.Color.Transparent;
            this.hostPN.RectRadius = 20;
            this.hostPN.ShadowColor = System.Drawing.Color.DimGray;
            this.hostPN.ShadowShift = 20;
            this.hostPN.ShadowStyle = CustomControls_dll.ShadowMode.ForwardDiagonal;
            this.hostPN.Size = new System.Drawing.Size(151, 90);
            this.hostPN.StartColor = System.Drawing.Color.White;
            this.hostPN.Style = CustomControls_dll.BevelStyle.Raised;
            this.hostPN.TabIndex = 0;
            this.hostPN.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
            this.hostPN.TextString = "호스트\r\n시작";
            this.hostPN.Click += new System.EventHandler(this.hostPN_Click);
            // 
            // HostForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeBtn;
            this.ClientSize = new System.Drawing.Size(434, 411);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.shadowPanel1);
            this.Name = "HostForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "HostForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HostForm_FormClosing);
            this.Load += new System.EventHandler(this.HostForm_Load);
            this.shadowPanel1.ResumeLayout(false);
            this.shadowPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button closeBtn;
        private CustomControls_dll.ShadowPanel hostPN;
        private System.Windows.Forms.Button button1;
        private CustomControls_dll.ShadowPanel shadowPanel1;
        private System.Windows.Forms.Label client2MsgLbl;
        private System.Windows.Forms.Label client1MsgLbl;
    }
}