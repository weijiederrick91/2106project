
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Team11_2106Project.ViewModel
{
    public class VoterViewModel
    {
        [Key]
        public int VoterID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool HasVoted { get; set; }
    }
}