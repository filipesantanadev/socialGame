using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using socialGame.BLL;


namespace socialGame.DAL
{
    public class socialGameDBContext : IdentityDbContext<ApplicationUser>
    {
        public socialGameDBContext(DbContextOptions<socialGameDBContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Post> Posts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().ToTable("User");
            /*modelBuilder.Entity<Friendship>().ToTable("Friendship");

            modelBuilder.Entity<Friendship>()
                .HasKey(a => new { a.UserIdA, a.UserIdB });

            modelBuilder.Entity<Friendship>()
                .HasOne(a => a.UserA)
                .WithMany(u => u.FriendshipA)
                .HasForeignKey(a => a.UserIdA)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Friendship>()
                .HasOne(a => a.UserB)
                .WithMany(u => u.FriendshipB)
                .HasForeignKey(a => a.UserIdB)
                .OnDelete(DeleteBehavior.Restrict);*/
        }

        public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<socialGameDBContext>
        {
            public socialGameDBContext CreateDbContext(string[] args)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../socialGame.API/appsettings.json").Build();

                var builder = new DbContextOptionsBuilder<socialGameDBContext>();
                var connectionString = configuration.GetConnectionString("DatabaseConnection");
                builder.UseSqlServer(connectionString);
                return new socialGameDBContext(builder.Options);
            }
        }
    }        
}
