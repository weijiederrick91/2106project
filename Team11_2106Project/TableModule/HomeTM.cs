using System.Collections.Generic;
using Team11_2106Project.Gateway;
using Team11_2106Project.Models;

namespace Team11_2106Project.TableModule
{
    public class HomeTM
    {
        private IDataRUGateway<Voter> voterGateway = new DataRUGateway<Voter>();

        public bool ValidateLogin(string email, string password)
        {
            IEnumerable<Voter> votersData = voterGateway.SelectAll();

            foreach (Voter voters in votersData)
            {
                if (voters.Email.Equals(email) && voters.Password.Equals(password))
                {
                    return true;
                }
            }
            return false;
        }

    }
}