using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team11_2106Project.DomainModel
{
    public class Rallies : IRallies
    {
        private int ralliesID { get; set; }
        private int candidateID { get; set; }
        private DateTime date { get; set; }
        private string location { get; set; }
        private string description { get; set; }

        IRallies IRallies.ViewRallies(int id)
        {
            throw new NotImplementedException();
        }

        void IRallies.EditRallies(IRallies irally)
        {
            throw new NotImplementedException();
        }

        void IRallies.CreateRallies(IRallies irally)
        {
            throw new NotImplementedException();
        }

        void IRallies.DeleteRallies(int id)
        {
            throw new NotImplementedException();
        }
    }
}