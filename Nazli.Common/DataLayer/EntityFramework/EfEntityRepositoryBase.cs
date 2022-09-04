using Microsoft.EntityFrameworkCore;
using Nazli.Common.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nazli.Common.DataLayer.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>

        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {

        TContext _context;
        public EfEntityRepositoryBase(TContext context)
        {
            _context = context;
        }



        public int Add(TEntity entity)
        {
            _context.Add(entity);
            return _context.SaveChanges();
        }

        public int Delete(TEntity entity)
        {
            _context.Remove(entity);
            return _context.SaveChanges();
        }
        public int Update(TEntity entity)
        {
            _context.Update(entity);
            return _context.SaveChanges();
        }
        //public TEntity Get(Expression<Func<TEntity, bool>> filter)
        //{
        //    using (TContext ctx = new TContext())
        //    {
        //        return ctx.Set<TEntity>()
        //            .SingleOrDefault(filter);

        //    }
        //}

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext ctx = new TContext())
            {
                return filter == null ?
                        ctx.Set<TEntity>().ToList()
                        : ctx.Set<TEntity>().Where(filter).ToList();

            }
        }



    }
}
