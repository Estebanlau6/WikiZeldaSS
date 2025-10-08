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
        private readonly SQLiteConnection _database; // Ajout de readonly pour plus de clarté
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
            _database.DeleteAll<Personnage>();
            _database.CreateTable<Personnage>();
            _database.CreateTable<Quete>();
            _database.Insert(new Personnage
            {
                Nom = "Link",
                DescriptionCourt = "Le héros principal de la série, souvent chargé de sauver la princesse Zelda et de vaincre Ganon.",
                Role = "Héros",
                Emoji = "🗡️"
            });
            _database.Insert(new Personnage {
                Nom = "Zelda",
                DescriptionCourt = "La princesse du royaume d'Hyrule, souvent enlevée par Ganon et sauvée par Link.",
                Role = "Princesse",
                Emoji = "👸"
            });
            _database.Insert(new Personnage {
                Nom = "Ganon",
                DescriptionCourt = "L'antagoniste principal de la série, souvent représenté comme un puissant sorcier ou un démon.",
                Role = "Antagoniste",
                Emoji = "👹"
            });
            _database.Insert(new Personnage {
                Nom = "Impa",
                DescriptionCourt = "Une membre du clan Sheikah, souvent protectrice de la princesse Zelda.",
                Role = "Protectrice",
                Emoji = "🛡️"
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

        public List<Quete> GetQuetes()
        {
            return _database.GetAllWithChildren<Quete>(recursive: true)
                .OrderBy(x => x.Nom)
                .ToList();
        }

        public int SaveQuete(Quete item)
        {
            if (item.Id != 0)
                return _database.Update(item);
            else
                return _database.Insert(item);
        }

        public int DeleteQuete(Quete item)
        {
            return _database.Delete(item);
        }

        public ObservableCollection<Personnage> Personnages { get; set; }

    }
        
}
