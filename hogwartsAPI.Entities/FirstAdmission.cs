using System;

namespace hogwartsAPI.Entities
{
    public class FirstAdmission : Entity
    {
        public string Name { get; set; }

        public string Lastname { get; set;}

        public string DNI { get; set; }

        public int Age { get; set; }

        public string House { get; set; }
    }
}
