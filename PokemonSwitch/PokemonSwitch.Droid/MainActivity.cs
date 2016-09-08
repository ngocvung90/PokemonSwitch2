using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using SQLite.Net.Platform.XamarinAndroid;

namespace PokemonSwitch.Droid
{
    [Activity(Label = "PokemonSwitch", Icon = "@drawable/icon", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            string dbPath = FileAccessHelper.GetLocalFilePath("PS.db3");

            LoadApplication(new App(dbPath, new SQLitePlatformAndroid()));
        }
    }
}

