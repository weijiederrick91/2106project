using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreCalifornia.DAL
{
    interface InterfaceDataRUGateway<T> where T:class 

    {
        IEnumerable<T> SelectAll();
        T SelectByID(int? id);
        void Update(T obj);
        void Save();
    }
}
