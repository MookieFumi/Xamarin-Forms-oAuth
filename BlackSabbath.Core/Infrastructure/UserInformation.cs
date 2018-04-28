namespace BlackSabbath.Core.Infrastructure
{
    public class UserInformation
    {
        public string Azp { get; set; }
        public string Aud { get; set; }
        public string Sub { get; set; }
        public string Email { get; set; }
        public bool EmailVerified { get; set; }
        public string AtHash { get; set; }
        public int Exp { get; set; }
        public string Iss { get; set; }
        public int Iat { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string Locale { get; set; }
    }
}
