    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Runtime.Remoting.Messaging;
    using System.Diagnostics;
    using System.Net.NetworkInformation;

    namespace RCWS_Situation_room
{
    public partial class GUI : Form
    {
        /*map*/
        private Bitmap mapImage;
        private float currentScale = 1.0f;
        private float zoomFactor = 1.1f;
        private bool isDragging = false;
        private int lastX;
        private int lastY;

        /*motion control*/
        private StreamWriter _streamWriter;
        private HashSet<Keys> _pressedKeys = new HashSet<Keys>();

        StreamReader streamReader;
        StreamWriter streamWriter;

        public GUI()
        {
            InitializeComponent();

            mapImage = new Bitmap(@"C:\JHIWHOON_ws\2023 Hanium\_file photo\demomap.bmp");
            UpdateMapImage();

            pictureBox_Map.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox_Map.MouseWheel += MapPictureBox_MouseWheel;
            pictureBox_Map.MouseDown += MapPictureBox_MouseDown;
            pictureBox_Map.MouseMove += MapPictureBox_MouseMove;
            pictureBox_Map.MouseUp += MapPictureBox_MouseUp;

            // pictureBox_Map.Click += new MouseEventHandler(pictureBox_Map_Click);

            this._streamWriter = streamWriter;
            this.KeyDown += new KeyEventHandler(MotionControl_KeyDown);
            this.KeyUp += new KeyEventHandler(MotionControl_KeyUp);

            //Thread _thread = new Thread(TcpConnect);
            //_thread.IsBackground = true;
            //_thread.Start();
        }

        private void UpdateMapImage()
        {
            int newWidth = (int)(mapImage.Width * currentScale);
            int newHeight = (int)(mapImage.Height * currentScale);
            var resizedImage = new Bitmap(newWidth, newHeight);
            using (var g = Graphics.FromImage(resizedImage))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(mapImage, new Rectangle(0, 0, newWidth, newHeight));
            }
            pictureBox_Map.Image = resizedImage;
        }

        private void MapPictureBox_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
                currentScale *= zoomFactor;
            else
                currentScale /= zoomFactor;

            UpdateMapImage();
        }

        private void MapPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastX = e.X;
                lastY = e.Y;
            }
        }

        private void MapPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (isDragging)
                {
                    int deltaX = e.X - lastX;
                    int deltaY = e.Y - lastY;

                    int map_newX = pictureBox_Map.Location.X + deltaX;
                    int map_newY = pictureBox_Map.Location.Y + deltaY;

                    pictureBox_Map.Location = new Point(map_newX, map_newY);
                    lastX = e.X;
                    lastY = e.Y;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error in MapPictureBox_MouseMove: " + ex.Message);
            }
        }

        private void MapPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

        //private void pictureBox_Map_Click(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        int imageX = (int)(e.X / currentScale);
        //        int imageY = (int)(e.Y / currentScale);

        //        DrawRCWSLocation(imageX, imageY);

        //        DrawDirection(imageX, imageY);
        //    }
        //}

        //private void DrawRCWSLocation(int x, int y)
        //{
        //    using (Graphics g = Graphics.FromImage(pictureBox_Map.Image))
        //    {
        //        int rcwsRadius = 10;
        //        Pen pen = new Pen(Color.Red, 2);
        //        g.DrawEllipse(pen, x - rcwsRadius, y - rcwsRadius, rcwsRadius * 2, rcwsRadius * 2);
        //    }

        //    pictureBox_Map.Invalidate();
        //}

        //private void DrawDirection(int rcwsX, int rcwsY)
        //{
        //    using (Graphics g = Graphics.FromImage(pictureBox_Map.Image))
        //    {
        //        Pen pen = new Pen(Color.Blue, 2);

        //        g.DrawLine(pen, rcwsX, rcwsY, lastX, lastY);
        //    }

        //    pictureBox_Map.Invalidate();
        //}

        //private void pictureBox_Map_Paint(object sender, PaintEventArgs e)
        //{
        //    e.Graphics.DrawImage(pictureBox_Map.Image, pictureBox_Map.Location);
        //}

        #region motion control
        private async void MotionControl_KeyDown(object sender, KeyEventArgs e)
        {
            _pressedKeys.Add(e.KeyCode);
            await SendCommandStructure();
        }

        private async void MotionControl_KeyUp(object sender, KeyEventArgs e)
        {
            _pressedKeys.Remove(e.KeyCode);
            await SendCommandStructure();
        }

        private bool ControlledByOperator = false;
        Packet.SendTCP command = new Packet.SendTCP();
        private async Task SendCommandStructure()
        {
            if (_pressedKeys.Contains(Keys.A))
                command.Pan = 1;
            if (_pressedKeys.Contains(Keys.D))
                command.Pan = -1;
            if (_pressedKeys.Contains(Keys.W))
                command.Tilt = (char)3;
            if (_pressedKeys.Contains(Keys.S))
                command.Tilt = (char)4;
            if (_pressedKeys.Contains(Keys.C))
            {
                command.Permission = 1;
                //ControlledByOperator = !ControlledByOperator;
            }
            byte[] commandBytes = TcpReturn.StructToBytes(command);
            await _streamWriter.BaseStream.WriteAsync(commandBytes, 0, commandBytes.Length);
            await _streamWriter.BaseStream.FlushAsync();
        }

        Packet.ReceiveTCP receivedStruct;
        private void TcpConnect()
        {
            TcpClient tcpClient = new TcpClient();

            try
            {
                writeTcpRichTextbox("Connecting...");
                tcpClient.Connect(define.SERVER_IP, define.TCPPORT);

                NetworkStream networkStream = tcpClient.GetStream();
                streamReader = new StreamReader(networkStream);
                streamWriter = new StreamWriter(networkStream);
                streamWriter.AutoFlush = true;
            }
            catch (Exception ex)
            {
                writeTcpRichTextbox("Connect ERROR: " + ex.Message);
                return;
            }

            writeTcpRichTextbox("Server Connected");

            try
            {
                while (true)
                {
                    byte[] receivedData = new byte[Marshal.SizeOf(typeof(Packet.ReceiveTCP))];
                    streamReader.BaseStream.Read(receivedData, 0, receivedData.Length);

                    receivedStruct = TcpReturn.BytesToStruct<Packet.ReceiveTCP>(receivedData);

                    writeTcpRichTextbox($"OpticalTilt: {receivedStruct.OpticalTilt}, OpticalPan: {receivedStruct.OpticalPan}, BodyTilt: {receivedStruct.BodyTilt}" +
                        $", BodyPan: {receivedStruct.BodyPan}, pointdistance: {receivedStruct.Permission}, Permission: {receivedStruct.Permission}");
                }
            }

            catch (Exception ex)
            {
                writeTcpRichTextbox("Connect ERROR: " + ex.Message);
                return;
            }
        }

        //private void View(Packet.ReceiveTCP ReceivedData)
        //{
        //    double _Pan, _Tilt;
        //    if (ControlledByOperator)
        //    {
        //        _Pan = command.Pan; _Tilt=command.Tilt;
        //    }
        //    else
        //    {
        //        _Pan = receivedStruct.BodyPan; _Tilt=receivedStruct.BodyTilt;
        //    }

        //    Bitmap bmp = new Bitmap(pictureBox_VIEW.Width, pictureBox_VIEW.Height);

        //    using (Graphics g = Graphics.FromImage(bmp))
        //    {
        //        g.Clear(Color.White);

        //        int x2 = (int)(pictureBox_VIEW.Width / 2 + Math.Cos(_Pan) * pictureBox_VIEW.Width / 2);
        //        int y2 = (int)(pictureBox_VIEW.Height / 2 - Math.Sin(_Pan) * pictureBox_VIEW.Height / 2);

        //        Pen p = new Pen(Color.Black);
        //        g.DrawLine(p, pictureBox_VIEW.Width / 2, pictureBox_VIEW.Height / 2, x2, y2);
        //    }

        //    pictureBox_VIEW.Image?.Dispose();
        //    pictureBox_VIEW.Image = bmp;
        //}

        double currentRCWSDirection;
        private void pictureBox_VIEW_Paint(object sender, PaintEventArgs e)
        {
            double angleInRadians = Math.PI * (currentRCWSDirection / 180.0);

            int centerX = pictureBox_VIEW.Width / 2;
            int centerY = pictureBox_VIEW.Height / 2;
            int radius = Math.Min(centerX, centerY);

            int lineX = centerX + (int)(radius * Math.Cos(angleInRadians));
            int lineY = centerY - (int)(radius * Math.Sin(angleInRadians));

            using (Pen pen = new Pen(Color.Black, 2))
            {
                e.Graphics.DrawLine(pen, centerX, centerY, lineX, lineY);
            }

            using (Pen redPen = new Pen(Color.Red, 2))
            {
                e.Graphics.DrawLine(redPen, centerX, centerY, lineX, lineY);
            }
        }

        private double CalculateRCWSDirection(double bodyPan, double bodyTilt)
        {

            double directionInRadians = 0/*방위각, 고각 계산 여기*/ ;
            return directionInRadians;
        }

        private void UpdateRCWSDirection()
        {
            double bodyPan = receivedStruct.BodyPan;
            double bodyTilt = receivedStruct.BodyTilt;

            currentRCWSDirection = CalculateRCWSDirection(bodyPan, bodyTilt);

            pictureBox_VIEW.Invalidate();
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            Thread _thread = new Thread(TcpConnect);
            _thread.IsBackground = true;
            _thread.Start();
        }

        private void writeTcpRichTextbox(string str)
        {
            rtb_sendtcp.Invoke((MethodInvoker)delegate { rtb_sendtcp.AppendText(str + "\r\n"); });
            rtb_sendtcp.Invoke((MethodInvoker)delegate { rtb_sendtcp.ScrollToCaret(); });
        }
        #endregion

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
            Application.Exit();
        }
    }
}