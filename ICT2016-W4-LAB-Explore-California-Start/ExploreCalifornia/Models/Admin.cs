﻿
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExploreCalifornia.Models
{
    public class Admin
    {
        [Key]
        public int UserID { get; set; }
        public string email { get; set; }
        public string password { get; set;}
        public int SingleVote { get; set; }
        public int AdminID { get; set; }
    }
}