using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTask1.Data
{
    internal class Availability
    {
        public Catalog Book { get; }
        public bool Available = true;

        public Availability(Catalog book)
        {
            Book = book;
        }

        internal void ChangeAvailability()
        {
            if (!Available)
            {
                Available = true;
            }
            else
            {
                Available = false;
            }
        }
    }
}
