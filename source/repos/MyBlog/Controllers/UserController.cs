using Microsoft.AspNetCore.Mvc;
using MyBlog.Models;
using MyBlog.Service;
using MyBlog.Service.Interface;
using System.Collections.Generic;

namespace MyBlog.Controllers
{
    [ApiController]
    public class UserController
    {
        private readonly IUserService _service;

        public UserController()
        {
            this._service = new UserService();
        }

        [HttpPost]
        [Route("api/User/getAllUsers")]
        public List<Users> GetAllUsers()
        {
            return this._service.GetAllUsers();
        }

        [HttpPost]
        [Route("api/User/getAllUsersNotFreeze")]
        public List<Users> GetAllUsersNotFreeze()
        {
            return this._service.GetAllUsersNotFreeze();
        }

        [HttpPost]
        [Route("api/User/getUserByUserId")]
        public Users GetUserByUserId(string userId)
        {
            return this._service.GetUserByUserId(userId);
        }

        [HttpPost]
        [Route("api/User/getUserByUserNameAndPassword")]
        public Users GetUserByUserNameAndPassword(string userName, string passWord)
        {
            return this._service.GetUserByUserNameAndPassword(userName, passWord);
        }

        [HttpPost]
        [Route("api/User/login")]
        public bool Login(string userName, string passWord)
        {
            return this._service.Login(userName, passWord);
        }

        [HttpPut]
        [Route("api/User/register")]
        public bool Register(Users user)
        {
            return this._service.Register(user);
        }

        [HttpGet]
        [Route("api/User/freezeUser")]
        public int FreezeUser(string userId)
        {
            return this._service.FreezeUser(userId);
        }

        [HttpGet]
        [Route("api/User/unFreezeUser")]
        public int UnFreezeUser(string userId)
        {
            return this._service.UnFreezeUser(userId);
        }

        [HttpPost]
        [Route("api/User/updateUser")]
        public int UpdateUser(Users user)
        {
            return this._service.UpdateUser(user);
        }
    }
}
