using System;
using AluraNutricao.Droid;
using Xamarin.Forms;
using AluraNutricao.Data;
using System.IO;
using SQLite.Net;

[assembly: Dependency(typeof(SQLite_droid))]
namespace AluraNutricao.Droid
{
    public class SQLite_droid : ISqlite
    {
        public SQLite_droid()
        {

        }

        public SQLiteConnection GetConnection()
        {
            var fileName = "Refeicoes.db3";
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documents, fileName);
            
            var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            var connection = new SQLiteConnection(platform, path);
            return connection;
        }
    }
}