using System;
using System.ComponentModel.DataAnnotations;

namespace DaneshkarShop.Domain.DTOs.SiteSide.Account
{
	public class UserRegisterDTO
	{
        public string Mobile { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "کلمه ی عبور و تکرار آن با هم متفاوت هستند")]
        public string RePassword { get; set; }
    }
}

