
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Classes
{
    public class Cinema
    {
        public string Name { get; set; }
        public List<int> Halls { get; set; }
        public List<Movie> ListOfMovies { get; set; }

        public Cinema(string name, List<int> halls, List<Movie> movies)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("Cinema name must be entered");
            }
            if (halls == null || halls.Count == 0)
            {
                throw new Exception("There must be at least one hall");
            }
            if (movies == null || movies.Count == 0)
            {
                throw new Exception("There must be at least one movie");
            }

            Name = name;
            Halls = halls;
            ListOfMovies = movies;
        }
        public void WatchMovie(Movie movie)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Watching {movie.Title}");
        }
    }
}
