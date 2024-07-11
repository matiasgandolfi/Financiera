using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Financiera.Data.Interfaces.IRepositorio
{
    public interface IRepositorioGenerico<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(
            Expression<Func<T, bool>> filtro = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string incluirPropiedades = null    // Include
            );


        Task<T> GetFirst(
            Expression<Func<T, bool>> filtro = null,
            string incluirPropiedades = null        //Include
            );


        Task Create(T entidad);
        void Delete(T entidad);
    }
}
