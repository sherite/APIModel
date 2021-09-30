namespace DAL
{
    using Entities.Models;

    using Microsoft.EntityFrameworkCore;

    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        { }

        public DbSet<User> Users {get;set;}
        public DbSet<Group> Groups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable(nameof(Users));
            modelBuilder.Entity<Group>().ToTable(nameof(Groups));

            base.OnModelCreating(modelBuilder);
        }
    }
}