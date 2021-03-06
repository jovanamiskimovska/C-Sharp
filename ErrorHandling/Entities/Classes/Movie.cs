using Entities.Enums;
using System;

namespace Entities.Classes
{
    public class Movie
    {
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public int Rating { get; set; }
        public double TicketPrice { get; set; }

        public Movie(string title, Genre genre, int rating)
        {
            if (rating < 1 || rating > 5)
            {
                throw new Exception("Rating must be between 1 and 5");
            }
            if (string.IsNullOrEmpty(title))
            {
                throw new Exception("You must enter a title");
            }

            Title = title;
            Genre = genre;
            Rating = rating;
            TicketPrice = 5 * rating;
        }
    }
}
