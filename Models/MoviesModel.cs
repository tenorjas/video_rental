using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace video_rental.Models
{
    public class MoviesModel
    {
        [Key]
        public int MovieID {get; set;}
        public string MovieTitle {get; set;}
        public int YearReleased {get; set;}
        public string Director {get; set;}
        public int GenresModelID {get; set;}
        public bool IsCheckedOut {get; set;}

        public GenresModel GenresModel { get; set; }
    }
}