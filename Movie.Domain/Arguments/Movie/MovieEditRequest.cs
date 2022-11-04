﻿namespace Movie.Domain.Arguments.Movie;

public class MovieEditRequest
{
    public DateTime date;
    public TimeSpan endDate;
    public double price;
    public TimeSpan startDate;
    public Enum typeAnimation;


    public MovieEditRequest()
    {
    }

    public MovieEditRequest(DateTime date, TimeSpan endDate, double price, TimeSpan startDate, Enum typeAnimation,
        Guid id, Entities.Movie movie, Entities.Room room)
    {
        this.date = date;
        this.endDate = endDate;
        this.price = price;
        this.startDate = startDate;
        this.typeAnimation = typeAnimation;
        Id = id;
        Movie = movie;
        Room = room;
    }

    public Guid Id { get; set; }


    public Entities.Movie Movie { get; set; }
    public Entities.Room Room { get; set; }
}