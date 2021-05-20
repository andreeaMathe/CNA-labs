using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizService.DataAccess.MongoDB.Settings
{
    public class QuizDatabaseSettings : IQuizDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
