using Team11_2106Project.Gateway;

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
        private IDataGateway<Candidate> dataGatewayCandidate = new DataGateway<Candidate>();

        // iterate through every candidate in the candidate table to determine if 
        // candidate with the parameters (email and password) exists in the system
        public new bool Login(string email, string password)
        {
            foreach (Candidate candidate in dataGatewayCandidate.SelectAll())
            {

                // candidate is found in the table, candidate login is valid
                if (candidate.email.Equals(email) && candidate.password.Equals(password))
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