using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Health_Matters
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        public static string username;
        public static string location;
        public static string theme;
        public static OleDbConnection connection;
        public int count = 0;
        public static int ID;


        private void load_create_form(object sender, EventArgs e)
        {
            this.Hide();
            var create_form = new Create_Account();
            create_form.Closed += (s, args) => this.Close();
            create_form.Show();
        }
        
        private void Username_textBox_click (object sender, System.EventArgs e){Username_textBox.Text = ""; Username_textBox.ForeColor = Color.White; }
        private void Password_textBox_click(object sender, System.EventArgs e) {Password_textBox.Text = ""; Password_textBox.PasswordChar = '*'; Password_textBox.ForeColor = Color.White; }

        private void login_button_Click(object sender, EventArgs e)
        {

            string username_user = Username_textBox.Text;
            string password_user = Password_textBox.Text;

            //Check that the user has entered data
            if (username_user == "" || password_user == "")
            {
                user_message.Text = "Please enter a value";
                user_message.Show();
                return;
            }

            //Hash the password
            string hashed_password = hash(password_user);

            //See if user username and password are correct
            OleDbCommand command = new OleDbCommand($"SELECT * FROM [User] WHERE '{username_user}' = [Username] AND '{hashed_password}' = [Password]", connection);
            OleDbDataReader reader = command.ExecuteReader();


            if (reader.Read() == true && count < 3)
            {
                //If user gets password correct
                ID = reader.GetInt32(0);
                username = reader.GetString(1);
                location = reader.GetString(3);
                theme = reader.GetString(4);

                this.Hide();
                var home_page = new Home();
                home_page.Closed += (s, args) => this.Close();
                home_page.Show();
            }
            else if(count >= 3){
                //If the user is locked out
                user_message.Text = "You are locked out";
                user_message.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
                user_message.Show();
            }
            else
            {
                //If the user gets username or password wrong
                user_message.Text = "Username or password are incorrect";
                user_message.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
                user_message.Show();
                count++;
            }

            reader.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {

            user_message.Hide();


            string connect = $"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = {Directory.GetCurrentDirectory().Replace(@"\bin\Debug", "/data/Database.accdb")}";

            connection = new OleDbConnection(connect);
            connection.Open();


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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
