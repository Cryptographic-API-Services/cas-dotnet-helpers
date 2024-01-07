namespace CASHelpers.Types.HttpResponses.BenchmarkAPI
{
    public class BenchmarkSDKChartMethod
    {
        public double AmountOfTime { get; set; }
        public string MethodName { get; set; }
        public string MethodDescription { get; set; }
        public BenchmarkMethodType MethodType { get; set; }
    }
}
