using hogwartsAPI.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace hogwartsAPI.Repository
{
    public interface IRepository<T> : InterfaceCRUD<T>
    {

    }

    public class Repository<T> : IRepository<T> where T : Abstractions.InterfaceEntity
    {
        IDbContext<T> _newcontext;
        public Repository(IDbContext<T> newcontext)
        {
            _newcontext = newcontext;

        }


        public void Delete(int id)
        {
            _newcontext.Delete(id);
        }

     
        public IList<T> GetAll()
        {
            return _newcontext.GetAll();
        }

 

        public T GetById(int id)
        {
            return _newcontext.GetById(id);
        }


        public T Save(T entity)
        {
            return _newcontext.Save(entity);
        }

    }
}
