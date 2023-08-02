namespace RCWS_Client
{
    partial class Form1
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
            this.textBox_TCPIP = new System.Windows.Forms.TextBox();
            this.textBox_TCPPort = new System.Windows.Forms.TextBox();
            this.btnTcpConnect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.richTcpConnectionStatus = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.richUdpConnectionStatus = new System.Windows.Forms.RichTextBox();
            this.btnConnectUDP = new System.Windows.Forms.Button();
            this.textBox_UDPPort = new System.Windows.Forms.TextBox();
            this.textBox_UDPIP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Video = new System.Windows.Forms.Button();
            this.btn_Control = new System.Windows.Forms.Button();
            this.btn_Map = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_TCPIP
            // 
            this.textBox_TCPIP.Location = new System.Drawing.Point(371, 50);
            this.textBox_TCPIP.Name = "textBox_TCPIP";
            this.textBox_TCPIP.Size = new System.Drawing.Size(100, 21);
            this.textBox_TCPIP.TabIndex = 1;
            // 
            // textBox_TCPPort
            // 
            this.textBox_TCPPort.Location = new System.Drawing.Point(489, 50);
            this.textBox_TCPPort.Name = "textBox_TCPPort";
            this.textBox_TCPPort.Size = new System.Drawing.Size(100, 21);
            this.textBox_TCPPort.TabIndex = 2;
            // 
            // btnTcpConnect
            // 
            this.btnTcpConnect.Location = new System.Drawing.Point(371, 77);
            this.btnTcpConnect.Name = "btnTcpConnect";
            this.btnTcpConnect.Size = new System.Drawing.Size(218, 60);
            this.btnTcpConnect.TabIndex = 6;
            this.btnTcpConnect.Text = "Connect";
            this.btnTcpConnect.UseVisualStyleBackColor = true;
            this.btnTcpConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(369, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "IP 주소";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(487, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "Port";
            // 
            // richTcpConnectionStatus
            // 
            this.richTcpConnectionStatus.Location = new System.Drawing.Point(371, 143);
            this.richTcpConnectionStatus.Name = "richTcpConnectionStatus";
            this.richTcpConnectionStatus.Size = new System.Drawing.Size(218, 96);
            this.richTcpConnectionStatus.TabIndex = 9;
            this.richTcpConnectionStatus.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(356, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(251, 244);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TCP/IP";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.richUdpConnectionStatus);
            this.groupBox2.Controls.Add(this.btnConnectUDP);
            this.groupBox2.Controls.Add(this.textBox_UDPPort);
            this.groupBox2.Controls.Add(this.textBox_UDPIP);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(356, 287);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(251, 244);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "UDP/IP";
            // 
            // richUdpConnectionStatus
            // 
            this.richUdpConnectionStatus.Location = new System.Drawing.Point(15, 129);
            this.richUdpConnectionStatus.Name = "richUdpConnectionStatus";
            this.richUdpConnectionStatus.Size = new System.Drawing.Size(218, 96);
            this.richUdpConnectionStatus.TabIndex = 12;
            this.richUdpConnectionStatus.Text = "";
            // 
            // btnConnectUDP
            // 
            this.btnConnectUDP.ForeColor = System.Drawing.Color.Black;
            this.btnConnectUDP.Location = new System.Drawing.Point(15, 63);
            this.btnConnectUDP.Name = "btnConnectUDP";
            this.btnConnectUDP.Size = new System.Drawing.Size(218, 60);
            this.btnConnectUDP.TabIndex = 12;
            this.btnConnectUDP.Text = "Connect";
            this.btnConnectUDP.UseVisualStyleBackColor = true;
            this.btnConnectUDP.Click += new System.EventHandler(this.btnConnectUDP_Click);
            // 
            // textBox_UDPPort
            // 
            this.textBox_UDPPort.Location = new System.Drawing.Point(133, 36);
            this.textBox_UDPPort.Name = "textBox_UDPPort";
            this.textBox_UDPPort.Size = new System.Drawing.Size(100, 21);
            this.textBox_UDPPort.TabIndex = 12;
            // 
            // textBox_UDPIP
            // 
            this.textBox_UDPIP.Location = new System.Drawing.Point(15, 36);
            this.textBox_UDPIP.Name = "textBox_UDPIP";
            this.textBox_UDPIP.Size = new System.Drawing.Size(100, 21);
            this.textBox_UDPIP.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(131, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "Port";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "IP 주소";
            // 
            // btn_Video
            // 
            this.btn_Video.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_Video.Font = new System.Drawing.Font("굴림", 17.75F, System.Drawing.FontStyle.Bold);
            this.btn_Video.ForeColor = System.Drawing.Color.White;
            this.btn_Video.Location = new System.Drawing.Point(12, 12);
            this.btn_Video.Name = "btn_Video";
            this.btn_Video.Size = new System.Drawing.Size(169, 86);
            this.btn_Video.TabIndex = 12;
            this.btn_Video.Text = "Video";
            this.btn_Video.UseVisualStyleBackColor = false;
            this.btn_Video.Click += new System.EventHandler(this.button_Video);
            // 
            // btn_Control
            // 
            this.btn_Control.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_Control.Font = new System.Drawing.Font("굴림", 17.75F, System.Drawing.FontStyle.Bold);
            this.btn_Control.ForeColor = System.Drawing.Color.White;
            this.btn_Control.Location = new System.Drawing.Point(12, 104);
            this.btn_Control.Name = "btn_Control";
            this.btn_Control.Size = new System.Drawing.Size(169, 86);
            this.btn_Control.TabIndex = 13;
            this.btn_Control.Text = "Control";
            this.btn_Control.UseVisualStyleBackColor = false;
            this.btn_Control.Click += new System.EventHandler(this.button_Control);
            // 
            // btn_Map
            // 
            this.btn_Map.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_Map.Font = new System.Drawing.Font("굴림", 17.75F, System.Drawing.FontStyle.Bold);
            this.btn_Map.ForeColor = System.Drawing.Color.White;
            this.btn_Map.Location = new System.Drawing.Point(12, 196);
            this.btn_Map.Name = "btn_Map";
            this.btn_Map.Size = new System.Drawing.Size(169, 86);
            this.btn_Map.TabIndex = 14;
            this.btn_Map.Text = "Map";
            this.btn_Map.UseVisualStyleBackColor = false;
            this.btn_Map.Click += new System.EventHandler(this.button_Map);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.button1.Font = new System.Drawing.Font("굴림", 17.75F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(12, 288);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(169, 84);
            this.button1.TabIndex = 15;
            this.button1.Text = "Configuration";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(624, 571);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_Map);
            this.Controls.Add(this.btn_Control);
            this.Controls.Add(this.btn_Video);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.richTcpConnectionStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTcpConnect);
            this.Controls.Add(this.textBox_TCPPort);
            this.Controls.Add(this.textBox_TCPIP);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "RCWS Client";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox_TCPIP;
        private System.Windows.Forms.TextBox textBox_TCPPort;
        private System.Windows.Forms.Button btnTcpConnect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTcpConnectionStatus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_UDPPort;
        private System.Windows.Forms.TextBox textBox_UDPIP;
        private System.Windows.Forms.RichTextBox richUdpConnectionStatus;
        private System.Windows.Forms.Button btnConnectUDP;
        private System.Windows.Forms.Button btn_Video;
        private System.Windows.Forms.Button btn_Control;
        private System.Windows.Forms.Button btn_Map;
        private System.Windows.Forms.Button button1;
    }
}

