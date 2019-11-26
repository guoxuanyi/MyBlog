using Microsoft.AspNetCore.Mvc;
using MyBlog.Models;
using MyBlog.Service;
using MyBlog.Service.Interface;
using System.Collections.Generic;

namespace MyBlog.Controllers
{
    [ApiController]
    public class UserController : DataFactory
    {
        [HttpPost]
        [Route("api/User/getAllUsers")]
        public List<Users> GetAllUsers()
        {
            return GetService<IUserService>().GetAllUsers();
        }

        [HttpPost]
        [Route("api/User/getAllUsersNotFreeze")]
        public List<Users> GetAllUsersNotFreeze()
        {
            return GetService<IUserService>().GetAllUsersNotFreeze();
        }

        [HttpPost]
        [Route("api/User/getUserByUserId")]
        public Users GetUserByUserId(string userId)
        {
            return GetService<IUserService>().GetUserByUserId(userId);
        }

        [HttpPost]
        [Route("api/User/getUserByUserNameAndPassword")]
        public Users GetUserByUserNameAndPassword(string userName, string passWord)
        {
            return GetService<IUserService>().GetUserByUserNameAndPassword(userName, passWord);
        }

        [HttpPost]
        [Route("api/User/login")]
        public bool Login(string userName, string passWord)
        {
            return GetService<IUserService>().Login(userName, passWord);
        }

        [HttpPost]
        [Route("api/User/register")]
        public bool Register(Users user)
        {
            return GetService<IUserService>().Register(user);
        }

        [HttpGet]
        [Route("api/User/freezeUser")]
        public int FreezeUser(string userId)
        {
            return GetService<IUserService>().FreezeUser(userId);
        }

        [HttpGet]
        [Route("api/User/unFreezeUser")]
        public int UnFreezeUser(string userId)
        {
            return GetService<IUserService>().UnFreezeUser(userId);
        }

        [HttpPut]
        [Route("api/User/updateUser")]
        public int UpdateUser(Users user)
        {
            return GetService<IUserService>().UpdateUser(user);
        }
    }
}
