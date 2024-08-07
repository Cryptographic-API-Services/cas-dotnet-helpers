﻿namespace CASHelpers.Types.HttpResponses.BenchmarkAPI
{
    public enum BenchmarkMethodType
    {
        Asymmetric = 0,
        Hash = 1,
        PasswordHash = 2,
        Signatures = 3,
        Symmetric = 4,
        DigitalSignature = 5,
        KeyExchange = 6,
        Sponge = 7,
        Compression = 8
    }
}