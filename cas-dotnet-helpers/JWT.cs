using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace CASHelpers
{
    public class JWT
    {
        public async Task<bool> ValidateECCToken(string token, ECDsa publicKey)
        {
            JsonWebTokenHandler newHandler = new JsonWebTokenHandler();
            TokenValidationResult result = await newHandler.ValidateTokenAsync(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                ValidateIssuer = true,
                ValidateAudience = false,
                ValidIssuer = "https://cryptographicapiservices.com",
                IssuerSigningKey = new ECDsaSecurityKey(publicKey)
            });
            return result.IsValid;
        }

        public string GenerateECCToken(string userId, bool isAdmin, ECDSAWrapper ecdsaKey, double hoursToAdd)
        {
            var handler = new JsonWebTokenHandler();
            DateTime now = DateTime.UtcNow;
            List<Claim> claims = new List<Claim>()
            {
                new Claim(Constants.TokenClaims.Id, userId),
                new Claim(Constants.TokenClaims.IsAdmin, isAdmin.ToString())
            };
            string token = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = "https://cryptographicapiservices.com",
                NotBefore = now,
                Expires = now.AddHours(1),
                IssuedAt = now,
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = new SigningCredentials(new ECDsaSecurityKey(ecdsaKey.ECDKey), "ES256")
            });
            return token;
        }


        public string GetUserIdFromToken(string token)
        {
            var handler = new JwtSecurityTokenHandler().ReadJwtToken(token);
            return handler.Claims.First(x => x.Type == Constants.TokenClaims.Id).Value;
        }
    }
}

