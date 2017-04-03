
using System.Collections.Generic;
using Team11_2106Project.ViewModel;

namespace Team11_2106Project.DomainModel
{
    interface IVote
    {
        void Vote(int candidateID, int currentUserID);
        bool hasCurrentUserVoted();
    }
}
