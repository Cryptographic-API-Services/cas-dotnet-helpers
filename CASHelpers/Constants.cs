﻿namespace CASHelpers
{
    public class Constants
    {
        public class ApiRoutes
        {
            public const string Token = "/Token";
            public const string RefreshToken = "/RefreshToken";
        }

        public class HeaderNames
        {
            public const string ApiKey = "ApiKey";
            public const string Authorization = "Authorization";
            public const string XForwardedFor = "X-Forwarded-For";
        }

        public class HttpItems
        {
            public const string UserID = "UserID";
            public const string IP = "IP";
        }

        public class TokenClaims
        {
            public const string Id = "id";
            public const string PublicKey = "PublicKey";
        }
    }
}
