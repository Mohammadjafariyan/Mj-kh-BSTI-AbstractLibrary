using System;

namespace BigPardakht.Model
{
    public class GatewayAddressNotRecognizedException : Exception
    {
        public GatewayAddressNotRecognizedException(string msg) : base(msg)
        {
        }
    }
}