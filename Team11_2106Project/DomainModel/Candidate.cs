using System;
using System.Collections.Generic;
using System.Linq;
using Team11_2106Project.Gateway;
using Team11_2106Project.ViewModel;

/**
 * DomainModel that handles the business logic of the Candidate
 */
namespace Team11_2106Project.DomainModel
{
    public class Candidate : Voter, ILogIn<Candidate>, IViewResults
    {

        // local variable
        private int candidateID { get; set; }

        // dataGatewayCandidate
        private IDataGateway<CandidateViewModel> dataGatewayCandidate = new DataGateway<CandidateViewModel>();

        // iterate through every candidate in the candidate table to determine if 
        // candidate with the parameters (email and password) exists in the system
        public new bool Login(string email, string password)
        {
            foreach (CandidateViewModel candidate in dataGatewayCandidate.SelectAll())
            {

                // candidate is found in the table, candidate login is valid
                if (candidate.Email.Equals(email) && candidate.Password.Equals(password))
                {
                    candidateID = candidate.CandidateID;
                    return true;
                }
            }
            
            // candidate is not found in the table, candidate login is NOT valid
            return false;
        }

        /**
         * Sort the Candidates via their total votes
         */
        public IEnumerable<CandidateViewModel> ViewVotingResults()
        {
            IEnumerable<CandidateViewModel> unsortedCandidates = dataGatewayCandidate.SelectAll();

            var sortedCandiates = from candidate in unsortedCandidates
                                  select candidate;

            return sortedCandiates.OrderByDescending(candidate => candidate.TotalVotes);
        }

        public int getID()
        {
            return candidateID;
        }
    }
}