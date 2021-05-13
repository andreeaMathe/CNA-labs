using System;
using System.Collections.Generic;
using System.Text;

namespace QuizLibrary.Model
{
    public class Answer
    {
        public Answer(int id, string description)
        {
            Id = id;
            Description = description ?? throw new ArgumentNullException(nameof(description));
        }

        public int Id { get; private set; }
        public string Description { get; private set; }

        public static Answer ConvertProtoAnswer(QuizProto.Answer protoAnswer) => new Answer(protoAnswer.Id, protoAnswer.Content);

        public override string ToString()
        {
            return "bla bla";
        }
    }
}
