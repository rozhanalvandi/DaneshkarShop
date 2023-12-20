﻿using System;
namespace DaneshkarShop.Domain.Entity.User
{
	public class User
	{
		public int Id { get; set; }
		public string  UserName { get; set; }
		public string Mobile { get; set; }
		public string Password { get; set; }
		public DateTime CreateDate { get; set; }
		public bool IsDelete { get; set; }
		public int RoleId { get; set; }

		public Role.Role Role { get; set; }

	}
}

