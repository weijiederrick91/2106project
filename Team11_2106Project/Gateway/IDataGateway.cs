using System.Collections.Generic;

namespace Team11_2106Project.Gateway
{
    //This interface specifies operations and methods to be used by the DataRUGateway. 
    //As DataRUGateway will mostly consist of updating and reading operations, the methods listed here are specifiv to those operations. 
    //It is part of the Data Source Layer.
    interface IDataGateway<T> where T : class

    {
        IEnumerable<T> SelectAll();
        T SelectByID(int? id);
        void Update(T obj);
        void Save();
        void Insert(T obj);
        T Delete(int? id);

    }
}
