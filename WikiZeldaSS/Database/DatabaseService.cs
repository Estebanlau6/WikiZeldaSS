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
            _database.DeleteAll<Lieu>();
            _database.DeleteAll<Personnage>();
            _database.DeleteAll<Objet>();
            _database.DeleteAll<Quete>();
            _database.CreateTable<Quete>();
            _database.CreateTable<Objet>();
            _database.CreateTable<Lieu>();
            _database.CreateTable<Personnage>();
            if (!_database.GetAllWithChildren<Lieu>().Any())
            {
                _database.Insert(new Lieu
                {
                    Nom = "Célesbourg",
                    DescriptionCourt = "Une île flottante dans le ciel, servant de village principal.",
                    DescriptionLong = "Célesbourg est le point de départ de Link et le hub central du jeu. C'est un village paisible flottant au-dessus des nuages, protégé par la Déesse Hylia. On y trouve la place du marché, l'École de Chevalerie et la majestueuse Statue de la Déesse.",
                    Region = "Le Ciel",
                    Emoji = "🏘️",
                    Couleur = "#87ceeb",
                    Image = "celesbourg.jpg",
                    Donjons = "Aucun (Hub principal)",
                    Habitants = "Hyliens (Célesbourgeois), Célestriers",
                    Mecanique = "Vol en Célestrier, Quêtes secondaires, Commerces",
                    ObjetsObtenus = "Épée d'entraînement, Bouclier, Fiole Vide"
                });

                _database.Insert(new Lieu
                {
                    Nom = "Forêt de Firone",
                    DescriptionCourt = "Une forêt ancienne et luxuriante, première région de la Terre d'en Bas.",
                    DescriptionLong = "La Forêt de Firone est un lieu dense et magique, rempli de champignons géants et de cours d'eau. C'est le foyer des Kikwis, de curieuses créatures végétales. C'est ici que Link commence sa quête sur la terre ferme.",
                    Region = "Firone (Terre d'en Bas)",
                    Emoji = "🌲",
                    Couleur = "#27ae60",
                    Image = "firone.webp",
                    Donjons = "Temple de la Contemplation, Grand Arbre Sacré",
                    Habitants = "Kikwis, Bokoblins, Parella",
                    Mecanique = "Recherche (Kikwis), Nage sous-marine, Lierres",
                    ObjetsObtenus = "Lance-Pierre, Bouteille (offerte par la Doyenne)"
                });

                _database.Insert(new Lieu
                {
                    Nom = "Volcan d'Ordinn",
                    DescriptionCourt = "Une région volcanique aride, pleine de dangers et de peuples robustes.",
                    DescriptionLong = "Le Volcan d'Ordinn est une montagne périlleuse où la chaleur est si intense que les boucliers en bois peuvent brûler. Des rivières de lave et des éruptions fréquentes en font un lieu hostile, foyer des Mogmas, un peuple de taupes chasseurs de trésors.",
                    Region = "Ordinn (Terre d'en Bas)",
                    Emoji = "⛰️",
                    Couleur = "#e74c3c",
                    Image = "volcan.jpg",
                    Donjons = "Temple de la Terre, Grand Sanctuaire Ancien",
                    Habitants = "Mogmas, Bokoblins de feu, Lizalfos",
                    Mecanique = "Chaleur intense (dégâts), Glissades, Creuser",
                    ObjetsObtenus = "Gants Creuse-Tout, Sac de Bombes"
                });

                _database.Insert(new Lieu
                {
                    Nom = "Désert de Lanelle",
                    DescriptionCourt = "Un ancien océan asséché, où le temps peut être manipulé.",
                    DescriptionLong = "Autrefois un océan verdoyant, le Désert de Lanelle est maintenant une étendue de sable sans vie. Grâce aux Chronolithes, Link peut ramener des zones à leur état passé glorieux, révélant une technologie ancienne, des robots et une mer luxuriante.",
                    Region = "Lanelle (Terre d'en Bas)",
                    Emoji = "🏜️",
                    Couleur = "#f39c12",
                    Image = "lanelle.jpg",
                    Donjons = "Raffinerie de Lanelle, Temple du Temps",
                    Habitants = "Robots Anciens (LD-301), Dragon de Foudre Lanelle",
                    Mecanique = "Chronolithes (voyage temporel), Sables mouvants",
                    ObjetsObtenus = "Jarron Magique, Grappin, Gants de Puissance"
                });
            }
            if (!_database.GetAllWithChildren<Personnage>().Any())
            {

                if (!_database.GetAllWithChildren<Personnage>().Any())
                {
                    _database.Insert(new Personnage
                    {
                        Nom = "Link",
                        DescriptionCourt = "Le héros de Skyward Sword, un chevalier de Célesbourg.",
                        DescriptionLong = "Un jeune apprenti chevalier de Célesbourg, ami d'enfance de Zelda. Courageux et déterminé, il est choisi par l'Épée de la Déesse pour descendre sur la Terre d'en Bas à la recherche de Zelda et accomplir son destin.",
                        Emoji = "🗡️",
                        Couleur = "#00b894",
                        Image = "link.avif",
                        Race = "Hylien (Célesbourgeois)",
                        Role = "Héros, Porteur de l'Épée de la Déesse",
                        Localisation = "Célesbourg, Terre d'en Bas",
                        QueteAssociee = "La quête principale (Sauver Zelda)"
                    });

                    _database.Insert(new Personnage
                    {
                        Nom = "Zelda",
                        DescriptionCourt = "L'amie d'enfance de Link et la réincarnation de la Déesse Hylia.",
                        DescriptionLong = "Fille du directeur Gaepora, Zelda est une jeune femme joyeuse et spirituelle de Célesbourg. Elle est emportée par une tornade et se réveille sur la Terre d'en Bas, où elle doit accomplir un pèlerinage pour purifier son esprit en tant que réincarnation de la Déesse Hylia.",
                        Emoji = "👸",
                        Couleur = "#FFD700",
                        Image = "zelda.jpg",
                        Race = "Hylienne (Réincarnation de Hylia)",
                        Role = "Pivot de l'histoire, Prêtresse",
                        Localisation = "Célesbourg, Divers Temples (Terre d'en Bas)",
                        QueteAssociee = "La quête principale (Pèlerinage)"
                    });

                    _database.Insert(new Personnage
                    {
                        Nom = "Ghirahim",
                        DescriptionCourt = "L'antagoniste excentrique et autoproclamé 'Seigneur Démon'.",
                        DescriptionLong = "Ghirahim est le principal antagoniste qui poursuit Zelda. Excentrique, narcissique et sadique, il se bat avec une grâce démoniaque. Il cherche à utiliser Zelda pour ressusciter son véritable maître.",
                        Emoji = "💎",
                        Couleur = "#9b59b6",
                        Image = "ghirahim.webp", 
                        Race = "Esprit de l'Épée (Démoniaque)",
                        Role = "Antagoniste principal, Serviteur de l'Avatar",
                        Localisation = "Divers donjons (Lieu de combat)",
                        QueteAssociee = "Bloquer l'avancée de Link"
                    });

                    _database.Insert(new Personnage
                    {
                        Nom = "Impa",
                        DescriptionCourt = "La protectrice de Zelda et une servante dévouée de la Déesse.",
                        DescriptionLong = "Une guerrière Sheikah mystérieuse et stoïque. Elle apparaît pour la première fois jeune, guidant et protégeant Zelda lors de son pèlerinage sur la Terre d'en Bas. Elle fait preuve d'une grande sagesse et d'une loyauté indéfectible envers la Déesse.",
                        Emoji = "🛡️",
                        Couleur = "#3498db",
                        Image = "impa.avif",
                        Race = "Sheikah",
                        Role = "Protectrice, Guide Spirituel",
                        Localisation = "Temple de la Contemplation, Temple du Temps",
                        QueteAssociee = "Protéger Zelda, Guider Link"
                    });

                    _database.Insert(new Personnage
                    {
                        Nom = "Hergo",
                        DescriptionCourt = "La brute de l'École de Chevalerie et le rival auto-proclamé de Link.",
                        DescriptionLong = "D'abord une brute jalouse qui tourmente Link, Hergo subit une évolution de personnage majeure. Après avoir suivi Link sur la Terre d'en Bas, il devient un allié improbable, utilisant son ingéniosité (et le 'Catapulte-stop') pour aider Link à sa manière.",
                        Emoji = "💪",
                        Couleur = "#e67e22",
                        Image = "hergo.jpg",
                        Race = "Hylien (Célesbourgeois)",
                        Role = "Rival, Allié comique, Inventeur",
                        Localisation = "Célesbourg, Vallon du Sceau",
                        QueteAssociee = "Construction du Catapulte-stop"
                    });

                    _database.Insert(new Personnage
                    {
                        Nom = "Fay",
                        DescriptionCourt = "L'esprit de l'Épée de la Déesse (Master Sword).",
                        DescriptionLong = "Fay est un esprit analytique et logique créé par la Déesse Hylia, résidant dans l'Épée de la Déesse. Elle sert de guide à Link, lui fournissant des informations, des statistiques sur les ennemis et des conseils (souvent très évidents) pour l'aider dans sa quête.",
                        Emoji = "⚔️",
                        Couleur = "#5eaaa8",
                        Image = "fay.png", 
                        Race = "Esprit (Création de la Déesse)",
                        Role = "Guide, Partenaire, Esprit de l'Épée",
                        Localisation = "Dans l'épée de Link",
                        QueteAssociee = "Guider le Héros Élu"
                    });
                }

                if (!_database.GetAllWithChildren<Objet>().Any())
                {
                

                    if (!_database.GetAllWithChildren<Objet>().Any())
                    {
                        _database.Insert(new Objet
                        {
                            Nom = "Épée de la Déesse",
                            DescriptionCourt = "L'épée sacrée confiée à Link, destinée à devenir la Master Sword.",
                            DescriptionLong = "L'Épée de la Déesse est l'arme légendaire de Link dans Skyward Sword. Elle réside dans la Statue de la Déesse à Célesbourg. Elle permet de lancer l'Éclat Céleste et est nécessaire pour frapper les Chronolithes.",
                            Emoji = "🗡️",
                            Couleur = "#00b894",
                            Image = "epee.jpg",
                            Type = "Équipement (Arme)",
                            Utilisation = "Combat, Éclat Céleste, Activer les Chronolithes",
                            Localisation = "Statue de la Déesse (Célesbourg)",
                            Donjon = "Aucun (Hub)"
                        });

                        _database.Insert(new Objet
                        {
                            Nom = "Scarabée",
                            DescriptionCourt = "Un insecte mécanique télécommandé par Link.",
                            DescriptionLong = "Le Scarabée est un gadget mécanique permettant d'explorer à distance, d'activer des interrupteurs, de couper des cordes ou des toiles d'araignée, et de ramasser des objets inatteignables. Il peut être amélioré pour être plus rapide ou pour attaquer.",
                            Emoji = "🐞",
                            Couleur = "#9b59b6",
                            Image = "scarabe.png", 
                            Type = "Objet Clé / Gadget",
                            Utilisation = "Mécanismes, Exploration, Récupération d'objets",
                            Localisation = "Obtenu dans le Temple de la Contemplation",
                            Donjon = "Temple de la Contemplation"
                        });

                        _database.Insert(new Objet
                        {
                            Nom = "Jarre Magique",
                            DescriptionCourt = "Un pot ancien capable de souffler un vent puissant.",
                            DescriptionLong = "Trouvé dans le Désert de Lanelle, ce pot souffle un grand coup de vent. Il est essentiel pour enlever les tas de sable, étourdir les ennemis, faire tourner les hélices et propulser Link sur certaines plateformes.",
                            Emoji = "💨",
                            Couleur = "#a29bfe",
                            Image = "jarre.jpg",
                            Type = "Objet Clé / Gadget",
                            Utilisation = "Souffler du vent, Enlever le sable, Étourdir les ennemis",
                            Localisation = "Obtenu au Désert de Lanelle",
                            Donjon = "Raffinerie de Lanelle (Zone)"
                        });

                        _database.Insert(new Objet
                        {
                            Nom = "Grappin",
                            DescriptionCourt = "Permet de s'accrocher à des cibles spécifiques et à des lierres.",
                            DescriptionLong = "Le Grappin est un outil indispensable pour la mobilité. Il permet à Link de s'accrocher à des cibles spéciales ou à des murs de lierre pour traverser des gouffres ou atteindre des zones en hauteur. Il est aussi utilisé pour arracher les boucliers de certains ennemis.",
                            Emoji = "🦞",
                            Couleur = "#e74c3c",
                            Image = "grappin.jpg", 
                            Type = "Objet Clé / Gadget",
                            Utilisation = "Traverser, Atteindre des hauteurs, Combat",
                            Localisation = "Obtenu dans le Désert de Lanelle (Raffinerie)",
                            Donjon = "Raffinerie de Lanelle"
                        });

                        _database.Insert(new Objet
                        {
                            Nom = "Bouclier Hylien",
                            DescriptionCourt = "Le bouclier ultime et indestructible.",
                            DescriptionLong = "Contrairement aux autres jeux, le Bouclier Hylien dans Skyward Sword n'est pas trouvé dans un donjon. Il est indestructible et protège contre toutes les attaques (feu, électricité). Il s'obtient en récompense en terminant le Défi de l'Héroïsme du Dragon de Foudre Lanelle.",
                            Emoji = "🛡️",
                            Couleur = "#3498db",
                            Image = "bouclier.jpg",
                            Type = "Équipement (Bouclier)",
                            Utilisation = "Défense (Indestructible)",
                            Localisation = "Récompense du Dragon de Foudre (Mini-jeu)",
                            Donjon = "Aucun"
                        });
                    }
                }

                if (!_database.GetAllWithChildren<Quete>().Any())
                {

                    if (!_database.GetAllWithChildren<Quete>().Any())
                    {
                        _database.Insert(new Quete
                        {
                            Nom = "Cristaux de gratitude",
                            DescriptionCourt = "Petites quêtes annexes confiées par les habitants de Célesbourg à échanger contre des récompenses.",
                            DescriptionLong = "Les Cristaux de gratitude sont des objets spéciaux que Link obtient en aidant les habitants de Célesbourg. Ces quêtes annexes consistent à résoudre les problèmes des habitants. Une fois les quêtes accomplies, Link reçoit un ou plusieurs cristaux qu’il peut rapporter à Morcego (le démon vivant sous Célesbourg). En les échangeant, Link reçoit de précieuses récompenses.",
                            Emoji = "💖",
                            Couleur = "#f39c12",
                            Objectif = "Aider les habitants de Célesbourg et des environs pour obtenir tous les 80 Cristaux de gratitude.",
                            Recompense = "Portefeuilles améliorés, Rubis, Cristal de démon (80).",
                            Image = "cristaux.avif",
                            DonneurQuete = "Divers habitants de Célesbourg (Récompenses chez Morcego)",
                            Localisation = "Célesbourg (principalement)"
                        });

                        _database.Insert(new Quete
                        {
                            Nom = "La lettre de Cawlin",
                            DescriptionCourt = "Une quête romantique où Link doit choisir entre deux prétendants amoureux de Karane.",
                            DescriptionLong = "Cawlin, l’un des apprentis chevaliers de Célesbourg, est amoureux de Karane. Il demande à Link de lui remettre une lettre d’amour. Cependant, un autre prétendant, Peater, est lui aussi épris de Karane. Link doit choisir à qui remettre la lettre.",
                            Emoji = "💌",
                            Couleur = "#e74c3c",
                            Objectif = "Remettre la lettre de Cawlin à Karane ou la donner à Peater.",
                            Recompense = "5 Cristaux de gratitude.",
                            Image = "amour.jpg",
                            DonneurQuete = "Cawlin",
                            Localisation = "École de Chevalerie (Célesbourg)"
                        });

                        _database.Insert(new Quete
                        {
                            Nom = "La Citrouille Perchée",
                            DescriptionCourt = "Au restaurant, Link doit travailler pour rembourser le chandelier cassé.",
                            DescriptionLong = "Lors de sa visite à la Citrouille perchée, Link casse accidentellement un énorme chandelier. Pour rembourser les dégâts, Link doit effectuer plusieurs petits boulots : transporter des citrouilles, servir les clients ou jouer de la harpe.",
                            Emoji = "🎃",
                            Couleur = "#27ae60",
                            Objectif = "Aider le propriétaire Pumm en accomplissant ses tâches.",
                            Recompense = "Cristaux de gratitude, accès à la mission de la Citrouille céleste.",
                            Image = "citrouilles.jpg",
                            DonneurQuete = "Pumm (Propriétaire)",
                            Localisation = "La Citrouille Perchée (Île)"
                        });

                        _database.Insert(new Quete
                        {
                            Nom = "Défi de l'île Bambou",
                            DescriptionCourt = "Un mini-jeu où Link doit couper le plus de bambous possible.",
                            DescriptionLong = "Sur l'île Bambou, Peater propose à Link de tester son adresse à l'épée. Le principe est simple : trancher un bambou géant autant de fois que possible avant qu’il ne tombe. Plus le nombre de coupes est élevé, plus la récompense est importante.",
                            Emoji = "🎋",
                            Couleur = "#87ceeb",
                            Objectif = "Obtenir le meilleur score possible en tranchant le bambou.",
                            Recompense = "Rubis ou Trésors (selon le score)",
                            Image = "bamboux.jpg",
                            DonneurQuete = "Peater",
                            Localisation = "Île Bambou (Le Ciel)"
                        });

                        _database.Insert(new Quete
                        {
                            Nom = "Chasse aux insectes",
                            DescriptionCourt = "Une quête confiée par Terry où Link doit capturer divers insectes rares.",
                            DescriptionLong = "Terry, le marchand volant, demande à Link de l’aider à compléter sa collection d’insectes rares. À l’aide du filet, Link doit parcourir les différentes régions pour attraper chaque espèce. En échange, Terry offre des réductions ou des récompenses.",
                            Emoji = "🐞",
                            Couleur = "#9b59b6",
                            Objectif = "Attraper toutes les espèces d’insectes et les rapporter à Terry.",
                            Recompense = "Rubis, améliorations de potions (via les insectes).",
                            Image = "insectes.webp",
                            DonneurQuete = "Terry",
                            Localisation = "Boutique de Terry / Toutes les régions"
                        });

                        _database.Insert(new Quete
                        {
                            Nom = "Harpe de la Déesse",
                            DescriptionCourt = "Quêtes musicales où Link doit jouer de la harpe pour progresser.",
                            DescriptionLong = "Link reçoit la Harpe de la Déesse de Zelda. En voyageant à travers les terres, il doit jouer des mélodies sacrées à différents endroits pour invoquer les Dragons protecteurs et activer les symboles de la Déesse.",
                            Emoji = "🎶",
                            Couleur = "#3498db",
                            Objectif = "Utiliser la Harpe de la Déesse pour réveiller les Dragons.",
                            Recompense = "Avancée dans la quête principale.",
                            Image = "harpes.webp",
                            DonneurQuete = "Zelda / Impa (Quête principale)",
                            Localisation = "Terre d'en Bas (Lieux de Sceaux)"
                        });
                    }
                }
            }
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
