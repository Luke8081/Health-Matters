using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Health_Matters
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }
        
        private void Weather_Button_Click(object sender, EventArgs e) { this.Hide(); Change_Page.weather(); }
        private void Air_Quality_button_Click(object sender, EventArgs e) { this.Hide(); Change_Page.Air(); }
        private void health_tracking_button_Click(object sender, EventArgs e) { this.Hide(); Change_Page.health(); }
        private void Settings_Button_Click(object sender, EventArgs e) { this.Hide(); Change_Page.settings(); }
        private void Logout_Button_Click(object sender, EventArgs e) { this.Hide(); Change_Page.logout(); }
        private void home_button_Click(object sender, EventArgs e) { this.Hide(); Change_Page.home(); }

        public void Settings_Load(object sender, EventArgs e)
        {
            
            user_message.Hide();
            account_label.Text = Login.username;

        }

        private void apply_location_button_Click(object sender, EventArgs e)
        {
            var connection = Login.connection;
            string location = location_textBox.Text;
            string search = $"UPDATE [User] SET Location = '{location}' WHERE [ID] = {Login.ID}";

            using (OleDbCommand Cmd = new OleDbCommand(search, connection))
            {
                Cmd.ExecuteNonQuery();
            }
            Login.location = location;
            user_message.BackColor = Color.Green;
            user_message.Text = "Location Changed";
        }

        private void delete_Account_Button_Click(object sender, EventArgs e)
        {
            //Delete there login data
            var connection = Login.connection;
            string delete = $"DELETE FROM [User] WHERE [ID] = {Login.ID} ";
            using (OleDbCommand Cmd = new OleDbCommand(delete, connection))
            {
                Cmd.ExecuteNonQuery();
            }
            //Delete there health data
            delete = $"DELETE FROM [Health] WHERE User_ID = {Login.ID} ";
            using (OleDbCommand Cmd = new OleDbCommand(delete, connection))
            {
                Cmd.ExecuteNonQuery();
            }
            user_message.BackColor = Color.Green;
            user_message.Text = "Account Deleted";

            this.Close();
            var login = new Login();
            login.Show();

        }

        private void apply_theme_button_Click(object sender, EventArgs e)
        {
            var connection = Login.connection;
            string theme = theme_textBox.Text;
            string search = $"UPDATE [User] SET Theme = '{theme}' WHERE [ID] = {Login.ID}";

            using (OleDbCommand Cmd = new OleDbCommand(search, connection))
            {
                Cmd.ExecuteNonQuery();
            }
            Login.theme = theme;
            user_message.BackColor = Color.Green;
            user_message.Text = "Theme Changed";
        }

        private void report_button_Click(object sender, EventArgs e)
        {
            string bug = bug_textBox.Text;
            string path = $"{Directory.GetCurrentDirectory().Replace(@"\bin\Debug", @"\Reported_Bugs.txt")}";
            File.AppendAllText(path, bug + Environment.NewLine);
            user_message.BackColor = Color.Green;
            user_message.Text = "Bug reported";
        }

    }
}
