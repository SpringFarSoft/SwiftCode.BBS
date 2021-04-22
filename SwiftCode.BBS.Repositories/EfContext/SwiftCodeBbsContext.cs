using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SwiftCode.BBS.Model.Models;

namespace SwiftCode.BBS.Repositories.EfContext
{
    public class SwiftCodeBbsContext : DbContext
    {
        public SwiftCodeBbsContext()
        {

        }
        public SwiftCodeBbsContext(DbContextOptions<SwiftCodeBbsContext> options)
            : base(options)
        {

        }
        public DbSet<Article> Articles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().Property(p => p.Title).HasMaxLength(128);
            modelBuilder.Entity<Article>().Property(p => p.Submitter).HasMaxLength(64);
            modelBuilder.Entity<Article>().Property(p => p.Category).HasMaxLength(256);
            // modelBuilder.Entity<Article>().Property(p => p.Content).HasMaxLength(128);
            modelBuilder.Entity<Article>().Property(p => p.Remark).HasMaxLength(1024);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Server=.; Database=SwiftCodeBbs; Trusted_Connection=True; Connection Timeout=600;MultipleActiveResultSets=true;")
                .LogTo(Console.WriteLine, LogLevel.Information);
        }
    }
}
