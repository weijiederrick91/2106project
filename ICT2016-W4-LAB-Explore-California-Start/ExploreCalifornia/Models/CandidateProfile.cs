
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
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime? UpdatedTime { get; set; }
        public string PositionApplied { get; set; }
        public string Introduction { get; set; }
        public string CCA { get; set; }
        public string Name { get; set; }
    }
}