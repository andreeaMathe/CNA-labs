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

        //public async Task SendSelectedAnswer(Answer selectedAnswer)
        //{
        //    var client = new GrpcServiceProvider().GetQuizClient();
        //    var reply = await client.SubmitAnswersAsync(
        //                      new QuizProto.SubmitAnswersRequest { Question });

        //    var protoQuestion = reply.Question;

        //    //var answers = protoQuestion.Answers
        //    var answers = new List<Answer>() { new Answer(1, "x"), new Answer(2, "qwert") };
        //    var receivedQuestion = new Question(protoQuestion.Id, protoQuestion.Content, answers);

        //    return receivedQuestion;
        //}
    }
}
