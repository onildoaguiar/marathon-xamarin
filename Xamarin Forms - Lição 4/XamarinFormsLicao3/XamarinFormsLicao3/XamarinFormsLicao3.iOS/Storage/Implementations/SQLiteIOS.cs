using SQLite;
using System;
using System.IO;
using Xamarin.Forms;
using XamarinFormsLicao3.iOS;

[assembly:Dependency(typeof(SQLiteIOS))]
namespace XamarinFormsLicao3.iOS
    {
        public class SQLiteIOS : ISQLite
        {
            public SQLiteConnection GetConnection()
            {
                SQLitePCL.Batteries.Init();
                var sqliteFileName = "TodoSQLite.db3";
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                string librayPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
                var path = Path.Combine(librayPath, sqliteFileName);
                // Create the connection
                var conn = new SQLiteConnection(path);
                // Return the database connection
                return conn;
            }
        }
}
