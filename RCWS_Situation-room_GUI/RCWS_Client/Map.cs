using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCWS_Client
{
    public partial class Map : Form
    {
        private Bitmap mapImage;
        private Bitmap arrow;
        private float currentScale = 1.0f;
        private float zoomFactor = 1.1f;
        private bool isDragging = false;
        private bool LButton = false;
        private int lastX;
        private int lastY;

        /*
        private List<Bitmap> mapOverlays;
        private List<Point> mapOverlayLocations;
        private Bitmap currentOverlay;
        */

        public Map()
        {
            InitializeComponent();

            pictureBox_Map.SizeMode = PictureBoxSizeMode.AutoSize;
            mapImage = new Bitmap(@"C:\JHIWHOON_ws\2023 Hanium\file photo\demomap.bmp");
            UpdateMapImage();

            pictureBox_Map.MouseWheel += MapPictureBox_MouseWheel;
            pictureBox_Map.MouseDown += MapPictureBox_MouseDown;
            pictureBox_Map.MouseMove += MapPictureBox_MouseMove;
            pictureBox_Map.MouseUp += MapPictureBox_MouseUp;

            /*
            mapOverlays = new List<Bitmap>();
            mapOverlayLocations = new List<Point>();
            currentOverlay = null;
            */
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

                /*
                for (int i = 0; i < mapOverlays.Count; i++)
                {
                    var overlay = mapOverlays[i];
                    var location = mapOverlayLocations[i];
                    g.DrawImage(overlay, new Rectangle(location.X, location.Y, overlay.Width, overlay.Height));
                }
                */
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

            if (e.Button == MouseButtons.Right)
            {
                LButton = true;
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
            catch(Exception ex)
            {
                MessageBox.Show("Error in MapPictur eBox_MouseMove: " + ex.Message);
            }
        }

        private void MapPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }

            /*
            if (e.Button == MouseButtons.Right)
            {
                if (currentOverlay != null)
                {
                    mapOverlays.Add(currentOverlay);
                    mapOverlayLocations.Add(e.Location);
                    UpdateMapImage();
                }
            }
            */
        }

        /*
        private void noEnemyMovementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentOverlay = new Bitmap(@"C:\JHIWHOON_ws\2023 Hanium\file photo\Arrow.bmp");
        }

        private void enemyContinuouslyMovingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentOverlay = new Bitmap(@"C:\JHIWHOON_ws\2023 Hanium\file photo\Arrow.bmp");
        }
        */
    }
}