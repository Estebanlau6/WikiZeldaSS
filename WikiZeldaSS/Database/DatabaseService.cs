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
            _database.DeleteAll<Quete>();
            _database.DeleteAll<Personnage>();
            _database.DeleteAll<Objet>();
            _database.DeleteAll<Lieu>();
            _database.CreateTable<Lieu>();
            _database.CreateTable<Objet>();
            _database.CreateTable<Personnage>();
            _database.CreateTable<Quete>();
            _database.Insert(new Personnage
            {
                Nom = "Link",
                DescriptionCourt = "Le héros principal de la série, souvent chargé de sauver la princesse Zelda et de vaincre Ganon.",
                Role = "Héros",
                Emoji = "🗡️" ,
                Couleur = "#00FF00"
            });
            _database.Insert(new Personnage {
                Nom = "Zelda",
                DescriptionCourt = "La princesse du royaume d'Hyrule, souvent enlevée par Ganon et sauvée par Link.",
                Role = "Princesse",
                Emoji = "👸",
                Couleur = "#FFD700"
            });
            _database.Insert(new Personnage {
                Nom = "Ganon",
                DescriptionCourt = "L'antagoniste principal de la série, souvent représenté comme un puissant sorcier ou un démon.",
                Role = "Antagoniste",
                Emoji = "👹",
                Couleur = "#FF0000"
            });
            _database.Insert(new Personnage {
                Nom = "Impa",
                DescriptionCourt = "Une membre du clan Sheikah, souvent protectrice de la princesse Zelda.",
                Role = "Protectrice",
                Emoji = "🛡️",
                Couleur = "#0000FF"
            }); 
            _database.Insert(new Personnage {                 
                Nom = "Celestrier",
                DescriptionCourt = "Chaque habitant de Célesbourg possède son propre célestrier, qu'il appelle en sifflant et monte pour voyager dans le Ciel. On dit qu'ils sont là pour protéger les habitants de Célesbourg.",
                Role = "Monture",
                Emoji = "🐴",
                Couleur = "#A52A2A"
            });

            _database.Insert(new Objet 
            {
                Nom = "Épée de Légende",
                DescriptionCourt = "L’arme principale de Link, qui évolue au fil de l’aventure jusqu’à devenir la Master Sword.",
                DescriptionLong = "",
                Emoji = "🗡️",
                Couleur = "#00FF00"
            });
            _database.Insert(new Objet {
                Nom = "Bouclier Hylien",
                DescriptionCourt = "La princesse du royaume d'Hyrule, souvent enlevée par Ganon et sauvée par Link.",
                DescriptionLong = "",
                Emoji = "🛡️",
                Couleur = "#0000FF"
            });
            _database.Insert(new Objet {
                Nom = "Scarabée",
                DescriptionCourt = "Petit insecte mécanique télécommandé par Link. Sert à activer des mécanismes et ramasser des objets.",
                DescriptionLong = "",
                Emoji = "🐞",
                Couleur = "#9b59b6"
            });
            _database.Insert(new Objet {
                Nom = "Arc",
                DescriptionCourt = "Permet de tirer des flèches avec précision, utile contre les ennemis volants ou éloignés.",
                DescriptionLong = "",
                Emoji = "🏹",
                Couleur = "#8e44ad"
            });
            _database.Insert(new Quete
            {
                Nom = "Cristaux de gratitude",
                DescriptionCourt = "Petites quêtes annexes confiées par les habitants de Célesbourg. Chaque mission réussie donne des cristaux à échanger contre des récompenses.",
                DescriptionLong = "",
                Emoji = "💖",
                Couleur = "#f39c12",
                Objectif = "",
                Recompense = ""
            });
            _database.Insert(new Quete
            {
                Nom = "Livre d'amour de Bertie",
                DescriptionCourt = "Une quête romantique où Link doit choisir entre deux prétendants amoureux de la même personne.",
                DescriptionLong = "",
                Emoji = "📖",
                Couleur = "#e74c3c",
                Objectif = "",
                Recompense = ""
            });
            _database.Insert(new Quete
            {
                Nom = "Quête des citrouilles",
                DescriptionCourt = "Au restaurant de la Citrouille perchée, Link doit travailler pour rembourser les pots cassés en servant les clients ou en transportant des citrouilles.",
                DescriptionLong = "",
                Emoji = "🎃",
                Couleur = "#27ae60",
                Objectif = "",
                Recompense = ""
            });
            _database.Insert(new Quete
            {
                Nom = "Défi de l'île Bambou",
                DescriptionCourt = "Un mini-jeu où Link doit couper le plus de bambous possible en un coup de sabre pour gagner des récompenses.",
                DescriptionLong = "",
                Emoji = "🎋",
                Couleur = "#87ceeb",
                Objectif = "",
                Recompense = ""
            });
            _database.Insert(new Quete
            {
                Nom = "Chasse aux insectes",
                DescriptionCourt = "Une quête confiée par Terry où Link doit capturer divers insectes rares disséminés dans les régions du monde.",
                DescriptionLong = "",
                Emoji = "🐞",
                Couleur = "#9b59b6",
                Objectif = "",
                Recompense = ""
            });
            _database.Insert(new Quete
            {
                Nom = "Harpe de la Déesse",
                DescriptionCourt = "Quêtes musicales où Link doit jouer de la harpe pour réveiller les Dragons et ouvrir de nouveaux chemins.",
                DescriptionLong = "",
                Emoji = "🎶",
                Couleur = "#3498db",
                Objectif = "",
                Recompense = ""
            });

            _database.Insert(new Lieu {
                Nom = "Célesbourg",
                DescriptionCourt = "Un village flottant dans le ciel, habité par des humains et des célestriers.",
                DescriptionLong = "",
                Region = "Ciel",
                Emoji = "🏘️",
                Couleur = "#87ceeb"

            });

            _database.Insert(new Lieu {
                Nom = "Forêt de Firone",
                DescriptionCourt = "Une vaste forêt mystérieuse, souvent le point de départ des aventures de Link.",
                DescriptionLong = "",
                Region = "Hyrule",
                Emoji = "🌲",
                Couleur = "#27ae60"
            });

            _database.Insert(new Lieu {
                Nom = "Volcan d'Ordinn",
                DescriptionCourt = "Une montagne volcanique dangereuse, abritant des ennemis puissants et des trésors cachés.",
                DescriptionLong = "",
                Region = "Hyrule",
                Emoji = "⛰️",
                Couleur = "#e74c3c"
            });
            _database.Insert(new Lieu {
                Nom = "Desert de Lanele",
                DescriptionCourt = "Un vaste désert aride, rempli de ruines anciennes et de créatures hostiles.",
                DescriptionLong = "",
                Region = "Hyrule",
                Emoji = "🏜️",
                Couleur = "#f39c12"
            });

            _database.Insert(new Lieu { 
                Nom = "Temple du Temps",
                DescriptionCourt = "Un lieu sacré où le temps peut être manipulé, souvent lié à la légende de la Master Sword.",
                DescriptionLong = "",
                Region = "Hyrule",
                Emoji = "⏳",
                Couleur = "#9b59b6"
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
        public List<Objet> GetObjets()
        {
            return _database.GetAllWithChildren<Objet>(recursive: true)
                .OrderBy(x => x.Nom)
                .ToList();
        }
        public int SaveObjet(Objet item)
        {
            if (item.Id != 0)
                return _database.Update(item);
            else
                return _database.Insert(item);
        }

        public int DeleteObjet(Objet item)
        {
            return _database.Delete(item);
        }

        public List<Lieu> GetLieux()
        {
            return _database.GetAllWithChildren<Lieu>(recursive: true)
                .OrderBy(x => x.Nom)
                .ToList();
        }

        public int SaveLieu(Lieu item)
        {
            if (item.Id != 0)
                return _database.Update(item);
            else
                return _database.Insert(item);
        }

        public int DeleteLieu(Lieu item)
        {
            return _database.Delete(item);
        }

        public List<LieuDetail> GetLieuxDetails()
        {
            return _database.GetAllWithChildren<LieuDetail>(recursive: true)
                .OrderBy(x => x.Nom)
                .ToList();
        }

        public int SaveLieuxDetail(LieuDetail item)
        {
            if (item.Id != 0)
                return _database.Update(item);
            else
                return _database.Insert(item);
        }

        public int DeleteLieuxDetail(LieuDetail item)
        {
            return _database.Delete(item);
        }



        public ObservableCollection<Personnage> Personnages { get; set; }
        public ObservableCollection<Objet> Objets { get; set; }
        public ObservableCollection<Quete> Quetes { get; set; }
        public ObservableCollection<Lieu> Lieux { get; set; }
        public ObservableCollection<LieuxDetail> LieuxDetails { get; set; }
        public ObservableCollection<ObjetsDetail> ObjetsDetails { get; set; }
        public ObservableCollection<PersonnesDetail> PersonnesDetails { get; set; }
        public ObservableCollection<QuetesDetail> QuetesDetails { get; set; }



    }

}
