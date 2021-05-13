using QuizLibrary.Model;
using QuizLibrary.ServiceProvider;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace QuizLibrary.Requests
{
    public class ClientRequest
    {
        public async Task<Question> RequestCurrentQuestion(int questionNumber)
        {
            var client = new GrpcServiceProvider().GetQuizClient();
            var reply = await client.GetQuestionAsync(
                              new QuizProto.GetQuestionRequest { QuestionNumber = questionNumber });

            var question = reply.Question;
            var answers = reply.PossibleAnswers;

            var receivedQuestion = new Question(question.Id, question.Content, answers.Select(protoAnswer => Answer.ConvertProtoAnswer(protoAnswer)).ToList());

            return receivedQuestion;
        }

        public async Task SendSelectedAnswer(Answer selectedAnswer)
        {
            //similar to RequestCurrentQuestion
        }
    }
}
