using System;
using System.Collections.Generic;
using Team11_2106Project.Gateway;
using Team11_2106Project.ViewModel;
namespace Team11_2106Project.DomainModel
{
    public class CandidateProfile : ICandidateProfile
    {
        private int candidateID { get; set; }
        private string name { get; set; }
        private int studentyear { get; set; }
        private string cca { get; set; }
        private string introduction { get; set; }
        private IDataGateway<CandidateProfileViewModel> dataGatewayCandidateProfile = new DataGateway<CandidateProfileViewModel>();

        public CandidateProfileViewModel ViewProfile(int id)
        {
            return dataGatewayCandidateProfile.SelectByID(id);


        }
        public void EditProfile(CandidateProfileViewModel cd)
        {
            dataGatewayCandidateProfile.Update(cd);

        }
        public IEnumerable<CandidateProfileViewModel> ViewAllProfiles()
        {
            return dataGatewayCandidateProfile.SelectAll();
        }


    }
}