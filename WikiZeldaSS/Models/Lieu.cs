using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace WikiZeldaSS.Models
{
    public class Lieu
    {
        [PrimaryKey, AutoIncrement] public int Id { get; set; }
        public string? Nom { get; set; }
        public string? DescriptionCourt { get; set; }
        public string? DescriptionLong { get; set; }
        public string? Region { get; set; }
        public string? Emoji { get; set; }
        public string? Couleur { get; set; }
        public string? Image { get; set; }
        public string? Importance { get; set; } 



    }
}
