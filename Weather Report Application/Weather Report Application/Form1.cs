using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using System.Web;
using System.Net;
namespace Weather_Report_Application
{
    
    public partial class Form1 : Form
    {
        public class OpenWeatherMap
        {
            public class Coord
            {
                public double lon { get; set; }
                public double lat { get; set; }
            }

            public class Sys
            {
                public int type { get; set; }
                public int id { get; set; }
                public double message { get; set; }
                public string country { get; set; }
                public int sunrise { get; set; }
                public int sunset { get; set; }

            }

            public class Weather
            {
                public int id { get; set; }
                public string main { get; set; }
                public string description { get; set; }
                public string icon { get; set; }
            }

            public class Main
            {
                public double temp { get; set; }
                public int humidity { get; set; }
                public double pressure { get; set; }
                public double temp_min { get; set; }
                public double temp_max { get; set; }
            }

            public class Wind
            {
                public double speed { get; set; }
                public double gust { get; set; }
                public double deg { get; set; }
            }



            public class Clouds
            {
                public int all { get; set; }
            }

            public class Root
            {
                public Coord coord { get; set; }
                public Sys sys { get; set; }
                public List<Weather> weather { get; set; }
                public string @base { get; set; }
                public Main main { get; set; }
                public Wind wind { get; set; }
                public Dictionary<string, double> rain { get; set; }
                public Clouds clouds { get; set; }
                public int dt { get; set; }
                public int id { get; set; }
                public string name { get; set; }
                public int cod { get; set; }
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //go
            const string apikey = "b65801209e754b349eb2d3233a39869c";
            if (!textBox1.Text.Equals(""))
            {
                using (WebClient wcumum = new WebClient())
                {
                    try
                    {
                        string request = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}&units=metric", textBox1.Text, apikey);
                        var jsonres = wcumum.DownloadString(request);
                        var objectres = JsonConvert.DeserializeObject<OpenWeatherMap.Root>(jsonres);
                        // mulai ngaco....
                        OpenWeatherMap.Root resultobj = objectres;
                        string ctry = string.Format("Country\t\t: {0}\n", resultobj.sys.country);
                        string cty = string.Format("City\t\t: {0}\n", resultobj.name);
                        string lttd = string.Format("Latitude\t\t: {0}\n", resultobj.coord.lat);
                        string lngtd = string.Format("Longitude\t\t: {0}\n", resultobj.coord.lon);
                        string tmprtr = string.Format("Temperature\t: {0} Celcius\n", resultobj.main.temp);
                        string wthr = string.Format("{0},{1}\n\n", resultobj.weather[0].main, resultobj.weather[0].description);
                        string hmdty = string.Format("Humidity\t\t: {0}\n", resultobj.main.humidity);
                        string prssr = string.Format("Air Pressure\t: {0}\n", resultobj.main.pressure);
                        richTextBox1.Text += ctry;
                        richTextBox1.Text += cty;
                        richTextBox1.Text += lttd;
                        richTextBox1.Text += lngtd;
                        richTextBox1.Text += hmdty;
                        richTextBox1.Text += prssr;
                        richTextBox1.Text += tmprtr;
                        richTextBox1.Text += wthr;
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else { MessageBox.Show("Unable to request. Please enter the city name first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            richTextBox1.Text = "";
        }
    }
}
