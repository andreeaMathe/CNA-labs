using MongoDB.Bson.Serialization.Attributes;
using QuizService.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace QuizService.DataAccess.MongoDB.ModelDb
{
    public class AnswerDb : IEquatable<Answer>
    {
        [BsonId]
        public int Id { get; set; }

        public string Content { get; set; }


        public override bool Equals(object obj)
        {
            return Equals(obj as AnswerDb);
        }

        public bool Equals([AllowNull] Answer other)
        {
            return other != null &&
                   Id.Equals(other.Id) &&
                   Content.Equals(other.Content);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Content);
        }

        public static implicit operator AnswerDb(Answer answer)
        {
            return new AnswerDb
            {
                Id = answer.Id,
                Content = answer.Content
            };
        }

        public static implicit operator Answer(AnswerDb answer)
        {
            return new Answer
            {
                Id = answer.Id,
                Content = answer.Content
            };
        }
    }
}
