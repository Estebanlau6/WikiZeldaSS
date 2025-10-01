using SQLite;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiZeldaSS.Models;

namespace WikiZeldaSS.Database
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
            _database.DeleteAll<Personnage>();
            //Ajout de données de test
            _database.InsertAll(new List<Personnage>
                        {
                            new Personnage { Nom = "Link", Description = "Le héros de l'aventure. Étudiant à l'Académie des Chevaliers.", Role = "Héros", Emoji = "🗡️" },
                            new Personnage { Nom = "Zelda", Description = "Princesse et réincarnation de la déesse Hylia.", Role = "Princesse", Emoji = "👸" },
                            new Personnage { Nom = "Ghirahim", Description = "Le Seigneur Démon, antagoniste principal.", Role = "Antagoniste", Emoji = "👹" },
                            new Personnage { Nom = "Fi", Description = "L'esprit de l'Épée Divine qui guide Link.", Role = "Guide", Emoji = "⚔️" },
                            new Personnage { Nom = "Impa", Description = "Gardienne Sheikah protectrice de Zelda.", Role = "Gardienne", Emoji = "🛡️" }
                        });
        }
        public List<Personnage> GetPersonnes()
        {
            return _database.GetAllWithChildren<Personnage>(recursive: true)
                .OrderBy(x => x.Nom)
                .ToList();
        }
        public int SavePersonne(Personnage item)
        {
            if (item.Id != 0)
                return _database.Update(item);
            else
                return _database.Insert(item);
        }

        public int DeletePersonne(Personnage item)
        {
            return _database.Delete(item);
        }


    }
}
