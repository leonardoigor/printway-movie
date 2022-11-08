using System.Data.Entity.Validation;
using Movie.Domain.Entities;
using Movie.Domain.Enums;
using Movie.Infra.Persistence.Contexts;
using Movie.Infra.Persistence.Repositories;
using Newtonsoft.Json;

namespace Movie.Infra.Persistence.Seeds;

public class ModelParse
{
    public string Image { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Minutes { get; set; }
    public string Hours { get; set; }
}

public class Seeds
{
    private readonly PopCornContext context;
    private readonly MovieRepository service;

    public Seeds(PopCornContext context)
    {
        this.context = context;
        service = new MovieRepository(context);
    }


    public void Seed()
    {
        #region Add seeds

        var str =
                @"[{'image':'https://images-na.ssl-images-amazon.com/images/M/MV5BMjEyOTYyMzUxNl5BMl5BanBnXkFtZTcwNTg0MTUzNA@@._V1_SX1500_CR0,0,1500,999_AL_.jpg','title':'Avatar','description':'A paraplegic marine dispatched','minutes':42,'hours':2},{'image':'https://images-na.ssl-images-amazon.com/images/M/MV5BMTI0NTI4NjE3NV5BMl5BanBnXkFtZTYwMDA0Nzc4._V1_.jpg','title':'I Am Legend','description':'Years after a plague kills mos','minutes':41,'hours':1},{'image':'https://images-na.ssl-images-amazon.com/images/M/MV5BMTMwNTg5MzMwMV5BMl5BanBnXkFtZTcwMzA2NTIyMw@@._V1_SX1777_CR0,0,1777,937_AL_.jpg','title':'300','description':'King Leonidas of Sparta and a ','minutes':57,'hours':1},{'image':'https://images-na.ssl-images-amazon.com/images/M/MV5BMTA0NjY0NzE4OTReQTJeQWpwZ15BbWU3MDczODg2Nzc@._V1_SX1777_CR0,0,1777,999_AL_.jpg','title':'The Avengers','description':'Earths mightiest heroes must c','minutes':23,'hours':2},{'image':'https://images-na.ssl-images-amazon.com/images/M/MV5BNDIwMDIxNzk3Ml5BMl5BanBnXkFtZTgwMTg0MzQ4MDE@._V1_SX1500_CR0,0,1500,999_AL_.jpg','title':'The Wolf of Wall Street','description':'Based on the true story of Jor','minutes':0,'hours':3},{'image':'https://images-na.ssl-images-amazon.com/images/M/MV5BMjA3NTEwOTMxMV5BMl5BanBnXkFtZTgwMjMyODgxMzE@._V1_SX1500_CR0,0,1500,999_AL_.jpg','title':'Interstellar','description':'A team of explorers travel thr','minutes':49,'hours':2},{'image':'https://images-na.ssl-images-amazon.com/images/M/MV5BNDc1MGUyNzItNWRkOC00MjM1LWJjNjMtZTZlYWIxMGRmYzVlXkEyXkFqcGdeQXVyMzU3MDEyNjk@._V1_SX1777_CR0,0,1777,999_AL_.jpg','title':'Game of Thrones','description':'While a civil war brews betwee','minutes':56,'hours':0},{'image':'https://images-na.ssl-images-amazon.com/images/M/MV5BMjM5MTM1ODUxNV5BMl5BanBnXkFtZTgwNTAzOTI2ODE@._V1_.jpg','title':'Vikings','description':'The world of the Vikings is br','minutes':44,'hours':0},{'image':'https://images-na.ssl-images-amazon.com/images/M/MV5BNDI3ODYyODY4OV5BMl5BanBnXkFtZTgwNjE5NDMwMDI@._V1_SY1000_SX1500_AL_.jpg','title':'Gotham','description':'The story behind Detective Jam','minutes':42,'hours':0},{'image':'https://images-na.ssl-images-amazon.com/images/M/MV5BMTc2ODg0MzMzM15BMl5BanBnXkFtZTgwODYxODA5NTE@._V1_SY1000_SX1500_AL_.jpg','title':'Power','description':'James GhostSt. Patrick, a weal','minutes':50,'hours':0},{'image':'https://images-na.ssl-images-amazon.com/images/M/MV5BMTk2MDMzMTc0MF5BMl5BanBnXkFtZTgwMTAyMzA1OTE@._V1_SX1500_CR0,0,1500,999_AL_.jpg','title':'Narcos','description':'A chronicled look at the crimi','minutes':49,'hours':0},{'image':'https://images-na.ssl-images-amazon.com/images/M/MV5BMTgyMzI5NDc5Nl5BMl5BanBnXkFtZTgwMjM0MTI2MDE@._V1_SY1000_CR0,0,1498,1000_AL_.jpg','title':'Breaking Bad','description':'A high school chemistry teache','minutes':49,'hours':0},{'image':'https://images-na.ssl-images-amazon.com/images/M/MV5BMjM3ODc1ODI5Ml5BMl5BanBnXkFtZTgwODMzMDY3OTE@._V1_.jpg','title':'Doctor Strange','description':'After his career is destroyed,','minutes':0,'hours':0},{'image':'https://images-na.ssl-images-amazon.com/images/M/MV5BMjE3MzA4Nzk3NV5BMl5BanBnXkFtZTgwNjAxMTc1ODE@._V1_SX1777_CR0,0,1777,744_AL_.jpg','title':'Rogue One: A Star Wars Story','description':'The Rebellion makes a risky mo','minutes':0,'hours':0},{'image':'https://images-na.ssl-images-amazon.com/images/M/MV5BN2EyYzgyOWEtNTY2NS00NjRjLWJiNDYtMWViMjg5MWZjYjgzXkEyXkFqcGdeQXVyNjUwNzk3NDc@._V1_.jpg','title':'Assassins Creed','description':'When Callum Lynch explores the','minutes':0,'hours':0},{'image':'https://images-na.ssl-images-amazon.com/images/M/MV5BMjMxNjc1NjI0NV5BMl5BanBnXkFtZTgwNzA0NzY0ODE@._V1_SY1000_CR0,0,1497,1000_AL_.jpg','title':'Luke Cage','description':'Given superstrength and durabi','minutes':55,'hours':0}]"
            ;
        str = str.Replace("\n", Environment.NewLine);
        str = str.Replace("'", "\"");
        var json = JsonConvert.DeserializeObject<List<ModelParse>>(str
        );

        #endregion

        var movies = json.Select(x => new Domain.Entities.Movie
        {
            Title = x.Title,
            Description = x.Description,
            Image = x.Image,
            Minutes = int.Parse(x.Minutes),
            Hours = int.Parse(x.Hours)
        }).ToList();
        if (!context.Movies.Any())
        {
            Console.WriteLine("Movies: " + movies.Count());

            foreach (var movie in movies)
                try
                {
                    service.Add(movie);
                    Console.WriteLine("Movie: " + movie.Title);
                }

                catch (DbEntityValidationException e)
                {
                    Console.WriteLine(e);
                    throw;
                }
        }

        var rooms_fake_size = 10;
        var rooms = new List<Room>();
        if (!context.Rooms.Any())
        {
            for (var i = 0; i < rooms_fake_size; i++)
                rooms.Add(new Room
                {
                    Name = $"Sala {i + 1}",
                    // range from 10 to 20 seats
                    Quantity = new Random().Next(10, 50)
                });
            context.Rooms.AddRange(rooms);
        }

        if (!context.Sessions.Any())
        {
            var sessions = new List<Session>();
            for (var i = 0; i < movies.Capacity; i++)
            {
                var movie = movies[i];

                var room = rooms[new Random().Next(0, rooms_fake_size)];
                sessions.Add(new Session
                {
                    Movie = movie,
                    Room = room,
                    Date = DateTime.Now.AddDays(i),
                    MovieId = movie.Id,
                    RoomId = room.Id,
                    StartDate = DateTime.Now.AddHours(i),
                    EndDate = DateTime.Now.AddHours(i + 1),
                    IsDubbed = new Random().Next(0, 2) == 1,
                    Price = new Random().Next(10, 50),
                    TypeAnimation = (TypeAnimation)new Random().Next(0, 2)
                });
            }

            context.Sessions.AddRange(sessions);
        }

        context.SaveChanges();
    }
}
