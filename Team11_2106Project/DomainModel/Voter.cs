using System;
using Team11_2106Project.Gateway;
using Team11_2106Project.ViewModel;

/**
 * DomainModel that handles the Voter's business logic
 */
namespace Team11_2106Project.DomainModel
{
    public class Voter : IVote, ILogIn<Voter>
    {

        private int voterID { get; set; }
        private bool hasVoted { get; set; }
        public static Voter currentVoter;

        // dataGatewayVoter
        private IDataGateway<VoterViewModel> dataGatewayVoter = new DataGateway<VoterViewModel>();
        private IDataGateway<CandidateViewModel> dataGatewayCandidate = new DataGateway<CandidateViewModel>();

        public int getID()
        {
            return currentVoter.voterID;
        }

        // iterate through the Voter table to determine if Voter's login (email and password parameters)
        // are valid
        public bool Login(string email, string password)
        {
            foreach(VoterViewModel voter in dataGatewayVoter.SelectAll())
            {
                // Voter is found in the table, Voter's login is valid!
                if (voter.Email.Equals(email) && voter.Password.Equals(password))
                {
                    currentVoter = new Voter();
                    currentVoter.voterID = voter.VoterID;
                    currentVoter.hasVoted = voter.HasVoted;
                    return true;
                }
            }

            // Voter is not found in the table, user's login is NOT valid!
            return false;
        }

        // TODO - implementation
        // allow the Voter to vote for the Candidate through the CandidateID
        public void Vote(int candidateID, int currentUserID)
        { 
            // capture currentUser, set HasVoted to true and save it to DB
            VoterViewModel currentUser = dataGatewayVoter.SelectByID(currentUserID);
            currentUser.HasVoted = true;
            dataGatewayVoter.Update(currentUser);

            currentVoter.hasVoted = true;   // save it in runtime class

            // capture Candidate to be voted, increment TotalVotes and save it to DB
            CandidateViewModel candidate = dataGatewayCandidate.SelectByID(candidateID);
            candidate.TotalVotes++;
            dataGatewayCandidate.Update(candidate);
        }

        public bool hasCurrentUserVoted()
        {
            return currentVoter.hasVoted;
        }
    }
}