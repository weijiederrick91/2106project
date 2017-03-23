
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Team11_2106Project.Models
{
    //THIS CLASS IS THE MODEL COMPONENT FOR THE CANDIDATEPROFILE.
    //IT HELPS TO INSTANTIATE THE CANDIDATEPROFILE DATABASE, AS IT STATES THE ATTRIBUTE OF THE CANDIDATEPROFILE TABLE.
    //IT ASSISTS IN PROVIDING FOR THE DOMAIN LAYER AS WELL.
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