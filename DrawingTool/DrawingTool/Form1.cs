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

namespace DrawingTool
{
    public partial class Form1 : Form
    {
        String currentImagePath = "";
        Color currentColor = System.Drawing.ColorTranslator.FromHtml("#000000");
        String selectedTool = "pencil";
        bool filled = false;
        private Point? _Previous = null;
        private Point? _Initial = null;
        //for history
        List<Image> historyImages = new List<Image>();
        List<String> historyMoves = new List<String>();
        int historyCount = 0;
        readonly int max = 5;
        
        
        

        
        public Form1()
        {
            InitializeComponent();
            
        }

       
        private void openImageButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = "c:\\";
            dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            dialog.FilterIndex = 2;
            dialog.RestoreDirectory = true;
            dialog.Multiselect = false;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                currentImagePath = dialog.FileName;
                this.pictureBox1.Image = Image.FromFile(currentImagePath);
                Bitmap bmp2 = new Bitmap(pictureBox1.Image);
                Image img = bmp2;
                saveToHistory(img, "New image from file: " + dialog.SafeFileName);
            }
        }
        
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            _Previous = e.Location;
            _Initial = e.Location;
            pictureBox1_MouseMove(sender, e);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_Previous != null && selectedTool == "pencil")
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
                    Pen myPen = new Pen(currentColor);
                    g.DrawLine(myPen, _Previous.Value, e.Location); //Pens.Black
                }
                pictureBox1.Invalidate();
                _Previous = e.Location;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            _Previous = null;
            Pen myPen = new Pen(currentColor);
            Point? current = e.Location;
            if (selectedTool == "pencil")
            {
                Bitmap bmp2 = new Bitmap(pictureBox1.Image);
                Image img = bmp2;
                saveToHistory(img, "New pencil drawing");
                
            }
                
            if (selectedTool == "square")
            {
                int _x = _Initial.Value.X;
                int _y = _Initial.Value.Y;
                int height = current.Value.Y- _Initial.Value.Y;
                int width = current.Value.X - _Initial.Value.X; 

                Rectangle ee = new Rectangle(_x,_y , Math.Abs(width), Math.Abs(height));
                
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
                    if (filled)
                    {
                        System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(currentColor);
                        g.FillRectangle(myBrush, new Rectangle(_x, _y, width, height));
                    }
                    else
                        g.DrawRectangle(myPen, ee);
                                
                }
                pictureBox1.Invalidate();
                Bitmap bmp2 = new Bitmap(pictureBox1.Image);
                Image img = bmp2;
                if(filled)
                    saveToHistory(img, "New filled rectangle");
                else
                    saveToHistory(img, "New rectangle");
                
            }
            if (selectedTool == "line")
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
                    g.DrawLine(myPen, (System.Drawing.PointF)_Initial, (System.Drawing.PointF)current);

                }
                pictureBox1.Invalidate();
                Bitmap bmp2 = new Bitmap(pictureBox1.Image);
                Image img = bmp2;
                saveToHistory(img, "New line");
                
            }
            if (selectedTool == "circle")
            {
                int _x = _Initial.Value.X;
                int _y = _Initial.Value.Y;
                int radius = current.Value.Y - _Initial.Value.Y;
                
 
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
                    if(filled){
                        System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(currentColor);
                        g.FillEllipse(myBrush, new Rectangle(_x, _y, radius * 2, radius * 2));                      
                    }
                    else  
                        g.DrawEllipse(myPen, _x, _y, radius * 2, radius * 2);
                    
                        
                }
                pictureBox1.Invalidate();
                Bitmap bmp2 = new Bitmap(pictureBox1.Image);
                Image img = bmp2;
                if(filled)
                    saveToHistory(img, "New filled circle");
                else
                    saveToHistory(img, "New circle");
                
            }
            if (selectedTool == "ellipse")
            {
                int _x = _Initial.Value.X;
                int _y = _Initial.Value.Y;
                int height = current.Value.Y - _Initial.Value.Y;
                int width = current.Value.X - _Initial.Value.X; 

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
                    if (filled)
                    {
                        System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(currentColor);
                        g.FillEllipse(myBrush, new Rectangle(_x, _y, width, height));
                    }
                    else
                        g.DrawEllipse(myPen, _x, _y, width, height);
                }
                pictureBox1.Invalidate();
                Bitmap bmp2 = new Bitmap(pictureBox1.Image);
                Image img = bmp2;
                if (filled)
                    saveToHistory(img, "New filled ellipse");
                else
                    saveToHistory(img, "New ellipse");

            }
        }

        
        private void colorPickerButton_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.ShowHelp = true;
            MyDialog.Color = currentColor;

            if (MyDialog.ShowDialog() == DialogResult.OK)
                currentColor = MyDialog.Color;
            this.currentColorButton.BackColor = currentColor;
        }

        
        private void saveButton_Click(object sender, EventArgs e)
        {
            if(currentImagePath!="")
                pictureBox1.Image.Save(currentImagePath);
        }

        private void pencilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedTool = "pencil";
            filled = false;
            this.toolSelectDropdownButton.Image = ((System.Drawing.Image)(resources1.GetObject("pencilToolStripMenuItem.Image")));
        }

        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedTool = "line";
            filled = false;
            this.toolSelectDropdownButton.Image = ((System.Drawing.Image)(resources1.GetObject("lineToolStripMenuItem.Image")));
        }

        private void circleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedTool = "circle";
            filled = false;
            this.toolSelectDropdownButton.Image = ((System.Drawing.Image)(resources1.GetObject("circleToolStripMenuItem.Image")));
        }

        private void ellipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedTool = "ellipse";
            filled = false;
            this.toolSelectDropdownButton.Image = ((System.Drawing.Image)(resources1.GetObject("ellipseToolStripMenuItem.Imagee")));
        }

        private void squareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedTool = "square";
            filled = false;
            this.toolSelectDropdownButton.Image = ((System.Drawing.Image)(resources1.GetObject("squareToolStripMenuItem.Image")));
        }

        private Bitmap RotateBitmap(Bitmap bm, float angle)
        {
            Matrix rotate_at_origin = new Matrix();
            rotate_at_origin.Rotate(angle);

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

 
        private void GetPointBounds(PointF[] points,
            out float xmin, out float xmax,
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

        private void filledCircleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedTool = "circle";
            filled = true;
            this.toolSelectDropdownButton.Image = ((System.Drawing.Image)(resources1.GetObject("filledCircleToolStripMenuItem.Image")));
        }

        private void filledEllipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedTool = "ellipse";
            filled = true;
            this.toolSelectDropdownButton.Image = ((System.Drawing.Image)(resources1.GetObject("filledEllipseToolStripMenuItem.Image")));
        }

        private void filledSquareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedTool = "square";
            filled = true;
            this.toolSelectDropdownButton.Image = ((System.Drawing.Image)(resources1.GetObject("filledSquareToolStripMenuItem.Image")));
        }

        private void rotateButton_Click(object sender, EventArgs e)
        {
            float angle;
            string txt = this.degreesTextBox.Text;
            if(txt != "")
                angle = float.Parse(txt);
            else
                angle = 0.0f;
            //angle = 90.0f;
            if (pictureBox1.Image == null)
            {
                Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.White);
                }
                pictureBox1.Image = bmp;
            }

            pictureBox1.Image = RotateBitmap((Bitmap)pictureBox1.Image, angle);
            Bitmap bmp2 = new Bitmap(pictureBox1.Image);
            Image img = bmp2;
            saveToHistory(img, "Rotation for angle: " + angle);
        }

        private void newEmptyImage_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
            }
            pictureBox1.Image = bmp;
            Bitmap bmp2 = new Bitmap(pictureBox1.Image);
            Image img = bmp2;
            saveToHistory(bmp2, "New empty image");
        }

        private void saveAsButton_Click(object sender, EventArgs e)
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
            ColorMatrix colorMatrix = new ColorMatrix(new float[][]
                        {
                            new float[]{1, 0, 0, 0, 0},
                            new float[]{0, 1, 0, 0, 0},
                            new float[]{0, 0, 1, 0, 0},
                            new float[]{0, 0, 0, 0.3f, 0},
                            new float[]{0, 0, 0, 0, 1}
                        });
            pictureBox1.Image = ApplyColorMatrix(pictureBox1.Image, colorMatrix);
            saveToHistory(pictureBox1.Image, "Transparency filter");

        }

        private void grayscale_Click(object sender, EventArgs e)
        {
            ColorMatrix colorMatrix = new ColorMatrix(new float[][]
                        {
                            new float[]{.3f, .3f, .3f, 0, 0},
                            new float[]{.59f, .59f, .59f, 0, 0},
                            new float[]{.11f, .11f, .11f, 0, 0},
                            new float[]{0, 0, 0, 1, 0},
                            new float[]{0, 0, 0, 0, 1}
                        });

            pictureBox1.Image = ApplyColorMatrix(pictureBox1.Image, colorMatrix);
            saveToHistory(pictureBox1.Image, "Grayscale filter");
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
            saveToHistory(pictureBox1.Image, "Sepia filter");
        }
        private void negative_Click(object sender, EventArgs e)
        {
            ColorMatrix colorMatrix = new ColorMatrix(new float[][] 
                    {
                            new float[]{-1, 0, 0, 0, 0},
                            new float[]{0, -1, 0, 0, 0},
                            new float[]{0, 0, -1, 0, 0},
                            new float[]{0, 0, 0, 1, 0},
                            new float[]{1, 1, 1, 1, 1}
                    });

            pictureBox1.Image = ApplyColorMatrix(pictureBox1.Image, colorMatrix);
            saveToHistory(pictureBox1.Image, "Color negative filter");
        }

        private void saveToHistory(Image img, String desc)
        {
            if (historyCount < max)
            {
                historyImages.Add(img);
                historyMoves.Add(desc);
                historyCount++;
            }
            else
            {
                historyImages.RemoveAt(0);
                historyMoves.RemoveAt(0);
                historyImages.Add(img);
                historyMoves.Add(desc);
            }
            updateTags();
        }
        private Image getFromHistory(int index)
        {           
            Image returnImg;
            returnImg = historyImages[index];   
            string tag = historyMoves[index];
            int k = index + 1;
            int historyCountCopy = historyCount;
            for (int i = index + 1; i < historyCount; ++i)
            {
                historyImages.RemoveAt(k);
                historyMoves.RemoveAt(k);
                historyCountCopy--;
            }
            historyCount = historyCountCopy;
            updateTags();
            return returnImg;
        }
        private void updateTags()
        {
            
            ToolStripMenuItem[] historyMenuItems = {toolStripMenuItem2,toolStripMenuItem3,toolStripMenuItem4, 
                                                       toolStripMenuItem5, toolStripMenuItem6 };
            historyMenuItems[0].Text = historyMoves[historyCount - 1] + " (current)";
            historyMenuItems[0].Visible = true;

            for (int i = 1; i < historyCount; i++)
            {
                historyMenuItems[i].Text = historyMoves[historyCount - i - 1];
                historyMenuItems[i].Visible = true;
            }
            for (int i = historyCount; i < 5; i++)
            {
                historyMenuItems[i].Visible = false;
            }
        }
   
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            int index = historyCount - 5;
            pictureBox1.Image = getFromHistory(index); 
            

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            int index = historyCount - 4;
            pictureBox1.Image = getFromHistory(index); 
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            int index = historyCount - 3;
            pictureBox1.Image = getFromHistory(index); 
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            int index = historyCount - 2;
            pictureBox1.Image = getFromHistory(index); 
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int index = historyCount - 1;
            pictureBox1.Image = getFromHistory(index); 
        }

        private void closeFileButton_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            currentImagePath = "";
        }

        private void collageButton_Click(object sender, EventArgs e)
        {
            CollageForm collageForm = new CollageForm();
            collageForm.Show();
        }
    }

}
