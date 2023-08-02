using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RCWS_Client
{
    internal class TcpUdpClient
    {
        private IPAddress _serverIpAddress;
        private int _tcpPort;
        private int _udpPort;

        public TcpUdpClient(string serverIpAddress, int tcpPort, int udpPort)
        {
            if (!IPAddress.TryParse(serverIpAddress, out _serverIpAddress))
            {
                throw new ArgumentException("Invalid server IP address.");
            }

            _tcpPort = tcpPort;
            _udpPort = udpPort;
        }

        public async Task SendTcpMessageAsync(string message)
        {
            using (var tcpClient = new TcpClient())
            {
                await tcpClient.ConnectAsync(_serverIpAddress, _tcpPort);

                var buffer = Encoding.ASCII.GetBytes(message);
                using (var stream = tcpClient.GetStream())
                {
                    await stream.WriteAsync(buffer, 0, buffer.Length);
                }
            }
        }

        public async Task SendUdpMessageAsync(string message)
        {
            using (var udpClient = new UdpClient())
            {
                var buffer = Encoding.ASCII.GetBytes(message);
                await udpClient.SendAsync(buffer, buffer.Length, new IPEndPoint(_serverIpAddress, _udpPort));
            }
        }
    }
}
