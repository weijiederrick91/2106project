using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Team11_2106Project.Models
{
    public class Campaign
    {
        [Key]
        public int CampaignID { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime StartTime { get; set; }
    }
}