using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace photoAddIn
{
    public partial class MyUserControl : UserControl
    {
        static photo[] fotoku;
        static int nofoto,jmlfoto;
        public MyUserControl()
        {
            InitializeComponent();
        }

        private void MyUserControl_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter ="Images (*.BMP;*.JPG)|*.BMP;*.JPG";
            ofd.Multiselect = true;
            DialogResult dr = ofd.ShowDialog();
            fotoku = new photo[ofd.FileNames.Length];
            jmlfoto = ofd.FileNames.Length;
            int ptrfotoku = 0;
            if (dr == DialogResult.OK) 
            {
                foreach (string filenya in ofd.FileNames) 
                {
                    Image loaded = Image.FromFile(filenya);
                    fotoku[ptrfotoku]=new photo(loaded.Width,loaded.Height,ofd.FileName,loaded);
                    ptrfotoku++;
                }
                pictureBox1.Width = fotoku[0].width;
                pictureBox1.Height = fotoku[0].height;
                pictureBox1.Image = fotoku[0].gambar;
                nofoto = 0;
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (nofoto == 0) 
            {
                pictureBox1.Width = fotoku[jmlfoto-1].width;
                pictureBox1.Height = fotoku[jmlfoto-1].height;
                pictureBox1.Image = fotoku[jmlfoto-1].gambar;
                nofoto = jmlfoto - 1;
            }
            else
            {
                pictureBox1.Width = fotoku[nofoto - 1].width;
                pictureBox1.Height = fotoku[nofoto - 1].height;
                pictureBox1.Image = fotoku[nofoto - 1].gambar;
                nofoto -= 1;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (nofoto == jmlfoto-1)
            {
                pictureBox1.Width = fotoku[0].width;
                pictureBox1.Height = fotoku[0].height;
                pictureBox1.Image = fotoku[0].gambar;
                nofoto = 0;
            }
            else
            {
                pictureBox1.Width = fotoku[nofoto + 1].width;
                pictureBox1.Height = fotoku[nofoto + 1].height;
                pictureBox1.Image = fotoku[nofoto + 1].gambar;
                nofoto += 1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            for (int i = 0; i < jmlfoto; i++)
            { fotoku[i].reset(); }
            jmlfoto = 0;
            nofoto = 0;
        }
    }
}
