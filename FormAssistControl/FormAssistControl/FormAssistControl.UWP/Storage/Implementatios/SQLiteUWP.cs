using FormAssistControl.Storage.Interfaces;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Windows.Storage;
using Xamarin.Forms;
using FormAssistControl.UWP.Storage.Implementatios;

[assembly:Dependency(typeof(SQLiteUWP))]
namespace FormAssistControl.UWP.Storage.Implementatios
{
    public class SQLiteUWP : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var sqliteFileName = "TodoSQLite.db3";
            string documentPath = ApplicationData.Current.LocalFolder.Path;
            string libraryPath = Path.Combine(documentPath, sqliteFileName);

            var conn = new SQLite.SQLiteConnection(libraryPath);

            return conn;
            
        }
    }
}
