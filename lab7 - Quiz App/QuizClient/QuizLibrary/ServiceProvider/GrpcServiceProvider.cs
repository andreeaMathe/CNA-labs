using Grpc.Net.Client;
using QuizProto;
using System;

namespace QuizLibrary.ServiceProvider
{
    public class GrpcServiceProvider
    {
        private string Url { get; set; }
        private Lazy<GrpcChannel> RpcChannel { get; set; }
        private Quiz.QuizClient QuizClient { get; set; }

        public GrpcServiceProvider()
        {
            this.Url = "https://localhost:5001";
            this.RpcChannel = new Lazy<GrpcChannel>(GrpcChannel.ForAddress(this.Url));
        }

        public Quiz.QuizClient GetQuizClient() => this.QuizClient ??= new Quiz.QuizClient(this.RpcChannel.Value);
    }
}
