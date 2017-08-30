using System;

namespace video_rental.Models
{
    public class GenresModel
    {
        [Key]
        public int GenreID {get; set;}
        public string GenreName {get; set;}
    }
}