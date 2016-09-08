using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace PokemonSwitch.DB
{
    [Table("Gate")]
    public class Gate
    {
        [PrimaryKey, Column("GateIndex")]
        public int GateIndex { get; set; }
        [PrimaryKey, Column("LevelID")]
        public int LevelID { get; set; }
        [Column("Map")]
        public string Map { get; set; }
        [Column("Star")]
        public int Star { get; set; }
    }

    public class GateCell
    {
        public int GateIndex { get; set; }
        public string LevelDescription { get; set; }
        public int Star { get; set; }
        public string StarOne { get; set; }
        public string StarTwo { get; set; }
        public string StarThree { get; set; }

    }
}
