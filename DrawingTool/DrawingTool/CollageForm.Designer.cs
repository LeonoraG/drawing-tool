namespace DrawingTool
{
    partial class CollageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CollageForm));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.loadLayoutButton = new System.Windows.Forms.ToolStripButton();
            this.createLayoutButton = new System.Windows.Forms.ToolStripButton();
            this.loadImagesButton = new System.Windows.Forms.ToolStripButton();
            this.saveAsButton = new System.Windows.Forms.ToolStripButton();
            this.presetsButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.smilePresetButton = new System.Windows.Forms.ToolStripMenuItem();
            this.notebookPresetButton = new System.Windows.Forms.ToolStripMenuItem();
            this.moviePresetButton = new System.Windows.Forms.ToolStripMenuItem();
            this.heartsPresetButton = new System.Windows.Forms.ToolStripMenuItem();
            this.closeButton = new System.Windows.Forms.ToolStripButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.panel1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(369, 237);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(369, 262);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(369, 237);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(134, 101);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadLayoutButton,
            this.createLayoutButton,
            this.loadImagesButton,
            this.saveAsButton,
            this.presetsButton,
            this.closeButton});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(187, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // loadLayoutButton
            // 
            this.loadLayoutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.loadLayoutButton.Image = ((System.Drawing.Image)(resources.GetObject("loadLayoutButton.Image")));
            this.loadLayoutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.loadLayoutButton.Name = "loadLayoutButton";
            this.loadLayoutButton.Size = new System.Drawing.Size(23, 22);
            this.loadLayoutButton.Text = "Load exsisting collage layout";
            this.loadLayoutButton.Click += new System.EventHandler(this.loadLayoutButton_Click);
            // 
            // createLayoutButton
            // 
            this.createLayoutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.createLayoutButton.Image = ((System.Drawing.Image)(resources.GetObject("createLayoutButton.Image")));
            this.createLayoutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.createLayoutButton.Name = "createLayoutButton";
            this.createLayoutButton.Size = new System.Drawing.Size(23, 22);
            this.createLayoutButton.Text = "Create layout";
            this.createLayoutButton.Click += new System.EventHandler(this.createLayoutButton_Click);
            // 
            // loadImagesButton
            // 
            this.loadImagesButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.loadImagesButton.Enabled = false;
            this.loadImagesButton.Image = ((System.Drawing.Image)(resources.GetObject("loadImagesButton.Image")));
            this.loadImagesButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.loadImagesButton.Name = "loadImagesButton";
            this.loadImagesButton.Size = new System.Drawing.Size(23, 22);
            this.loadImagesButton.Text = "Load images to layout";
            this.loadImagesButton.Click += new System.EventHandler(this.loadImagesButton_Click);
            // 
            // saveAsButton
            // 
            this.saveAsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveAsButton.Enabled = false;
            this.saveAsButton.Image = ((System.Drawing.Image)(resources.GetObject("saveAsButton.Image")));
            this.saveAsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveAsButton.Name = "saveAsButton";
            this.saveAsButton.Size = new System.Drawing.Size(23, 22);
            this.saveAsButton.Text = "Save as...";
            this.saveAsButton.Click += new System.EventHandler(this.saveAsButton_Click);
            // 
            // presetsButton
            // 
            this.presetsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.presetsButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smilePresetButton,
            this.notebookPresetButton,
            this.moviePresetButton,
            this.heartsPresetButton});
            this.presetsButton.Image = ((System.Drawing.Image)(resources.GetObject("presetsButton.Image")));
            this.presetsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.presetsButton.Name = "presetsButton";
            this.presetsButton.Size = new System.Drawing.Size(29, 22);
            this.presetsButton.Text = "Load presets";
            // 
            // smilePresetButton
            // 
            this.smilePresetButton.Name = "smilePresetButton";
            this.smilePresetButton.Size = new System.Drawing.Size(129, 22);
            this.smilePresetButton.Text = "Smile";
            this.smilePresetButton.Click += new System.EventHandler(this.smilePresetButton_Click);
            // 
            // notebookPresetButton
            // 
            this.notebookPresetButton.Name = "notebookPresetButton";
            this.notebookPresetButton.Size = new System.Drawing.Size(129, 22);
            this.notebookPresetButton.Text = "Notebook";
            this.notebookPresetButton.Click += new System.EventHandler(this.notebookPresetButton_Click);
            // 
            // moviePresetButton
            // 
            this.moviePresetButton.Name = "moviePresetButton";
            this.moviePresetButton.Size = new System.Drawing.Size(129, 22);
            this.moviePresetButton.Text = "Movie reel";
            this.moviePresetButton.Click += new System.EventHandler(this.moviePresetButton_Click);
            // 
            // heartsPresetButton
            // 
            this.heartsPresetButton.Name = "heartsPresetButton";
            this.heartsPresetButton.Size = new System.Drawing.Size(129, 22);
            this.heartsPresetButton.Text = "Hearts";
            this.heartsPresetButton.Click += new System.EventHandler(this.heartsPresetButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.closeButton.Enabled = false;
            this.closeButton.Image = ((System.Drawing.Image)(resources.GetObject("closeButton.Image")));
            this.closeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(23, 22);
            this.closeButton.Text = "Close collage";
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imageList2
            // 
            this.imageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList2.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // CollageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 262);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "CollageForm";
            this.Text = "Collage maker";
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton loadLayoutButton;
        private System.Windows.Forms.ToolStripButton createLayoutButton;
        private System.Windows.Forms.ToolStripButton loadImagesButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripButton saveAsButton;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripDropDownButton presetsButton;
        private System.Windows.Forms.ToolStripMenuItem smilePresetButton;
        private System.Windows.Forms.ToolStripMenuItem notebookPresetButton;
        private System.Windows.Forms.ToolStripMenuItem moviePresetButton;
        private System.Windows.Forms.ToolStripMenuItem heartsPresetButton;
        private System.Windows.Forms.ToolStripButton closeButton;
    }
}