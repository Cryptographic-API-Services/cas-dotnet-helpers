using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace CASHelpers
{
    public class JWT
    {
        public string GenerateSecurityToken(string userId, RSAParameters rsaParameters, string publicKey, bool isAdmin)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(Constants.TokenClaims.Id, userId),
                    new Claim(Constants.TokenClaims.PublicKey, publicKey),
                    new Claim(Constants.TokenClaims.IsAdmin, isAdmin.ToString())
                }),
                Issuer = "https://encryptionapiservices.com",
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new RsaSecurityKey(rsaParameters), SecurityAlgorithms.RsaSha512Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }

        public async Task<bool> ValidateSecurityToken(string token, RSAParameters rsaParams)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            TokenValidationResult tokenValidationResult = await tokenHandler.ValidateTokenAsync(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                IssuerSigningKey = new RsaSecurityKey(rsaParams),
                ValidateIssuer = true,
                ValidateAudience = false,
                ValidIssuer = "https://encryptionapiservices.com",
                ClockSkew = TimeSpan.Zero
            });
            return tokenValidationResult.IsValid;
        }

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
                ValidIssuer = "https://encryptionapiservices.com",
                IssuerSigningKey = new ECDsaSecurityKey(publicKey)
            });
            return result.IsValid;
        }

        public string GenerateECCToken(string userId, bool isAdmin, ECDSAWrapper ecdsaKey, double hoursToAdd, string? subscriptionPublicKey = null)
        {
            var handler = new JsonWebTokenHandler();
            DateTime now = DateTime.UtcNow;
            List<Claim> claims = new List<Claim>()
            {
                new Claim(Constants.TokenClaims.Id, userId),
                new Claim(Constants.TokenClaims.IsAdmin, isAdmin.ToString())
            };
            if (subscriptionPublicKey != null)
            {
                claims.Add(new Claim(Constants.TokenClaims.SubscriptionPublicKey, subscriptionPublicKey));
            }
            string token = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = "https://encryptionapiservices.com",
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

