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
using Xamarin.Forms;
using PokemonSwitch.Droid;
using System.Threading.Tasks;
using Android.Graphics.Drawables;
using PokemonSwitch;

[assembly: ExportRenderer(typeof(SelectImageViewCellNative), typeof(SelectImageViewCellRender))]


namespace PokemonSwitch.Droid
{
    public class SelectImageViewCellRender : ViewCellRenderer
    {
        public SelectImageViewCellRender() { }

        void DisposeImage(Android.Content.Context context, Android.Views.View view, int imageResourceID, string strImageName)
        {
            // grab the old image and dispose of it
            // TODO: optimize if the image is the *same* and we want to just keep it
            if (view.FindViewById<ImageView>(imageResourceID).Drawable != null)
            {
                using (var image = view.FindViewById<ImageView>(imageResourceID).Drawable as BitmapDrawable)
                {
                    if (image != null)
                    {
                        if (image.Bitmap != null)
                        {
                            //image.Bitmap.Recycle ();
                            image.Bitmap.Dispose();
                        }
                    }
                }
            }

            // If a new image is required, display it
            if (!String.IsNullOrWhiteSpace(strImageName))
            {
                context.Resources.GetBitmapAsync(strImageName).ContinueWith((t) => {
                    var bitmap = t.Result;
                    if (bitmap != null)
                    {
                        view.FindViewById<ImageView>(imageResourceID).SetImageBitmap(bitmap);
                        bitmap.Dispose();
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());

            }
            else
            {
                // clear the image
                view.FindViewById<ImageView>(imageResourceID).SetImageBitmap(null);
            }
        }

        protected override Android.Views.View GetCellCore(Xamarin.Forms.Cell item, Android.Views.View convertView, Android.Views.ViewGroup parent, Android.Content.Context context)
        {
            var x = (SelectImageViewCellNative)item;

            var view = convertView;

            if (view == null)
            {// no view to re-use, create new
                view = (context as Activity).LayoutInflater.Inflate(Resource.Layout.SelectImageNativeViewCell, null);
            }
            else
            { // re-use, clear image
              // doesn't seem to help
              //view.FindViewById<ImageView> (Resource.Id.Image).Drawable.Dispose ();
            }

            view.FindViewById<TextView>(Resource.Id.Text1).Text = x.PairIndex.ToString();
            view.FindViewById<TextView>(Resource.Id.Text2).Text = x.PairName;

            DisposeImage(context, view, Resource.Id.Image1, x.Image1);
            DisposeImage(context, view, Resource.Id.Image2, x.Image2);
            return view;
        }

    }
}