namespace RCWS_Client
{
    partial class Map
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Map));
            this.pictureBox_Map = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Map)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_Map
            // 
            this.pictureBox_Map.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_Map.Image")));
            this.pictureBox_Map.InitialImage = null;
            this.pictureBox_Map.Location = new System.Drawing.Point(12, 12);
            this.pictureBox_Map.Name = "pictureBox_Map";
            this.pictureBox_Map.Size = new System.Drawing.Size(1206, 697);
            this.pictureBox_Map.TabIndex = 0;
            this.pictureBox_Map.TabStop = false;
            // 
            // Map
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1230, 721);
            this.Controls.Add(this.pictureBox_Map);
            this.Name = "Map";
            this.Text = "Map";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Map)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_Map;
    }
}