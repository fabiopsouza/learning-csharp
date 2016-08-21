using AluraNutricao.Data;
using AluraNutricao.iOS;
using SQLite.Net;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_ios))]
namespace AluraNutricao.iOS
{

    public class SQLite_ios : ISqlite
    {
        public SQLite_ios()
        {

        }

        public SQLiteConnection GetConnection()
        {
            var fileName = "Refeicoes.db3";
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documents, fileName);
            var platform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
            return new SQLiteConnection(platform, path);
        }
    }
}