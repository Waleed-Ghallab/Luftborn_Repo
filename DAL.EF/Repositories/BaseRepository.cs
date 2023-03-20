using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Modelinterface.Core.Interfaces;
using Modelinterface.Core.Models;
using Modelinterface.Core.Strings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly App_dbcontext _context;

        public BaseRepository(App_dbcontext context)
        {
            _context = context;
        }

        public async Task<T> Add(T entity)
        {
           await _context.Set<T>().AddAsync(entity);
           await _context.SaveChangesAsync(); 
            return entity;
            
        }

        public async Task<IEnumerable<T>> AddRange(IEnumerable<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
            await _context.SaveChangesAsync();
            return entities; 
        }

        public async Task<T> Delete(int id)
        {
            var x=_context.Set<T>().Find(id);
            if ( x != null)
            {
                _context.Set<T>().Remove(x);
                await _context.SaveChangesAsync();
            }
            return x ;
        }

        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> match, 
            Expression<Func<T, object>> orderBy = null, string orderByDirection = "ASC")
        {
            IQueryable<T> query= _context.Set<T>();

            if(orderBy != null)
            {
                if(orderByDirection == OrderBy.Ascending)
                {
                    query = query.OrderBy(orderBy);
                }
                else
                {
                    query = query.OrderByDescending(orderBy);
                }
            }
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public bool GetById(int id)
        {
            var x= _context.Set<T>().Find(id);
            if (x != null)
            {
                return true ;
            }
            else
            {
                return false ;
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> Put(int id, T entity)
        {
            
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                //entity.depto = employee.deptID; //update depto
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) // to avoid concurrency violation
            {
                if (!GetById(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return entity;
        }
    }
}
