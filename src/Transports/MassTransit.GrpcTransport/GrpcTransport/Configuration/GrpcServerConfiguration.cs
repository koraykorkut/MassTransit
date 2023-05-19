namespace MassTransit.GrpcTransport.Configuration
{
    using System;


    public class GrpcServerConfiguration
    {
        public GrpcServerConfiguration(Uri address, string loadBalancingPolicy = null)
        {
            Address = address;
            LoadbalancingPolicy = loadBalancingPolicy;
        }

        public Uri Address { get; }
        public string LoadbalancingPolicy { get; }
    }
}
