using Team11_2106Project.Gateway;
using Team11_2106Project.ViewModel;

/**
 * DomainModel that handles the Voter's business logic
 */
namespace Team11_2106Project.DomainModel
{
    public class Voter : IVote, ILogIn<Voter>
    {
        // dataGatewayVoter
        private IDataGateway<VoterViewModel> dataGatewayVoter = new DataGateway<VoterViewModel>();

        // iterate through the Voter table to determine if Voter's login (email and password parameters)
        // are valid
        public bool Login(string email, string password)
        {
            foreach(VoterViewModel voter in dataGatewayVoter.SelectAll())
            {
                // Voter is found in the table, Voter's login is valid!
                if (voter.Email.Equals(email) && voter.Password.Equals(password))
                {
                    return true;
                }
            }

            // Voter is not found in the table, user's login is NOT valid!
            return false;
        }

        // TODO - implementation
        // allow the Voter to vote for the Candidate through the CandidateID
        public bool Vote(int candidateID)
        {
            return true;
        }
    }
}