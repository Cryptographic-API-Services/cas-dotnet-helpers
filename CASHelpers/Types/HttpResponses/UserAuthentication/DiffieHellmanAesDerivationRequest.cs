namespace CASHelpers.Types.HttpResponses.UserAuthentication
{
    public class DiffieHellmanAesDerivationRequest
    {
        public string MacAddress { get; set; }
        public byte[] RequestersPublicKey { get; set; }
    }
}
