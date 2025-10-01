using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using WikiZeldaSS.Models;

namespace WikiZeldaSS
{
    public partial class DatabaseService
    {
        private SQLiteConnection _database;
        public const string DatabaseFilename = "TodoSQLite.db3";
        public const SQLiteOpenFlags Flags =
        // open the database in read/write mode
        SQLiteOpenFlags.ReadWrite |
        // create the database if it doesn't exist
        SQLiteOpenFlags.Create |
        // enable multi-threaded database access
        SQLiteOpenFlags.SharedCache;
        public static string DatabasePath =>
        Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
        public DatabaseService()
        {
            _database = new SQLiteConnection(DatabasePath, Flags);
            //Création des tables
            _database.CreateTable<Personnage>();
            
        }
    }
}
