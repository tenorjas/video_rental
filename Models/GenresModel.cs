using System;
using System.ComponentModel.DataAnnotations;

namespace video_rental.Models
{
    public class GenresModel
    {
        [Key]
        public int GenreID {get; set;}
        public string GenreName {get; set;}
    }
}