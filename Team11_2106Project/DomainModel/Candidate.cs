using Team11_2106Project.Gateway;
using Team11_2106Project.ViewModel;

/**
 * DomainModel that handles the business logic of the Candidate
 */ 
namespace Team11_2106Project.DomainModel
{
    public class Candidate : Voter, ILogIn<Candidate>
    {

        // local variable
        private int candidateID { get; set; }
        private int totalVotes { get; set; }

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
                    return true;
                }
            }
            
            // candidate is not found in the table, candidate login is NOT valid
            return false;
        }

        // inrement the totalVotesof the Candidate whenever a Voter votes for this Candidate
        public void IncrementVote()
        {
            totalVotes++;
        }
    }
}