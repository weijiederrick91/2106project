
using System.Collections.Generic;
using Team11_2106Project.ViewModel;

namespace Team11_2106Project.DomainModel
{
    interface IVote
    {
        bool Vote(int candidateID);
        bool hasCurrentUserVoted();
    }
}
