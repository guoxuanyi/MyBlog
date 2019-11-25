using MyBlog.Models;
using MyBlog.Repository;
using MyBlog.Repository.IRepository;
using MyBlog.Respostery.IRespostery;
using MyBlog.Service;
using MyBlog.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog
{
    public class DataFactory<T>
    {
        static IUserService userService = null;
        static ISortService sortService = null;
        static IUserRepository userRepository = null;
        static ISortRepository sortRepository = null;
        private static gxyContext db = new gxyContext();

        public dynamic Service
        {
            get
            {
                if (typeof(T) == typeof(ISortService))
                {
                    if (sortService == null)
                    {
                        object instance = new SortService();
                        return (T)instance;
                    }
                    return sortService;
                }
                else if (typeof(T) == typeof(IUserService))
                {
                    if (userService == null)
                    {
                        return new UserService();
                    }
                    return userService;
                }
                else
                {
                    throw new Exception();
                }
            }
        }

        public dynamic Repository
        {
            get
            {
                if (typeof(T) == typeof(IUserRepository))
                {
                    if (userRepository == null)
                    {
                        return new UserRepository();
                    }
                    return userRepository;
                }
                else if (typeof(T) == typeof(ISortRepository))
                {
                    if (sortRepository == null)
                    {
                        return new SortRepository();
                    }
                    return sortRepository;
                }
                else
                {
                    throw new Exception();
                }
            }
        }
        public static gxyContext Db
        {
            get
            {
                return db;
            }

        }
    }
}
