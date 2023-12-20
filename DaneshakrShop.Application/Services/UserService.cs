using System;
using DaneshakrShop.Application.IServices;
using DaneshakrShop.Application.Utilities;
using DaneshkarShop.Domain.DTOs.AdminSite.User;
using DaneshkarShop.Domain.DTOs.SiteSide.Account;
using DaneshkarShop.Domain.Entity;
using DaneshkarShop.Domain.Entity.User;
using DaneshkarShop.Domain.IRepository;

namespace DaneshakrShop.Application.Services
{
	public class UserService : IUserService
    {
		private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        #region General Methods

        public bool IsExistUserByMobile(string mobile)
        {
            return _userRepository.IsExistUserByMobile(mobile.Trim());
        }

        public User FillUserEntity(UserRegisterDTO userDTO)
        {
            //Object Mapping
            User user = new User()
            {
                Mobile = userDTO.Mobile.Trim(),
                Password = PasswordHelper.EncodePasswordMd5(userDTO.Password),
                UserName = userDTO.Mobile,
                CreateDate = DateTime.Now
            };

            return user;
        }

        public void AddUser(User user)
        {
            _userRepository.AddUser(user);
        }

        public bool RegisterUser(UserRegisterDTO userDTO)
        {
            //Is Exist Any User By Mobile
            var isExist = IsExistUserByMobile(userDTO.Mobile);
            if (isExist == true)
            {
                return false;
            }

            //Fill Entity
            var user = FillUserEntity(userDTO);

            //Add User To Data Base 
            AddUser(user);

            return true;
        }

        public bool LoginUser(UserLoginDTO loginDTO)
        {
            //Get User By Mobile
            var user = _userRepository.GetUserByMobile(loginDTO.Mobile);
            if (user == null)
            {
                return false;
            }

            return true;
        }

        public User? GetUserByMobile(string mobile)
        {
            return _userRepository.GetUserByMobile(mobile);
        }

        #endregion

        #region Admin Side Methods

        public List<User> ListOfUsers()
        {
            return _userRepository.ListOfUsers();
        }

        public List<ListOfUsersDTO> listOfUsersWithDTO()
        {
            return _userRepository.listOfUsersWithDTO();
        }

        #endregion
    }
}

