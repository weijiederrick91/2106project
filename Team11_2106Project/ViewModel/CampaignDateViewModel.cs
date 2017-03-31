using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Team11_2106Project.ViewModel
{
    public class CampaignDateViewModel
    {
        [Key]
        public int CampaignID { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartDate { get; set; }
    }
}