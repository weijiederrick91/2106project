using ExploreCalifornia.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace ExploreCalifornia.DAL
{
    public class ElectionDBContext: DbContext
    {
        public ElectionDBContext() : base("ElectionDB")
        {

        }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Voter> Voters { get; set; }
        public DbSet<Rallies> Ralliess { get; set; }
        public DbSet<CandidateProfile> CandidateProfiles { get; set;  }

    }
}