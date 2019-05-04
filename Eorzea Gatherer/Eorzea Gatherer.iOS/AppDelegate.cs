using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace Eorzea_Gatherer.iOS
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

            //https://forums.xamarin.com/discussion/99122/how-to-set-color-to-icons-in-the-tabbedpage-in-ios
            // Color of the selected tab icon:
            UITabBar.Appearance.SelectedImageTintColor = UIColor.FromRGB(159, 38, 55);

            return base.FinishedLaunching(app, options);
        }
    }
}
