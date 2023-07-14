﻿using Microsoft.IdentityModel.Tokens;

namespace DigitalPoint.Identity.Configuration
{
    public class JwtOptions {

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public SigningCredentials SigningCredentials { get; set; }

    }
}
