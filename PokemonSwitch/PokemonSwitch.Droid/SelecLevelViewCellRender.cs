using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Android.Graphics.Drawables;
using System.Threading.Tasks;
using PokemonSwitch;
using PokemonSwitch.Droid;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(SelectLevelViewCellNative), typeof(SelecLevelViewCellRender))]

namespace PokemonSwitch.Droid
{
    class SelecLevelViewCellRender : ViewCellRenderer
    {
        public SelecLevelViewCellRender() { }
        protected override Android.Views.View GetCellCore(Xamarin.Forms.Cell item, Android.Views.View convertView, Android.Views.ViewGroup parent, Android.Content.Context context)
        {
            var x = (SelectLevelViewCellNative)item;

            var view = convertView;

            if (view == null)
            {// no view to re-use, create new
                view = (context as Activity).LayoutInflater.Inflate(Resource.Layout.SelectLevelNativeViewCell, null);
            }
            else
            { // re-use, clear image
              // doesn't seem to help
              //view.FindViewById<ImageView> (Resource.Id.Image).Drawable.Dispose ();
            }

            view.FindViewById<TextView>(Resource.Id.Text1).Text = x.LevelID.ToString();
            view.FindViewById<TextView>(Resource.Id.Text2).Text = x.LevelDescription;
            view.FindViewById<TextView>(Resource.Id.Text3).Text = x.GateNumber;
            return view;
        }
    }
}