using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace RestAPIXamarin.Models
{
    public class Constants{
        public static bool isDev = true;

        public static Color BackgroundColor = Color.White;
        public static Color MainTextColor = Color.FromHex("#333");
        public static int LoginIconHeight = 120;

        public static string loginUrl = "https://test.com/api/auth/login";
        public static string noInternetText = "No internet, please reconnect!";
    }
}
