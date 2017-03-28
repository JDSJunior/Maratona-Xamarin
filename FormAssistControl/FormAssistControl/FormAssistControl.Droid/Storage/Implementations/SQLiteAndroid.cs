using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using SQLitePCL;
using FormAssistControl.Storage.Interfaces;
using System.IO;
using Xamarin.Forms;
using FormAssistControl.Droid.Restorage.Implementations;

[assembly:Dependency(typeof(SQLiteAndroid))]
namespace FormAssistControl.Droid.Restorage.Implementations
{
    public class SQLiteAndroid : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            SQLitePCL.Batteries.Init();
            var sqliteFilename = "TodoSqlite.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);
            //Create the connection
            var conn = new SQLite.SQLiteConnection(path);
            //return the database connection
            return conn;
        }
    }
}