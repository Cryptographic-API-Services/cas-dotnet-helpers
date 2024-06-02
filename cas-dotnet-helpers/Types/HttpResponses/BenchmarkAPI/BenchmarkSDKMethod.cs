namespace CASHelpers.Types.HttpResponses.BenchmarkAPI
{
    public class BenchmarkSDKMethod
    {
        public string? MacAddress { get; set; } = string.Empty;
        public DateTime MethodStart { get; set; }
        public DateTime MethodEnd { get; set; }
        public string MethodName { get; set; }
        public string? MethodDescription { get; set; } = string.Empty;
        public BenchmarkMethodType MethodType { get; set; }
    }
}
