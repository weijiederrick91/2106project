using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team11_2106Project.ViewModel;

namespace Team11_2106Project.DomainModel
{
    public class Rallies : IRallies
    {
        private int ralliesID { get; set; }
        private int candidateID { get; set; }
        private DateTime date { get; set; }
        private string location { get; set; }
        private string description { get; set; }

        public RalliesViewModel ViewRallies(int id)
        {
            throw new NotImplementedException();
        }

        public void EditRallies(RalliesViewModel irally)
        {
            throw new NotImplementedException();
        }

        public void CreateRallies(RalliesViewModel irally)
        {
            throw new NotImplementedException();
        }

        public void DeleteRallies(int id)
        {
            throw new NotImplementedException();
        }
    }
}