using hogwartsAPI.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace hogwartsAPI.Application
{
    public interface InterfaceApplication<T> : Abstractions.InterfaceCRUD<T>
    {

    }


    public class Application<T> : InterfaceApplication<T> where T: Abstractions.InterfaceEntity
    {
        IRepository<T> _repository;

        public Application(IRepository<T> repository)
        {
            _repository = repository;
        }


        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IList<T> GetAll()
        {
           return _repository.GetAll();
        }

        public T GetById(int id)
        {
           return _repository.GetById(id);
        }

        public T Save(T entity)
        {
            return _repository.Save(entity);
        }
    }
}
