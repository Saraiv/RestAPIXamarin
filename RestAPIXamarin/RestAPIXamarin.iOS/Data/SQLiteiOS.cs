using Foundation;
using RestAPIXamarin.Data;
using RestAPIXamarin.iOS.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteiOS))]

namespace RestAPIXamarin.iOS.Data
{
    class SQLiteiOS : ISQLite {
        public SQLiteiOS() { }
        public SQLite.SQLiteConnection GetConnection(){
            var sqliteFileName = "Test.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFileName);
            var conn = new SQLite.SQLiteConnection(path);

            return conn;
        }

    }
}