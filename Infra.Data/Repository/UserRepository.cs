using System;
using DaneshkarShop.Domain.DTOs.AdminSite.User;
using DaneshkarShop.Domain.Entity;
using DaneshkarShop.Domain.IRepository;
using Infra.Data.AppDbContext;

namespace Infra.Data.Repository
{
	public class UserRepository: IUserRepository
    {
        #region Ctor

        private readonly DaneshkarAppDbContext _context;

        public UserRepository(DaneshkarAppDbContext context)
        {
            _context = context;
        }

        #endregion

        #region General Methods 

        public bool IsExistUserByMobile(string mobile)
        {
            return _context.users.Any(p => p.Mobile == mobile);
        }

        public void AddUser(User user)
        {
            _context.users.Add(user);

            SaveChange();
        }

        public void SaveChange()
        {
            _context.SaveChanges();
        }

        public User? GetUserByMobile(string mobile)
        {
            return _context.users.SingleOrDefault(p => p.IsDelete == false && p.Mobile == mobile);
        }

        public User? GetUserById(int userId)
        {
            return _context.users.Find(userId);
        }

        #endregion

        #region Admin Side Methods

        public List<User> ListOfUsers()
        {
            return _context.users
                           .Where(p => !p.IsDelete)
                           .OrderByDescending(p => p.CreateDate)
                           .ToList();
        }

        public List<ListOfUsersDTO> listOfUsersWithDTO()
        {
            var users = _context.users
                           .Where(p => !p.IsDelete)
                           .OrderByDescending(p => p.CreateDate)
                           .ToList();

            List<ListOfUsersDTO> returnModel = new List<ListOfUsersDTO>();

            foreach (var user in users)
            {
                ListOfUsersDTO childModel = new ListOfUsersDTO()
                {
                    CreateDate = user.CreateDate,
                    Mobile = user.Mobile,
                    Username = user.UserName
                };

                returnModel.Add(childModel);
            }

            return returnModel;
        }

        #endregion
    }
}

