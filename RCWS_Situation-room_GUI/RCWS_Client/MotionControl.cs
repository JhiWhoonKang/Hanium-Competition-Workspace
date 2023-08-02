//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.IO;
//using System.Linq;
//using System.Net.Sockets;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace RCWS_Client
//{
//    public partial class MotionControl : Form
//    {
//        private StreamWriter streamWriter;

//        public MotionControl(StreamWriter streamWriter)
//        {
//            InitializeComponent();
//            this.streamWriter = streamWriter;
//            this.KeyPress += MotionControl_KeyPress;
//        }

//        private async void MotionControl_KeyPress(object sender, KeyPressEventArgs e)
//        {
//            char direction;

//            switch (e.KeyChar)
//            {
//                case 'w':
//                    direction = 'U';
//                    await streamWriter.WriteAsync(direction);
//                    break;

//                case 'a':
//                    direction = 'L';
//                    await streamWriter.WriteAsync(direction);
//                    break;

//                case 's':
//                    direction = 'D';
//                    await streamWriter.WriteAsync(direction);
//                    break;

//                case 'd':
//                    direction = 'R';
//                    await streamWriter.WriteAsync(direction);
//                    break;
                
//                default:
//                    return;
//            }
//            await streamWriter.WriteAsync(direction + "\n");
//            streamWriter.Flush();
//        }
//    }
//}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//namespace RCWS_Client
//{
//    public partial class MotionControl : Form
//    {
//        private StreamWriter _streamWriter;
//        private HashSet<Keys> _pressedKeys = new HashSet<Keys>();

//        public MotionControl(StreamWriter streamWriter)
//        {
//            InitializeComponent();
//            this._streamWriter = streamWriter;
//            this.KeyDown += new KeyEventHandler(MotionControl_KeyDown);
//            this.KeyUp += new KeyEventHandler(MotionControl_KeyUp);
//        }

//        private async void MotionControl_KeyDown(object sender, KeyEventArgs e)
//        {
//            _pressedKeys.Add(e.KeyCode);

//            char horizontalDirection = (_pressedKeys.Contains(Keys.A) ? 'L' : (_pressedKeys.Contains(Keys.D) ? 'R' : '\0'));
//            char verticalDirection = (_pressedKeys.Contains(Keys.W) ? 'U' : (_pressedKeys.Contains(Keys.S) ? 'D' : '\0'));

//            if (horizontalDirection != '\0')
//                await SendDirectionAsync(horizontalDirection);

//            if (verticalDirection != '\0')
//                await SendDirectionAsync(verticalDirection);
//        }

//        private void MotionControl_KeyUp(object sender, KeyEventArgs e)
//        {
//            _pressedKeys.Remove(e.KeyCode);
//        }

//        private async Task SendDirectionAsync(char direction)
//        {
//            await _streamWriter.WriteAsync(direction + "\n");
//            _streamWriter.Flush();
//        }
//    }
//}


namespace RCWS_Client
{
    public partial class MotionControl : Form
    {
        private StreamWriter _streamWriter;
        private HashSet<Keys> _pressedKeys = new HashSet<Keys>();

        public MotionControl(StreamWriter streamWriter)
        {
            InitializeComponent();
            this._streamWriter = streamWriter;
            this.KeyDown += new KeyEventHandler(MotionControl_KeyDown);
            this.KeyUp += new KeyEventHandler(MotionControl_KeyUp);
        }

        private async void MotionControl_KeyDown(object sender, KeyEventArgs e)
        {
            _pressedKeys.Add(e.KeyCode);
            await SendDirectionPacketAsync();
        }

        private async void MotionControl_KeyUp(object sender, KeyEventArgs e)
        {
            _pressedKeys.Remove(e.KeyCode);
            await SendDirectionPacketAsync();
        }

        /*
         * Packet
        좌측      | 1 0000 0001
        우측      | 2 0000 0010
        상단      | 4 0000 0100
        하단      | 8 0000 1000
        좌상단    | 5 0000 0101
        우상단    | 6 0000 0110
        좌하단    | 9 0000 1001
        우하단    | 10 0000 1010
        명령권    | 16 0001 xxxx
         *
         */
        private async Task SendDirectionPacketAsync()
        {
            byte packet = 0;

            if (_pressedKeys.Contains(Keys.A))
                packet |= 1 << 0;

            if (_pressedKeys.Contains(Keys.D))
                packet |= 1 << 1;

            if (_pressedKeys.Contains(Keys.W))
                packet |= 1 << 2;

            if (_pressedKeys.Contains(Keys.S))
                packet |= 1 << 3;

            if(_pressedKeys.Contains(Keys.C))
                packet |= 1 << 4;

            await _streamWriter.WriteAsync(packet.ToString() + "\n");
            _streamWriter.Flush();
        }
    }
}
