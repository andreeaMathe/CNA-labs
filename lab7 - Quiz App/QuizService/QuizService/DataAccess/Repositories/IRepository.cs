using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizService.DataAccess.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAll();
        Task Add(TEntity entity);
    }
}
