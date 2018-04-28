# Xamarin Forms app using Google OAuth

![Xamarin Forms iOS][iOS]
![Xamarin Forms Android][Android]

[iOS]: iOS.gif
[Android]: Android.gif

It's was a litte pain in the ass because I had one project but I had to add two oAUth clients, one per each platform (Android/ iOS) because it's the way that Google works.

[Xamarin Auth](https://github.com/xamarin/Xamarin.Auth) is a nuget package to work with oAuth in Xamarin and it do the hard work with the oAuth flow. This libray includes the **OAuthLoginPresenter** that works in both platforms (it's not required to add custom UI in each platform) and the **OAuth2Authenticator** that allows us to handle the proccess with the events *Completed* and *Error*.

## To Remember

We have to manage the returnUrl of our OAuth2Authenticator in each platform, so in Android platform we have to use an activity interceptor that it's the place to setup the DataSchemes and DataPaths. 

```csharp
[IntentFilter(
        actions: new[] { Intent.ActionView },
        Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable },
        DataSchemes = new[]
                {
                    "com.mookiefumi.blacksabbath",
                    "com.googleusercontent.apps.[YOUR_CLIENT_ID]",
                    "urn:ietf:wg:oauth:2.0:oob"
                },
        DataPaths = new[] { "/oauth2redirect" },
        AutoVerify = true
)]
```

In iOS platform we have to add two Url Types in our Info.plist file (Advanced tab).

## Hacks

In Android platform the OAuthLoginPresenter uses CustomTabs. It doesn't work well so we have to call StartActicity int our CustomUrlSchemeInterceptorActivity because the browser is not closing automatically. 

```csharp
new Task(() =>
{
    var intent = new Intent(ApplicationContext, typeof(MainActivity));
    intent.AddFlags(ActivityFlags.ClearTop);
    intent.AddFlags(ActivityFlags.SingleTop);
    StartActivity(intent);
}).Start();
```

In iOS platform works without any issues.

# Summary

Why always the Android platform have so many hacks or issues?

# Links

[Google Cloud Platform](https://console.cloud.google.com)

[Xamarin Auth](https://github.com/xamarin/Xamarin.Auth)

[Google OpenId discover document](https://accounts.google.com/.well-known/openid-configuration)

[Google developers OAuth 2.0 Playground](https://developers.google.com/oauthplayground/)

[OpenID Connect Playground](https://openidconnect.net)

[Mobile authentication with Xamarin.Auth and refresh tokens](https://lostechies.com/jimmybogard/2014/11/13/mobile-authentication-with-xamarin-auth-and-refresh-tokens/)

