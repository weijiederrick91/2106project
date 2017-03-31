using Team11_2106Project.Gateway;

/**
 * DomainModel that handles the Voter's business logic
 */
namespace Team11_2106Project.DomainModel
{
    public class Voter : IVote, ILogIn<Voter>
    {
        
        // local variables
        protected int voterID { get; set; }
        protected string email { get; set; }
        protected string password { get; set; }
        protected bool hasVoted { get; set; }

        // dataGatewayVoter
        private IDataGateway<Voter> dataGatewayVoter = new DataGateway<Voter>();

        // iterate through the Voter table to determine if Voter's login (email and password parameters)
        // are valid
        public bool Login(string email, string password)
        {
            foreach(Voter voter in dataGatewayVoter.SelectAll())
            {
                // Voter is found in the table, Voter's login is valid!
                if (voter.email.Equals(email) && voter.password.Equals(password))
                {
                    return true;
                }
            }

            // Voter is not found in the table, user's login is NOT valid!
            return false;
        }

        // allow the Voter to vote for the Candidate through the CandidateID
        public bool Vote(int candidateID)
        {
            
            // if Voter has already voted, they will be unable to vote!
            if (hasVoted)
            {
                return false;
            }
            else
            {
                // access the Candidate with the same ID from its DataGateway
                // and increment their totalVotes
                new DataGateway<Candidate>().SelectByID(candidateID).IncrementVote();
                hasVoted = false;   // to prevent Voter from voting again
                return true;
            }
        }
    }
}