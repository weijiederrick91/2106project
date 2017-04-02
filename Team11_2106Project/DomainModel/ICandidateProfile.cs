using System.Collections.Generic;
using Team11_2106Project.ViewModel;
namespace Team11_2106Project.DomainModel
{
    interface ICandidateProfile
    {
        CandidateProfileViewModel ViewProfile(int id);
        void EditProfile(CandidateProfileViewModel ic);
        IEnumerable<CandidateProfileViewModel> ViewAllProfiles();
    }
}
