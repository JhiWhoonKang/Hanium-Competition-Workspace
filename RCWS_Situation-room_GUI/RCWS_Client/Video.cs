//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Net;
//using System.Net.Sockets;
//using System.Threading;
//using System.Windows.Forms;
//using OpenCvSharp;
//using System.Linq;
//using System.Text;

//namespace RCWS_Client
//{
//    public partial class Video : Form
//    {
//        private const int Port = define.UDPPORT;
//        private const string ServerIP = define.SERVER_IP;

//        private UdpClient _udpClient;
//        private IPEndPoint _remoteEndPoint;

//        public Video(UdpClient udpClient, IPEndPoint endPoint)
//        {
//            InitializeComponent();

//            _udpClient = udpClient;
//            _remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);

//            pictureBox_Display.SizeMode = PictureBoxSizeMode.StretchImage;

//            // 영상 수신 및 디코딩 스레드  
//            Thread receiveAndDisplayThread = new Thread(ReceiveAndDisplay);
//            receiveAndDisplayThread.IsBackground = true;
//            receiveAndDisplayThread.Start();
//        }

//        //private void ReceiveAndDisplay()
//        //{
//        //    while (true)
//        //    {
//        //        try
//        //        {
//        //            Dictionary<int, byte[]> imageParts = new Dictionary<int, byte[]>();
//        //            int partsReceived = 0;

//        //            /* 4등분해서 들어오는 buffer data 받기 */
//        //            while (partsReceived < 4)
//        //            {
//        //                byte[] imageData = _udpClient.Receive(ref _remoteEndPoint);

//        //                int partIndex = imageData[0] - 0x30;
//        //                byte[] partData = imageData.Skip(1).ToArray();

//        //                if (!imageParts.ContainsKey(partIndex))
//        //                {
//        //                    imageParts[partIndex] = partData;
//        //                    partsReceived++;
//        //                }

//        //                byte ack = (byte)(partIndex + 0x30);
//        //                _udpClient.Send(new byte[] { ack }, 1, _remoteEndPoint);
//        //            }

//        //            int totalBytes = imageParts.Sum(part => part.Value.Length);
//        //            byte[] mergedImageData = new byte[totalBytes];
//        //            int offset = 0;

//        //            for (int i = 0; i < imageParts.Count; i++)
//        //            {
//        //                byte[] part = imageParts[i];
//        //                Buffer.BlockCopy(part, 0, mergedImageData, offset, part.Length);
//        //                offset += part.Length;
//        //            }

//        //            Mat rawData = new Mat(1, mergedImageData.Length, MatType.CV_8UC3, mergedImageData);
//        //            var image = Cv2.ImDecode(rawData, ImreadModes.Color);
//        //            pictureBox_Display.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(image);
//        //        }
//        //        catch (Exception ex)
//        //        {
//        //            Console.WriteLine("Server Error: " + ex.Message);
//        //        }
//        //    }
//        //}

//        public Mat ReceiveAndDisplay()
//        {
//            const int SendBufSize = 40960;
//            const int SplitImg = 4;
//            const int BufSize = SendBufSize * SplitImg;

//            Dictionary<int, byte[]> imageParts = new Dictionary<int, byte[]>();
//            int partsReceived = 0;

//            while (partsReceived < SplitImg)
//            {
//                byte[] receiveData = _udpClient.Receive(ref _remoteEndPoint);

//                int partIndex = receiveData[0] - 0x30;
//                byte[] partData = receiveData.Skip(1).ToArray();

//                if (!imageParts.ContainsKey(partIndex))
//                {
//                    imageParts[partIndex] = partData;
//                    partsReceived++;

//                    byte[] ack = Encoding.ASCII.GetBytes(((char)(partIndex + 0x30)).ToString());
//                    _udpClient.Send(ack, ack.Length, _remoteEndPoint);
//                }
//            }

//            int totalBytes = imageParts.Sum(part => part.Value.Length);
//            byte[] mergedImageData = new byte[totalBytes];
//            int offset = 0;

//            for (int i = 0; i < imageParts.Count; i++)
//            {
//                byte[] part = imageParts[i];
//                Buffer.BlockCopy(part, 0, mergedImageData, offset, part.Length);
//                offset += part.Length;
//            }

//            Mat image = Cv2.ImDecode(mergedImageData, ImreadModes.Color);
//            if (image == null || image.Empty())
//            {
//                Console.WriteLine("Invalid image data received or wrong image format.");
//                return null; //  또는 적절한 대체 이미지를 반환합니다.
//            }
//            return image;
//        }

//    }
//}



using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using OpenCvSharp;
using System.Linq;
using System.Text;

namespace RCWS_Client
{
    public partial class Video : Form
    {
        private const int Port = define.UDPPORT;
        private const string ServerIP = define.SERVER_IP;

        private UdpClient _udpClient;
        private IPEndPoint _remoteEndPoint;

        public Video(UdpClient udpClient, IPEndPoint endPoint)
        {
            InitializeComponent();

            _udpClient = udpClient;
            _remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);

            pictureBox_Display.SizeMode = PictureBoxSizeMode.StretchImage;

            // 영상 수신 및 디코딩 스레드
            Thread receiveAndDisplayThread = new Thread(ReceiveAndDisplay);
            receiveAndDisplayThread.IsBackground = true;
            receiveAndDisplayThread.Start();
        }

        //private void ReceiveAndDisplay()
        //{
        //    while (true)
        //    {
        //        try
        //        {
        //            Mat image = ReceiveImage();

        //            if (image != null && !image.Empty())
        //            {
        //                pictureBox_Display.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(image);
        //            }
        //            else
        //            {
        //                Console.WriteLine("Image ERROR while <ReceiveImage>");
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine("Server Error: " + ex.Message);
        //        }
        //    }
        //}

        //private Mat ReceiveImage()
        //{
        //    const int SendBufSize = 40960;
        //    const int SplitImg = 4;
        //    const int BufSize = SendBufSize * SplitImg;

        //    /*Image 수신 변수*/
        //    Dictionary<int, byte[]> imageParts = new Dictionary<int, byte[]>();
        //    int partsReceived = 0; // 받은 이미지 수

        //    while (partsReceived < SplitImg)
        //    {
        //        /*데이터 수신*/
        //        byte[] receiveData = _udpClient.Receive(ref _remoteEndPoint);

        //        int partIndex = receiveData[0] - 0x30;
        //        byte[] partData = receiveData.Skip(1).ToArray();

        //        if (!imageParts.ContainsKey(partIndex))
        //        {
        //            imageParts[partIndex] = partData;
        //            partsReceived++;

        //            byte[] ack = Encoding.ASCII.GetBytes(((char)(partIndex + 0x30)).ToString());
        //            _udpClient.Send(ack, ack.Length, _remoteEndPoint);
        //        }
        //    }

        //    int totalBytes = imageParts.Sum(part => part.Value.Length);
        //    byte[] mergedImageData = new byte[totalBytes];
        //    int offset = 0;

        //    for (int i = 0; i < imageParts.Count; i++)
        //    {
        //        byte[] part = imageParts[i];
        //        Buffer.BlockCopy(part, 0, mergedImageData, offset, part.Length);
        //        offset += part.Length;
        //    }

        //    Mat image = Cv2.ImDecode(mergedImageData, ImreadModes.Color);
        //    if (image == null || image.Empty())
        //    {
        //        Console.WriteLine("Image ERROR");
        //        return null;
        //    }
        //    return image;
        //}
        //private void ReceiveAndDisplay()
        //{
        //    while (true)
        //    {
        //        try
        //        {
        //            Mat image = ReceiveImage();

        //            if (image != null && !image.Empty())
        //            {
        //                pictureBox_Display.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(image);
        //            }
        //            else
        //            {
        //                Console.WriteLine("Image ERROR while <ReceiveImage>");
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine("Server Error: " + ex.Message);
        //        }
        //    }
        //}

        //private Mat ReceiveImage()
        //{
        //    const int SendBufSize = 40960;
        //    const int SplitImg = 4;
        //    const int BufSize = SendBufSize * SplitImg;

        //    byte[] buffer = new byte[BufSize];
        //    IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);

        //    for (int i = 0; i < SplitImg; i++)
        //    {
        //        byte[] recvBuffer = new byte[SendBufSize];
        //        int ret = _udpClient.Client.ReceiveFrom(recvBuffer, SocketFlags.None, ref remoteEndPoint);

        //        if (ret < 0)
        //        {
        //            throw new Exception("recvfrom failed");
        //            i--;
        //        }

        //        Array.Copy(recvBuffer, 0, buffer, i * SendBufSize, SendBufSize);

        //        char ack = (char)(i + 0x30);
        //        byte[] ackBytes = new byte[] { (byte)ack };
        //        _udpClient.Client.SendTo(ackBytes, SocketFlags.None, remoteEndPoint);
        //    }

        //    Mat image = Cv2.ImDecode(buffer, ImreadModes.Color);

        //    if (image == null || image.Empty())
        //    {
        //        Console.WriteLine("Image ERROR");
        //        return null;
        //    }

        //    return image;
        //}


        // ======================================
        private void ReceiveAndDisplay()
        {
            while (true)
            {
                try
                {
                    Mat image = ReceiveImage();

                    if (image != null && !image.Empty())
                    {
                        pictureBox_Display.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(image);
                    }
                    else
                    {
                        Console.WriteLine("Image ERROR while <ReceiveImage>");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Server Error: " + ex.Message);
                }
            }
        }

        private Mat ReceiveImage()
        {
            const int SendBufSize = 40960;
            const int SplitImg = 4;
            const int BufSize = SendBufSize * SplitImg;

            byte[] buffer = new byte[BufSize];
            EndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);

            for (int i = 0; i < SplitImg; i++)
            {
                byte[] recvBuffer = new byte[SendBufSize];
                int ret = _udpClient.Client.ReceiveFrom(recvBuffer, SocketFlags.None, ref remoteEndPoint);

                if (ret < 0)
                {
                    throw new Exception("recvfrom failed");
                    i--;
                }

                Array.Copy(recvBuffer, 0, buffer, i * SendBufSize, SendBufSize);

                char ack = (char)(i + 0x30);
                byte[] ackBytes = new byte[] { (byte)ack };
                _udpClient.Client.SendTo(ackBytes, SocketFlags.None, remoteEndPoint);
            }

            Mat image = Cv2.ImDecode(buffer, ImreadModes.Color);

            if (image == null || image.Empty())
            {
                Console.WriteLine("Image ERROR");
                return null;
            }

            return image;
        }

    }
}