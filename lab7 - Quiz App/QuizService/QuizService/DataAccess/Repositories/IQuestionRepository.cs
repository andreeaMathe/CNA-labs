using QuizService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizService.DataAccess.Repositories
{
    public interface IQuestionRepository : IRepository<Question>
    {
        Task Update(Question question);

        Task Delete(int id);

        Task<Question> GetQuestionByContent(string content);

        Task<Question> GetQuestionById(int id);

    }
}
