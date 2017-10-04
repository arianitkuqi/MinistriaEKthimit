using MKthimit.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MKthimit.Repository.Implementation
{
    class Repository
    {
        public T GetSingle<T>() where T : new()
        {
            T t = new T();
            return t;
        }

        public IEnumerable<T> GetAll<T>() where T : new ()
        {

            List<T> t = new List<T>();

            return t;
        }

        public bool Delete<T>(T id) 
        {
            return false;
        }

        public bool Insert<T>(T item)
        {
            return false;
        }



    }
}
