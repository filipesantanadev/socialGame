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
    public class socialGameDBContext : IdentityDbContext<User>
    {
        public socialGameDBContext(DbContextOptions<socialGameDBContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("User");
            /*modelBuilder.Entity<Amizade>().ToTable("Amizade");

            modelBuilder.Entity<Amizade>()
                .HasKey(a => new { a.UsuarioIdA, a.UsuarioIdB });

            modelBuilder.Entity<Amizade>()
                .HasOne(a => a.UsuarioA)
                .WithMany(u => u.AmizadesA)
                .HasForeignKey(a => a.UsuarioIdA)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Amizade>()
                .HasOne(a => a.UsuarioB)
                .WithMany(u => u.AmizadesB)
                .HasForeignKey(a => a.UsuarioIdB)
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
