namespace CASHelpers
{
    public class Constants
    {
        public class ApiRoutes
        {
            public const string Token = "/Token";
            public const string RefreshToken = "/RefreshToken";
            public const string BenchmarkSDKMethodController = "/BenchmarkSDKMethod";
            public const string MethodBenchmark = "/MethodBenchmark";
        }

        public class HeaderNames
        {
            public const string ApiKey = "ApiKey";
            public const string Authorization = "Authorization";
            public const string XForwardedFor = "X-Forwarded-For";
            public const string ContentType = "Content-Type";
            public const string ApplicationJson = "application/json";
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
            public const string IsAdmin = "IsAdmin";
        }

        public class Configuration
        {
            public const string Url = "Url";
        }
    }
}
