using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IApplication<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> Get(int id);
        Task Edit(T entity);
        Task Add(T entity);
        Task Delete(int id);
        Task<bool> Save();
    }
}
