using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bahasa_Gaul_Jogja
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /*
        pa dha ja ya nya
        ma ga ba tha nga
        ha na ca ra ka
        da ta sa wa la

        ha na ca ra ka
        da ta sa wa la
        pa dha ja ya nya
        ma ga ba tha nga

        */
        static string getcons(string cons)
        {
            switch (cons)
            {
                case "dh": { return "n";}
                case "ny": { return "k";}
                case "th": { return "w";}
                case "ng": { return "l";}
                case "h": { return "p";}
                case "n": { return "dh";}
                case "c": { return "j";}
                case "r": { return "y";}
                case "k": { return "ny";}
                case "d": { return "m";}
                case "t": { return "g";}
                case "s": { return "b";}
                case "w": { return "th";}
                case "l": { return "ng";}
                case "p": { return "h";}
                case "j": { return "c";}
                case "y": { return "r";}
                case "m": { return "d";}
                case "g": { return "t";}
                case "b": { return "s";}
                default: { return " "; }
            }
        }
        static string translateword(string wordin)
        {
            string build="";
            wordin = wordin.ToLower();
            int len = wordin.Length;
            for(int i=0;i< len; i++)
            {
                if ((i <= len - 2)&&(wordin.Substring(i, 2).Equals("dh")|| wordin.Substring(i, 2).Equals("th")|| wordin.Substring(i, 2).Equals("ng")|| wordin.Substring(i, 2).Equals("ny")))
                {build += getcons(wordin.Substring(i, 2));i++; }
                else if((i<len)&&(!wordin.Substring(i,1).Equals("a"))&&(!wordin.Substring(i, 1).Equals("i"))&&(!wordin.Substring(i, 1).Equals("u"))&&(!wordin.Substring(i, 1).Equals("e"))&&(!wordin.Substring(i, 1).Equals("o"))&& (!wordin.Substring(i, 1).Equals(","))&& (!wordin.Substring(i, 1).Equals("."))&&(!wordin.Substring(i, 1).Equals("?"))&& (!wordin.Substring(i, 1).Equals("!")))
                { build += getcons(wordin.Substring(i, 1)); }
                else { build += wordin.Substring(i, 1); }
            }
            return build;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string[] arrstr = richTextBox1.Text.Split();
            string s = "";
            for(int i = 0; i < arrstr.Length; i++)
            {s += translateword(arrstr[i]) + " ";}
            richTextBox2.Text = s;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            richTextBox2.Text = "";
        }
    }
}
