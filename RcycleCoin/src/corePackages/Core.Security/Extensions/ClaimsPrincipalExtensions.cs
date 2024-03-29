﻿using System.Security.Claims;

namespace Core.Security.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static List<string>? Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
    {
        List<string>? result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();
        return result;
    }

    public static List<string>? ClaimRoles(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal?.Claims(ClaimTypes.Role);
    }
    public static string? ClaimEmail(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal?.Claims(ClaimTypes.Email).FirstOrDefault();
    }

    public static string? ClaimPersonelId(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal?.Claims("personelId").FirstOrDefault();
    }

    public static string? GetUserId(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal?.Claims(ClaimTypes.NameIdentifier)?.FirstOrDefault();
    }
}