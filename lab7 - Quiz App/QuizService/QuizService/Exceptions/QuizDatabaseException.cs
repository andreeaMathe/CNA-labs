using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizService.Exceptions
{
    public class QuizDatabaseException : Exception
    {
        private const string DefaultMessage = "Unknown error at the database level.";

        public QuizDatabaseException()
            : base(DefaultMessage)
        {
        }

        public QuizDatabaseException(string message)
            : base(message)
        {
        }

        public QuizDatabaseException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public QuizDatabaseException(Exception innerException)
            : base(DefaultMessage, innerException)
        {
        }
    }
}
