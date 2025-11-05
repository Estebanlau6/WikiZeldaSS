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
                DescriptionLong = "Link est courageux et déterminé. Il parcourt Hyrule pour protéger le royaume et accomplir des quêtes légendaires. Il manie l'épée et le bouclier avec maîtrise, et son cœur pur lui permet de triompher des ténèbres.",
                Role = "Héros",
                Emoji = "🗡️",
                Couleur = "#00FF00",
                Importance = "Principal",
                Image = ""
            });
            _database.Insert(new Personnage {
                Nom = "Zelda",
                DescriptionCourt = "La princesse du royaume d'Hyrule, souvent enlevée par Ganon et sauvée par Link.",
                DescriptionLong = "Zelda est intelligente et sage, possédant souvent des pouvoirs magiques liés à la Triforce. Elle guide Link et joue un rôle central dans la lutte contre les forces du mal.",
                Role = "Princesse",
                Emoji = "👸",
                Couleur = "#FFD700",
                Importance = "Clé de l'histoire",
                Image = ""
            });
            _database.Insert(new Personnage {
                Nom = "Ganon",
                DescriptionCourt = "L'antagoniste principal de la série, souvent représenté comme un puissant sorcier ou un démon.",
                DescriptionLong = "Ganon est l'ennemi juré de Link et Zelda. Maître de la magie noire, il cherche à conquérir Hyrule et à s'emparer de la Triforce. Son pouvoir et sa ruse en font un adversaire redoutable.",
                Role = "Antagoniste",
                Emoji = "👹",
                Couleur = "#FF0000",
                Importance = "Principal antagoniste",
                Image = "cristaux_de_gratitude.jpg"
            });
            _database.Insert(new Personnage {
                Nom = "Impa",
                DescriptionCourt = "Une membre du clan Sheikah, souvent protectrice de la princesse Zelda.",
                DescriptionLong = "Impa est une guerrière loyale et sage, veillant sur la princesse Zelda depuis son enfance. Elle maîtrise de nombreuses techniques de combat et possède des connaissances secrètes du clan Sheikah.",
                Role = "Protectrice",
                Emoji = "🛡️",
                Couleur = "#0000FF",
                Importance = "Secondaire",
                Image = ""
            }); 
            _database.Insert(new Personnage {
                Nom = "Celestrier",
                DescriptionCourt = "Chaque habitant de Célesbourg possède son propre célestrier, qu'il appelle en sifflant et monte pour voyager dans le Ciel.",
                DescriptionLong = "Les célestriers sont des montures volantes rapides et intelligentes, permettant de voyager dans le Ciel. Ils sont fidèles à leur cavalier et jouent un rôle essentiel dans le quotidien de Célesbourg.",
                Role = "Monture",
                Emoji = "🦅",
                Couleur = "#A52A2A",
                Importance = "Secondaire",
                Image = ""
            });

            _database.Insert(new Objet 
            {
                Nom = "Épée de Légende",
                DescriptionCourt = "L’arme principale de Link, qui évolue au fil de l’aventure jusqu’à devenir la Master Sword.",
                DescriptionLong = "L’Épée de Légende est l’arme légendaire de Link, capable de repousser les forces du mal. Elle doit être purifiée et améliorée au cours de l’aventure pour atteindre sa forme finale, la Master Sword.",
                Emoji = "🗡️",
                Couleur = "#00FF00",
                Type = "Arme",
                Importance = "Clé de l’aventure",
                Image = ""
            });
            _database.Insert(new Objet {
                Nom = "Bouclier Hylien",
                DescriptionCourt = "Le bouclier emblématique de Link pour se protéger des attaques.",
                DescriptionLong = "Le Bouclier Hylien est robuste et résistant aux attaques magiques et physiques. Il est indispensable pour affronter les ennemis puissants et protéger Link lors de ses aventures.",
                Emoji = "🛡️",
                Couleur = "#0000FF",
                Type = "Bouclier",
                Importance = "Indispensable",
                Image = ""
            });
            _database.Insert(new Objet {
                Nom = "Scarabée",
                DescriptionCourt = "Petit insecte mécanique télécommandé par Link. Sert à activer des mécanismes et ramasser des objets.",
                DescriptionLong = "Le Scarabée est un gadget mécanique permettant d'activer des interrupteurs à distance, de récupérer des objets dans des zones difficiles d'accès et de résoudre des énigmes complexes.",
                Emoji = "🐞",
                Couleur = "#9b59b6",
                Type = "Gadget",
                Importance = "Très utile",
                Image = ""
            });
            _database.Insert(new Objet {
                Nom = "Arc",
                DescriptionCourt = "Permet de tirer des flèches avec précision, utile contre les ennemis volants ou éloignés.",
                DescriptionLong = "L'Arc est une arme à distance qui permet de toucher des ennemis depuis la sécurité. Il peut être amélioré avec différents types de flèches et joue un rôle crucial dans les combats stratégiques.",
                Emoji = "🏹",
                Couleur = "#8e44ad",
                Type = "Arme",
                Importance = "Très utile",
                Image = ""
            });
            _database.Insert(new Quete
            {
                Nom = "Cristaux de gratitude",
                DescriptionCourt = "Petites quêtes annexes confiées par les habitants de Célesbourg. Chaque mission réussie donne des cristaux à échanger contre des récompenses.",
                DescriptionLong = "Les Cristaux de gratitude sont des objets spéciaux que Link obtient en aidant les habitants de Célesbourg et des environs. Ces quêtes annexes consistent à résoudre les problèmes des habitants, de jour comme de nuit. Une fois les quêtes accomplies, Link reçoit un ou plusieurs cristaux qu’il peut rapporter à Morcego (le démon vivant sous Célesbourg). En les échangeant, Morcego se rapproche de son rêve : devenir humain, et Link reçoit de précieuses récompenses.",
                Emoji = "💖",
                Couleur = "#f39c12",
                Objectif = "Aider les habitants de Célesbourg et des environs pour obtenir tous les 80 Cristaux de gratitude.",
                Recompense = "Différentes récompenses offertes par Morcego : Portefeuille moyen (5 cristaux), Grand portefeuille (10), Portefeuille géant (30), 300 rubis (30), Rubis d'argent (40), Rubis d'or (70), et le Cristal de démon (80).",
                Image = "cristaux_de_gratitude.jpg"
            });
            _database.Insert(new Quete
            {
                Nom = "Livre d'amour de Bertie",
                DescriptionCourt = "Une quête romantique où Link doit choisir entre deux prétendants amoureux de la même personne.",
                DescriptionLong = "Cawlin, l’un des apprentis chevaliers de Célesbourg, est amoureux de Karane, une élève de l’Académie. Il demande à Link de lui remettre une lettre d’amour. Cependant, un autre prétendant, Peater, est lui aussi épris de Karane. Link doit choisir à qui remettre la lettre. Selon le choix, la quête prend une tournure différente : Karane peut tomber amoureuse de Peater, ou Cawlin finit effrayé par un fantôme s’il ne reçoit pas de réponse. Une quête pleine d’humour et de dilemmes !",
                Emoji = "📖",
                Couleur = "#e74c3c",
                Objectif = "Remettre la lettre de Cawlin à Karane ou la donner à Peater, et assumer les conséquences du choix.",
                Recompense = "5 Cristaux de gratitude offerts par Peater si la quête est terminée avec succès.",
                Image = ""
            });
            _database.Insert(new Quete
            {
                Nom = "Quête des citrouilles",
                DescriptionCourt = "Au restaurant de la Citrouille perchée, Link doit travailler pour rembourser les pots cassés en servant les clients ou en transportant des citrouilles.",
                DescriptionLong = "Lors de sa visite à la Citrouille perchée, Link casse accidentellement un énorme chandelier, provoquant la colère du propriétaire, Pumm. Pour rembourser les dégâts, Link doit effectuer plusieurs petits boulots : transporter des citrouilles, servir les clients ou jouer de la harpe. En accomplissant toutes les tâches, Pumm finit par lui confier une mission spéciale liée à la Citrouille céleste.",
                Emoji = "🎃",
                Couleur = "#27ae60",
                Objectif = "Aider le propriétaire Pumm de la Citrouille perchée en accomplissant ses tâches jusqu’à remboursement complet des dégâts.",
                Recompense = "Cristaux de gratitude, accès à la mission de la Citrouille céleste et reconnaissance de Pumm.",
                Image = ""
            });
            _database.Insert(new Quete
            {
                Nom = "Défi de l'île Bambou",
                DescriptionCourt = "Un mini-jeu où Link doit couper le plus de bambous possible en un coup de sabre pour gagner des récompenses.",
                DescriptionLong = "Sur l'île Bambou, Peater propose à Link de tester son adresse à l'épée. Le principe est simple : trancher un bambou géant autant de fois que possible avant qu’il ne tombe. Plus le nombre de coupes est élevé, plus la récompense est importante. C’est un excellent moyen de perfectionner les coups d'épée et de gagner des rubis ou des cristaux.",
                Emoji = "🎋",
                Couleur = "#87ceeb",
                Objectif = "Obtenir le meilleur score possible en tranchant le bambou plusieurs fois d’affilée.",
                Recompense = "Cristaux de gratitude et rubis selon le score obtenu.",
                Image = ""
            });
            _database.Insert(new Quete
            {
                Nom = "Chasse aux insectes",
                DescriptionCourt = "Une quête confiée par Terry où Link doit capturer divers insectes rares disséminés dans les régions du monde.",
                DescriptionLong = "Terry, le marchand volant, demande à Link de l’aider à compléter sa collection d’insectes rares. À l’aide du filet, Link doit parcourir les différentes régions de Skyloft et des Terres Inférieures pour attraper chaque espèce. Certains insectes apparaissent seulement à des moments précis ou dans des lieux isolés, ce qui rend la quête longue mais gratifiante.",
                Emoji = "🐞",
                Couleur = "#9b59b6",
                Objectif = "Attraper toutes les espèces d’insectes et les rapporter à Terry pour compléter sa collection.",
                Recompense = "Rubis, cristaux de gratitude et améliorations de potions grâce aux insectes capturés.",
                Image = ""
            });
            _database.Insert(new Quete
            {
                Nom = "Harpe de la Déesse",
                DescriptionCourt = "Quêtes musicales où Link doit jouer de la harpe pour réveiller les Dragons et ouvrir de nouveaux chemins.",
                DescriptionLong = "Link reçoit la Harpe de la Déesse de Zelda. En voyageant à travers les terres, il doit jouer des mélodies sacrées à différents endroits pour invoquer les Dragons protecteurs et activer les symboles de la Déesse. Chaque mélodie ouvre un nouveau chemin ou révèle un passage secret, rapprochant Link de son destin.",
                Emoji = "🎶",
                Couleur = "#3498db",
                Objectif = "Utiliser la Harpe de la Déesse pour réveiller les Dragons et progresser dans la quête principale.",
                Recompense = "Avancée dans la quête principale, activation de nouvelles zones et révélation des symboles sacrés.",
                Image = ""
            });

            _database.Insert(new Lieu {
                Nom = "Célesbourg",
                DescriptionCourt = "Un village flottant dans le ciel, habité par des humains et des célestriers.",
                DescriptionLong = "Célesbourg est le village principal des habitants du ciel. On y trouve des maisons flottantes et des commerces où les voyageurs peuvent se reposer avant d'explorer d'autres régions célestes.",
                Region = "Ciel",
                Emoji = "🏘️",
                Couleur = "#87ceeb",
                Importance = "Capitale régionale",
                Image = ""

            });

            _database.Insert(new Lieu {
                Nom = "Forêt de Firone",
                DescriptionCourt = "Une vaste forêt mystérieuse, souvent le point de départ des aventures de Link.",
                DescriptionLong = "La Forêt de Firone est dense et magique, remplie de créatures étranges et de secrets cachés. Les aventuriers doivent faire attention aux embuscades et aux énigmes naturelles qui s'y trouvent.",
                Region = "Hyrule",
                Emoji = "🌲",
                Couleur = "#27ae60",
                Importance = "Point de départ des aventures",
                Image = ""
            });

            _database.Insert(new Lieu {
                Nom = "Volcan d'Ordinn",
                DescriptionCourt = "Une montagne volcanique dangereuse, abritant des ennemis puissants et des trésors cachés.",
                DescriptionLong = "Le Volcan d'Ordinn est un lieu ardent où la lave et les créatures de feu sont omniprésentes. Les aventuriers doivent être bien équipés pour survivre et trouver les trésors légendaires.",
                Region = "Hyrule",
                Emoji = "⛰️",
                Couleur = "#e74c3c",
                Importance = "Zone de haut niveau",
                Image = ""
            });
            _database.Insert(new Lieu {
                Nom = "Désert de Lanele",
                DescriptionCourt = "Un vaste désert aride, rempli de ruines anciennes et de créatures hostiles.",
                DescriptionLong = "Le Désert de Lanele est une étendue brûlante où le sable et les vents tourbillonnants mettent à l'épreuve la résistance des voyageurs. On y trouve des temples enfouis et des trésors anciens.",
                Region = "Hyrule",
                Emoji = "🏜️",
                Couleur = "#f39c12",
                Importance = "Exploration et énigmes",
                Image = ""
            });

            _database.Insert(new Lieu {
                Nom = "Temple du Temps",
                DescriptionCourt = "Un lieu sacré où le temps peut être manipulé, souvent lié à la légende de la Master Sword.",
                DescriptionLong = "Le Temple du Temps est un lieu emblématique, chargé d'histoire et de magie. Les aventuriers peuvent y apprendre des secrets anciens et trouver des reliques légendaires.",
                Region = "Hyrule",
                Emoji = "⏳",
                Couleur = "#9b59b6",
                Importance = "Clé de la légende",
                Image = ""
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

        public List<Lieu> GetLieuxDetails()
        {
            return _database.GetAllWithChildren<Lieu>(recursive: true)
                .OrderBy(x => x.Nom)
                .ToList();
        }

        public int SaveLieuxDetail(Lieu item)
        {
            if (item.Id != 0)
                return _database.Update(item);
            else
                return _database.Insert(item);
        }

        public int DeleteLieuxDetail(Lieu item)
        {
            return _database.Delete(item);
        }



        public ObservableCollection<Personnage> Personnages { get; set; }
        public ObservableCollection<Objet> Objets { get; set; }
        public ObservableCollection<Quete> Quetes { get; set; }
        public ObservableCollection<Lieu> Lieux { get; set; }
    }

}
