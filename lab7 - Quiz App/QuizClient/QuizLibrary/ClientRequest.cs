using QuizLibrary.ServiceProvider;
using QuizProto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QuizLibrary.Model;

namespace QuizLibrary
{
    public class ClientRequest
    {
        public async Task<Model.Question> RequestQuestion(int questionNumber)
        {
            var client = new GrpcServiceProvider().GetQuizClient();
            var reply = await client.GetQuestionAsync(
                              new GetQuestionRequest { QuestionNumber = questionNumber });

            var protoQuestion = reply.Question;

            var answers = new List<Model.Answer>() { new Model.Answer(1, "first"), new Model.Answer(2, "second") };
            //todo check proto answers
            var receivedQuestion = new Model.Question(protoQuestion.Content, answers);

            return receivedQuestion;
        }
    }
}
