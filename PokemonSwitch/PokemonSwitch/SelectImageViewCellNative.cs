using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PokemonSwitch
{
    public class SelectImageViewCellNative : ViewCell
    {
        public static readonly BindableProperty PairIndexProperty =
            BindableProperty.Create("PairIndex", typeof(int), typeof(SelectImageViewCellNative), -1);
        public int PairIndex
        {
            get { return (int)GetValue(PairIndexProperty); }
            set { SetValue(PairIndexProperty, value); }
        }

        public static readonly BindableProperty PairNameProperty =
            BindableProperty.Create("PairName", typeof(string), typeof(SelectImageViewCellNative), "");
        public string PairName
        {
            get { return (string)GetValue(PairNameProperty); }
            set { SetValue(PairNameProperty, value); }
        }

        public static readonly BindableProperty Image1Property =
            BindableProperty.Create("Image1", typeof(string), typeof(SelectImageViewCellNative), "");
        public string Image1
        {
            get { return (string)GetValue(Image1Property); }
            set { SetValue(Image1Property, value); }
        }

        public static readonly BindableProperty Image2Property =
            BindableProperty.Create("Image2", typeof(string), typeof(SelectImageViewCellNative), "");
        public string Image2
        {
            get { return (string)GetValue(Image2Property); }
            set { SetValue(Image2Property, value); }
        }
    }
}
