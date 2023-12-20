
using DaneshkarShop.Domain.Entity.Role;

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
		

		public ICollection<UserSelectedRole> UserSelectedRoles { get; set; }

    }
}


