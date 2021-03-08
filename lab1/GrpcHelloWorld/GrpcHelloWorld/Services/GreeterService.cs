using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcHelloWorld
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            _logger.LogInformation(request.Name);
            _logger.LogInformation(request.Age.ToString());

            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name + ", age " + request.Age,
                Message2 = "hello again" 
            }) ;
        }
    }
}
