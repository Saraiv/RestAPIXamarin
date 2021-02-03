using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestAPIXamarin.Data;
using System.IO;
using Xamarin.Forms;
using RestAPIXamarin.Droid.Data;

[assembly: Dependency(typeof(SQLiteAndroid))]

namespace RestAPIXamarin.Droid.Data
{
    public class SQLiteAndroid : ISQLite{
        public SQLiteAndroid(){ }

        public SQLite.SQLiteConnection GetConnection(){
            var sqliteFileName = "Test.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFileName);
            var conn = new SQLite.SQLiteConnection(path);

            return conn;
        }
    }
}