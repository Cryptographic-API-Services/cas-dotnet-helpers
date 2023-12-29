﻿

namespace CASHelpers
{
    public sealed class HttpClientSingleton : HttpClient
    {
        private static HttpClientSingleton instance;
        private static object padlock = new object();
        public static HttpClientSingleton Instance
        {
            get
            {
                return GetThreadSafeInstance();
            }
        }
        private static HttpClientSingleton GetThreadSafeInstance()
        {
            if (instance == null)
            {
                lock (padlock)
                {
                    if (instance == null)
                        instance = new HttpClientSingleton();
                }
            }
            instance.DefaultRequestHeaders.Clear();
            return instance;
        }
    }
}
