﻿using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using System.Text;
using SQLite.Net.Platform.XamarinIOS;

namespace PokemonSwitch.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());
            var fontList = new StringBuilder();
            var familyNames = UIFont.FamilyNames;
            foreach (var familyName in familyNames)
            {
                fontList.Append($"Family: {familyName}\n");
                Console.WriteLine("Family: {0}\n", familyName);
                var fontNames = UIFont.FontNamesForFamilyName(familyName);
                foreach (var fontName in fontNames)
                {
                    Console.WriteLine("\tFont: {0}\n", fontName);
                    fontList.Append($"\tFont: {fontName}\n");
                }
            };

            string dbPath = FileAccessHelper.GetLocalFilePath("PS.db3");

            LoadApplication(new App(dbPath, new SQLitePlatformIOS()));


            return base.FinishedLaunching(app, options);
        }
    }
}
