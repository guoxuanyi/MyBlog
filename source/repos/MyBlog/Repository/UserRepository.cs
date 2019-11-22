using MyBlog.Models;
using MyBlog.Respostery.IRespostery;
using MyBlog.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly gxyContext _db;
        public UserRepository()
        {
            this._db = new gxyContext();
        }

        public List<Users> GetAllUsers()
        {
            List<Users> users = this._db.Users.ToList();
            return users;
        }

        public List<Users> GetAllUsersNotDelete()
        {
            List<Users> users = this._db.Users.Where(u => u.UserDeleteFlag != 1).ToList();
            return users;
        }

        public Users GetUserByUserId(string userId)
        {
            Users user = this._db.Users.FirstOrDefault(u => u.UserId == userId);
            return user;
        }

        public Users GetUserByUserNameAndPassword(string userName, string passWord)
        {
            Users user = this._db.Users.FirstOrDefault(u => u.UserName == userName && u.UserPassword == passWord);
            return user;
        }

        public bool IsUserNameExist(string userName)
        {
            int count = this._db.Users.Where(u => u.UserName == userName).ToList().Count;
            if (count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int UpdateUser(Users user, Users modifyUser)
        {
            user.UserName = modifyUser.UserName;
            user.UserPassword = modifyUser.UserPassword;
            user.UserEmail = modifyUser.UserEmail;
            user.UserPhoto = modifyUser.UserPhoto;
            user.UserPhoneNumber = modifyUser.UserPhoneNumber;
            user.UserRegisterDate = modifyUser.UserRegisterDate;
            user.UserNickname = modifyUser.UserNickname;
            return this._db.SaveChanges();
        }

        public bool Register(Users user)
        {
            user.UserId = Guid.NewGuid().ToString().ToUpper();
            this._db.Users.Add(user);
            int count = this._db.SaveChanges();
            if (count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int FreezeUser(string userId)
        {
            var user = this._db.Users.FirstOrDefault(u => u.UserId == userId);
            user.UserDeleteFlag = 1;
            return this._db.SaveChanges();
        }

        public int UnFreezeUser(string userId)
        {
            var user = this._db.Users.FirstOrDefault(u => u.UserId == userId);
            user.UserDeleteFlag = 0;
            return this._db.SaveChanges();
        }
    }
}
