using System;
using System.Collections.Generic;
using hogwartsAPI.Abstractions;
using hogwartsAPI.DataAccess;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace hogwartsAPI.DataAccess
{
    public class Dbcontext<T> : IDbContext<T> where T : class,InterfaceEntity
    {
        DbSet<T> _items;
        APIDbContext _newcontext;

        public Dbcontext(APIDbContext newcontext)
        {
            _newcontext = newcontext;
            _items = newcontext.Set<T>();
        }


        //entity to remove a student by id
        public void Delete(int id)
        {
            var tmp = _items.Find(id);
            if (tmp != null)
            {
                _items.Remove(tmp);
                _newcontext.SaveChanges();
            }

        }

        //entity to see all students
        public IList<T> GetAll()
        {
            return _items.ToList();
        }

        //entity to find a new a student
        public T GetById(int id)
        {
            return _items.Find(id);
        }

        //entity to add a new a student
        public T Save(T entity)
        {
            if (entity.Id.Equals(0))
            {
                _items.Add(entity);
            }
            else
            {
                _items.Update(entity);
            }

            _newcontext.SaveChanges();
            return entity;
        }

    }
}
