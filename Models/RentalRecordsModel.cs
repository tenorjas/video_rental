using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace video_rental.Models
{
    public class RentalRecordsModel
    {
        public int RentalID {get; set;}
        public int CustomerID {get; set;}
        public string CustomerName {get; set;}
        public int MovieID {get; set;}
        public string MovieTitle {get; set;}
        public DateTime DueDate {get; set;}
        public bool IsOverdue {get; set;}
    }
}