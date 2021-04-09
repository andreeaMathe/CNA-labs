using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizProto;

namespace GreeterService
{
    public class QuizService : Quiz.QuizBase
    {
        private readonly ILogger<QuizService> _logger;
        public QuizService(ILogger<QuizService> logger)
        {
            _logger = logger;
        }

        public override Task<GetQuestionReply> GetQuestion(GetQuestionRequest request, ServerCallContext context)
        {
            var question = new Question() { Content = "here will be a question" };
            return Task.FromResult(new GetQuestionReply() { Question = question});
        }

        public override Task<SubmitAnswersReply> SubmitAnswers(SubmitAnswersRequest request, ServerCallContext context)
        {
            return Task.FromResult(new SubmitAnswersReply() { Points = 3 });
        }
    }
}
