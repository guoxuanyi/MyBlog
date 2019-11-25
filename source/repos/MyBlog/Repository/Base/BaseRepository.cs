using Microsoft.EntityFrameworkCore;
using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Repository.Base
{
    public class BaseRepository<EfContext, TEntity>
        where TEntity : class
        where EfContext : DbContext
    {
        protected EfContext context;
        protected DbSet<TEntity> dbSet;

        protected virtual EfContext Context { get { return context; } }
        protected virtual DbSet<TEntity> DbSet { get { return dbSet; } }
        public BaseRepository(EfContext dbContext)
        {
            context = dbContext;
            dbSet = context.Set<TEntity>();
        }
    }
}
