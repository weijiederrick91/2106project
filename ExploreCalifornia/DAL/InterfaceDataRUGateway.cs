using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreCalifornia.DAL
{
    //This interface specifies operations and methods to be used by the DataRUGateway. 
    //As DataRUGateway will mostly consist of updating and reading operations, the methods listed here are specifiv to those operations. 
    //It is part of the Data Source Layer.
    interface InterfaceDataRUGateway<T> where T:class 

    {
        IEnumerable<T> SelectAll();
        T SelectByID(int? id);
        void Update(T obj);
        void Save();
    }
}
