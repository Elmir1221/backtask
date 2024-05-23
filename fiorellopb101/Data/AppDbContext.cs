using Fiorello_PB101.Models;
using fiorellopb101.Models;
using Microsoft.EntityFrameworkCore;

namespace fiorellopb101.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SliderInfo> SliderInfo { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Expert> Experts { get; set; }
        public DbSet<Setting> Settings { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Slider>().HasQueryFilter(m => !m.SoftDeleted);
            modelBuilder.Entity<Blog>().HasQueryFilter(m => !m.SoftDeleted);
            modelBuilder.Entity<Category>().HasQueryFilter(m => !m.SoftDeleted);
            modelBuilder.Entity<Product>().HasQueryFilter(m => !m.SoftDeleted);




            modelBuilder.Entity<Blog>().HasData(
               new Blog
               {
                   Id =1,
                   Title="REsadin Blogu",
                   Description= "Resadin Blogu",
                   Image = "blog-feature-img-1.jpg",
                   CreatedDate = DateTime.Now

               },
            new Blog
            {
                Id = 2,
                Title = "Behruzun Blogu",
                Description = "Resadin Blogu",
                Image = "blog-feature-img-2.jpg",
                CreatedDate = DateTime.Now

            },
            new Blog
            {
                Id = 3,
                Title = "Ilqarin Blogu",
                Description = "Ilqarin Blogu",
                Image = "blog-feature-img-3.jpg",
                CreatedDate = DateTime.Now

            });
            modelBuilder.Entity<Expert>().HasData(
          new Expert
          {
              Id = 1,
              Image = "h3-team-img-1.png ",
              Name = "CRYSTAL BROOKS",
              Position = "FLORIST",
              CreatedDate = DateTime.Now
          },
          new Expert
          {
              Id = 2,
              Image = "h3-team-img-2.png ",
              Name = "SHIRLEY HARRIS",
              Position = "Manager",
              CreatedDate = DateTime.Now
          },
          new Expert
          {
              Id = 3,
              Image = "h3-team-img-3.png ",
              Name = "BEVERLY CLARK",
              Position = "Florist",
              CreatedDate = DateTime.Now
          },
          new Expert
          {
              Id = 4,
              Image = "h3-team-img-4.png ",
              Name = "AMANDA WATKINS ",
              Position = "Florist",
              CreatedDate = DateTime.Now
          });

        }
    }

}
