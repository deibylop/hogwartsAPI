using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace hogwartsAPI.Abstractions
{

    public interface InterfaceCRUD<T>
    {
        T Save(T entity);
        IList<T> GetAll();
        T GetById(int id);
        void Delete(int id);

    }
}
