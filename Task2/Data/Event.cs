using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Data
{
    internal abstract class Event
    {
        public Availability availability { get; set; }
        public User user { get; set; }
    }

    internal class BorrowEvent : Event
    {
        internal BorrowEvent(Availability availability, User User)
        {
            this.availability = availability;
            this.user = User;
        }

    }

    internal class ReturnEvent : Event
    {
        internal ReturnEvent(Availability state, User User)
        {
            this.availability = availability;
            this.user = User;
        }

    }
}
