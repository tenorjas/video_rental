using System;

namespace video_rental.Models
{
    public class CustomersModel
    {
        [Key]
        public int CustomerID {get; set;}
        public string CustomerName {get; set;}
        public string CustomerEmail {get; set;}
        public string CustomerPhoneNumber {get; set;}
    }
}