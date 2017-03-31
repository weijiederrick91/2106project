using System;
using System.Collections.Generic;
using Team11_2106Project.Gateway;

namespace Team11_2106Project.DomainModel
{
    public class CandidateProfile :ICandidateProfile
    {
        private int candidateID {get;set;}
        private string name { get; set; }
        private int studentyear { get; set; }
        private string cca { get; set; }
        private string introduction { get; set; }
        private IDataGateway<CandidateProfile> dataGatewayCandidateProfile = new DataGateway<CandidateProfile>(); 

        public CandidateProfile ViewProfile(int id)
        {
            return null; 
        }
       public void EditProfile(CandidateProfile cd)
        {
        }

        ICandidateProfile ICandidateProfile.ViewProfile(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CandidateProfile> ViewAllProfiles()
        {
            throw new NotImplementedException();
        }

        void ICandidateProfile.EditProfile(ICandidateProfile ic)
        {
            throw new NotImplementedException();
        }

        IEnumerable<CandidateProfile> ICandidateProfile.ViewAllProfiles()
        {
            throw new NotImplementedException();
        }
    }
}