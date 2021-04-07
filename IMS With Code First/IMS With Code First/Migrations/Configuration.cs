namespace IMS_With_Code_First.Migrations
{
    using IMS_With_Code_First.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<IMS_With_Code_First.Models.InventoryDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "IMS_With_Code_First.Models.InventoryDbContext";
        }

        protected override void Seed(IMS_With_Code_First.Models.InventoryDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            List<Category> categories = new List<Category>()
            {
                new Category(){CategoryName="Book"},
                new Category(){CategoryName="Grocery"},
                new Category(){CategoryName="Electronics"},
                new Category(){CategoryName="Cloth"},
            };

            
            if (!context.Categories.Any())
            {
                foreach (var item in categories)
                {
                    context.Categories.Add(item);
                    context.SaveChanges();
                }
            }
            
        }
    }
}
