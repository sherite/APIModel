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

        public DbSet<UserGroups> UserGroups { get; set; }
        public DbSet<GroupUsers> GroupUsers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable(nameof(Users));
            modelBuilder.Entity<Group>().ToTable(nameof(Groups));
            modelBuilder.Entity<GroupUsers>().ToTable(nameof(GroupUsers));
            modelBuilder.Entity<UserGroups>().ToTable(nameof(UserGroups));

            base.OnModelCreating(modelBuilder);
        }
    }
}