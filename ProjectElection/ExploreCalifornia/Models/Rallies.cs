
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace ExploreCalifornia.Models
{
    public class Rallies
    {
        [Key]
        public int RalliesID { get; set; }
        public System.DateTime Date { get; set; }
        public string Location { get; set; }
        public string CandidateID { get; set;}
    }
}