
using System.ComponentModel.DataAnnotations;
namespace DaneshkarShop.Domain.Entity.Role
{
	public class Role
	{
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string RoleTitle { get; set; }

        [MaxLength(100)]
        [Required]
        public string RoleUniqueName { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsDelete { get; set; }



        

        public ICollection<UserSelectedRole> UserSelectedRoles { get; set; }
    }
}