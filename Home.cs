using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;
using System.Data.OleDb;

namespace Health_Matters
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }
        public static string lon;
        public static string lat;
        public static string alert = "";

        




        



        private void menu_Load(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.FromArgb(68, 114, 196);
            label1.BackColor = Color.FromArgb(68, 114, 196);
            home_button.BackColor = Color.SteelBlue;
            
            string location = Login.location;
            get_health_data();

            using (WebClient client = new WebClient())
            {
                //Get the data from API
                string json = client.DownloadString($"https://api.openweathermap.org/data/2.5/weather?q={location}&appid=1e71e6015ddfec0ab9f95f230ffb87c0&units=metric");
                
                //Convert the data from json to a C# class
                Current_Weather.Root resp = JsonConvert.DeserializeObject<Current_Weather.Root>(json);

                //Store varible names to different data for easy referances 
                string temp = resp.main.temp.ToString();
                string icon = resp.weather[0].icon;
                lon = resp.coord.lon.ToString();
                lat = resp.coord.lat.ToString();
                string description = resp.weather[0].description;
                string main = resp.weather[0].main;

                temp_label.Text = $"{temp}°";
                description_label.Text = main;

                //Get the icon image of the current weather
                string icon_url = "http://openweathermap.org/img/w/" + icon + ".png";
                string directory = Path.GetDirectoryName(Application.ExecutablePath).Replace(@"\bin\Debug", @"\icons\icon.png");
                client.DownloadFile(new Uri(icon_url), directory);
                icon_picture.Image = Image.FromFile(directory);

                //Get the air quality data
                json = client.DownloadString($"http://api.openweathermap.org/data/2.5/air_pollution?lat={lat}&lon={lon}&appid=1e71e6015ddfec0ab9f95f230ffb87c0&units=metric");
                
                //Convert air quality json to C# 
                Air_Gas.Root gas_resp = JsonConvert.DeserializeObject<Air_Gas.Root>(json);

                double rating = gas_resp.list[0].main.aqi;

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
                        alert = "Bad air quality";
                        break;
                    case 5:
                        rating_label.Text = "Very Poor";
                        rating_label.ForeColor = Color.DarkRed;
                        alert = "Bad air quality";
                        break;
                }

                if (Convert.ToDouble(temp) > 26)
                {
                    alert = "High temperature";
                } else if (Convert.ToDouble(temp) < 0)
                {
                    alert = "Low temperature";
                }

                if (alert != "")
                {
                    weather_alert.Text = alert;
                }
                else
                {
                    alert = "No weather alerts";
                    weather_alert.Text = alert;
                }

            }
        }

        private void get_health_data()
        {
            var connection = Login.connection;
            int ID = Login.ID;
            //Get the sumary of the calories and steps to today
            OleDbCommand command = new OleDbCommand($"SELECT SUM(Calories), SUM(Steps) FROM Health WHERE User_ID = {ID} AND [Date] = Date()", connection);
            OleDbDataReader reader = command.ExecuteReader();

            if (reader.Read() == true)
            {
                //Present the data to the user
                string calories = reader.GetValue(0).ToString();
                string steps = reader.GetValue(1).ToString();

                Calories_label.Text = $"Calories: {calories}";
                steps_label.Text = $"Steps: {steps}";
            }
        }

        private void Weather_Button_Click(object sender, EventArgs e) { Change_Page.weather(); this.Hide();}
        private void Air_Quality_button_Click(object sender, EventArgs e) {Change_Page.Air(); this.Hide(); }
        private void health_tracking_button_Click(object sender, EventArgs e) {Change_Page.health(); this.Hide(); }
        private void Settings_Button_Click(object sender, EventArgs e) {Change_Page.settings(); this.Hide(); }

        private void Logout_Button_Click(object sender, EventArgs e){Change_Page.logout(); this.Hide(); }
    }
}
