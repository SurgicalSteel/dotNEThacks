using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace photoAddIn
{
    class photo
    {
        public int width, height;
        public string filename;
        public Image gambar;
        public void reset() 
        {
            width = 0;
            height = 0;
            filename = "";
            gambar = null;
        }
        public photo(int w, int h, string f, Image i) 
        {
            this.filename = f;
            this.width = w;
            this.height = h;
            this.gambar = i;
        }
    }
}
