using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExploreCalifornia.DAL;
using ExploreCalifornia.Models;
using System.Web.Mvc;
namespace ExploreCalifornia.TableModule
{
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