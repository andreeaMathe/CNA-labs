using Grpc.Core;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
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
            var question = new Question() { Content = "question from server" };
            var answers = new List<Answer>() {
            new Answer(){ Id = 1, Content = "First answer" },
            new Answer(){ Id = 2, Content = "Some other answer" },
            new Answer(){ Id = 3, Content = "Bad one" }};

            var reply = new GetQuestionReply() { Question = question };
            reply.PossibleAnswers.AddRange(answers);

            return Task.FromResult(reply);
        }

        public override Task<SubmitAnswersReply> SubmitAnswers(SubmitAnswersRequest request, ServerCallContext context)
        {
            return Task.FromResult(new SubmitAnswersReply() { Points = 3 });
        }
    }
}
