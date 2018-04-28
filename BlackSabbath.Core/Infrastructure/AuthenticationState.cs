using Xamarin.Auth;

namespace BlackSabbath.Core.Infrastructure
{
    public static class AuthenticationState
    {
        public static OAuth2Authenticator Authenticator { get; set; }
        public static UserInformation UserInformation { get; set; }
    }
}
