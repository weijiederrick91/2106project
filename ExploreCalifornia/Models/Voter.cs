
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExploreCalifornia.Models
{
    public class Voter
    {
        [Key]
        public int VoterID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int SingleVote { get; set; }
    }
}