using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreEFDemo.DataAccess
{
    public interface IRepository<T>
    {
        void Add(T entity);
        IEnumerable<T> GetAll();
    }
}
