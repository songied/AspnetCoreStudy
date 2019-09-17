using AspnetCoreStudy.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetCoreStudy.DataContext
{
    public class AspnetCoreStudyDbContext : DbContext
    {
        public DbSet<Member> Members { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Reply> Replies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=AspnetCoreStudyDb;User Id=sa;Password = 1234; ");
        }
    }
}
