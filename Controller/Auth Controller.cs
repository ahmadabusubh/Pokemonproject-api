using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration; // Added missing import
using Microsoft.IdentityModel.Tokens;
using Pokemonproject.data;
using Pokemonproject.dto;
using Pokemonproject.Model;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Pokemonproject.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class Auth_Controller : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly datacontexts dbContext;
        private readonly IWebHostEnvironment webHost;
        private static User user = new User(); // Change 'static' to avoid sharing user data across requests

        public Auth_Controller(IConfiguration configuration, datacontexts dbContext, IWebHostEnvironment  webHost)
        {
            this.configuration = configuration;
            this.dbContext = dbContext;
            this.webHost = webHost;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register([FromForm] UserDto request)
        {
            if (request.ProfilePicture != null && request.ProfilePicture.Length > 0)
            {
                // Save the image to the server or cloud storage
                string imagePath = new rootimage(webHost).SaveProfilePicture(request.ProfilePicture);

                // Set the image path in the User object
                user.ProfilePicture = imagePath;
            }

            CreatePasswordHash(request.Password, out byte[] PasswordHash, out byte[] PasswordSalt);
            user.UserName = request.Username;
            user.PasswordSalt = PasswordSalt;
            user.PasswordHash = PasswordHash;
            dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync();

            return Ok(user);
        }


        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login([FromForm] Userssdto request)
        {
            User userFromDb = dbContext.Users.FirstOrDefault(u => u.UserName == request.Username);

            if (userFromDb == null)
            {
                return BadRequest("User not found");
            }

            // Verify the password
            if (!VerifyPasswordHash(request.Password, userFromDb.PasswordHash, userFromDb.PasswordSalt))
            {
                return BadRequest("Invalid password");
            }

            // Generate and return the JWT token
            string token = CreateToken(userFromDb);
            return Ok(token);

        }

        private string CreateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("AppSettings:Token").Value));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            List< Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
            };

            var token = new JwtSecurityToken(
                issuer: "your-issuer",
                audience: "your-audience",
                claims: claims,
                expires: DateTime.Now.AddDays(20),
                signingCredentials: credentials
            );

            var tokenHandler = new JwtSecurityTokenHandler().WriteToken(token);

            //  return tokenHandler.WriteToken(token);
            var tokenEntity = new Token
            {
                UserId = user.Id,
                Value = tokenHandler,
                ExpirationDate = token.ValidTo
            };

            dbContext.Token.Add(tokenEntity);
            dbContext.SaveChanges();
            return tokenHandler;
        }

        private void CreatePasswordHash(string password, out byte[] PasswordHash, out byte[] PasswordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                PasswordSalt = hmac.Key;
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            using (var hmac = new HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Compare computed hash with stored hash
                return computedHash.SequenceEqual(storedHash);
            }
        }
      //  private string SaveProfilePicture(IFormFile profilePicture)
       
    }
}
