﻿using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PruebaJWT.Helpers
{
    public class JwtTokenGenerator
    {
        public string GetToken(string nombre)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("Rol", "Admin"));
            claims.Add(new Claim(ClaimTypes.Name, nombre));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iss, "Saludos"));
            claims.Add(new Claim(JwtRegisteredClaimNames.Aud, "prueba"));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Exp, DateTime.Now.AddMinutes(5).ToString()));
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            var token = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = "Saludos",
                Audience = "prueba",
                IssuedAt = DateTime.Now,
                Expires = DateTime.Now.AddMinutes(5),
                NotBefore = DateTime.Now.AddMinutes(-1),
                SigningCredentials=new SigningCredentials(new SymmetricSecurityKey(System.Text.Encoding.UTF8
            .GetBytes("ESTAESMILLAVEDECIFRADODELTOKEN2024")),SecurityAlgorithms.HmacSha256)
            };


            return handler.CreateEncodedJwt(token);
        }
    }
}
