using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editor_Imágenes
{


    public partial class Form1 : Form
    {
        Bitmap bmp;
        string imagen = null;
        bool isFile = false;
        bool fileSaved = false;


        public Form1()
        {
            InitializeComponent();

        }


        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            d.Filter = "Imágenes (*.jpg)|*.jpg|Imágenes (*.png)|*.png";
            DialogResult r = d.ShowDialog();
            if(r == DialogResult.OK)
            {
                bmp = (Bitmap)Image.FromFile(d.FileName);
                imagen = d.FileName;
                pictureBox.Image = bmp;
                isFile = true;
            }

        }

        private void guardar()
        {
            if(isFile)
            {
                SaveFileDialog d = new SaveFileDialog();
                d.Filter = "Imágenes (*.jpg)|*.jpg|Imágenes (*.png)|*.png";
                DialogResult r = d.ShowDialog();
                if(r == DialogResult.OK)
                {
                    bmp.Save(d.FileName);
                    fileSaved = true;
                }
            }
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            guardar();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {   
            if(!fileSaved && isFile)
            {
                DialogResult r = MessageBox.Show("Salir sin guardar","Cerrar",MessageBoxButtons.YesNo);
                if(r == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else if(r == DialogResult.No)
                {
                    guardar();
                }
            }
        }

        private void negativoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bmp = (Bitmap)Image.FromFile(imagen);
            for (int h = 0; h < bmp.Height; h++)
            {
                for(int w = 0; w < bmp.Width; w++)
                {
                    Color c = bmp.GetPixel(w, h);
                    Color n = Color.FromArgb(c.A, 255-c.R, 255-c.G, 255-c.B);
                    bmp.SetPixel(w, h, n);
                }
            }
            pictureBox.Image = bmp;
            fileSaved = false;
        }

        private void blancoYNegroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int avg;
            bmp = (Bitmap)Image.FromFile(imagen);
            for (int h = 0; h < bmp.Height; h++)
            {
                for (int w = 0; w < bmp.Width; w++)
                {
                    Color c = bmp.GetPixel(w, h);
                    avg = (c.R + c.G + c.B) / 3;
                    Color n;
                    if(avg>=127)
                    {
                        n = Color.Black;
                    }
                    else
                    {
                        n = Color.White;
                    }
                    bmp.SetPixel(w, h, n);
                }
            }
            pictureBox.Image = bmp;
            fileSaved = false;
        }

        private void grisesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int avg;
            bmp = (Bitmap)Image.FromFile(imagen);
            for (int h = 0; h < bmp.Height; h++)
            {
                for (int w = 0; w < bmp.Width; w++)
                {
                    Color c = bmp.GetPixel(w, h);
                    avg = (c.R + c.G + c.B) / 3;
                    Color n = Color.FromArgb(c.A, avg, avg, avg);
                    bmp.SetPixel(w, h, n);
                }
            }
            pictureBox.Image = bmp;
            fileSaved = false;
        }

        private void sepíaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int tr, tg, tb;
            int r, g, b;
            bmp = (Bitmap)Image.FromFile(imagen);
            for (int h = 0; h < bmp.Height; h++)
            {
                for (int w = 0; w < bmp.Width; w++)
                {
                    Color c = bmp.GetPixel(w, h);
                    r = c.R;
                    g = c.G;
                    b = c.B;
                    tr = (int)(0.393 * c.R + 0.769 * c.G + 0.189 * c.B);
                    tg = (int)(0.349 * c.R + 0.686 * c.G + 0.168 * c.B);
                    tb = (int)(0.272 * c.R + 0.534 * c.G + 0.131 * c.B);
                    if(tr > 255)
                    {
                        r = 255;
                    }
                    else
                    {
                        r = tr;
                    }
                    if (tg > 255)
                    {
                        g = 255;
                    }
                    else
                    {
                        r = tg;
                    }
                    if (tb > 255)
                    {
                        b = 255;
                    }
                    else
                    {
                        r = tb;
                    }
                    Color n = Color.FromArgb(c.A, r, g, b);
                    bmp.SetPixel(w, h, n);
                }
            }
            pictureBox.Image = bmp;
            fileSaved = false;

        }
    }
}
