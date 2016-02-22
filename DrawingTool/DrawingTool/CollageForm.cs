using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingTool
{
    
    public partial class CollageForm : Form
    {
        List<Image> imagesToInsert = new List<Image>();
        //each tuple contains the coordinates where the images will be inserted
        // (x1,y1,x2,y2)
        // x1,y1 is the position of upper left corner
        // x2,y2 is the position of lower right corner
        List<Tuple<int, int, int, int>> positions = new List<Tuple<int, int, int, int>>();
        
        int numOfImages = 0;

        public CollageForm()
        {
            InitializeComponent();
        }

        private void loadLayoutButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                String[] paths = dialog.FileNames;
                String currentImagePath = "";
                Boolean imageLoaded = false;
                Boolean positionsLoaded = false;
                bool validTxtFile = true;
                foreach (String path in paths)
                {
                    if (path.EndsWith(".txt"))
                    {
                        loadImagesButton.Enabled = true;
                        using (StreamReader sr = File.OpenText(path))
                        {
                            string s = "";
                            while ((s = sr.ReadLine()) != null)
                            {
                                if (numOfImages == 0)
                                {
                                    validTxtFile = validTxtFile && Int32.TryParse(s, out numOfImages);
                                    numOfImages = Int32.Parse(s);
                                }
                                else
                                {
                                    char[] delimiterChars = { ' ', ',' };
                                    string[] strCoords = s.Split(delimiterChars);
                                    int x1 = 0, y1 = 0, x2 = 0, y2 = 0;
                                    validTxtFile = validTxtFile && Int32.TryParse(strCoords[0], out x1);
                                    validTxtFile = validTxtFile && Int32.TryParse(strCoords[1], out y1);
                                    validTxtFile = validTxtFile && Int32.TryParse(strCoords[2], out x2);
                                    validTxtFile = validTxtFile && Int32.TryParse(strCoords[3], out y2);
                                    positions.Add(new Tuple<int, int, int, int>(x1,y1,x2,y2));
                                }
                            }
                        }
                        positionsLoaded = true;
                    }
                    if (path.EndsWith(".png") || path.EndsWith(".jpg") || path.EndsWith(".gif"))
                    {
                        currentImagePath = path;
                        this.pictureBox1.Image = Image.FromFile(currentImagePath);
                        saveAsButton.Enabled = true;
                        closeButton.Enabled = true;
                        imageLoaded = true;
                    }
                }
                if (!imageLoaded || !positionsLoaded)
                {
                    String errMessage = "";
                    if (!imageLoaded)
                        errMessage += "Background image not loaded. Select an image for background.\n";
                    if (!positionsLoaded || !validTxtFile)
                        errMessage += "Positions not loaded. Select a valid .txt file with positions.\n";
                    MessageBox.Show(errMessage, "Form layout loading error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                    this.pictureBox1.Image = null;
                    this.positions = new List<Tuple<int, int, int, int>>();
                    saveAsButton.Enabled = false;
                    closeButton.Enabled = false;
                }
                
            }
        }

        private void createLayoutButton_Click(object sender, EventArgs e)
        {
            CreateCollageLayoutForm cclf = new CreateCollageLayoutForm();
            cclf.Show();
        }

        private void loadImagesButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            dialog.FilterIndex = 2;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                String[] filenames = dialog.FileNames;
                if (filenames.Length == numOfImages)
                {
                    int i = 0;
                    foreach (String filename in filenames)
                    {
                        Image img_ = Image.FromFile(filename);
                        int width = positions[i].Item3 - positions[i].Item1;
                        int height = positions[i].Item4 - positions[i].Item2;
                        Console.WriteLine("w:" + width + ", h" + height);
                        Rectangle destRect = new Rectangle(positions[i].Item1, positions[i].Item2, width+1, height+1);
                        
                        Graphics g = Graphics.FromImage(pictureBox1.Image);
                        g.DrawImage(img_, destRect);
                        pictureBox1.Invalidate();
                        i++;
                    }
                }
            }
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;
            Console.WriteLine("x: " + x + "y: " + y);
            foreach (Tuple<int, int, int, int> t in positions)
            {
                //if we clicket within bounds of a rectangle to contain image
                //open the openFileDialog
                if (t.Item1 <= x && x <= t.Item3 &&
                   t.Item2 <= y && y <= t.Item4)
                {
                    OpenFileDialog dialog = new OpenFileDialog();
                    dialog.Multiselect = false;
                    dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                    dialog.FilterIndex = 2;
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        String filename = dialog.FileName;
                        Image img_ = Image.FromFile(filename);
                        int width = t.Item3 - t.Item1;
                        int height = t.Item4 - t.Item2;

                        //load the selected image
                        Rectangle destRect = new Rectangle(t.Item1, t.Item2, width + 1, height + 1);
                        Graphics g = Graphics.FromImage(pictureBox1.Image);
                        g.DrawImage(img_, destRect);
                        pictureBox1.Invalidate();
                        break;
                    }
                }
            }
        }

        private void smilePresetButton_Click(object sender, EventArgs e)
        {
            Image img = DrawingTool.Properties.Resources.smileLayout;
            pictureBox1.Image = img;
            String fileContent = DrawingTool.Properties.Resources.smileLayoutLocations;
            //load the positions for images
            using (var reader = new StringReader(fileContent))
            {
                string s = "";
                while ((s = reader.ReadLine()) != null)
                {
                    if (numOfImages == 0)
                    {
                        numOfImages = Int32.Parse(s);
                    }
                    else
                    {
                        char[] delimiterChars = { ' ', ',' };
                        string[] strCoords = s.Split(delimiterChars);
                        int x1 = Int32.Parse(strCoords[0]);
                        int y1 = Int32.Parse(strCoords[1]);
                        int x2 = Int32.Parse(strCoords[2]);
                        int y2 = Int32.Parse(strCoords[3]);
                        positions.Add(new Tuple<int, int, int, int>(x1, y1, x2, y2));
                    }
                }
            }
            saveAsButton.Enabled = true;
            loadImagesButton.Enabled = true;
        }

        private void notebookPresetButton_Click(object sender, EventArgs e)
        {
            Image img = DrawingTool.Properties.Resources.mathLayout;
            pictureBox1.Image = img;
            String fileContent = DrawingTool.Properties.Resources.mathLayoutLocations;
            //load the positions for images
            using (var reader = new StringReader(fileContent))
            {
                string s = "";
                while ((s = reader.ReadLine()) != null)
                {
                    if (numOfImages == 0)
                    {
                        numOfImages = Int32.Parse(s);
                    }
                    else
                    {
                        char[] delimiterChars = { ' ', ',' };
                        string[] strCoords = s.Split(delimiterChars);
                        int x1 = Int32.Parse(strCoords[0]);
                        int y1 = Int32.Parse(strCoords[1]);
                        int x2 = Int32.Parse(strCoords[2]);
                        int y2 = Int32.Parse(strCoords[3]);
                        positions.Add(new Tuple<int, int, int, int>(x1, y1, x2, y2));
                    }
                }
            }
            saveAsButton.Enabled = true;
            loadImagesButton.Enabled = true;
        }

        private void moviePresetButton_Click(object sender, EventArgs e)
        {
            Image img = DrawingTool.Properties.Resources.tapeReelLayout;
            pictureBox1.Image = img;
            String fileContent = DrawingTool.Properties.Resources.tapeReelLayoutLocations;
            //load the positions for images
            using (var reader = new StringReader(fileContent))
            {
                string s = "";
                while ((s = reader.ReadLine()) != null)
                {
                    if (numOfImages == 0)
                    {
                        numOfImages = Int32.Parse(s);
                    }
                    else
                    {
                        char[] delimiterChars = { ' ', ',' };
                        string[] strCoords = s.Split(delimiterChars);
                        int x1 = Int32.Parse(strCoords[0]);
                        int y1 = Int32.Parse(strCoords[1]);
                        int x2 = Int32.Parse(strCoords[2]);
                        int y2 = Int32.Parse(strCoords[3]);
                        positions.Add(new Tuple<int, int, int, int>(x1, y1, x2, y2));
                    }
                }
            }
            saveAsButton.Enabled = true;
            loadImagesButton.Enabled = true;
        }

        private void heartsPresetButton_Click(object sender, EventArgs e)
        {
            Image img = DrawingTool.Properties.Resources.heartsLayout;
            pictureBox1.Image = img;
            String fileContent = DrawingTool.Properties.Resources.heartsLayoutLocations;
            //load the positions for images
            using (var reader = new StringReader(fileContent))
            {
                string s = "";
                while ((s = reader.ReadLine()) != null)
                {
                    if (numOfImages == 0)
                    {
                        numOfImages = Int32.Parse(s);
                    }
                    else
                    {
                        char[] delimiterChars = { ' ', ',' };
                        string[] strCoords = s.Split(delimiterChars);
                        int x1 = Int32.Parse(strCoords[0]);
                        int y1 = Int32.Parse(strCoords[1]);
                        int x2 = Int32.Parse(strCoords[2]);
                        int y2 = Int32.Parse(strCoords[3]);
                        positions.Add(new Tuple<int, int, int, int>(x1, y1, x2, y2));
                    }
                }
            }
            saveAsButton.Enabled = true;
            loadImagesButton.Enabled = true;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            //reset the variables
            pictureBox1.Image = null;
            positions = new List<Tuple<int, int, int, int>>();
            numOfImages = 0;
            //disable the buttons
            saveAsButton.Enabled = false;
            loadImagesButton.Enabled = false;
        }
    }
}
