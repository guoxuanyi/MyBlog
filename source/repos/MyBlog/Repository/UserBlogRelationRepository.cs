using MyBlog.Models;
using MyBlog.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Repository
{
    public class UserBlogRelationRepository : DataFactory, IUserBlogRelationRepository
    {
        public UserBlogRelation GetRelationByUserId(string userId)
        {
            UserBlogRelation relation = Db.UserBlogRelation.FirstOrDefault(ubr => ubr.UserId == userId);
            return relation;
        }

        public int BlogIdExistCount(string blogId)
        {
            int count = Db.UserBlogRelation.Where(ubr => ubr.BlogId == blogId).ToList().Count;
            return count;
        }

    }
}
