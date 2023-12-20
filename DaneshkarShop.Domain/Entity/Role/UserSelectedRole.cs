using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaneshkarShop.Domain.Entity.Role
{
	public class UserSelectedRole
	{
        public int Id { get; set; }

        public int UserId { get; set; }

        public int RoleId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User.User User { get; set; }


        [ForeignKey(nameof(RoleId))]
        public Role Role { get; set; }
    }
}

