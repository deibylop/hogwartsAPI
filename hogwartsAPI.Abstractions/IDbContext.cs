using System;
using System.Collections.Generic;
using System.Text;

namespace hogwartsAPI.Abstractions
{
    public interface IDbContext<T> : InterfaceCRUD<T>
    {

    }
}
