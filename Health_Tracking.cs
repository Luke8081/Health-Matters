using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Health_Matters
{
    public partial class Health_Tracking : Form
    {
        public Health_Tracking()
        {
            InitializeComponent();
        }
        private void Weather_Button_Click(object sender, EventArgs e) { this.Hide(); Change_Page.weather(); }
        private void Air_Quality_button_Click(object sender, EventArgs e) { this.Hide(); Change_Page.Air(); }
        private void health_tracking_button_Click(object sender, EventArgs e) { this.Hide(); Change_Page.health(); }
        private void Settings_Button_Click(object sender, EventArgs e) { this.Hide(); Change_Page.settings(); }
        private void Logout_Button_Click(object sender, EventArgs e) { this.Hide(); Change_Page.logout(); }
        private void home_button_Click(object sender, EventArgs e) { this.Hide(); Change_Page.home(); }

        private void Health_Tracking_Load(object sender, EventArgs e)
        {
            user_message.Hide();

            var connection = Login.connection;
            int id = Login.ID;

            
            Dictionary<string, string> Steps = new Dictionary<string, string>();


            for (int i = 0; i < 7; i++)
            {
                DateTime date = DateTime.Today.AddDays(-i);
                
                //Selecting the users sum steps of each day within the last week
                string search = $"SELECT SUM(Steps) from Health where [Date] = #{date}# AND User_ID = {id}";
                using (OleDbCommand Cmd = new OleDbCommand(search, connection))
                {

                    OleDbDataReader reader = Cmd.ExecuteReader();
                    var data = reader.Read();

                    //Check if there was any returned data and store it
                    if (data)
                    {
                        //Format date so it looks good on graph
                        string date_format = date.ToString("MMM-dd");

                        Steps.Add(date_format, reader.GetValue(0).ToString());

                    }

                }
            }
            chart1.Series.Add("Steps");
            chart1.Titles.Add("Steps Chart");

            //Plot graph
            foreach (KeyValuePair<string, string> entry in Steps)
            {
                chart1.Series["Steps"].Points.AddXY(entry.Key, entry.Value);
            }
            
            

            Dictionary<string, string> Calories = new Dictionary<string, string>();


            for (int i = 0; i < 7; i++)
            {
                DateTime date = DateTime.Today.AddDays(-i);

                //Selecting the users sum steps of each day within the last week
                string search = $"SELECT SUM(Calories) from Health where [Date] = #{date}# AND User_ID = {id}";
                using (OleDbCommand Cmd = new OleDbCommand(search, connection))
                {

                    OleDbDataReader reader = Cmd.ExecuteReader();
                    var data = reader.Read();

                    //Check if there was any returned data and store it
                    if (data)
                    {
                        //Format date so it looks good on graph
                        string date_format = date.ToString("MMM-dd");

                        Calories.Add(date_format, reader.GetValue(0).ToString());

                    }

                }
            }
            chart2.Series.Add("Calories");
            chart2.Titles.Add("Calories Chart");

            //Plot graph
            foreach (KeyValuePair<string, string> entry in Calories)
            {
                chart2.Series["Calories"].Points.AddXY(entry.Key, entry.Value);
            }

            
        }

        private void submit_button_Click(object sender, EventArgs e)
        {
            OleDbConnection connection = Login.connection;
            string steps_input = steps_textBox.Text;
            string calories_input = calories_textBox.Text;
            int steps;
            int calories;

            int length_step = steps_input.Length;
            int length_cal = calories_input.Length;

            //Range check
            if (length_step > 10 || length_cal > 10)
            {
                user_message.Text = "Number is to large";
                user_message.Show();
                return;
            } else if(length_step < 0 || length_cal < 0)
            {
                user_message.Text = "Number must be positive";
                user_message.Show();
                return;
            }
            
            if (int.TryParse(steps_input, out steps) == false || int.TryParse(calories_input, out calories) == false)
            {
                user_message.Text = "Must be a number";
                user_message.Show();
                return;
            }
            OleDbCommand command = new OleDbCommand("INSERT INTO Health (User_ID, Calories, Steps, [Date]) VALUES (@User_ID, @Calories, @Steps, Date())", connection);
            command.Parameters.AddWithValue("@User_ID", Login.ID);
            command.Parameters.AddWithValue("@Calories", calories);
            command.Parameters.AddWithValue("@Steps", steps);
            command.ExecuteNonQuery();

            user_message.Show();
            user_message.Text = "Added data";
            user_message.BackColor = Color.Green;
            steps_textBox.Text = "";
            calories_textBox.Text = "";
            

           
        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }
    }
}
