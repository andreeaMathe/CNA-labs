using System;
using System.Collections.Generic;
using System.Text;

namespace QuizLibrary.Model
{
    public class Question
    {
        public Question(int id, string description, List<Answer> answers)
        {
            Id = id;
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Answers = answers ?? throw new ArgumentNullException(nameof(answers));
        }

        public int Id { get; private set; }
        public string Description { get; private set; }
        public List<Answer> Answers { get; private set; }

        public override string ToString()
        {
            return $"{Id} + {Description}";
        }
    }
}
