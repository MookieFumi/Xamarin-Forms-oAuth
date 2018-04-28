using System;
using BlackSabbath.Core.Infrastructure;
using Foundation;
using UIKit;

namespace BlackSabbath.Core.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            global::Xamarin.Auth.Presenters.XamarinIOS.AuthenticationConfiguration.Init();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }


        public override bool OpenUrl(UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
        {
            // Convert iOS NSUrl to C#/netxf/BCL System.Uri - common API
            Uri uri_netfx = new Uri(url.AbsoluteString);

            // load redirect_url Page for parsing
            AuthenticationState.Authenticator.OnPageLoading(uri_netfx);

            return true;
        }
    }
}
