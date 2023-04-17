using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Health_Matters
{
    public partial class Air_Quality : Form
    {
        public Air_Quality()
        {
            InitializeComponent();
        }
        private void Weather_Button_Click(object sender, EventArgs e) { this.Hide(); Change_Page.weather(); }
        private void Air_Quality_button_Click(object sender, EventArgs e) { this.Hide(); Change_Page.Air(); }
        private void health_tracking_button_Click(object sender, EventArgs e) { this.Hide(); Change_Page.health(); }
        private void Settings_Button_Click(object sender, EventArgs e) { this.Hide(); Change_Page.settings(); }
        private void Logout_Button_Click(object sender, EventArgs e) { this.Hide(); Change_Page.logout(); }
        private void home_button_Click(object sender, EventArgs e) { this.Hide(); Change_Page.home(); }

        private void Air_Quality_Load(object sender, EventArgs e)
        {
            refresh();
        }
        

        private void refresh()
        {
            string lat = Home.lat;
            string lon = Home.lon;
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString($"http://api.openweathermap.org/data/2.5/air_pollution?lat={lat}&lon={lon}&appid=1e71e6015ddfec0ab9f95f230ffb87c0");
                Air_Gas.Root resp = JsonConvert.DeserializeObject<Air_Gas.Root>(json);

                CO_label.Text = resp.list[0].components.co.ToString();
                NO_label.Text = resp.list[0].components.no.ToString();
                NO2_label.Text = resp.list[0].components.no2.ToString();
                O3_label.Text = resp.list[0].components.o3.ToString();
                SO2_label.Text = resp.list[0].components.so2.ToString();
                PM2_label.Text = resp.list[0].components.pm2_5.ToString();
                PM10_label.Text = resp.list[0].components.pm10.ToString();
                Nh3_label.Text = resp.list[0].components.nh3.ToString();

                double rating = resp.list[0].main.aqi;

                switch (rating)
                {
                    case 1:
                        rating_label.Text = "Good";
                        rating_label.ForeColor = Color.Green;
                        break;
                    case 2:
                        rating_label.Text = "Fair";
                        rating_label.ForeColor = Color.Yellow;
                        break;
                    case 3:
                        rating_label.Text = "Moderate";
                        rating_label.ForeColor = Color.Orange;
                        break;
                    case 4:
                        rating_label.Text = "Poor";
                        rating_label.ForeColor = Color.Red;
                        break;
                    case 5:
                        rating_label.Text = "Very Poor";
                        rating_label.ForeColor = Color.DarkRed;
                        break;
                }
            }
        }

        private void refresh_button_Click(object sender, EventArgs e)
        {
            refresh();
        }
    }
}
