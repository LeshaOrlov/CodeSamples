using AuthJWT.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AuthJWT
{
    /// <summary>
    /// Реализация сервиса токенной авторизации при помощи JWT токенов
    /// </summary>
    public class JwtTokenAuthService : ITokenAuthorization
    {
        private readonly IdentityOptions _identityOptions;

        /// <summary/>
        public JwtTokenAuthService(IdentityOptions identityOptions)
        {
            _identityOptions = identityOptions;
        }

        /// <inheritdoc />
        public Task<Token> GetToken(ClaimsIdentity identity)
        {
            var handler = new JwtSecurityTokenHandler();

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_identityOptions.SigningKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var jwtToken = handler.CreateJwtSecurityToken(subject: identity,
                signingCredentials: signingCredentials,
                audience: _identityOptions.TokenAudience,
                issuer: _identityOptions.TokenIssuer,
                expires: DateTime.UtcNow.Add(_identityOptions.LifeTime));
            var encodedJwt = handler.WriteToken(jwtToken);

            var tokenModel = new Token
            {
                TokenType = "bearer",
                AccessToken = encodedJwt
            };

            return Task.FromResult(tokenModel);
        }

        /// <inheritdoc />
        public async Task<Token> RefreshToken(Token oldToken)
        {
            var decodedJwt = new JwtSecurityTokenHandler().ReadJwtToken(oldToken.AccessToken);
            if (decodedJwt.ValidTo >= DateTime.Now)
            {
                var identity = new ClaimsIdentity(new ClaimsIdentity(new GenericIdentity(decodedJwt.Subject, "Token"), new Claim[] { }));
                return await GetToken(identity);
            }
            return null; // Invalid token
        }
    }
}
