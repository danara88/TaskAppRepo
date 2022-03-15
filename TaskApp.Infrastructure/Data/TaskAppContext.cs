using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TaskApp.Core.Entities;

namespace TaskApp.Infrastructure.Data
{
    /// <summary>
    /// Class to set up context
    /// </summary>
    public class TaskAppContext : DbContext
    {
        public TaskAppContext()
        {
        }

        public TaskAppContext(DbContextOptions<TaskAppContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// OnConfiguring method
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("Default");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        /// <summary>
        /// OnModelCreating method
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryHomework>().HasKey(x => new { x.CategoryId, x.HomeworkId });

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Homework> Homeworks { get; set; }

        public virtual DbSet<CategoryHomework> CategoriesHomeworks { get; set; }

    }
}
