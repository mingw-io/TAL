
namespace IdentityService.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// 
    /// </summary>
    public sealed class Login
    {
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string Username { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}