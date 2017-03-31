using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;

namespace Team11_2106Project.Domain_Model
{
    interface IRallies
    {

        IRallies ViewRallies(int id);
        void EditRallies(IRallies irally);
        void CreateRallies(IRallies irally);
        void DeleteRallies(int id);
    }
}