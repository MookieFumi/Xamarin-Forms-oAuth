using BlackSabbath.Core.ViewModels.Base;

namespace BlackSabbath.Core.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private string _name;
        private string _email;
        private string _picture;
        private string _accessToken;
        private string _refreshToken;
        private bool _isAuthenticated;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                RaisePropertyChanged(nameof(Email));
            }
        }

        public string Picture
        {
            get { return _picture; }
            set
            {
                _picture = value;
                RaisePropertyChanged(nameof(Picture));
            }
        }

        public string AccessToken
        {
            get { return _accessToken; }
            set
            {
                _accessToken = value;
                RaisePropertyChanged(nameof(AccessToken));
            }
        }

        public string RefreshToken
        {
            get { return _refreshToken; }
            set
            {
                _refreshToken = value;
                RaisePropertyChanged(nameof(RefreshToken));
            }
        }

        public bool IsAuthenticated
        {
            get { return _isAuthenticated; }
            set
            {
                _isAuthenticated = value;
                RaisePropertyChanged(nameof(IsAuthenticated));
            }
        }

    }
}
