using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PokemonSwitch
{
    public class SelectLevelViewCellNative : ViewCell 
    {
        public static readonly BindableProperty LevelIDProperty =
          BindableProperty.Create("LevelID", typeof(int), typeof(SelectLevelViewCellNative), -1);
        public int LevelID
        {
            get { return (int)GetValue(LevelIDProperty); }
            set { SetValue(LevelIDProperty, value); }
        }

        public static readonly BindableProperty LevelDescriptionProperty =
            BindableProperty.Create("LevelDescription", typeof(string), typeof(SelectLevelViewCellNative), "");
        public string LevelDescription
        {
            get { return (string)GetValue(LevelDescriptionProperty); }
            set { SetValue(LevelDescriptionProperty, value); }
        }

        public static readonly BindableProperty GateNumberProperty =
            BindableProperty.Create("GateNumber", typeof(string), typeof(SelectLevelViewCellNative), "");
        public string GateNumber
        {
            get { return (string)GetValue(GateNumberProperty); }
            set { SetValue(GateNumberProperty, value); }
        }
    }
}
