using System;
using System.ComponentModel.DataAnnotations;


namespace ExploreCalifornia.Models
{
    public class Candidate
    {
        //i changed here 
        public int candidateID { get; set; }
        public string candidateName { get; set; }
        public int candidateYear { get; set; }
        public string PositionApplied { get; set; }
        [MaxLength(500)]
        public string Introduction { get; set; }
        public string CCA { get; set; }
  
    }
}