using System;
using System.Collections.Generic;
using System.Text;

namespace Vendr.Domain.Interfaces
{
    public interface IRepository<T> 
    {
        void Insert(T obj);

        void Update(T obj);

        void Delete(int id);

        object Select(int id);

        T SelectAs(int id);
        
        IList<object> List();

        IList<T> ListAs();
    }
}

