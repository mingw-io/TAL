namespace IdentityService.Services
{
    using IdentityService.Helpers;
    using IdentityService.Models;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.Collections.Generic;

    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;

    /// <summary>
    /// 
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Models.SecurityToken Authenticate(string username, string password);
    }

    /// <summary>
    /// 
    /// </summary>
    public sealed class UserService : IUserService
    {
        // NOTE: The list of users can (or should) come from a DB.
        //       For the sake of this exercise, a static list is provided
        //       However, the Member.Microservices project fetches data from MS SQL Server
        private List<User> _users = new List<User>
        {
            new User { Id = 1, Email = "soma@mail.net", DisplayName = "Soma Theganahally", Username = "soma", Password = "soma@123" },
            new User { Id = 2, Email = "sergio@mail.net", DisplayName = "Sergio CITIZEN", Username = "sergio", Password = "pass@123" }
        };

        private readonly AppSettings _appSettings;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appSettings"></param>
        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Models.SecurityToken Authenticate(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password)) return null;

            var user = _users.SingleOrDefault(x => x.Username == username && x.Password == password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("userId", user.Id.ToString()),
                    new Claim("email", user.Email),
                    new Claim("name", user.DisplayName)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtSecurityToken = tokenHandler.WriteToken(token);

            return new Models.SecurityToken() { accessToken = jwtSecurityToken, firstName = user.DisplayName, userId = user.Id };
        }
    }
}