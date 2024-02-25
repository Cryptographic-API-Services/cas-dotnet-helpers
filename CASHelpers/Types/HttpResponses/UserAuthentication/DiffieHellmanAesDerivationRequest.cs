namespace CASHelpers.Types.HttpResponses.UserAuthentication
{
    public class DiffieHellmanAesDerivationRequest
    {
        public string MacAddress { get; set; }
        public string RequestersPublicKey { get; set; }
    }
}
