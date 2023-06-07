
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using MVCAPP.DAL;
using MVCAPP.Models;

using System.Diagnostics.Metrics;
using System.Linq.Expressions;
using System.Reflection.Emit;

namespace DAL
{
    public class MyAppDbContext : DbContext
    {
        public MyAppDbContext(DbContextOptions<MyAppDbContext> options) : base(options) { }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<PaymentDetail> PaymentDetails { get; set; }    
        public  DbSet<Favorite> Favorites { get; set; }
        public DbSet<Producer> Producers { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        protected override void OnModelCreating(ModelBuilder applicationBuilder)
        {






            foreach (var entityType in applicationBuilder.Model.GetEntityTypes())
            {
                var isDeletedProperty = entityType.FindProperty("IsDeleted");
                if (isDeletedProperty != null && isDeletedProperty.ClrType == typeof(bool))
                {
                    var parameter = Expression.Parameter(entityType.ClrType, "e");
                    var body = Expression.Equal(
                        Expression.Property(parameter, isDeletedProperty.PropertyInfo),
                        Expression.Constant(false)
                    );
                    var lambda = Expression.Lambda(body, parameter);

                    applicationBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
                }
            }
            //Cinema
            applicationBuilder.Entity<Actor>().HasData(new Actor()
            {
                Id = 1,
                FullName = "Actor 1",
                Bio = "This is the Bio of the first actor",
                ProfilePictureURL = "http://dotnethow.net/images/actors/actor-1.jpeg"

            },
                        new Actor()
                        {
                            Id = 2,
                            FullName = "Actor 2",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-2.jpeg"
                        },
                        new Actor()
                        { 
                            Id = 3,
                            FullName = "Actor 3",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-3.jpeg"
                        },
                        new Actor()
                        {
                            Id = 4,
                            FullName = "Actor 4",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-4.jpeg"
                        },
                        new Actor()
                        {
                            Id = 5,
                            
                            FullName = "Actor 5",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-5.jpeg"
                        });

            applicationBuilder.Entity<Cinema>().HasData(new Cinema()
            {
                Id = 1,
                Name = "Cinema 1",
                Logo = "http://dotnethow.net/images/cinemas/cinema-1.jpeg",
                Description = "This is the description of the first cinema"
            },
                     new Cinema()
                     {
                         Id = 2,
                         Name = "Cinema 2",
                         Logo = "http://dotnethow.net/images/cinemas/cinema-2.jpeg",
                         Description = "This is the description of the first cinema"
                     },
                     new Cinema()
                     {
                         Id = 3,
                         Name = "Cinema 3",
                         Logo = "http://dotnethow.net/images/cinemas/cinema-3.jpeg",
                         Description = "This is the description of the first cinema"
                     },
                     new Cinema()
                     {

                         Id = 4,
                         Name = "Cinema 4",
                         Logo = "http://dotnethow.net/images/cinemas/cinema-4.jpeg",
                         Description = "This is the description of the first cinema"
                     },
                     new Cinema()
                     {
                         Id = 5,
                         Name = "Cinema 5",
                         Logo = "http://dotnethow.net/images/cinemas/cinema-5.jpeg",
                         Description = "This is the description of the first cinema"
                     });
        
            applicationBuilder.Entity<Producer>().HasData(new Producer()
            {
                Id = 1,
                FullName = "Producer 1",
                Bio = "This is the Bio of the first ",
                ProfilePictureURL = "http://dotnethow.net/images/producers/producer-1.jpeg"

            },
                        new Producer()
                        {
                            Id = 2,
                            FullName = "Producer 2",
                            Bio = "This is the Bio of the second ",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-2.jpeg"
                        },
                        new Producer()
                        {
                            Id = 3,
                            FullName = "Producer 3",
                            Bio = "This is the Bio of the second ",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-3.jpeg"
                        },
                        new Producer()
                        {
                            Id = 4,
                            FullName = "Producer 4",
                            Bio = "This is the Bio of the second ",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-4.jpeg"
                        },
                        new Producer()
                        {
                            Id = 5,
                            FullName = "Producer 5",
                            Bio = "This is the Bio of the second ",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-5.jpeg"
                        });
            applicationBuilder.Entity<Movie>().HasData(
                        new Movie()
                        {
                            Id = 1,
                            Name = "Life",
                            Description = "This is the Life movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",

                            CinemaId = 3,
                            ProducerId = 3,
                            MovieCategory = MovieCategory.Documentary,


                        },


                        new Movie()
                        {

                            Id = 2,
                            Name = "The Shawshank Redemption",
                            Description = "This is the Shawshank Redemption description",
                            Price = 29.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-1.jpeg",

                            CinemaId = 1,
                            ProducerId = 1,
                            MovieCategory = MovieCategory.Action
                        },
                        new Movie()
                        {

                            Id = 3,
                            Name = "Ghost",
                            Description = "This is the Ghost movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-4.jpeg",

                            CinemaId = 4,
                            ProducerId = 4,
                            MovieCategory = MovieCategory.Horror
                        },
                        new Movie()
                        {

                            Id = 4,
                            Name = "Race",
                            Description = "This is the Race movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-6.jpeg",

                            CinemaId = 1,
                            ProducerId = 2,
                            MovieCategory = MovieCategory.Documentary
                        },
                        new Movie()
                        {

                            Id = 5,
                            Name = "Scoob",
                            Description = "This is the Scoob movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-7.jpeg",

                            CinemaId = 1,
                            ProducerId = 3,
                            MovieCategory = MovieCategory.Cartoon
                        },
                        new Movie()
                        {
                            Id = 6,
                            Name = "Cold Soles",
                            Description = "This is the Cold Soles movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-8.jpeg",

                            CinemaId = 1,
                            ProducerId = 5,
                            MovieCategory = MovieCategory.Drama
                        });

            applicationBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser()
            {
                Id = 1,
                FullName = "Leyla",
                UserName = "Selimli",
                Email = "admin@etickets.com",
                EmailConfirmed = true,
                Roles = UserRoles.Admin,
                Password = "Leyla123"
            },

            new ApplicationUser()
            {
                Id = 2,
                FullName = "Kamran",
                UserName = "Ehmedli",
                Email = "kamran@gmail.com",
                EmailConfirmed = true,
                Roles = UserRoles.User,
                Password = "Admin123"
            }
            );


        }
    }
}

