using Team11_2106Project.ViewModel;
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
        public DbSet<CampaignDateViewModel> CampaignDate { get; set; }
        public DbSet<AdminViewModel> Admins { get; set; }
        public DbSet<CandidateViewModel> Candidates { get; set; }
        public DbSet<VoterViewModel> Voters { get; set; }
        public DbSet<RalliesViewModel> Rallies { get; set; }
        public DbSet<CandidateProfileViewModel> CandidateProfiles { get; set;  }

    }
}