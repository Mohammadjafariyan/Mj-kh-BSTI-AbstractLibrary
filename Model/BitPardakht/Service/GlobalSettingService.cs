using System;
using System.Net;
using NBitcoin;

namespace BigPardakht.Service
{
    public class GlobalSettingService
    {
        public static Network Network = Network.TestNet;

        public GlobalSettingService()
        {
            FakeNode = true;
        }

        public bool FakeNode { get; set; }
        public string NodeAddress { get; set; }
        public int NodePort { get; set; }
        public bool FromExternalServers { get; set; } = true;
    }
}