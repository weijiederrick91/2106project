using System.Collections.Generic;
using Team11_2106Project.Gateway;
using Team11_2106Project.Models;
namespace Team11_2106Project.TableModule
{
    //This class handles the business logic for all rows in the CandidateProfile Database table. It is part of the Domain Layer.
    public class CandidateProfileTM
    {
        private DataRUGateway<CandidateProfile> TestGateway = new DataRUGateway<CandidateProfile>();

        public IEnumerable<CandidateProfile> ViewProfiles()
        {
            return TestGateway.SelectAll();
        }

        public CandidateProfile ViewSpecificProfile(int? id)
        {
            return TestGateway.SelectByID(id);
        }
        public void EditProfile(CandidateProfile candidateprofile)
        {
            TestGateway.Update(candidateprofile);
        }

    }
}