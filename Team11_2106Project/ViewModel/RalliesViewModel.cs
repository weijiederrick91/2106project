
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Team11_2106Project.ViewModel
{
    public class RalliesViewModel
    {
        [Key]
        public int RalliesID { get; set; }
        public string CandidateID { get; set; }
        public string CandidateName { get; set; }
        public System.DateTime Date { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
    }
}