using System;
using Team11_2106Project.Gateway;
using Team11_2106Project.ViewModel;

/**
 * DomainModel that handles the business logic for the Admin class
 */
namespace Team11_2106Project.DomainModel
{
    public class Admin : Voter, ILogIn<Admin>
    {

        // local variables
        private int adminID { get; set; }

        // adminGateway
        private IDataGateway<AdminViewModel> dataGatewayAdmin = new DataGateway<AdminViewModel>();

        // valiate Admin's login
        public new bool Login(string email, string password)
        {
            // iterate through every admin in the table
            foreach(AdminViewModel admin in dataGatewayAdmin.SelectAll())
            {
                // if email and password matches an Admin found in the table, admin's login is valid!
                if (admin.Email.Equals(email) && admin.Password.Equals(password))
                {
                    adminID = admin.AdminID;
                    return true;
                }
            }

            // else, admin's login is invalid!
            return false;
        }

        public int getID()
        {
            return adminID;
        }
    }
}