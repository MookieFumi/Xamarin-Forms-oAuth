using System;
using System.IO;
using System.Linq;
using BlackSabbath.Core.Infrastructure;
using Newtonsoft.Json;
using Xamarin.Auth;
using Xamarin.Auth.Presenters;
using Xamarin.Forms;
using BlackSabbath.Core.ViewModels;

namespace BlackSabbath.Core
{
    public partial class MainPage : ContentPage
    {
        private const string ServiceId = "Google";

        public MainPage()
        {
            InitializeComponent();

            var mainViewModel = new MainViewModel();
            BindingContext = mainViewModel;

            Button1.Clicked += (sender, args) =>
            {
                var presenter = new OAuthLoginPresenter();
                AuthenticationState.Authenticator = GetOAuth2Authenticator();
                AuthenticationState.Authenticator.Completed += (object a, AuthenticatorCompletedEventArgs e) =>
                {
                    mainViewModel.IsAuthenticated = e.IsAuthenticated;

                    if (e.IsAuthenticated)
                    {
                        var accessToken = e.Account.Properties.SingleOrDefault(p => p.Key == "access_token").Value;
                        mainViewModel.AccessToken = accessToken;

                        var refreshToken = e.Account.Properties.SingleOrDefault(p => p.Key == "refresh_token").Value;
                        mainViewModel.RefreshToken = refreshToken;

                        var token = e.Account.Properties.SingleOrDefault(p => p.Key == "id_token").Value;
                        AuthenticationState.UserInformation = GetUserInformation(token);

                        mainViewModel.Name = AuthenticationState.UserInformation.Name;
                        mainViewModel.Email = AuthenticationState.UserInformation.Email;
                        mainViewModel.Picture = AuthenticationState.UserInformation.Picture;

                        //TODO En IOS excepción
                        //AccountStore.Create().SaveAsync(e.Account, ServiceId);
                    }
                };
                AuthenticationState.Authenticator.Error += (a, e) =>
                {

                };

                presenter.Login(AuthenticationState.Authenticator);

            };

        }

        private UserInformation GetUserInformation(string token)
        {
            byte[] decodedBytes = Convert.FromBase64String(token.Split('.')[1]);
            var memoryStream = new MemoryStream(decodedBytes);
            var value = new StreamReader(memoryStream).ReadToEnd();

            return JsonConvert.DeserializeObject<UserInformation>(value);
        }

        private OAuth2Authenticator GetOAuth2Authenticator()
        {
            string clientId = string.Empty;
            string redirectUrl = string.Empty;

            if (Device.RuntimePlatform == Device.iOS)
            {
                clientId = "480489795646-6m6mmt57mtkgne9jib710f6gvd65c0du";
            }
            else if (Device.RuntimePlatform == Device.Android)
            {
                clientId = "480489795646-1j0r1cdmi7g9bvrqp7j1hm8k970mbq4c";
            }
            redirectUrl = $"com.googleusercontent.apps.{clientId}:/oauth2redirect";

            return new OAuth2Authenticator(
                clientId: $"{clientId}.apps.googleusercontent.com",
                clientSecret: null,
                scope: @"openid email profile",
                authorizeUrl: new System.Uri("https://accounts.google.com/o/oauth2/v2/auth"),
                accessTokenUrl: new System.Uri("https://www.googleapis.com/oauth2/v4/token"),
                redirectUrl: new System.Uri(redirectUrl),
                isUsingNativeUI: true
            );
        }
    }
}
