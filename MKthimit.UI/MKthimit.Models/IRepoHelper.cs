using System;
using System.Collections.Generic;
using System.Text;

namespace MKthimit.Models
{
    public interface IRepoHelper<T>
    {
        IEnumerable<T> GetAll();  //Gets a list of data, from a concrete type
        T GetSingle(int id);    //Gets a single data from a concrete type 

        bool Insert(T item);    
        bool Update(T item);

        bool Delete(int id);
    }
}
