namespace DAL.Data
{
    using System;
    using System.Linq;

    using Entities.Models;

    public static class DbInitializer
    {
        public static void Initialize(DataBaseContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return;
            }

            var firstDate = DateTime.Now;

            var users = new User[]
            {
                new User{
                    Name="Administrator",
                    Alias="Admin",
                    Enabled=true,
                    Password="admin",
                    AuditID=null,
                    RowVersion=1,
                    CreatedDate=firstDate,
                    LastUpdate=  firstDate}
            };

            foreach (User user in users)
            {
                context.Users.Add(user);
            }

            context.SaveChanges();
        }
    }
}