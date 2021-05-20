using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizService.Model
{
    public class Question
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public List<Answer> PossibleAnswers { get; set; } = new List<Answer>();
        public List<Answer> CorrectAnswers { get; set; } = new List<Answer>();
    }
}
