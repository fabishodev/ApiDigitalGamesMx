﻿using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace ApiProducts.Library.Interfaces
{
    public interface IToken
    {
        string GenerateAccessToken(IEnumerable<Claim> claims);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
