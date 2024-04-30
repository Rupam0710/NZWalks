using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Data
{
    public class NZWalksDbContextcs : DbContext
    {   
        //To create a constructor - ctor
        public NZWalksDbContextcs(DbContextOptions<NZWalksDbContextcs> dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Difficulty> Difficulties { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed data for Difficulties
            //Easy, Medium , Hard

            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("51120843-e0f2-4ea5-a073-0a40f2f376ee") ,
                    Name = "Easy"
                },
                 new Difficulty()
                {
                    Id = Guid.Parse("8cb9e5b9-84f5-4974-81fd-e133a24bc87b") ,
                    Name = "Medium"
                },
                  new Difficulty()
                {
                    Id = Guid.Parse("5a8ca8af-58f6-47f4-b032-259b6f1fe1fb") ,
                    Name = "Hard"
                },
            };

            //seed difficulties to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);


            //Seed data for Regions
            var regions = new List<Region>()
            {
                new Region()
                {
                  Id = Guid.Parse("4303c959-2a22-4f8c-bb20-924990a73364"),
                  Name = "Auckland",
                  Code = "AKL",
                  RegionImageUrl = "https://images.ctfassets.net/bth3mlrehms2/3Iquh7an0sBOkJLzCDv5iX/03e5eda0131ce61bc6a1010caf5b25c4/Neuseeland__Christchurch.jpg?w=3504&h=1971&fl=progressive&q=50&fm=jpg"

                },
                 new Region()
                {
                  Id = Guid.Parse("9afa9c73-3dbe-46e0-ba0a-dca4b5e29913"),
                  Name = "ChristChurch",
                  Code = "CHC",
                  RegionImageUrl = "https://i.natgeofe.com/n/2d8130f8-becb-4fef-8a78-eafad9bdf2c5/IGCC1_4x3.jpg"

                },
                  new Region()
                {
                  Id = Guid.Parse("8bca55be-7e8e-42d9-bd9d-f1655b4b923b"),
                  Name = "Wellington",
                  Code = "WLG",
                  RegionImageUrl = "https://images.prismic.io/indiecampers-demo/627620cc-2a55-4f55-ab38-a7d3b4a623fb_christchurch_card-min.jpg?auto=compress,format&rect=0,0,4498,3000&w=1360&q=30"

                },
            };

            //seed regions to the database
            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
