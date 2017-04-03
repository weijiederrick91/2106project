using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team11_2106Project.ViewModel;

namespace Team11_2106Project.DomainModel
{
    interface IViewResults
    {
        IEnumerable<CandidateViewModel> ViewVotingResults();
    }
}
