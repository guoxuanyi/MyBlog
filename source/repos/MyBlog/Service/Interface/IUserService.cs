using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Service.Interface
{
    public interface IUserService
    {
        List<Users> GetAllUsers();
        List<Users> GetAllUsersNotFreeze();
        Users GetUserByUserId(string userId);
        public int GetUserStatus(Users user);
        public bool IsAdmin(Users user);
        Users GetUserByUserNameAndPassword(string userName, string passWord);
        bool Login(string userName, string passWord);
        bool Register(Users user);
        int UpdateUser(Users user);
        int FreezeUser(string userId);
        int UnFreezeUser(string userId);
    }
}
