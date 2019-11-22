using MyBlog.Models;
using MyBlog.Repository;
using MyBlog.Respostery.IRespostery;
using MyBlog.Service.Interface;
using MyBlog.Tool;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyBlog.Service
{
    public class UserService : Tools, IUserService
    {
        private readonly IUserRepository _repository;

        public UserService()
        {
            this._repository = new UserRepository();
        }

        /// <summary>
        /// 管理员操作：获取所有用户(包括冻结)
        /// </summary>
        /// <returns>用户列表</returns>
        public List<Users> GetAllUsers()
        {
            return this._repository.GetAllUsers();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Users> GetAllUsersNotFreeze()
        {
            return this._repository.GetAllUsersNotDelete();
        }

        /// <summary>
        /// 共通操作：根据用户ID找到该用户
        /// </summary>
        /// <param name="userId">http请求发送用户ID</param>
        /// <returns>用户</returns>
        public Users GetUserByUserId(string userId)
        {
            return this._repository.GetUserByUserId(userId);
        }

        /// <summary>
        /// 判断用户名是否存在
        /// </summary>
        /// <param name="userName">HTTP请求发送用户ID</param>
        /// <returns>是否存在</returns>
        public bool IsUserNameExist(string userName)
        {
            return this._repository.IsUserNameExist(userName);
        }

        public Users GetUserByUserNameAndPassword(string userName, string passWord)
        {
            return this._repository.GetUserByUserNameAndPassword(userName, passWord);
        }

        public int GetUserStatus(Users user)
        {
            bool userIsTrue = IsNull(user);
            if (!userIsTrue)
            {
                int status = user.UserDeleteFlag;
                return status;
            }
            else
            {
                return -2;
            }
        }

        public bool IsAdmin(Users user)
        {
            bool userIsTrue = IsNull(user);
            if (!userIsTrue && user.Admin == 1)
            {
                return !userIsTrue;
            }
            else
            {
                return userIsTrue;
            }
        }

        /// <summary>
        /// 关联GetUserByUserNameAndPassword，IsAdmin，GetUserStatus三个方法获取登录状态
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="passWord">密码</param>
        /// <returns>登录状态</returns>
        public bool Login(string userName, string passWord)
        {
            Users user = GetUserByUserNameAndPassword(userName, passWord);
            bool isAdmin = IsAdmin(user);
            int userStatus = GetUserStatus(user);
            if (isAdmin)
            {
                return isAdmin;
            }
            else
            {
                if (userStatus == 0)
                {
                    return !isAdmin;
                }
                else
                {
                    return isAdmin;
                }
            }
        }

        /// <summary>
        /// 用户操作：注册
        /// </summary>
        /// <param name="user">http请求发送的信息</param>
        /// <returns>注册结果</returns>
        public bool Register(Users user)
        {
            bool isUserNameExist = IsUserNameExist(user.UserName);
            if (!isUserNameExist)
            {
                return this._repository.Register(user);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 管理员操作：冻结账户
        /// </summary>
        /// <param name="userId">客户端发送的用户Id</param>
        /// <returns>返回受影响的用户数量</returns>
        public int FreezeUser(string userId)
        {
            return this._repository.FreezeUser(userId);
        }

        public int UpdateUser(Users modifyUser)
        {
            Users user = GetUserByUserId(modifyUser.UserId);
            bool userIsTrue = IsNull(user);
            if (!userIsTrue)
            {
                bool status = IsUserNameExist(modifyUser.UserName);
                if (!status)
                {
                    return this._repository.UpdateUser(user, modifyUser);
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -2;
            }
        }

        /// <summary>
        /// 管理员操作：解冻账户
        /// </summary>
        /// <param name="userId">客户端发送的用户Id</param>
        /// <returns>返回受影响的用户数量</returns>
        public int UnFreezeUser(string userId)
        {
            return this._repository.UnFreezeUser(userId);
        }
    }
}
