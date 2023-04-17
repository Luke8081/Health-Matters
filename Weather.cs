
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Health_Matters
{
    public partial class Weather : Form
    {
        public Weather()
        {
            InitializeComponent();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void download_img(string icon, string date) 
        {
            using (WebClient client = new WebClient())
            {
                //Gets the image of the weather and saves the name of the file with date so it can be referanced 
                string icon_url = "http://openweathermap.org/img/w/" + icon + ".png";
                string directory = Path.GetDirectoryName(Application.ExecutablePath).Replace(@"\bin\Debug", $"\\icons\\icon_{date}.png");
                client.DownloadFile(new Uri(icon_url), directory);
            }
        }

        private void Weather_Load(object sender, EventArgs e)
        {
           
            string location = Login.location;
            var list = new List<string> {};
            string alert = Home.alert;

            if (alert == "Bad air quality")
            {
                alert_label.Text = "Avoid outdoor activities \r\n in the afternoons on \r\n warm days, \r\nwhen the risk of air  \r\npollution is highest.";
            }
            else if(alert == "High temperature"){
                alert_label.Text = "Get lots of rest. \r\nDrink lots of water and \r\n obvoid physical activities";
            }
            else if (alert == "Low temperature")
            {
                alert_label.Text = "Dress well in lots of layers.\r\n If you drive obvoid \r\n hard braking and cornering";
            }
            else
            {
                alert_label.Text = "No health alerts";
            }








            using (WebClient client = new WebClient()) 
            {
                string api = client.DownloadString($"https://api.openweathermap.org/data/2.5/forecast?q={location}&appid=1e71e6015ddfec0ab9f95f230ffb87c0&units=metric");
                Weather_Forecast.Root data = JsonConvert.DeserializeObject<Weather_Forecast.Root>(api);


                for (var i = 0; i < data.list.Count; i+=8) {
                    //Console.WriteLine(data.list[i].dt_txt);
                    string date_time = data.list[i].dt_txt;

                    //Formatting date so it shows month and day
                    DateTime x = DateTime.Parse(date_time);
                    string date = x.ToString("MMM-dd");

                    string temp = data.list[i].main.temp.ToString();
                    string desc = data.list[i].weather[0].main.ToString();
                    download_img(data.list[i].weather[0].icon, date);
                    list.Add(date);
                    list.Add(temp);
                    list.Add(desc);
                }

            }
            //Set up graph
            chart1.Series.Add("Temperature"); 
            chart1.Titles.Add("Weather Forecast Temperatures");


            //Get the directory of where the icons are stored
            string directory = Path.GetDirectoryName(Application.ExecutablePath).Replace(@"\bin\Debug", @"\icons");

            date_label.Text = list[0];
            temp_label.Text = list[1] + "°";
            picture.Image = Image.FromFile($"{directory}\\icon_{list[0]}.png");
            description_label.Text = list[2];

            chart1.Series["Temperature"].Points.AddXY(list[0], list[1]);

            date_label_1.Text = list[3];
            temp_label_1.Text = list[4] + "°";
            picture_1.Image = Image.FromFile($"{directory}\\icon_{list[3]}.png");
            descr_lable_1.Text = list[5];

            chart1.Series["Temperature"].Points.AddXY(list[3], list[4]);

            date_label_2.Text = list[6];
            temp_label_2.Text = list[7] + "°";
            picture_2.Image = Image.FromFile($"{directory}\\icon_{list[6]}.png");
            descr_lable_2.Text = list[8];

            chart1.Series["Temperature"].Points.AddXY(list[6], list[7]);

            date_label_3.Text = list[9];
            temp_label_3.Text = list[10] + "°";
            picture_3.Image = Image.FromFile($"{directory}\\icon_{list[9]}.png");
            descr_lable_3.Text = list[11];

            chart1.Series["Temperature"].Points.AddXY(list[9], list[10]);

            date_label_4.Text = list[12];
            temp_label_4.Text = list[13] + "°";
            picture_4.Image = Image.FromFile($"{directory}\\icon_{list[12]}.png");
            descr_lable_4.Text = list[14];

            chart1.Series["Temperature"].Points.AddXY(list[12], list[13]);





        }


        
        private void Weather_Button_Click(object sender, EventArgs e) { this.Hide(); Change_Page.weather(); }
        private void Air_Quality_button_Click(object sender, EventArgs e) { this.Hide(); Change_Page.Air(); }
        private void health_tracking_button_Click(object sender, EventArgs e) { this.Hide(); Change_Page.health(); }
        private void Settings_Button_Click(object sender, EventArgs e) { this.Hide(); Change_Page.settings(); }
        private void Logout_Button_Click(object sender, EventArgs e) { this.Hide(); Change_Page.logout(); }
        private void home_button_Click(object sender, EventArgs e) { this.Hide(); Change_Page.home(); }
    }
}
