
using SQLite;
using System.IO;
using Windows.Storage;
using Xamarin.Forms;
using XamarinFormsLicao3.UWP;

[assembly: Dependency(typeof(SQLiteUWP))]
namespace XamarinFormsLicao3.UWP
{
    public class SQLiteUWP : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            SQLitePCL.Batteries.Init();
            var sqliteFileName = "TodoSQLite.db3";
            string documentsPath = ApplicationData.Current.LocalFolder.Path;
            var path = Path.Combine(documentsPath, sqliteFileName);

            var conn = new SQLiteConnection(path);

            return conn;
        }
    }
}