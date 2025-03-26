﻿namespace HW.Jwt;

public class JwtOptions
{
    public string SecretKey { get; set; }
    public int ExpiresHours { get; set; }
    public string CookieName { get; set; }
}
