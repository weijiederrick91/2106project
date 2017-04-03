using System;
using Team11_2106Project.ViewModel;

namespace Team11_2106Project.DomainModel
{
    interface ICampaignDate
    {
        bool saveDates(DateTime startDate, DateTime endDate);
        bool isCurrentDateValid();
        CampaignDateViewModel getCampaignViewModel();
    }
}
