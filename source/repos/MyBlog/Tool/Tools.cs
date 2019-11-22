using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Tool
{
    public class Tools
    {
        public bool IsNull<T>(T obj) where T : class
        {
            if (obj != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
