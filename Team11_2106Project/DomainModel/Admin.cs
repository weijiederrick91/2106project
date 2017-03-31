using Team11_2106Project.Gateway;

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
        private IDataGateway<Admin> dataGatewayAdmin = new DataGateway<Admin>();

        // valiate Admin's login
        public new bool Login(string email, string password)
        {
            // iterate through every admin in the table
            foreach(Admin admin in dataGatewayAdmin.SelectAll())
            {
                // if email and password matches an Admin found in the table, admin's login is valid!
                if (admin.email.Equals(email) && admin.password.Equals(password))
                {
                    return true;
                }
            }

            // else, admin's login is invalid!
            return false;
        }
    }
}