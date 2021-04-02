using GreeterProtos;
using Grpc.Net.Client;
using System;

namespace GreeterLibrary
{
    public class GrpcServiceProvider
    {
        private string Url { get; set; }
        private Lazy<GrpcChannel> RpcChannel { get; set; }
        private Greeter.GreeterClient GreeterClient { get; set; }

        public GrpcServiceProvider()
        {
            this.Url = "https://localhost:5001";
            this.RpcChannel = new Lazy<GrpcChannel>(GrpcChannel.ForAddress(this.Url));
        }

        public Greeter.GreeterClient GetGreeterClient() => this.GreeterClient ??= new Greeter.GreeterClient(this.RpcChannel.Value);
    }
}
