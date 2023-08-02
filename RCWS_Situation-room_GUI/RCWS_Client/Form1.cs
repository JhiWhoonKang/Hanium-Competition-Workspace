using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;
using System.Drawing.Drawing2D;



namespace RCWS_Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        StreamReader streamReader;
        StreamWriter streamWriter;

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Thread thread1 = new Thread(TcpConnect);
            thread1.IsBackground = true;
            thread1.Start();
        }

        private void btnConnectUDP_Click(object sender, EventArgs e)
        {
            Thread socketThread = new Thread(new ThreadStart(UdpConnect));
            socketThread.IsBackground = true;
            socketThread.Start();
        }

        string serverIP = define.SERVER_IP;
        private void TcpConnect()
        {
            TcpClient tcpClient1 = new TcpClient();
            //IPEndPoint ipEnd = new IPEndPoint(IPAddress.Parse(textBox_TCPIP.Text), int.Parse(textBox_TCPPort.Text));

            int TCPPORT=define.TCPPORT;
            try
            {
                writeTcpRichTextbox("통신 시도 중...");
                //tcpClient1.Connect(ipEnd);
                tcpClient1.Connect(serverIP, TCPPORT);

                NetworkStream networkStream = tcpClient1.GetStream();
                streamReader = new StreamReader(networkStream);
                streamWriter = new StreamWriter(networkStream);
                streamWriter.AutoFlush = true;
            }
            catch (Exception ex)
            {
                writeTcpRichTextbox("서버 연결 실패: " + ex.Message);
                return;
            }

            writeTcpRichTextbox("서버 연결됨...");
        }

        private static UdpClient udpClient;
        private static IPEndPoint endPoint;

        private void UdpConnect()
        {
            int UDPPORT = define.UDPPORT;
            try
            {
                writeUdpRichTextbox("통신 시도 중...");

                int localPort = UDPPORT;
                int remotePort = UDPPORT;

                udpClient =new UdpClient(localPort);
                endPoint = new IPEndPoint(IPAddress.Any, 0);

                //IPEndPoint clientEndPoint = new IPEndPoint(IPAddress.Parse(textBox_UDPIP.Text), int.Parse(textBox_UDPPort.Text));
                IPEndPoint clientEndPoint = new IPEndPoint(IPAddress.Parse(serverIP), remotePort);

                //byte[] receivedData;
                //string receivedMessage;

                //// 서버 연결 확인 메시지 전송
                //byte[] connectMessage = Encoding.UTF8.GetBytes("서버 연결 확인");
                //udpClient.Send(connectMessage, connectMessage.Length, clientEndPoint);

                //// 서버 연결 확인 대기
                //while (true)
                //{
                //    receivedData = udpClient.Receive(ref endPoint);
                //    receivedMessage = Encoding.UTF8.GetString(receivedData);
                //    if (receivedMessage == "서버 연결")
                //    {
                //        writeUdpRichTextbox("통신 성공");
                //        break;
                //    }
                //}
            }
            catch (Exception ex)
            {
                writeUdpRichTextbox("오류: " + ex.Message);
            }
        }

        private void writeTcpRichTextbox(string str)  // richTextbox1 에 쓰기 함수
        {
            richTcpConnectionStatus.Invoke((MethodInvoker)delegate { richTcpConnectionStatus.AppendText(str + "\r\n"); });
            richTcpConnectionStatus.Invoke((MethodInvoker)delegate { richTcpConnectionStatus.ScrollToCaret(); });
        }

        private void writeUdpRichTextbox(string str)  // richTextbox1 에 쓰기 함수
        {
            richUdpConnectionStatus.Invoke((MethodInvoker)delegate { richUdpConnectionStatus.AppendText(str + "\r\n"); });
            richUdpConnectionStatus.Invoke((MethodInvoker)delegate { richUdpConnectionStatus.ScrollToCaret(); });
        }

        //private static UdpClient udpClient;
        //private static IPEndPoint endPoint;
        private Video newVideo;
        private void button_Video(object sender, EventArgs e)
        {
            if (newVideo != null) newVideo.Close();

            //Video newVideo = new Video(udpClient, endPoint);
            newVideo = new Video(udpClient, endPoint);
            newVideo.Show();
        }

        private void button_Control(object sender, EventArgs e)
        {
            MotionControl motionControl = new MotionControl(streamWriter);
            motionControl.Show();
        }

        private void button_Map(object sender, EventArgs e)
        {
            Map map= new Map();
            map.Show();
        }
    }
    static class define
    {
        //public const string SERVER_IP= "192.168.0.2";
        public const string SERVER_IP = "127.0.0.1";
        public const int TCPPORT = 9001;
        public const int UDPPORT = 9000;
    }
}