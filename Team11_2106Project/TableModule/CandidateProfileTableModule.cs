using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team11_2106Project.DAL;
using Team11_2106Project.Models;
using System.Web.Mvc;
namespace Team11_2106Project.TableModule
{
    //This class handles the business logic for all rows in the CandidateProfile Database table. It is part of the Domain Layer.
    public class CandidateProfileTableModule
    {
        private DataRUGateway<CandidateProfile> TestGateway = new DataRUGateway<CandidateProfile>();

        //public CandidateProfileTableModule()
        //{
        //    TestGateway = new DataRUGateway<CandidateProfile>();
        //}
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