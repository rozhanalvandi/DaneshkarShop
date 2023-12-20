using System;
using DaneshkarShop.Domain.DTOs.AdminSite.User;
using DaneshkarShop.Domain.Entity;

namespace DaneshkarShop.Domain.IRepository
{
	public interface IUserRepository
	{
        #region General Methods

        bool IsExistUserByMobile(string mobile);

        void AddUser(User user);

        void SaveChange();

        User? GetUserByMobile(string mobile);

        User? GetUserById(int userId);

        #endregion

        #region Admin Side Methods 

        List<User> ListOfUsers();

        List<ListOfUsersDTO> listOfUsersWithDTO();

        #endregion
    }
}
