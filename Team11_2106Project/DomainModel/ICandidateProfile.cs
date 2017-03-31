using System.Collections.Generic;

namespace Team11_2106Project.DomainModel
{
    interface ICandidateProfile
    {
        ICandidateProfile ViewProfile(int id);
        void EditProfile(ICandidateProfile ic);
        IEnumerable<CandidateProfile> ViewAllProfiles(); 
    }
}
