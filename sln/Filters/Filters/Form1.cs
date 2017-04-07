using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Filters
{
    public partial class Filters : Form
    {
        Bitmap image;
        Stack<Bitmap> oldMap;

        public Filters()
        {
            oldMap = new Stack<Bitmap>();
            InitializeComponent();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Bitmap newImage = ((Filter)e.Argument).processImage(image, backgroundWorker1);
            if (backgroundWorker1.CancellationPending != true)
            {
                oldMap.Push(image);
                image = newImage;
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            pictureBox1.Image = image;
            pictureBox1.Refresh();
            progressBar1.Value = 0;
        }
        
        //point filters
        private void инверсияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvertFilter filter = new InvertFilter();
            backgroundWorker1.RunWorkerAsync(filter);
            /*Bitmap resultImage = filter.processImage(image, backgroundWorker1);
            pictureBox1.Image = resultImage;
            pictureBox1.Refresh();*/
        }

        private void черныйбелыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new GrayScaleFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void сепияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new SepiaFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void яркостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new IntensFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void стеклоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new Glass();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void волныToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new Wave();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        //matrix filters
        private void размытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new BlurFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void фильтрГауссаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new GaussianFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void фильтрСобеляToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new SobelFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void резкостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new Sharp();
            backgroundWorker1.RunWorkerAsync(filter);
        }
       
        private void медианныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new MedianFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }
        
        //file operations
        private void отменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (oldMap.Count != 0)
            {
                pictureBox1.Image = oldMap.Peek();
                image = oldMap.Pop();
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            save.Title = "Сохранить изображение";
            save.ShowDialog();

            if (save.FileName != "")
            {
                System.IO.FileStream fileStream = (System.IO.FileStream)save.OpenFile();
                this.pictureBox1.Image.Save(fileStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                fileStream.Close();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files | *.png; *.jpg; *.bmp | All Files (*.*) | *.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(dialog.FileName);
            }

            pictureBox1.Image = image;
            pictureBox1.Refresh();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        //mat morfology
        private void эрозияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new ErosionMask();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void расширениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new DilationMask();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void замыканиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter1 = new DilationMask();
            Filter filter2 = new ErosionMask();
            //Bitmap resultImage = filter1.processImage(image);
            //backgroundWorker1.RunWorkerAsync(filter2);

            oldMap.Push(image);
            Bitmap result = filter1.processImage(image);
            result = filter2.processImage(result);
            pictureBox1.Image = result;
            pictureBox1.Refresh();
        }

        private void размыканиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter1 = new ErosionMask();
            Filter filter2 = new DilationMask();
            //Bitmap resultImage = filter1.processImage(image);
            //backgroundWorker1.RunWorkerAsync(filter2);

            oldMap.Push(image);
            Bitmap result = filter1.processImage(image);
            result = filter2.processImage(result);
            pictureBox1.Image = result;
            pictureBox1.Refresh();
        }

    }
}
