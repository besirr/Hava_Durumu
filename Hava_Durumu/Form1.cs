using System.Globalization;
using System.Xml.Linq;

namespace Hava_Durumu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label2.Text=DateTime.Now.ToShortDateString();

            string api = "xxxx";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument hava = XDocument.Load(connection);
            var sicaklik = hava.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            var nem = hava.Descendants("humidity").ElementAt(0).Attribute("value").Value;
            var rüzgar = hava.Descendants("speed").ElementAt(0).Attribute("value").Value;
            var durum = hava.Descendants("clouds").ElementAt(0).Attribute("name").Value;

            label4.Text = sicaklik.ToString();
            label6.Text = rüzgar.ToString();
            label7.Text = nem.ToString();
            label9.Text = durum.ToString();

            double sicaklikDegeri = Convert.ToDouble(sicaklik, CultureInfo.InvariantCulture);

            if (sicaklikDegeri <= 10)
            {
                pictureBox1.ImageLocation = "C:\\Users\\Mehmet Beþir\\Desktop\\depositphotos_425579014-stock-illustration-weather-overcast-snowing-icon-color.jpg";
            }

            else
            {
                pictureBox1.ImageLocation = "C:\\Users\\Mehmet Beþir\\Desktop\\istockphoto-907865488-612x612.jpg";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
           

        }
    }
}
