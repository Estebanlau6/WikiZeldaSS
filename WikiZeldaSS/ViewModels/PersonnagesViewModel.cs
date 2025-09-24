using System.Collections.ObjectModel;
using WikiZeldaSS.Models;

namespace WikiZeldaSS.ViewModels
{
    public class PersonnagesViewModel
    {
        public ObservableCollection<Personnage> Personnages { get; set; }

        public PersonnagesViewModel()
        {
            Personnages = new ObservableCollection<Personnage>
            {
                new Personnage { Nom = "Link", Description = "Le héros de l'aventure. Étudiant à l'Académie des Chevaliers.", Role = "Héros", Emoji = "🗡️" },
                new Personnage { Nom = "Zelda", Description = "Princesse et réincarnation de la déesse Hylia.", Role = "Princesse", Emoji = "👸" },
                new Personnage { Nom = "Ghirahim", Description = "Le Seigneur Démon, antagoniste principal.", Role = "Antagoniste", Emoji = "👹" },
                new Personnage { Nom = "Fi", Description = "L'esprit de l'Épée Divine qui guide Link.", Role = "Guide", Emoji = "⚔️" },
                new Personnage { Nom = "Impa", Description = "Gardienne Sheikah protectrice de Zelda.", Role = "Gardienne", Emoji = "🛡️" }
            };
        }
    }
}