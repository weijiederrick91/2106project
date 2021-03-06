﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Team11_2106Project.DBContext;

namespace Team11_2106Project.Gateway
{
    //This DataRUGateway class implements the InterfaceDataRUGateway. It deals with the database context with regards to its operations. 
    //It is part of the Data Source Layer.
    public class DataGateway<T> : IDataGateway<T> where T : class
    {
        internal ElectionDBContext db = new ElectionDBContext();
        internal DbSet<T> data = null;

        public DataGateway()
        {
            this.data = db.Set<T>();
        }
        public IEnumerable<T> SelectAll()
        {
            return data.ToList();

        }
        public T Delete(int? id)
        {
            T obj = data.Find(id);
            data.Remove(obj);
            db.SaveChanges();
            return obj;


        }

        public void Insert(T obj)
        {
            data.Add(obj);
            db.SaveChanges();
        }
        public void Update(T obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            this.Save();

        }
        public void Save()
        {
            db.SaveChanges();
        }

        public T SelectByID(int? id)
        {
            if (id == null)
            {
                return null;
            }
            T obj = data.Find(id);
            if (obj == null)
            {
                return null;
            }
            return obj;
        }
    }
}