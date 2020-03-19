namespace TestAsm.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TestAsm.Data.TestAsmContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TestAsm.Data.TestAsmContext context)
        {
            context.Categories.AddOrUpdate(x => x.Id, new Models.Category()
            {
                Id = 1,
                Name = "Quần Bé Gái",
                Description = "Quần dành cho bé gái",
                Status = Models.Category.CategoryStatus.Active

            },
            new Models.Category()
            {
                Id = 2,
                Name = "Áo Bé Gái",
                Description = "Áo dành cho bé gái",
                Status = Models.Category.CategoryStatus.Active
            },
            new Models.Category()
            {
                Id = 3,
                Name = "Áo Bé Trai",
                Description = "Áo dành cho bé trai",
                Status = Models.Category.CategoryStatus.Active
            },
            new Models.Category()
            {
                Id = 4,
                Name = "Quần Bé Trai",
                Description = "Quần dành cho bé trai",
                Status = Models.Category.CategoryStatus.Active
            },
            new Models.Category()
            {
                Id = 5,
                Name = "Bộ Bé Trai",
                Description = "Trang phục theo bộ dành cho bé trai",
                Status = Models.Category.CategoryStatus.Active
            },
            new Models.Category()
            {
                Id = 6,
                Name = "Bộ Bé Gái",
                Description = "Trang phục theo bộ dành cho bé gái",
                Status = Models.Category.CategoryStatus.Active
            },
             new Models.Category()
             {
                 Id = 7,
                 Name = "Váy cho bé gái",
                 Description = "Váy dành cho bé gái",
                 Status = Models.Category.CategoryStatus.Active
             });
            context.Products.AddOrUpdate(x => x.Id,
                new Models.Product()
                {
                    Id = 1,
                    Name = "Áo sơ mi trắng loại 1",
                    Description = "No description",
                    Image = "https://babi.vn/images/watermarked/1/variant_image/71/ao-so-mi-soc-ngan-tay-cho-be-trai-size-dai-co-11-14-tuoi-vi_(3).JPG",
                    Price = 150000,
                    Status = Models.Product.ProductStatus.Active,
                    CategoryId = 3
                },
                new Models.Product()
                {
                    Id = 2,
                    Name = "Áo sơ mi trắng loại 2",
                    Description = "No description",
                    Image = "https://babi.vn/images/watermarked/1/variant_image/71/ao-so-mi-soc-ngan-tay-cho-be-trai-size-dai-co-11-14-tuoi-vi_(3).JPG",
                    Price = 90000,
                    Status = Models.Product.ProductStatus.Active,
                    CategoryId = 3
                },
                new Models.Product()
                {
                    Id = 3,
                    Name = "Áo sơ mi loại xxx",
                    Description = "No description",
                    Image = "https://babi.vn/images/watermarked/1/variant_image/71/ao-so-mi-soc-ngan-tay-cho-be-trai-size-dai-co-11-14-tuoi-vi_(3).JPG",
                    Price = 110000,
                    Status = Models.Product.ProductStatus.Active,
                    CategoryId = 3
                },
                new Models.Product()
                {
                    Id = 4,
                    Name = "Quần Legging Lửng",
                    Description = "No description",
                    Image = "https://babi.vn/images/watermarked/1/variant_image/71/quan-legging-lung-be-gai-lien-vay-mau-tron-in-meo-sieu-cute-9-thang-9-tuoi_(4).JPG",
                    Price = 110000,
                    Status = Models.Product.ProductStatus.Active,
                    CategoryId = 1
                },
                 new Models.Product()
                 {
                     Id = 5,
                     Name = "Đồ bộ thể thao bé trai",
                     Description = "No description",
                     Image = "https://babi.vn/images/watermarked/1/variant_image/71/do-bo-bong-ro-sat-nach-cho-be-trai-in-so-24-nang-dong-1-10-tuoi_(2).jpg",
                     Price = 300000,
                     Status = Models.Product.ProductStatus.Active,
                     CategoryId = 5
                 });
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
        }
    }
}
