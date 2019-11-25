using Microsoft.AspNetCore.Mvc;
using MyBlog.Models;
using MyBlog.Service;
using MyBlog.Service.Interface;
using System.Collections.Generic;

namespace MyBlog.Controllers
{
    [ApiController]
    public class UserController : DataFactory<IUserService>
    {
        [HttpPost]
        [Route("api/User/getAllUsers")]
        public List<Users> GetAllUsers()
        {
            return Service.GetAllUsers();
        }

        [HttpPost]
        [Route("api/User/getAllUsersNotFreeze")]
        public List<Users> GetAllUsersNotFreeze()
        {
            return Service.GetAllUsersNotFreeze();
        }

        [HttpPost]
        [Route("api/User/getUserByUserId")]
        public Users GetUserByUserId(string userId)
        {
            return Service.GetUserByUserId(userId);
        }

        [HttpPost]
        [Route("api/User/getUserByUserNameAndPassword")]
        public Users GetUserByUserNameAndPassword(string userName, string passWord)
        {
            return Service.GetUserByUserNameAndPassword(userName, passWord);
        }

        [HttpPost]
        [Route("api/User/login")]
        public bool Login(string userName, string passWord)
        {
            return Service.Login(userName, passWord);
        }

        [HttpPost]
        [Route("api/User/register")]
        public bool Register(Users user)
        {
            return Service.Register(user);
        }

        [HttpGet]
        [Route("api/User/freezeUser")]
        public int FreezeUser(string userId)
        {
            return Service.FreezeUser(userId);
        }

        [HttpGet]
        [Route("api/User/unFreezeUser")]
        public int UnFreezeUser(string userId)
        {
            return Service.UnFreezeUser(userId);
        }

        [HttpPut]
        [Route("api/User/updateUser")]
        public int UpdateUser(Users user)
        {
            return Service.UpdateUser(user);
        }
    }
}
