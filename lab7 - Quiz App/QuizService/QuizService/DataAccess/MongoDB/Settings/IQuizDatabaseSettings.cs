using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizService.DataAccess.MongoDB.Settings
{
    public interface IQuizDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
