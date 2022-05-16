using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTask1.Data
{
    public abstract class AbstractDataApi
    {
        private List<Catalog> catalogs = new List<Catalog>();
        private List<Availability> availabilities
            = new List<Availability>();
        private List<User> users = new List<User>();
        private List<Event> events = new List<Event>();

        private Availability SearchBook(int id, bool available)
        {
            Predicate<Availability> predicate = x => x.Book.Id == id && x.Available == available;
            if (availabilities.Exists(predicate))
            {
                return availabilities.Find(predicate);
            }
            else
            {
                return null;
            }
        }
        private User SearchUser(string Name, string Surname, int id)
        {
            Predicate<User> predicate = x =>x.Id == id && x.Name == Name && x.Surname == Surname;
            if (users.Exists(predicate))
            {
                return users.Find(predicate);
            }
            else
            {
                return null;
            }
        }

        public void ChangeAvailability(bool available, int id)
        {
            Availability availability = SearchBook(id, !available);
            availability.ChangeAvailability();
        }
        public void Borrow(String Title, String Author, String Name, String Surname, int idBook, int idUser)
        {
            Availability availability = SearchBook(idBook, true);
            if (availability != null)
            {
                User User = SearchUser(Name, Surname, idUser);
                if (User != null)
                {
                    availability.Available = false;
                    events.Add(new BorrowEvent(availability, User));
                }
                else
                {
                    throw new Exception("No user found");
                }
            }
            else
            {
                throw new Exception("No book found");
            }
        }
        public void Return(String Title, String Author, String Name, String Surname, int idBook, int idUser)
        {
            User User = SearchUser(Name, Surname, idUser);
            if (User == null)
            {
                throw new Exception("No user found");
            }
            else
            {
                Availability availability = SearchBook(idBook, false);
                if (availability != null)
                {
                    availability.Available = true;
                    events.Add(new ReturnEvent(availability, User));
                }
                else
                {
                    throw new Exception("No book found");
                }
            }
        }
        public void AddBook(String Title, String Author, int id)
        {

            if (!catalogs.Exists(x => x.Id == id))
            {
                catalogs.Add(new Catalog(Title, Author, id));
            }
            availabilities.Add(new Availability(catalogs.Find(x => x.Id == id)));

        }
        public void DeleteBook( int id)
        {
            Predicate<Catalog> Predicate = x => x.Id == id ;
            Catalog catalog;
            if (catalogs.Exists(Predicate))
            {
                catalog = catalogs.Find(Predicate);
            }
            else
            {
                throw new Exception("No book found");
            }

            Predicate<Availability> predicate = x => x.Book == catalog;
            if (availabilities.Exists(predicate) && !availabilities.Find(predicate).Available)
            {
                throw new Exception("The book can not be removed, it is borrowed");
            }
            else
            {
                catalogs.Remove(catalog);
            }
        }
        public void AddUser(String Name, String Surname, int id)
        {
            users.Add(new User(Name, Surname, id));
        }
        public bool GetAvailability(int id)
        {
            Availability availability = SearchBook(id, true);
            if (availability != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public abstract void daBorrow(String Title, String Author, String Name, String Surname, int idBook, int idUser);
        public abstract void daReturn(String Title, String Author, String Name, String Surname, int idBook, int idUser);

    }

}
