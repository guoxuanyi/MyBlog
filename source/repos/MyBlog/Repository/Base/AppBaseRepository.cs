using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Repository.Base
{
    public class AppBaseRepository<TEntity> : BaseRepository<gxyContext, TEntity>
        where TEntity : class
    {
        public AppBaseRepository(gxyContext dbContext) : base(dbContext)
        {

        }
    }
}
