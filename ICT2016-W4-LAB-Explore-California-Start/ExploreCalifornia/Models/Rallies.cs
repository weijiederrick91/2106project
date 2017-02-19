
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
        public string Date { get; set; }
        public string Location { get; set; }
    }
}