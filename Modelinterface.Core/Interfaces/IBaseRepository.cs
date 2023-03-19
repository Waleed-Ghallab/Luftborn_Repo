using Modelinterface.Core.Strings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Modelinterface.Core.Interfaces
{
    public interface IBaseRepository <T> where T : class
    {
        //T GetById(int id);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();

        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T,bool>> match,
            Expression<Func<T,Object>> orderBy=null,string orderByDirection=OrderBy.Ascending);

        Task<T> Add(T entity);

        Task<IEnumerable<T>> AddRange (IEnumerable<T> entities);
    }
}
