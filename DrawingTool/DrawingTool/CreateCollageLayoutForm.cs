using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingTool
{
    public partial class CreateCollageLayoutForm : Form
    {
       
        Point startPos; 
        Point currentPos;
        bool drawing;
        List<Rectangle> rectangles = new List<Rectangle>();
        List<Tuple<int, int, int, int>> positions = new List<Tuple<int, int, int, int>>();
        String imgName = "";
        public CreateCollageLayoutForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        //open the background image for the new layout
        private void openImageButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.InitialDirectory = "c:\\";
            dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            dialog.FilterIndex = 2;
            dialog.RestoreDirectory = true;
            dialog.Multiselect = false;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                String currentImagePath = dialog.FileName;
                imgName = dialog.SafeFileName;
                this.pictureBox1.Image = Image.FromFile(currentImagePath);
                this.saveLayoutButton.Enabled = true;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            currentPos = startPos = e.Location;
            drawing = true;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            currentPos = e.Location;
            if (drawing) pictureBox1.Invalidate();

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (drawing)
            {
                drawing = false;
                var rc = getRectangle();
                if (rc.Width > 0 && rc.Height > 0) rectangles.Add(rc);
                pictureBox1.Invalidate();
                positions.Add(new Tuple<int,int,int,int>(startPos.X, startPos.Y, currentPos.X, currentPos.Y));
            }

        }
        private Rectangle getRectangle()
        {
            return new Rectangle(
                Math.Min(startPos.X, currentPos.X),
                Math.Min(startPos.Y, currentPos.Y),
                Math.Abs(startPos.X - currentPos.X),
                Math.Abs(startPos.Y - currentPos.Y));
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

                if (rectangles.Count > 0)
                {
                    if (pictureBox1.Image != null)
                    {
                        Graphics g = Graphics.FromImage(pictureBox1.Image);
                        g.DrawRectangles(Pens.Black, rectangles.ToArray());
                    }
                    e.Graphics.DrawRectangles(Pens.Black, rectangles.ToArray());
                } 
                if (drawing) e.Graphics.DrawRectangle(Pens.Red, getRectangle());

        }

        private void saveLayoutButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String name = saveFileDialog1.FileName;
                string extension = System.IO.Path.GetExtension(name);
                string locPath = name.Substring(0, name.Length - extension.Length)+"Locations.txt";
       
                int size = positions.Count;
                //save the background image
                pictureBox1.Image.Save(name);
                //save the locations of collage images
                if (!File.Exists(locPath))
                {
                    // Create a file to write to.
                    using (StreamWriter sw = File.CreateText(locPath))
                    {
                        sw.WriteLine(size);
                        foreach (Tuple<int, int, int, int> t in positions)
                        {
                            sw.WriteLine(t.Item1 + "," + t.Item2 + "," + t.Item3 + "," + t.Item4);
                        }
                        
                    }
                }
            }
        }
    }
}
