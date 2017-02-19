using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ExploreCalifornia.Models
{
    public class Campaign
    {
        [Key]
        public int CampaignID { get; set; }
        public double EndTime { get; set; }
        public double StartTime { get; set; }
    }
}