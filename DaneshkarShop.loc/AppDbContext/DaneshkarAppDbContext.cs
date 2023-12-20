using System;
using DaneshkarShop.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace DaneshkarShop.loc.AppDbContext
{
	public class DaneshkarAppDbContext :DbContext
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
    }
}

