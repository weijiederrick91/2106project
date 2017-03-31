using System;
using Team11_2106Project.Gateway;

/*
 * DomainModel that handles the business logic of the Campaign class
 */
namespace Team11_2106Project.DomainModel
{
    public class Campaign : ICampaign
    {

        // local variables
        private DateTime startDate { get; set; }
        private DateTime endDate { get; set; }
        private Campaign campaign { get; set; }

        // dataGatewayCampaign
        private IDataGateway<Campaign> dataGatewayCampaign; 

        // empty constructor to initilize null singleton
        private Campaign(){}

        // return instance of singleton if not null. Else, initialize and returns it
        public Campaign GetInstance()
        {
            if (campaign == null)
            {
                campaign = new Campaign();
            }
            return campaign;
        }

        // ensure that the startDate cannot be greater than the endDate and vice-versas
        private bool validateDates(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // Determines whether a Voter is able to log into our Voting system
        // ensure that the current date when this function is executed is between 
        // the start and end dates. 
        private bool isCurrentDateValid()
        {
            DateTime todayDate = DateTime.Today;

            // if date is valid, voter is able to log in
            if (todayDate >= startDate && todayDate <= endDate)
            {
                return true;
            }

            // else, voter is NOT able to log in
            return false;
        }
    }
}