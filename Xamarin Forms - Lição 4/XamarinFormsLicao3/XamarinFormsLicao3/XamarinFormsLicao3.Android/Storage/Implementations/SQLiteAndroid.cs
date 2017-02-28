using System;
using SQLite;
using System.IO;
using Xamarin.Forms;
using XamarinFormsLicao3.Droid;

[assembly:Dependency(typeof(SQLiteAndroid))]
namespace XamarinFormsLicao3.Droid
{
    public class SQLiteAndroid:ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            SQLitePCL.Batteries.Init();
            var sqliteFileName = "TodoSQLite.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var path = Path.Combine(documentsPath, sqliteFileName);
            // Create the connection
            var conn = new SQLiteConnection(path);
            // Return the database connection
            return conn;
        }
    }
}