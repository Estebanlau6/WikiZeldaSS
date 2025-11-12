using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace WikiZeldaSS.Models
{
    public class Personnage
    {
        [PrimaryKey, AutoIncrement] public int Id { get; set; }
        public string? Nom { get; set; }
        public string? DescriptionCourt { get; set; }
        public string? DescriptionLong { get; set; }
        public string? Role { get; set; }
        public string? Emoji { get; set; }
        public string? Couleur { get; set; }
        public string? Importance { get; set; }
        public string? Image { get; set; }

        public string?  Race { get; set; }

        public string? Localisation { get; set; }

        public string? QueteAssociee { get; set; }

    }
}
