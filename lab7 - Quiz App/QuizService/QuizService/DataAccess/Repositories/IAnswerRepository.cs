using QuizService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizService.DataAccess.Repositories
{
    public interface IAnswerRepository : IRepository<Answer>
    {
        Task Update(Answer question);

        Task Delete(int id);

        Task<Answer> GetAnswerByContent(string content);

        Task<Answer> GetAnswerById(int id);

    }
}
