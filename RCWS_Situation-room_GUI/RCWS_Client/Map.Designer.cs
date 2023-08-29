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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Map));
            this.pictureBox_Map = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.enemyGatheringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noEnemyMovementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enemyContinuouslyMovingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Map)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
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
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enemyGatheringToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 48);
            // 
            // enemyGatheringToolStripMenuItem
            // 
            this.enemyGatheringToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noEnemyMovementToolStripMenuItem,
            this.enemyContinuouslyMovingToolStripMenuItem});
            this.enemyGatheringToolStripMenuItem.Name = "enemyGatheringToolStripMenuItem";
            this.enemyGatheringToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.enemyGatheringToolStripMenuItem.Text = "Enemy Gathering";
            // 
            // noEnemyMovementToolStripMenuItem
            // 
            this.noEnemyMovementToolStripMenuItem.Name = "noEnemyMovementToolStripMenuItem";
            this.noEnemyMovementToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.noEnemyMovementToolStripMenuItem.Text = "No enemy movement";
            //this.noEnemyMovementToolStripMenuItem.Click += new System.EventHandler(this.noEnemyMovementToolStripMenuItem_Click);
            // 
            // enemyContinuouslyMovingToolStripMenuItem
            // 
            this.enemyContinuouslyMovingToolStripMenuItem.Name = "enemyContinuouslyMovingToolStripMenuItem";
            this.enemyContinuouslyMovingToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.enemyContinuouslyMovingToolStripMenuItem.Text = "Enemy continuously moving";
            //this.enemyContinuouslyMovingToolStripMenuItem.Click += new System.EventHandler(this.enemyContinuouslyMovingToolStripMenuItem_Click);
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
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_Map;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem enemyGatheringToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noEnemyMovementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enemyContinuouslyMovingToolStripMenuItem;
    }
}