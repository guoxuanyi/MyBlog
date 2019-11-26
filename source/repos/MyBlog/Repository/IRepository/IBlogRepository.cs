using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Repository.IRepository
{
    public interface IBlogRepository
    {
        List<Blog> GetAllBlogs();
        List<Blog> GetAllBlogsNotDelete();
        List<Blog> GetDeletedBlogs();
        List<Blog> GetBlogsByUserId(string userId);
        List<Blog> GetBlogsNotDeleteByUserName(string userName);
        int AddBlog(Blog blog, string userId);
        int DeleteBlog(string blogId);
        int ReDeleteBlog(string blogId);
        int UpdateBlog(Blog blog, string userId);
    }
}
