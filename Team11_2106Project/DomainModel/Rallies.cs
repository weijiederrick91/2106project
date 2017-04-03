using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team11_2106Project.ViewModel;

using Team11_2106Project.Gateway;

namespace Team11_2106Project.DomainModel
{
    public class Rallies : IRallies
    {
    
        private IDataGateway<RalliesViewModel> dataGatewayRallies = new DataGateway<RalliesViewModel>();


        public RalliesViewModel ViewRallies(int id)
        {

            return dataGatewayRallies.SelectByID(id);
        }

        public IEnumerable<RalliesViewModel> ViewAllRallies()
        {

            return dataGatewayRallies.SelectAll();
        }
        public void EditRallies(RalliesViewModel irally)
        {
            dataGatewayRallies.Update(irally);
            dataGatewayRallies.Save();
        }

        public void CreateRallies(RalliesViewModel irally)
        {
            dataGatewayRallies.Insert(irally);
            dataGatewayRallies.Save();
        }

        public void DeleteRallies(int id)
        {
            dataGatewayRallies.Delete(id);
            dataGatewayRallies.Save();
        }
    }
}