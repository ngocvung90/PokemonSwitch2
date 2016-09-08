using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonSwitch.DB
{
    [Table("Level")]
    public class Level
    {
        [PrimaryKey, Column("SolveStep")]
        public int SolveStep { get; set; }
        [Column("Description")]
        public string Description { get; set; }
        [Column("GateNumber")]
        public int GateNumber { get; set; }
    }
}
