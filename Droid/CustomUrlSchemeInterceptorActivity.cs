using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using BlackSabbath.Core.Infrastructure;

namespace BlackSabbath.Core.Droid
{
    [Activity(NoHistory = true, LaunchMode = LaunchMode.SingleTop)]
    [IntentFilter(
            actions: new[] { Intent.ActionView },
            Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable },
            DataSchemes = new[]
                    {
                        "com.mookiefumi.blacksabbath",
                        "com.googleusercontent.apps.480489795646-1j0r1cdmi7g9bvrqp7j1hm8k970mbq4c",
                        "urn:ietf:wg:oauth:2.0:oob"
                    },
            DataPaths = new[] { "/oauth2redirect" },
            AutoVerify = true
    )]
    public class CustomUrlSchemeInterceptorActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            global::Android.Net.Uri uri_android = Intent.Data;

            Uri uri_netfx = new Uri(uri_android.ToString());

            //Hack
            new Task(() =>
            {
                var intent = new Intent(ApplicationContext, typeof(MainActivity));
                intent.AddFlags(ActivityFlags.ClearTop);
                intent.AddFlags(ActivityFlags.SingleTop);
                StartActivity(intent);
            }).Start();

            // load redirect_url Page
            AuthenticationState.Authenticator.OnPageLoading(uri_netfx);

            Finish();
        }
    }
}
