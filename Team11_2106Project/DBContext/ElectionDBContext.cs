using Team11_2106Project.Models;
using System.Data.Entity;

namespace Team11_2106Project.DBContext
{
    //This Class inherits from the DbContext to the folder. This helps to expose entities in the database by using public properties of a type called DBSet/
    //Adding a generic DBSet helps to hold the CandidateProfiles.  
    //It is part of the Data Source Layer.
    public class ElectionDBContext: DbContext
    {
        public ElectionDBContext() : base("ElectionDBContext")
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