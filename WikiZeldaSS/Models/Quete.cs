using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace WikiZeldaSS.Models
{
    public class Quete
    {
        [PrimaryKey, AutoIncrement] public int Id { get; set; }
        public string? Nom { get; set; }
        public string? DescriptionCourt { get; set; }
        public string? DescriptionLong { get; set; }
        public string? Objectif { get; set; }
        public string? Recompense { get; set; }
        public string? Emoji { get; set; }
        public string? Couleur { get; set; }
        public string? Image { get; set; }

        public string DonneurQuete { get; set; }

        public string Localisation { get; set; }


    }
}
