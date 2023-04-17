using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Health_Matters
{
    public partial class Create_Account : Form
    {
        public Create_Account()
        {
            InitializeComponent();
        }

        private void load_login_form(object sender, EventArgs e)
        {
            this.Hide();
            var login_form = new Login();
            login_form.Closed += (s, args) => this.Close();
            login_form.Show();
        }

        //When the user clicks on the textbox the text disappears
        private void Username_textBox_click(object sender, System.EventArgs e){Username_textBox.Text = "";}
        private void location_texBox_click(object sender, System.EventArgs e) {Location_textBox.Text = "";}
        private void Password_textBox_click(object sender, System.EventArgs e){ Password_textBox.Text = ""; Password_textBox.PasswordChar = '*';}

        private void Create_Account_Load(object sender, EventArgs e)
        {
            user_message.Hide();
        }

        private void create_button_Click(object sender, EventArgs e)
        {
            var connection = Login.connection;

            string username = Username_textBox.Text;
            string password = Password_textBox.Text;
            string location = Location_textBox.Text;

            //Presence check
            if (username == "" || password == "")
            {
                user_message.Text = "Please enter a value";
                user_message.Show();
                return;
            }

            //Range check
            if (password.Length > 15 || password.Length < 4)
            {
                user_message.Text = "Password must be 4-15 characters long";
                user_message.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
                user_message.Show();
                return;
            }

            //Check password contain at least 1 number
            bool contains = false;
            foreach (char c in password)
            {
                if (Char.IsDigit(c))
                {
                    contains = true;
                }
            }
            if (contains == false)
            {
                user_message.Text = "Password must contain a number";
                user_message.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
                user_message.Show();
                return;
            }

            //Hash the password
            string hashedData = hash(password);

            OleDbCommand command = new OleDbCommand("INSERT INTO [User] ([Username], [Password], Location, Theme) VALUES (@Username_login, @Password_login, @Location, @Theme)", connection);
            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@Password", hashedData);
            command.Parameters.AddWithValue("@Location", location);
            command.Parameters.AddWithValue("@Theme", "standard");
            command.ExecuteNonQuery();

            Change_Page.logout();
            this.Hide();

        }
        static string hash(string plain)
        {
            // Create a SHA256 - This is a secure hashing algorithm
            using (SHA256 sha256Hash = SHA256.Create())
            {
                //returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(plain));

                // Convert byte array to a string   
                StringBuilder build = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    build.Append(bytes[i].ToString("x2"));
                }
                return build.ToString();
            }
        }


    }
}
