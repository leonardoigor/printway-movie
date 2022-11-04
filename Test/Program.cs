// See https://aka.ms/new-console-template for more information

using Movie.Domain.Entities;

var movie = new Room("teste", 100);
var isValid = movie.Chairs.Select(x => x.Name);
Console.WriteLine("Hello, World!");
