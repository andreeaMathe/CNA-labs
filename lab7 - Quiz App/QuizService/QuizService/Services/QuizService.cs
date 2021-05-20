using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizProto;
using QuizService.DataAccess.MongoDB.Repositories;

namespace GreeterService
{
    public class QuizService : Quiz.QuizBase
    {
        private readonly ILogger<QuizService> _logger;
        private readonly QuestionRepository _repository;
        public QuizService(ILogger<QuizService> logger)
        {
            _logger = logger;
            //_repository = new QuestionRepository();
        }

        public override Task<GetQuestionReply> GetQuestion(GetQuestionRequest request, ServerCallContext context)
        {
            //var question = new Question() { Content = "question from server" };
            //var answers = new List<Answer>() {
            //new Answer(){ Id = 1, Content = "First answer" },
            //new Answer(){ Id = 2, Content = "Some other answer" },
            //new Answer(){ Id = 3, Content = "Bad one" }};

            //var reply = new GetQuestionReply() { Question = question };
            //reply.PossibleAnswers.AddRange(answers);

            var response = GetQuestionFromDb(request.QuestionNumber);

            return Task.FromResult(response.Result);
        }

        public override Task<SubmitAnswersReply> SubmitAnswers(SubmitAnswersRequest request, ServerCallContext context)
        {
            return Task.FromResult(new SubmitAnswersReply() { Points = 3 });
        }

        private async Task<GetQuestionReply> GetQuestionFromDb(int id)
        {
            var q = await _repository.GetQuestionById(id);
            var reply = new GetQuestionReply() { Question = new Question() { Content = q.Content} };
            reply.PossibleAnswers.AddRange(q.PossibleAnswers.Select(a => new Answer() { Content = a.Content}));

            return reply;
        }
    }
}
