using System;
using DaneshkarShop.Domain.Entity;
using DaneshkarShop.Domain.IRepository;
using DaneshkarShop.loc.AppDbContext;

namespace DaneshkarShop.loc.Repository
{
	public class UserRepository : IUserRepository
    {
		private readonly DaneshkarAppDbContext _context;
		public UserRepository (DaneshkarAppDbContext context)
		{
            _context = context;
        }

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

    }
}

