using hogwartsAPI.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace hogwartsAPI.Entities
{
    public abstract class Entity: InterfaceEntity
    {
        
        public int Id { get; set; }

    }
}
