using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Media;

namespace DrawingTool
{
    public partial class MainForm : Form
    {
        String currentImagePath = "";

        int thickness = 1;
        Color currentColor = System.Drawing.ColorTranslator.FromHtml("#000000");
        Color backColor = System.Drawing.ColorTranslator.FromHtml("#000000");
        String selectedTool = "pencil";
        bool filled = false;
        private Point? previous = null;
        private Point? initial = null;
        Point? current = null;
        //for drawing
        Rectangle r;
        bool finalPaint = false;
        bool drawing = false;

        //for history
        int max = 5;
        int historyCount = 0;
        List<Image> historyImages = new List<Image>();
        List<String> historyMoves = new List<String>();
        

        //select,cut,paste

        int X0, Y0, X1, Y1;
        bool selectionRectangleSet = false;
        bool selectingArea = false;
        Bitmap SelectedImage = null;
        Bitmap OriginalImage = null;
        Graphics SelectedGraphics = null;
        Rectangle selection;
        Image beforeSelection; //backup in case we gave up from selection
        
        public MainForm()
        {
            InitializeComponent();
            degreesTextBox.Text = "0,0";
        }


        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            initial = e.Location;
            current = initial;
            X0 = e.X;
            Y0 = e.Y;
            OriginalImage = new Bitmap(pictureBox1.Image);

            if (selectedTool == "selectionTool")
            {
                selectingArea = true;

                //backup image
                Bitmap bmp2 = new Bitmap(pictureBox1.Image);
                Image img = bmp2;
                beforeSelection = img;

                SelectedImage = new Bitmap(OriginalImage);
                SelectedGraphics = Graphics.FromImage(SelectedImage);
                pictureBox1.Image = SelectedImage;
            }
            else if (selectedTool == "pencil")
            {
                previous = e.Location;
                PictureBox1_MouseMove(sender, e);
            }
            else if (selectedTool == "line")
            {
                drawing = true;
                pictureBox1.Invalidate();

            }
            else{
                drawing = true;
                r = new Rectangle(e.X, e.Y, 0, 0);
                pictureBox1.Invalidate();
            }
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            current = e.Location;
            Pen myPen = new Pen(currentColor, thickness);

            if (previous != null && selectedTool == "pencil")
            {
                if (pictureBox1.Image == null)
                {
                    Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.Clear(Color.White);
                    }
                    pictureBox1.Image = bmp;
                }
                using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                {
                    System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(currentColor);
                    Rectangle temp = r = new Rectangle(current.Value.X, current.Value.Y, thickness, thickness);
                    if (thickness == 1)
                        g.FillRectangle(myBrush, current.Value.X, current.Value.Y,1,1);
                    else
                        g.FillEllipse(myBrush, r);
                }
                pictureBox1.Invalidate();
                previous = e.Location;
            }
            if ((selectedTool == "rectangle" || selectedTool == "ellipse") && drawing)
            {
                r = new Rectangle(Math.Min(X0, e.X), Math.Min(Y0, e.Y), Math.Abs(e.X - X0), Math.Abs(e.Y - Y0));
                pictureBox1.Invalidate();
            }
            if ((selectedTool == "square" || selectedTool == "circle") && drawing) 
            {
                int l = Math.Max(Math.Abs(e.X - X0), Math.Abs(e.Y - Y0));
                r = new Rectangle(Math.Min(X0, e.X), Math.Min(Y0, e.Y), l, l);
                pictureBox1.Invalidate();
            }
            if (selectedTool == "line" && drawing)
            {
                pictureBox1.Invalidate();
            }
            
            if (selectedTool == "selectionTool")
            {
                if (!selectingArea) return;
                X1 = e.X;
                Y1 = e.Y;


                SelectedGraphics.DrawImage(OriginalImage, 0, 0);

                //draw red dashed selection rectangle on the image
                using (Pen select_pen = new Pen(Color.Red))
                {
                    select_pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    Rectangle rect = new Rectangle(X0,Y0,Math.Abs(X0-X1),Math.Abs(Y0-Y1));
                    SelectedGraphics.DrawRectangle(select_pen, rect);
                }

                pictureBox1.Refresh();
            }
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            previous = null;
            Pen myPen = new Pen(currentColor, thickness);
            current = e.Location;
            if (selectedTool == "pencil")
            {
                Bitmap bmp2 = new Bitmap(pictureBox1.Image);
                Image img = bmp2;
                SaveToHistory(img, "New pencil drawing");
            }

            if (drawing && (selectedTool == "square" || selectedTool == "ellipse" || selectedTool == "circle" || selectedTool == "rectangle"))
            {
                finalPaint = true;
                pictureBox1.Invalidate();
                drawing = false;
                Bitmap bmp2 = new Bitmap(pictureBox1.Image);
                Image img = bmp2;
                if (filled)
                    SaveToHistory(img, "New filled " + selectedTool);
                else
                    SaveToHistory(img, "New " + selectedTool);
                
            }
           
            if (selectedTool == "line" && drawing)
            {
                finalPaint = true;
                pictureBox1.Invalidate();
                Bitmap bmp2 = new Bitmap(pictureBox1.Image);
                Image img = bmp2;
                SaveToHistory(img, "New line");
                drawing = false;
            }
            
            
            if (selectedTool == "selectionTool")
            {
                if (!selectingArea) return;
                selectingArea = false;

                SelectedGraphics = null;

                // Convert the points into a Rectangle.
                selection = new Rectangle(X0, Y0, Math.Abs(X0 - X1), Math.Abs(Y0 - Y1));
                selectionRectangleSet = (
                    (selection.Width > 0) &&
                    (selection.Height > 0));
                this.cutButton.Enabled = true;
                this.copyButton.Enabled = true;
                selectedTool = "";
                
                if (Clipboard.GetImage() != null)
                {
                    this.pasteButton.Enabled = true;
                }
            }
        }

        
        private void ColorPickerButton_Click(object sender, EventArgs e)
        {
            this.selectButton.BackColor = SystemColors.Control;
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.ShowHelp = true;
            MyDialog.Color = currentColor;

            if (MyDialog.ShowDialog() == DialogResult.OK)
                currentColor = MyDialog.Color;
            this.currentColorButton.BackColor = currentColor;
        }

        #region openSaveImage
        private void OpenImageButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = "c:\\";
            dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            dialog.FilterIndex = 2;
            dialog.RestoreDirectory = true;
            dialog.Multiselect = false;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                //loading the image to the form
                currentImagePath = dialog.FileName;
                this.pictureBox1.Image = Image.FromFile(currentImagePath);

                //saving to history
                Bitmap bmp2 = new Bitmap(pictureBox1.Image);
                Image img = bmp2;
                SaveToHistory(img, "New image from file: " + dialog.SafeFileName);

                //enabling the buttons
                toolSelectDropdownButton.Enabled = true;
                filterDropDownButton2.Enabled = true;
                saveAsButton.Enabled = true;
                saveButton.Enabled = true;
                closeFileButton.Enabled = true;
                rotateButton.Enabled = true;
                selectButton.Enabled = true;
            }
        }
        private void NewEmptyImage_Click(object sender, EventArgs e)
        {
            //creating an empty image
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
            }
            pictureBox1.Image = bmp;

            //saving to history
            Bitmap bmp2 = new Bitmap(pictureBox1.Image);
            Image img = bmp2;
            SaveToHistory(img, "New empty image");

            //enabling the buttons
            toolSelectDropdownButton.Enabled = true;
            filterDropDownButton2.Enabled = true;
            saveAsButton.Enabled = true;
            saveButton.Enabled = true;
            closeFileButton.Enabled = true;
            rotateButton.Enabled = true;
            selectButton.Enabled = true;
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if(currentImagePath!="")
                pictureBox1.Image.Save(currentImagePath);
        }
        private void SaveAsButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String name = saveFileDialog1.FileName;
                pictureBox1.Image.Save(name);
            }
        }
        private void CloseFileButton_Click(object sender, EventArgs e)
        {
            //reseting the values
            pictureBox1.Image = null;
            currentImagePath = "";
            historyImages = new List<Image>();
            historyMoves = new List<String>();
            historyCount = 0;

            //disabling the buttons...
            toolSelectDropdownButton.Enabled = false;
            filterDropDownButton2.Enabled = false;
            saveAsButton.Enabled = false;
            saveButton.Enabled = false;
            closeFileButton.Enabled = false;
            rotateButton.Enabled = false;
            selectButton.Enabled = false;
            cutButton.Enabled = false;
            pasteButton.Enabled = false;
            copyButton.Enabled = false;
        }
        #endregion openSaveImage

        #region tools
        private void PencilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveSelectionRectangle();

            this.selectButton.BackColor = SystemColors.Control;
            selectedTool = "pencil";
            filled = false;
            this.toolSelectDropdownButton.Image = ((System.Drawing.Image)(resources1.GetObject("pencilToolStripMenuItem.Image")));
        }

        private void LineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveSelectionRectangle();

            this.selectButton.BackColor = SystemColors.Control;
            selectedTool = "line";
            filled = false;
            this.toolSelectDropdownButton.Image = ((System.Drawing.Image)(resources1.GetObject("lineToolStripMenuItem.Image")));
        }

        private void CircleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveSelectionRectangle();

            this.selectButton.BackColor = SystemColors.Control;
            selectedTool = "circle";
            filled = false;
            this.toolSelectDropdownButton.Image = ((System.Drawing.Image)(resources1.GetObject("circleToolStripMenuItem.Image")));
        }

        private void EllipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveSelectionRectangle();

            this.selectButton.BackColor = SystemColors.Control;
            selectedTool = "ellipse";
            filled = false;
            this.toolSelectDropdownButton.Image = ((System.Drawing.Image)(resources1.GetObject("ellipseToolStripMenuItem.Image")));
        }

        private void SquareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveSelectionRectangle();

            this.selectButton.BackColor = SystemColors.Control;
            selectedTool = "square";
            filled = false;
            this.toolSelectDropdownButton.Image = ((System.Drawing.Image)(resources1.GetObject("squareToolStripMenuItem.Image")));
        }
        private void RectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveSelectionRectangle();

            this.selectButton.BackColor = SystemColors.Control;
            selectedTool = "rectangle";
            filled = false;
            this.toolSelectDropdownButton.Image = ((System.Drawing.Image)(resources1.GetObject("rectangleToolStripMenuItem.Image")));
        }
        private void FilledCircleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveSelectionRectangle();

            this.selectButton.BackColor = SystemColors.Control;
            selectedTool = "circle";
            filled = true;
            this.toolSelectDropdownButton.Image = ((System.Drawing.Image)(resources1.GetObject("filledCircleToolStripMenuItem.Image")));
        }

        private void FilledEllipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveSelectionRectangle();

            this.selectButton.BackColor = SystemColors.Control;
            selectedTool = "ellipse";
            filled = true;
            this.toolSelectDropdownButton.Image = ((System.Drawing.Image)(resources1.GetObject("filledEllipseToolStripMenuItem.Image")));
        }

        private void FilledSquareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveSelectionRectangle();

            this.selectButton.BackColor = SystemColors.Control;
            selectedTool = "square";
            filled = true;
            this.toolSelectDropdownButton.Image = ((System.Drawing.Image)(resources1.GetObject("filledSquareToolStripMenuItem.Image")));
        }
        private void FilledRectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveSelectionRectangle();

            this.selectButton.BackColor = SystemColors.Control;
            selectedTool = "rectangle";
            filled = true;
            this.toolSelectDropdownButton.Image = ((System.Drawing.Image)(resources1.GetObject("rectangleToolStripMenuItem.Image")));
        }
        
        private void CollageButton_Click(object sender, EventArgs e)
        {
            RemoveSelectionRectangle();

            this.selectButton.BackColor = SystemColors.Control;
            CollageForm collageForm = new CollageForm();
            collageForm.Show();
        }
        #endregion tools

        #region rotate
        private Bitmap RotateBitmap(Bitmap bm, float angle)
        {
            Matrix rotate_at_origin = new Matrix();
            rotate_at_origin.Rotate(angle);

            //calculating how big final image should be
            PointF[] points =
            {
                new PointF(0, 0),
                new PointF(bm.Width, 0),
                new PointF(bm.Width, bm.Height),
                new PointF(0, bm.Height),
            };
            rotate_at_origin.TransformPoints(points);
            float xmin, xmax, ymin, ymax;
            GetPointBounds(points, out xmin, out xmax,
                out ymin, out ymax);

            int wid = (int)Math.Round(xmax - xmin);
            int hgt = (int)Math.Round(ymax - ymin);
            Bitmap result = new Bitmap(wid, hgt);

            Matrix rotate_at_center = new Matrix();
            rotate_at_center.RotateAt(angle,
            new PointF(wid / 2f, hgt / 2f));

            using (Graphics gr = Graphics.FromImage(result))
            {
                gr.InterpolationMode = InterpolationMode.High;
                gr.Clear(bm.GetPixel(0, 0));
                gr.Transform = rotate_at_center;
                int x = (wid - bm.Width) / 2;
                int y = (hgt - bm.Height) / 2;
                gr.DrawImage(bm, x, y);
            }
            return result;
        }

 
        private void GetPointBounds(PointF[] points, out float xmin, out float xmax,
            out float ymin, out float ymax)
        {
            xmin = points[0].X;
            xmax = xmin;
            ymin = points[0].Y;
            ymax = ymin;
            foreach (PointF point in points)
            {
                if (xmin > point.X) xmin = point.X;
                if (xmax < point.X) xmax = point.X;
                if (ymin > point.Y) ymin = point.Y;
                if (ymax < point.Y) ymax = point.Y;
            }
        }

        

        private void rotateButton_Click(object sender, EventArgs e)
        {
            RemoveSelectionRectangle();

            this.selectButton.BackColor = SystemColors.Control;
            float angle;
            string txt = this.degreesTextBox.Text;
            if(txt != "")
                angle = float.Parse(txt);
            else
                angle = 0.0f;

            pictureBox1.Image = RotateBitmap((Bitmap)pictureBox1.Image, angle);

            //saving to history
            Bitmap bmp2 = new Bitmap(pictureBox1.Image);
            Image img = bmp2;
            SaveToHistory(img, "Rotation for angle: " + angle);
        }

        #endregion rotate

        #region filters
        //applies the color matrix to copy of the image
        private static Bitmap ApplyColorMatrix(Image sourceImage, ColorMatrix colorMatrix)
        {
            Bitmap bmp32BppSource = GetArgbCopy(sourceImage);
            Bitmap bmp32BppDest = new Bitmap(bmp32BppSource.Width, bmp32BppSource.Height, PixelFormat.Format32bppArgb);

            using (Graphics graphics = Graphics.FromImage(bmp32BppDest))
            {
                ImageAttributes bmpAttributes = new ImageAttributes();
                bmpAttributes.SetColorMatrix(colorMatrix);

                graphics.DrawImage(bmp32BppSource, new Rectangle(0, 0, bmp32BppSource.Width, bmp32BppSource.Height),
                                    0, 0, bmp32BppSource.Width, bmp32BppSource.Height, GraphicsUnit.Pixel, bmpAttributes);

            }
            bmp32BppSource.Dispose();
            return bmp32BppDest;
        }

        //creates the argb copy of an image
        private static Bitmap GetArgbCopy(Image sourceImage)
        {
            Bitmap bmpNew = new Bitmap(sourceImage.Width, sourceImage.Height, PixelFormat.Format32bppArgb);
            using (Graphics graphics = Graphics.FromImage(bmpNew))
            {
                graphics.DrawImage(sourceImage, new Rectangle(0, 0, bmpNew.Width, bmpNew.Height), new Rectangle(0, 0, bmpNew.Width, bmpNew.Height), GraphicsUnit.Pixel);
                graphics.Flush();
            }
            return bmpNew;
        }

        private void transparency_Click(object sender, EventArgs e)
        {
            //we reduce the alpha component by 60%
            ColorMatrix colorMatrix = new ColorMatrix(new float[][]
                        {
                            new float[]{1, 0, 0, 0, 0},
                            new float[]{0, 1, 0, 0, 0},
                            new float[]{0, 0, 1, 0, 0},
                            new float[]{0, 0, 0, 0.4f, 0},
                            new float[]{0, 0, 0, 0, 1}
                        });
            pictureBox1.Image = ApplyColorMatrix(pictureBox1.Image, colorMatrix);
            SaveToHistory(pictureBox1.Image, "Transparency filter");

        }

        private void grayscale_Click(object sender, EventArgs e)
        {
            //The grayscale is achieved by using 11% blue, 59% green and 30% red
            ColorMatrix colorMatrix = new ColorMatrix(new float[][]
                        {
                            new float[]{.3f, .3f, .3f, 0, 0},
                            new float[]{.59f, .59f, .59f, 0, 0},
                            new float[]{.11f, .11f, .11f, 0, 0},
                            new float[]{0, 0, 0, 1, 0},
                            new float[]{0, 0, 0, 0, 1}
                        });

            pictureBox1.Image = ApplyColorMatrix(pictureBox1.Image, colorMatrix);
            SaveToHistory(pictureBox1.Image, "Grayscale filter");
        }

        private void sepia_Click(object sender, EventArgs e)
        {
            ColorMatrix colorMatrix = new ColorMatrix(new float[][] 
                {
                        new float[]{.393f, .349f, .272f, 0, 0},
                        new float[]{.769f, .686f, .534f, 0, 0},
                        new float[]{.189f, .168f, .131f, 0, 0},
                        new float[]{0, 0, 0, 1, 0},
                        new float[]{0, 0, 0, 0, 1}
                });

            pictureBox1.Image = ApplyColorMatrix(pictureBox1.Image, colorMatrix);
            SaveToHistory(pictureBox1.Image, "Sepia filter");
        }
        private void negative_Click(object sender, EventArgs e)
        {
            //Negative inverts the colors
            ColorMatrix colorMatrix = new ColorMatrix(new float[][] 
                    {
                            new float[]{-1, 0, 0, 0, 0},
                            new float[]{0, -1, 0, 0, 0},
                            new float[]{0, 0, -1, 0, 0},
                            new float[]{0, 0, 0, 1, 0},
                            new float[]{1, 1, 1, 1, 1}
                    });

            pictureBox1.Image = ApplyColorMatrix(pictureBox1.Image, colorMatrix);
            SaveToHistory(pictureBox1.Image, "Color negative filter");
        }
        #endregion filters

        #region history
        private void SaveToHistory(Image img, String desc)
        {
            //when we have less than max moves saved
            //we simply add the image and description
            //to the history
            if (historyCount < max)
            {
                historyImages.Add(img);
                historyMoves.Add(desc);
                historyCount++;
            }
            //otherwise, we reject the oldest entry
            else
            {
                historyImages.RemoveAt(0);
                historyMoves.RemoveAt(0);
                historyImages.Add(img);
                historyMoves.Add(desc);
            }
            //update the descriptions in the 
            //history drop down menu
            UpdateTags();
        }
        private Image GetFromHistory(int index)
        {           
            Image returnImg;
            //fetch the image and description
            returnImg = historyImages[index];   
            string tag = historyMoves[index];

            int k = index + 1;
            int historyCountCopy = historyCount;
            //discard the changes that happened after
            //retrieved move
            for (int i = index + 1; i < historyCount; ++i)
            {
                historyImages.RemoveAt(k);
                historyMoves.RemoveAt(k);
                historyCountCopy--;
            }
            historyCount = historyCountCopy;
            //update the descriptions in the 
            //history drop down menu
            UpdateTags();
            return returnImg;
        }

        private void UpdateTags()
        {
            
            ToolStripMenuItem[] historyMenuItems = {toolStripMenuItem2,toolStripMenuItem3,toolStripMenuItem4, 
                                                       toolStripMenuItem5, toolStripMenuItem6 };
            //the newest entry is current move
            historyMenuItems[0].Text = historyMoves[historyCount - 1] + " (current)";
            historyMenuItems[0].Visible = true;

            for (int i = 1; i < historyCount; i++)
            {
                historyMenuItems[i].Text = historyMoves[historyCount - i - 1];
                //items containing text are visible
                historyMenuItems[i].Visible = true;
            }
            for (int i = historyCount; i < 5; i++)
            {
                historyMenuItems[i].Visible = false;
            }
        }
   
        private void ToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            this.selectButton.BackColor = SystemColors.Control;
            int index = historyCount - 5;
            pictureBox1.Image = GetFromHistory(index); 
        }

        private void ToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            this.selectButton.BackColor = SystemColors.Control;
            int index = historyCount - 4;
            pictureBox1.Image = GetFromHistory(index); 
        }

        private void ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            this.selectButton.BackColor = SystemColors.Control;
            int index = historyCount - 3;
            pictureBox1.Image = GetFromHistory(index); 
        }

        private void ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.selectButton.BackColor = SystemColors.Control;
            int index = historyCount - 2;
            pictureBox1.Image = GetFromHistory(index); 
        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.selectButton.BackColor = SystemColors.Control;
            int index = historyCount - 1;
            pictureBox1.Image = GetFromHistory(index); 
        }

        #endregion history

        #region cutCopyPasteSelect
        private void CopyButton_Click(object sender, EventArgs e)
        {
            this.selectButton.BackColor = SystemColors.Control;
            Bitmap bm = new Bitmap(selection.Width, selection.Height);

            using (Graphics gr = Graphics.FromImage(bm))
            {

                Rectangle src_rect =
                    new Rectangle(selection.X + 1, selection.Y + 1, selection.Width - 1, selection.Height - 1);

                Rectangle dest_rect =
                    new Rectangle(0, 0, selection.Width + 1, selection.Height + 1);
                gr.DrawImage(pictureBox1.Image, dest_rect, src_rect,
                    GraphicsUnit.Pixel);


            }
            Clipboard.SetImage(bm);
            pictureBox1.Image = OriginalImage;
            pictureBox1.Refresh();
            this.cutButton.Enabled = false;
            this.copyButton.Enabled = false;
            selectedTool = "selectionTool";
            this.selectButton.BackColor = Color.LightGray;
        }

        private void CutButton_Click(object sender, EventArgs e)
        {
            this.selectButton.BackColor = SystemColors.Control;
            OriginalImage = new Bitmap(pictureBox1.Image);
            Bitmap bm = new Bitmap(selection.Width, selection.Height);

            using (Graphics gr = Graphics.FromImage(bm))
            {
                Rectangle dest_rect =
                    new Rectangle(0, 0, selection.Width, selection.Height);
                gr.DrawImage(pictureBox1.Image, dest_rect, selection,
                    GraphicsUnit.Pixel);
            }
            Clipboard.SetImage(bm);

            using (Graphics gr = Graphics.FromImage(OriginalImage))
            {
                using (SolidBrush br = new SolidBrush(backColor))
                {
                    Rectangle fillRect = new Rectangle(selection.X, selection.Y, selection.Width + 1, selection.Height + 1);
                    gr.FillRectangle(br, fillRect);
                }
            }

            SelectedImage = new Bitmap(OriginalImage);
            pictureBox1.Image = SelectedImage;

            SelectedImage = null;
            SelectedGraphics = null;
            
            this.cutButton.Enabled = false;
            this.copyButton.Enabled = false;
            selectedTool = "selectionTool";
            this.selectButton.BackColor = Color.LightGray;
        }

        private void PasteButton_Click(object sender, EventArgs e)
        {
            this.selectButton.BackColor = SystemColors.Control;
            // Do nothing if the clipboard doesn't hold an image.
            if (!Clipboard.ContainsImage()) return;

            // Get the clipboard's image.
            Image clipboard_image = Clipboard.GetImage();

            // Figure out where to put it.
            int cx = selection.X +
                (selection.Width - clipboard_image.Width) / 2;
            int cy = selection.Y +
                (selection.Height - clipboard_image.Height) / 2;
            Rectangle dest_rect = new Rectangle(
                cx, cy,
                clipboard_image.Width,
                clipboard_image.Height);

            using (Graphics gr = Graphics.FromImage(OriginalImage))
            {
                gr.DrawImage(clipboard_image, dest_rect);
            }

            pictureBox1.Image = OriginalImage;
            pictureBox1.Refresh();

            SelectedImage = null;
            SelectedGraphics = null;
            selectionRectangleSet = false;
        }
        private void SelectButton_Click(object sender, EventArgs e)
        {
            selectedTool = "selectionTool";
            this.selectButton.BackColor = Color.LightGray;
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //copy from selection
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.C)
            {
                if(!copyButton.Enabled)
                    SystemSounds.Beep.Play();
                else
                    CopyButton_Click(sender, e);
                return;
            }
            //cut from selection
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.X)
            {
                if(!cutButton.Enabled)
                    SystemSounds.Beep.Play();
                else
                    CutButton_Click(sender, e);
                return;
            }
            //paste to selection
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.V)
            {
                if(!pasteButton.Enabled)
                    SystemSounds.Beep.Play();
                else
                    PasteButton_Click(sender, e);
                return;
            }
        }
        //Removes the red dashed selection triangle from the picture
        private void RemoveSelectionRectangle()
        {
            if(cutButton.Enabled || copyButton.Enabled || pasteButton.Enabled)
                pictureBox1.Image = beforeSelection;
            
        }
        #endregion cutCopyPasteSelect

        #region lineThickness
        private void Px1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.selectButton.BackColor = SystemColors.Control;
            thickness = 1;
            px5ToolStripMenuItem.Checked = false;
            px10ToolStripMenuItem.Checked = false;
            px15ToolStripMenuItem.Checked = false;
        }

        private void Px5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.selectButton.BackColor = SystemColors.Control;
            thickness = 5;
            px1ToolStripMenuItem.Checked = false;
            px10ToolStripMenuItem.Checked = false;
            px15ToolStripMenuItem.Checked = false;
        }
        private void Px10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.selectButton.BackColor = SystemColors.Control;
            thickness = 10;
            px1ToolStripMenuItem.Checked = false;
            px5ToolStripMenuItem.Checked = false;
            px15ToolStripMenuItem.Checked = false;
        }

        private void Px15ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.selectButton.BackColor = SystemColors.Control;
            thickness = 15;
            px1ToolStripMenuItem.Checked = false;
            px5ToolStripMenuItem.Checked = false;
            px10ToolStripMenuItem.Checked = false;
        }
        #endregion lineThickness

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(currentColor, thickness);
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(currentColor);
            if (selectedTool == "square" || selectedTool == "rectangle")
            {
                if (finalPaint)
                {
                    Graphics g = Graphics.FromImage(pictureBox1.Image);
                    if (filled)
                        g.FillRectangle(myBrush, r);
                    else
                        g.DrawRectangle(pen, r);
                }
                else if(drawing)
                    if (filled)
                        e.Graphics.FillRectangle(myBrush, r);
                    else
                        e.Graphics.DrawRectangle(pen, r);
                finalPaint = false;
                pictureBox1.Invalidate();
            }
            if (selectedTool == "ellipse" || selectedTool == "circle")
            {
                if (finalPaint)
                {
                    Graphics g = Graphics.FromImage(pictureBox1.Image);
                    if (filled)
                        g.FillEllipse(myBrush, r);
                    else
                        g.DrawEllipse(pen, r);
                }
                else if(drawing)
                    if (filled)
                        e.Graphics.FillEllipse(myBrush, r);
                    else
                        e.Graphics.DrawEllipse(pen, r);
                finalPaint = false;
                pictureBox1.Invalidate();
            }
            if (selectedTool == "line")
            {
                if (finalPaint)
                {
                    Graphics g = Graphics.FromImage(pictureBox1.Image);
                    g.DrawLine(pen, (System.Drawing.PointF)initial, (System.Drawing.PointF)current);
                }
                else if(drawing)
                    e.Graphics.DrawLine(pen, (System.Drawing.PointF)initial, (System.Drawing.PointF)current);
                finalPaint = false;
                pictureBox1.Invalidate();
            }
            
                
        }

        
    }
}
