using FormAssistControl.Model.Entities;
using FormAssistControl.Storage.Interfaces;
using SQLite;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FormAssistControl.Storage
{
    public interface IKeyObject
    {
        string Key { get; set; }
    }
    class DatabaseManager
    {
        SQLiteConnection database;

        public DatabaseManager()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<Aluno>();
        }

        public void SaveValue<T>(T value) where T : IKeyObject, new()
        {
            var all = (from entry in database.Table<T>().AsEnumerable<T>()
                where entry.Key == value.Key
                select entry).ToList();
            if (all.Count == 0)
                database.Insert(value);
            else
                database.Update(value);
        }

        public void DeleteValue<T>(T value) where T : IKeyObject, new()
        {
            var all = (from entry in database.Table<T>().AsEnumerable<T>()
                       where entry.Key == value.Key
                       select entry).ToList();
            if (all.Count == 1)
                database.Delete(value);
            else
                throw new Exception("The db doesn't contain a entry with a specified key");
        }

        public List<TSource> GetAllItems<TSource>() where TSource : IKeyObject, new()
        {
            return database.Table<TSource>().AsEnumerable<TSource>().ToList();
        }

        public Tsource GetItem<Tsource>(string key) where Tsource : IKeyObject, new()
        {
            var result = (from entry in database.Table<Tsource>().AsEnumerable<Tsource>()
                          where entry.Key == key
                          select entry).FirstOrDefault();
            return result;
        }
    }
}
