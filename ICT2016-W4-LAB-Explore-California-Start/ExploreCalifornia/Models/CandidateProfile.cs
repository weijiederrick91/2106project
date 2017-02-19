
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace ExploreCalifornia.Models
{
    public class CandidateProfile
    {
        [Key]
        public int CandidateID { get; set; }
        public int StudentYear { get; set; }
        public double UpdatedTime { get; set; }
        public string PositionApplied { get; set; }
        public string Introduction { get; set; }
        public string CCA { get; set; }

    }
}