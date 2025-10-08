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
        public string? Description { get; set; }
        public string? Region { get; set; }
        public string? Emoji { get; set; }
    }
}
