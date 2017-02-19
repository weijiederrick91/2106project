using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExploreCalifornia.Models
{
    public class Booking
    {
        [Key]
        public int BookingID { get; set; }
        public int TourID { get; set; }
        public string TourName { get; set; }
        public string ClientID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DepartureDate { get; set; }
        [Required]
        public int NumberofPeople { get; set; }
        [Required]
        public string FullName { get; set; }
        public string Email { get; set; }
        [Required]
        public string ContactNo { get; set; }
        public string SpecialRequest { get; set; }

    }

}