using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTask1.Data
{
    internal class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }
        

        public User(string name, string surname, int id)
        {
            this.Surname = surname;
            this.Name = name;
            this.Id = id;
        }

    }
}
