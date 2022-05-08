namespace IdentityService.Models
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class SecurityToken
    {
        public string accessToken { get; set; }
        public string refreshToken { get; set; }

        public string firstName { get; set; }

        public int userId { get; set; }
    }
}