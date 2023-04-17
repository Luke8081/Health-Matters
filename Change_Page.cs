using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Health_Matters
{
    class Change_Page
    {
        public static void home()
        {
            Home page = new Home();
            page.Show();
        }
        public static void weather()
        {
            Weather page = new Weather();
            page.Show();
        }
        public static void Air()
        {
            Air_Quality page = new Air_Quality();
            page.Show();
        }

        public static void health()
        {
            Health_Tracking page = new Health_Tracking();
            page.Show();
        }

        public static void settings()
        {
            Settings page = new Settings();
            page.Show();
        }

        public static void logout() 
        {
            Login page = new Login();
            page.Show();
        }
    }
}
