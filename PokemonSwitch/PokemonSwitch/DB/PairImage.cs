using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonSwitch.DB
{
    [Table("PairImage")]
    public class PairImage
    {
        [PrimaryKey, Column("PairName")]
        public string PairName { get; set; }
    }

    public class PairImageCell
    {
        public int PairIndex { get; set; }
        public string PairName { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
    }
}
