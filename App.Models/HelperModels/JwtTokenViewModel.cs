namespace App.Models.AppModels
{
    public class JwtTokenViewModel
    {
        public string Id { get; set; }
        public string AuthToken { get; set; }
        public string RefreshToken { get; set; }
        public int ExpiresIn { get; set; }
    }
}
