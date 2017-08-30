using System;

namespace video_rental.Models
{
    public class MoviesModel
    {
        [Key]
        public int MovieID {get; set;}
        public string MovieTitle {get; set;}
        public int YearReleased {get; set;}
        public string Director {get; set;}
        [ForeignKey]
        public int GenreID {get; set;}
    }
}