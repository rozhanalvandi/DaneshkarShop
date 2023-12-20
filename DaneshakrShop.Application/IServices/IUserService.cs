using System;
using DaneshkarShop.Domain.DTOs.AdminSite.User;
using DaneshkarShop.Domain.DTOs.SiteSide.Account;
using DaneshkarShop.Domain.Entity;
using DaneshkarShop.Domain.Entity.User;

namespace DaneshakrShop.Application.IServices
{
	public interface IUserService
	{
        #region General Methods

        bool IsExistUserByMobile(string mobile);

        User FillUserEntity(UserRegisterDTO userDTO);

        void AddUser(User user);

        bool RegisterUser(UserRegisterDTO userDTO);

        User? GetUserByMobile(string mobile);

        #endregion

        #region Admin Side Methods 

        List<User> ListOfUsers();

        List<ListOfUsersDTO> listOfUsersWithDTO();

        #endregion
    }
}

