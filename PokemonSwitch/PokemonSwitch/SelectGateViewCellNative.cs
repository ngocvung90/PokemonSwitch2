using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PokemonSwitch
{
    public class SelectGateViewCellNative : ViewCell
    {
        public static readonly BindableProperty GateIndexProperty =
            BindableProperty.Create("GateIndex", typeof(int), typeof(SelectGateViewCellNative), -1);
        public int GateIndex
        {
            get { return (int)GetValue(GateIndexProperty); }
            set { SetValue(GateIndexProperty, value); }
        }

        public static readonly BindableProperty LevelDescriptionProperty =
            BindableProperty.Create("LevelDescription", typeof(string), typeof(SelectGateViewCellNative), "");
        public string LevelDescription
        {
            get { return (string)GetValue(LevelDescriptionProperty); }
            set { SetValue(LevelDescriptionProperty, value); }
        }

        public static readonly BindableProperty StarOneProperty =
            BindableProperty.Create("StarOne", typeof(string), typeof(SelectGateViewCellNative), "");
        public string StarOne
        {
            get { return (string)GetValue(StarOneProperty); }
            set { SetValue(StarOneProperty, value); }
        }

        public static readonly BindableProperty StarTwoProperty =
            BindableProperty.Create("StarTwo", typeof(string), typeof(SelectGateViewCellNative), "");
        public string StarTwo
        {
            get { return (string)GetValue(StarTwoProperty); }
            set { SetValue(StarTwoProperty, value); }
        }

        public static readonly BindableProperty StarThreeProperty =
            BindableProperty.Create("StarThree", typeof(string), typeof(SelectGateViewCellNative), "");
        public string StarThree
        {
            get { return (string)GetValue(StarThreeProperty); }
            set { SetValue(StarThreeProperty, value); }
        }
    }
}
