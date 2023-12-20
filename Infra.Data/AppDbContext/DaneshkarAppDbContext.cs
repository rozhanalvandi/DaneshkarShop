using System;
using DaneshkarShop.Domain.Entity;
using DaneshkarShop.Domain.Entity.Role;
using DaneshkarShop.Domain.Entity.User;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.AppDbContext
{
	public class DaneshkarAppDbContext:DbContext
	{
        public DaneshkarAppDbContext()
        {

        }
        public DaneshkarAppDbContext(DbContextOptions<DaneshkarAppDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlite("Data Source=data.db");

        public DbSet<User> users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserSelectedRole> UserSelectedRoles { get; set; }


    }
}

