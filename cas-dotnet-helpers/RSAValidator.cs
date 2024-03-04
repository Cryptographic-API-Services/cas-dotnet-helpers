using System.Security.Cryptography;

namespace CASHelpers
{
    public static class RSAValidator
    {
        public static bool ValidateRsaPemKey(string pemKey)
        {
            try
            {
                var rsa = RSA.Create();
                rsa.ImportFromPem(pemKey.ToCharArray());
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error validating RSA PEM key: {ex.Message}");
                return false;
            }
        }
    }
}