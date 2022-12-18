﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Core.Security.Extensions;

public static class ClaimExtensions
{
    public static void AddEmail(this ICollection<Claim> claims, string email)
    {
        claims.Add(new Claim(ClaimTypes.Email, email));
    }

    public static void AddName(this ICollection<Claim> claims, string name)
    {
        claims.Add(new Claim(ClaimTypes.Name, name));
    }

    public static void AddNameIdentifier(this ICollection<Claim> claims, string nameIdentifier)
    {
        claims.Add(new Claim(ClaimTypes.NameIdentifier, nameIdentifier));
    }
    public static void AddUserName(this ICollection<Claim> claims, string userName)
    {
        claims.Add(new Claim(ClaimTypes.Name, userName));
    }
    public static void AddPersonelId(this ICollection<Claim> claims, string personelId)
    {
        claims.Add(new Claim("personelId", personelId));
    }
    public static void AddRole(this ICollection<Claim> claims, string role)
    {
        claims.Add(new Claim(ClaimTypes.Role, role));
    }
}