using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASHelpers.Types.HttpResponses.BenchmarkAPI
{
    public enum BenchmarkMethodType
    {
        Asymmetric = 0, 
        Hash = 1,
        PasswordHash = 2,
        Signatures = 3,
        Symmetric = 4
    }
}