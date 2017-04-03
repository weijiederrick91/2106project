using System;
using Team11_2106Project.Gateway;
using Team11_2106Project.ViewModel;

/**
 * DomainModel that handles the business logic for the Admin class
 */
namespace Team11_2106Project.DomainModel
{
    public class Admin : ILogIn<Admin>, IVote
    {

        // local variables
        private int adminID { get; set; }
        private bool hasVoted { get; set; }
        private static Admin currentAdmin;

        // adminGateway
        private IDataGateway<AdminViewModel> dataGatewayAdmin = new DataGateway<AdminViewModel>();
        private IDataGateway<CandidateViewModel> dataGatewayCandidate = new DataGateway<CandidateViewModel>();

        // valiate Admin's login
        public bool Login(string email, string password)
        {
            // iterate through every admin in the table
            foreach(AdminViewModel admin in dataGatewayAdmin.SelectAll())
            {
                // if email and password matches an Admin found in the table, admin's login is valid!
                if (admin.Email.Equals(email) && admin.Password.Equals(password))
                {
                    currentAdmin = new Admin();
                    currentAdmin.hasVoted = admin.HasVoted;
                    currentAdmin.adminID = admin.AdminID;
                    return true;
                }
            }

            // else, admin's login is invalid!
            return false;
        }

        public int getID()
        {
            return currentAdmin.adminID;
        }

        public void Vote(int candidateID, int currentUserID)
        {
            // capture currentAdmin, set HasVoted to true and save it to DB
            AdminViewModel currentUser = dataGatewayAdmin.SelectByID(currentUserID);
            currentUser.HasVoted = true;
            dataGatewayAdmin.Update(currentUser);

            currentAdmin.hasVoted = true;   // save it in runtime class

            // capture Candidate to be voted, increment TotalVotes and save it to DB
            CandidateViewModel candidate = dataGatewayCandidate.SelectByID(candidateID);
            candidate.TotalVotes++;
            dataGatewayCandidate.Update(candidate);
        }

        public bool hasCurrentUserVoted()
        {
            return currentAdmin.hasVoted;
        }
    }
}