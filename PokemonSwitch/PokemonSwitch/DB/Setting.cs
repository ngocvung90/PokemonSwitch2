using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace PokemonSwitch.DB
{
    [Table("Setting")]
    public class Setting
    {
        [PrimaryKey, Column("ID")]
        public int ID { get; set; }
        [Column("LevelID")]
        public int LevelID { get; set; }
        [Column("GateIndex")]
        public int GateIndex { get; set; }
        [Column("PairImageName")]
        public string PairImageName { get; set; }
        [Column("ShowTipPopup")]
        public int ShowTipPopup { get; set; }
        [Column("ShowWelcomePopup")]
        public int ShowWelcomePopup { get; set; }
    }
}
