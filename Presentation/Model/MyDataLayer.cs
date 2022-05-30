using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Data;

namespace Task2.Presentation.Model
{
    public class MyDataLayer : AbstractDataAPI
    {
        public MyDataLayer(DataClassesDataContext dataContext) : base(dataContext)
        {

        }

        public override States FindBook(string title, string author)
        {

            foreach (Catalogs c in this.Catalogs)
            {
                if (c.Title == title && c.Author == author)
                {
                    return States.Where(x => x.Book == c.Id).First();

                }
            }
            return null;

        }
        public override void Borrow(string Title, string Author, string Name, string Surname)
        {
            States state = FindBook(Title, Author);
            if (state != null)
            {
                Users User = FindUser(Name, Surname);
                if (User != null)
                {


                    dataContext.Events.InsertOnSubmit(new Events { stateId = state.Id, userId = User.Id, description = "borrow" });
                    dataContext.SubmitChanges();
                    this.Events = dataContext.GetTable<Events>().ToList();

                    state.Availible = 0;
                    dataContext.SubmitChanges();
                }
                else
                {
                    throw new ArgumentException("User not found");
                }
            }
            else
            {
                throw new ArgumentException("Book not found");
            }

        }

        public override void Return(string Title, string Author, string Name, string Surname)
        {
            Users User = FindUser(Name, Surname);
            if (User == null)
            {
                throw new ArgumentException("User not found");
            }
            else
            {
                States state = FindBook(Title, Author);
                if (state != null)
                {
                    dataContext.Events.InsertOnSubmit(new Events { stateId = state.Id, userId = User.Id, description = "Return" });
                    dataContext.SubmitChanges();
                    Events = dataContext.GetTable<Events>().ToList();
                    state.Availible = 1;
                    dataContext.SubmitChanges();

                }
                else
                {
                    throw new ArgumentException("Book not found");
                }
            }
        }

        public override Users FindUser(string name, string surname)
        {
            try
            {
                return Users.Where(x => x.Name == name && x.Surname == surname).First();

            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public override bool isAvailible(Catalogs book)
        {
            if (book != null)
            {
                if (FindBook(book.Title, book.Author).Availible == 1)
                    return true;
                else
                    return false;
            }
            return false;
        }
        public override void addBook(Catalog catalog)
        {
            int id = -1;
            if (FindBook(catalog.Title, catalog.Author) == null)
            {
                Catalog tmp = new Catalog { Title = catalog.Title, Author = catalog.Author };

                dataContext.Catalog.InsertOnSubmit(tmp);
                dataContext.SubmitChanges();
                Catalogs = dataContext.GetTable<Catalog>().ToList();
                id = Catalogs.Where(x => x.Title == catalog.Title && x.Author == catalog.Author).First().Id;
                dataContext.State.InsertOnSubmit(new State { Book = id, Availible = 1 });
                dataContext.SubmitChanges();
                States = dataContext.GetTable<State>().ToList();
            }
        }
        public override void addUser(Users user)
        {
            dataContext.Users.InsertOnSubmit(new Users { Name = user.Name, Surname = user.Surname });
            dataContext.SubmitChanges();
            Users = dataContext.GetTable<Users>().ToList();
        }


        
        }

     
    }
}
