using System;
using Team11_2106Project.Gateway;
using Team11_2106Project.ViewModel;

/*
 * DomainModel that handles the business logic of the Campaign class
 */
namespace Team11_2106Project.DomainModel
{
    public class CampaignDate : ICampaignDate
    {

        // local variables
        private DateTime startDate { get; set; }
        private DateTime endDate { get; set; }
        private int campaignID { get; set; }
        private static CampaignDate campaign;

        // dataGatewayCampaign
        private IDataGateway<CampaignDateViewModel> dataGatewayCampaign = new DataGateway<CampaignDateViewModel>(); 

        // empty constructor to initilize null singleton
        public CampaignDate(){
            foreach (CampaignDateViewModel campaign in dataGatewayCampaign.SelectAll())
            {
                startDate = campaign.StartDate;
                endDate = campaign.EndDate;
                campaignID = campaign.CampaignID;
            }
        }

        public CampaignDateViewModel getCampaignViewModel()
        {
            return dataGatewayCampaign.SelectByID(campaignID);
        }

        // ensure that the startDate cannot be greater than the endDate and vice-versas
        public bool validateDates(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                return false;
            }
            else
            {
                this.startDate = startDate;
                this.endDate = endDate;
                return true;
            }
        }

        // Save dates to DB
        public bool saveDates(DateTime startDate, DateTime endDate)
        {
            if (validateDates(startDate, endDate))
            {
                CampaignDateViewModel campaign = dataGatewayCampaign.SelectByID(campaignID);
                campaign.StartDate = startDate;
                campaign.EndDate = endDate;
                dataGatewayCampaign.Update(campaign);
                return true;
            }
            else
            {
                return false;
            }
        }

        // Determines whether a Voter is able to log into our Voting system
        // ensure that the current date when this function is executed is between 
        // the start and end dates. 
        public bool isCurrentDateValid()
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