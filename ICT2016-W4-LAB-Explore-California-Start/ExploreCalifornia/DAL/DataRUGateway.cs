﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ExploreCalifornia.DAL
{
    public class DataRUGateway<T> :InterfaceDataRUGateway<T> where T : class
    {
        internal ElectionDBContext db = new ElectionDBContext();
        internal DbSet<T> data = null; 

        public DataRUGateway()
        {
            this.data = db.Set<T>();
        }
        public IEnumerable<T> SelectAll()
        {
            return data.ToList();

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