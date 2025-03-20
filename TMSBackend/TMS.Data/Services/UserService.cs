using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using TMS.Data.DTO;
using TMS.Data.Interfaces;
using TMS.Data.Models;
using TMS.Data.Services.Interfaces;


namespace TMS.Data.Services
{

    public class UserService : IUserService
    {
        private readonly Microsoft.Extensions.Configuration.IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        private readonly ILogRepository _logRepository;

        public UserService(IUserRepository userRepository, IConfiguration configuration, ILogRepository logRepository)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _logRepository = logRepository;
        }


        public async Task<LoginResultDTO> LoginAsync(string username, string password,int userId)
        {
            var user = _userRepository.FIndUser(username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                throw new UnauthorizedAccessException("Invalid credentials");
            }
            var token =  GenerateJwtToken(user);
            await _logRepository.AddLog(new LogDTO { UserId = userId, Action = "Logged User", ActionDateTime = DateTime.UtcNow });
            return new LoginResultDTO
            {
                Token = token,
                UserId = user.Id
            };
        }



        private string GenerateJwtToken(User user)
        {

            var userRoleString = user.UserRole.ToString();
            Console.WriteLine($"User role for token: {userRoleString}"); 

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.Username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Role, user.UserRole.ToString()) // Add user role here
            
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AppSettings:Token"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

    }
}
