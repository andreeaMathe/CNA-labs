using MongoDB.Bson.Serialization.Attributes;
using QuizService.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace QuizService.DataAccess.MongoDB.ModelDb
{
    public class QuestionDb : IEquatable<Question>
    {
        [BsonId]
        public int Id { get; set; }
        public string Content { get; set; }
        public List<AnswerDb> PossibleAnswers { get; set; }
        public List<AnswerDb> CorrectAnswers { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as QuestionDb);
        }

        public bool Equals([AllowNull] Question other)
        {
            return other != null &&
                   Id.Equals(other.Id) &&
                   Content.Equals(other.Content) &&
                   PossibleAnswers.Equals(other.PossibleAnswers) &&
                   CorrectAnswers.Equals(other.CorrectAnswers);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Content, PossibleAnswers, CorrectAnswers);
        }

        public static implicit operator QuestionDb(Question question)
        {
            return new QuestionDb
            {
                Id = question.Id,
                Content = question.Content,
                PossibleAnswers = (List<AnswerDb>)question.PossibleAnswers.Cast<List<AnswerDb>>(),
                CorrectAnswers = (List<AnswerDb>)question.CorrectAnswers.Cast<List<AnswerDb>>(),
            };
        }

        public static implicit operator Question(QuestionDb question)
        {
            return new Question
            {
                Id = question.Id,
                Content = question.Content,
                PossibleAnswers = (List<Answer>)question.PossibleAnswers.Cast<List<Answer>>(),
                CorrectAnswers = (List<Answer>)question.CorrectAnswers.Cast<List<Answer>>(),
            };
        }
    }
}
