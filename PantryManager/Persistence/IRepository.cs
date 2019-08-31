using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bonsai.Persistence
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(long id);
        T Add(T entity);
        T Update(long id, T entity);
        T Delete(long id);
    }
}
