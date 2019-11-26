using Microsoft.AspNetCore.Mvc;
using MyBlog.Models;
using MyBlog.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Controllers
{
    [ApiController]
    public class BlogController : DataFactory
    {
        [HttpPost]
        [Route("api/Blog/getAllBlogs")]
        public List<Blog> GetAllBlogs()
        {
            return GetService<IBlogService>().GetAllBlogs();
        }

        [HttpPost]
        [Route("api/Blog/getAllBlogsNotDelete")]
        public List<Blog> GetAllBlogsNotDelete()
        {
            return GetService<IBlogService>().GetAllBlogsNotDelete();
        }

        [HttpGet]
        [Route("api/Blog/getBlogsByUserId")]
        public List<Blog> GetBlogsByUserId(string userId)
        {
            return GetService<IBlogService>().GetBlogsByUserId(userId);
        }

        [HttpGet]
        [Route("api/Blog/getBlogsNotDeleteByUserName")]
        public List<Blog> GetBlogsNotDeleteByUserName(string userName)
        {
            return GetService<IBlogService>().GetBlogsNotDeleteByUserName(userName);
        }

        [HttpPost]
        [Route("api/Blog/addBlog")]
        public bool AddBlog(Blog blog, string userId)
        {
            return GetService<IBlogService>().AddBlog(blog, userId);
        }

        [HttpPost]
        [Route("api/Blog/deleteBlog")]
        public int DeleteBlog(string blogId)
        {
            return GetService<IBlogService>().DeleteBlog(blogId);
        }

        [HttpPost]
        [Route("api/Blog/reDeleteBlog")]
        public int ReDeleteBlog(string blogId)
        {
            return GetService<IBlogService>().ReDeleteBlog(blogId);
        }
    }
}
