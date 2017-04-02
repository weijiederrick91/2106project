
using System.Collections.Generic;
using Team11_2106Project.ViewModel;
namespace Team11_2106Project.DomainModel
{
    interface IRallies
    {
        RalliesViewModel ViewRallies(int id);
        void EditRallies(RalliesViewModel irally);
        void CreateRallies(RalliesViewModel irally);
        void DeleteRallies(int id);
        IEnumerable<RalliesViewModel> ViewAllRallies();
    }
}