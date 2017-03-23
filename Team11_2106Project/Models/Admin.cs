
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Team11_2106Project.Models
{
    public class Admin
    {
        [Key]
        public int UserID { get; set; }
        public string Email { get; set; }
        public string Password { get; set;}
        public int SingleVote { get; set; }
        public int AdminID { get; set; }
    }
}