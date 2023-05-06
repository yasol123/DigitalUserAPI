using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Yasol.DigitalUser.Model.Account;

namespace Yasol.DigitalUser.Common.Security
{
    public class AccountJwtImplementation:IAccountJwt
    {
        private const string TOKEN_KEY_GENERATOR = "USErAcCOunTApICReAtEdByYAsOLJeONgItiSaVeRYloNGanDLoNgKEyFOrGeNERaTIngAjWTTOKeN";
        public string GetUserToken(UserAccount account)
        {
            var token = this.GenerateUserJWT(account);
            return token;
        }
        private string GenerateUserJWT(UserAccount account)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TOKEN_KEY_GENERATOR));
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, account.UserName),
                new Claim(ClaimTypes.NameIdentifier, account.ADB2CId),
                new Claim(ClaimTypes.GivenName, account.UserProfile.FirstName),
                new Claim(ClaimTypes.Surname, account.UserProfile.LastName),
                new Claim(ClaimTypes.Role, account.UserType.ToString()),
                new Claim(ClaimTypes.Email, account.UserProfile.ContactInformation.ContactValue),
                new Claim(ClaimTypes.StreetAddress, account.UserProfile.UserAddress.StreetAddress1 + ", " + account.UserProfile.UserAddress.StreetAddress2),
                new Claim(ClaimTypes.StateOrProvince, account.UserProfile.UserAddress.State),
                new Claim(ClaimTypes.PostalCode, account.UserProfile.UserAddress.ZipCode),
                new Claim(ClaimTypes.Country, account.UserProfile.UserAddress.Country)
            };
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = signingCredentials
            };

            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
