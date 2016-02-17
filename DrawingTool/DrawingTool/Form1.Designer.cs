namespace DrawingTool
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        System.ComponentModel.ComponentResourceManager resources1 = new System.ComponentModel.ComponentResourceManager(typeof(Form1));

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.colorPickerButton = new System.Windows.Forms.ToolStripButton();
            this.currentColorButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.openImageButton = new System.Windows.Forms.ToolStripButton();
            this.newEmptyImageButton = new System.Windows.Forms.ToolStripButton();
            this.saveButton = new System.Windows.Forms.ToolStripButton();
            this.saveAsButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolSelectDropdownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.pencilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.circleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filledCircleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ellipseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filledEllipseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.squareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filledSquareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotateButton = new System.Windows.Forms.ToolStripButton();
            this.degreesTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.degreesLabel = new System.Windows.Forms.ToolStripLabel();
            this.filterDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.sepiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blackAndWhiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.negativeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transparencyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historyDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.LeftToolStripPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.panel1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(657, 388);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // toolStripContainer1.LeftToolStripPanel
            // 
            this.toolStripContainer1.LeftToolStripPanel.Controls.Add(this.toolStrip2);
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(681, 413);
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
            this.panel1.Size = new System.Drawing.Size(657, 388);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(657, 388);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorPickerButton,
            this.currentColorButton,
            this.toolStripButton6});
            this.toolStrip2.Location = new System.Drawing.Point(0, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(24, 80);
            this.toolStrip2.TabIndex = 0;
            // 
            // colorPickerButton
            // 
            this.colorPickerButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.colorPickerButton.Image = ((System.Drawing.Image)(resources.GetObject("colorPickerButton.Image")));
            this.colorPickerButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.colorPickerButton.Name = "colorPickerButton";
            this.colorPickerButton.Size = new System.Drawing.Size(22, 20);
            this.colorPickerButton.Text = "Color picker";
            this.colorPickerButton.Click += new System.EventHandler(this.colorPickerButton_Click);
            // 
            // currentColorButton
            // 
            this.currentColorButton.BackColor = System.Drawing.Color.Black;
            this.currentColorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.currentColorButton.Image = ((System.Drawing.Image)(resources.GetObject("currentColorButton.Image")));
            this.currentColorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.currentColorButton.Name = "currentColorButton";
            this.currentColorButton.Size = new System.Drawing.Size(22, 20);
            this.currentColorButton.Text = "toolStripButton5";
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(22, 20);
            this.toolStripButton6.Text = "toolStripButton6";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openImageButton,
            this.newEmptyImageButton,
            this.saveButton,
            this.saveAsButton,
            this.toolStripSeparator1,
            this.toolSelectDropdownButton,
            this.rotateButton,
            this.degreesTextBox,
            this.degreesLabel,
            this.filterDropDownButton2,
            this.historyDropDownButton});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(305, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // openImageButton
            // 
            this.openImageButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openImageButton.Image = ((System.Drawing.Image)(resources.GetObject("openImageButton.Image")));
            this.openImageButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openImageButton.Name = "openImageButton";
            this.openImageButton.Size = new System.Drawing.Size(23, 22);
            this.openImageButton.Text = "Load image";
            this.openImageButton.Click += new System.EventHandler(this.openImageButton_Click);
            // 
            // newEmptyImageButton
            // 
            this.newEmptyImageButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newEmptyImageButton.Image = ((System.Drawing.Image)(resources.GetObject("newEmptyImageButton.Image")));
            this.newEmptyImageButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newEmptyImageButton.Name = "newEmptyImageButton";
            this.newEmptyImageButton.Size = new System.Drawing.Size(23, 22);
            this.newEmptyImageButton.Text = "New";
            this.newEmptyImageButton.Click += new System.EventHandler(this.newEmptyImage_Click);
            // 
            // saveButton
            // 
            this.saveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveButton.Image = ((System.Drawing.Image)(resources.GetObject("saveButton.Image")));
            this.saveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(23, 22);
            this.saveButton.Text = "Save";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // saveAsButton
            // 
            this.saveAsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveAsButton.Image = ((System.Drawing.Image)(resources.GetObject("saveAsButton.Image")));
            this.saveAsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveAsButton.Name = "saveAsButton";
            this.saveAsButton.Size = new System.Drawing.Size(23, 22);
            this.saveAsButton.Text = "Save As...";
            this.saveAsButton.Click += new System.EventHandler(this.saveAsButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolSelectDropdownButton
            // 
            this.toolSelectDropdownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolSelectDropdownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pencilToolStripMenuItem,
            this.lineToolStripMenuItem,
            this.circleToolStripMenuItem,
            this.filledCircleToolStripMenuItem,
            this.ellipseToolStripMenuItem,
            this.filledEllipseToolStripMenuItem,
            this.squareToolStripMenuItem,
            this.filledSquareToolStripMenuItem});
            this.toolSelectDropdownButton.Image = ((System.Drawing.Image)(resources.GetObject("toolSelectDropdownButton.Image")));
            this.toolSelectDropdownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSelectDropdownButton.Name = "toolSelectDropdownButton";
            this.toolSelectDropdownButton.Size = new System.Drawing.Size(29, 22);
            this.toolSelectDropdownButton.Text = "Tool select";
            // 
            // pencilToolStripMenuItem
            // 
            this.pencilToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pencilToolStripMenuItem.Image")));
            this.pencilToolStripMenuItem.Name = "pencilToolStripMenuItem";
            this.pencilToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.pencilToolStripMenuItem.Text = "Pencil";
            this.pencilToolStripMenuItem.Click += new System.EventHandler(this.pencilToolStripMenuItem_Click);
            // 
            // lineToolStripMenuItem
            // 
            this.lineToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("lineToolStripMenuItem.Image")));
            this.lineToolStripMenuItem.Name = "lineToolStripMenuItem";
            this.lineToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.lineToolStripMenuItem.Text = "Line";
            this.lineToolStripMenuItem.Click += new System.EventHandler(this.lineToolStripMenuItem_Click);
            // 
            // circleToolStripMenuItem
            // 
            this.circleToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("circleToolStripMenuItem.Image")));
            this.circleToolStripMenuItem.Name = "circleToolStripMenuItem";
            this.circleToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.circleToolStripMenuItem.Text = "Circle";
            this.circleToolStripMenuItem.Click += new System.EventHandler(this.circleToolStripMenuItem_Click);
            // 
            // filledCircleToolStripMenuItem
            // 
            this.filledCircleToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("filledCircleToolStripMenuItem.Image")));
            this.filledCircleToolStripMenuItem.Name = "filledCircleToolStripMenuItem";
            this.filledCircleToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.filledCircleToolStripMenuItem.Text = "Filled circle";
            this.filledCircleToolStripMenuItem.Click += new System.EventHandler(this.filledCircleToolStripMenuItem_Click);
            // 
            // ellipseToolStripMenuItem
            // 
            this.ellipseToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ellipseToolStripMenuItem.Image")));
            this.ellipseToolStripMenuItem.Name = "ellipseToolStripMenuItem";
            this.ellipseToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.ellipseToolStripMenuItem.Text = "Ellipse";
            this.ellipseToolStripMenuItem.Click += new System.EventHandler(this.ellipseToolStripMenuItem_Click);
            // 
            // filledEllipseToolStripMenuItem
            // 
            this.filledEllipseToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("filledEllipseToolStripMenuItem.Image")));
            this.filledEllipseToolStripMenuItem.Name = "filledEllipseToolStripMenuItem";
            this.filledEllipseToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.filledEllipseToolStripMenuItem.Text = "Filled ellipse";
            this.filledEllipseToolStripMenuItem.Click += new System.EventHandler(this.filledEllipseToolStripMenuItem_Click);
            // 
            // squareToolStripMenuItem
            // 
            this.squareToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("squareToolStripMenuItem.Image")));
            this.squareToolStripMenuItem.Name = "squareToolStripMenuItem";
            this.squareToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.squareToolStripMenuItem.Text = "Square";
            this.squareToolStripMenuItem.Click += new System.EventHandler(this.squareToolStripMenuItem_Click);
            // 
            // filledSquareToolStripMenuItem
            // 
            this.filledSquareToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("filledSquareToolStripMenuItem.Image")));
            this.filledSquareToolStripMenuItem.Name = "filledSquareToolStripMenuItem";
            this.filledSquareToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.filledSquareToolStripMenuItem.Text = "Filled square";
            this.filledSquareToolStripMenuItem.Click += new System.EventHandler(this.filledSquareToolStripMenuItem_Click);
            // 
            // rotateButton
            // 
            this.rotateButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rotateButton.Image = ((System.Drawing.Image)(resources.GetObject("rotateButton.Image")));
            this.rotateButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rotateButton.Name = "rotateButton";
            this.rotateButton.Size = new System.Drawing.Size(23, 22);
            this.rotateButton.Text = "Rotate image";
            this.rotateButton.Click += new System.EventHandler(this.rotateButton_Click);
            // 
            // degreesTextBox
            // 
            this.degreesTextBox.Name = "degreesTextBox";
            this.degreesTextBox.Size = new System.Drawing.Size(40, 25);
            // 
            // degreesLabel
            // 
            this.degreesLabel.Name = "degreesLabel";
            this.degreesLabel.Size = new System.Drawing.Size(12, 22);
            this.degreesLabel.Text = "°";
            // 
            // filterDropDownButton2
            // 
            this.filterDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.filterDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sepiaToolStripMenuItem,
            this.blackAndWhiteToolStripMenuItem,
            this.negativeToolStripMenuItem,
            this.transparencyToolStripMenuItem});
            this.filterDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("filterDropDownButton2.Image")));
            this.filterDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.filterDropDownButton2.Name = "filterDropDownButton2";
            this.filterDropDownButton2.Size = new System.Drawing.Size(29, 22);
            this.filterDropDownButton2.Text = "Filters";
            // 
            // sepiaToolStripMenuItem
            // 
            this.sepiaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("sepiaToolStripMenuItem.Image")));
            this.sepiaToolStripMenuItem.Name = "sepiaToolStripMenuItem";
            this.sepiaToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.sepiaToolStripMenuItem.Text = "Sepia";
            this.sepiaToolStripMenuItem.Click += new System.EventHandler(this.sepia_Click);
            // 
            // blackAndWhiteToolStripMenuItem
            // 
            this.blackAndWhiteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("blackAndWhiteToolStripMenuItem.Image")));
            this.blackAndWhiteToolStripMenuItem.Name = "blackAndWhiteToolStripMenuItem";
            this.blackAndWhiteToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.blackAndWhiteToolStripMenuItem.Text = "Black and white";
            this.blackAndWhiteToolStripMenuItem.Click += new System.EventHandler(this.grayscale_Click);
            // 
            // negativeToolStripMenuItem
            // 
            this.negativeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("negativeToolStripMenuItem.Image")));
            this.negativeToolStripMenuItem.Name = "negativeToolStripMenuItem";
            this.negativeToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.negativeToolStripMenuItem.Text = "Negative";
            this.negativeToolStripMenuItem.Click += new System.EventHandler(this.negative_Click);
            // 
            // transparencyToolStripMenuItem
            // 
            this.transparencyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("transparencyToolStripMenuItem.Image")));
            this.transparencyToolStripMenuItem.Name = "transparencyToolStripMenuItem";
            this.transparencyToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.transparencyToolStripMenuItem.Text = "Transparency";
            this.transparencyToolStripMenuItem.Click += new System.EventHandler(this.transparency_Click);
            // 
            // historyDropDownButton
            // 
            this.historyDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.historyDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6});
            this.historyDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("historyDropDownButton.Image")));
            this.historyDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.historyDropDownButton.Name = "historyDropDownButton";
            this.historyDropDownButton.Size = new System.Drawing.Size(29, 22);
            this.historyDropDownButton.Text = "History";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem2.Text = "---";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem3.Text = "---";
            this.toolStripMenuItem3.Visible = false;
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem4.Text = "---";
            this.toolStripMenuItem4.Visible = false;
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem5.Text = "---";
            this.toolStripMenuItem5.Visible = false;
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem6.Text = "---";
            this.toolStripMenuItem6.Visible = false;
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 413);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "Form1";
            this.Text = "Picture Tool";
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.LeftToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.LeftToolStripPanel.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton openImageButton;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton colorPickerButton;
        private System.Windows.Forms.ToolStripButton currentColorButton;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripButton saveButton;
        private System.Windows.Forms.ToolStripButton saveAsButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripDropDownButton toolSelectDropdownButton;
        private System.Windows.Forms.ToolStripMenuItem pencilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem circleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ellipseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem squareToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem filledCircleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filledEllipseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filledSquareToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox degreesTextBox;
        private System.Windows.Forms.ToolStripLabel degreesLabel;
        private System.Windows.Forms.ToolStripButton rotateButton;
        private System.Windows.Forms.ToolStripButton newEmptyImageButton;
        private System.Windows.Forms.ToolStripDropDownButton filterDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem sepiaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blackAndWhiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem negativeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transparencyToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton historyDropDownButton;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
    }
}

