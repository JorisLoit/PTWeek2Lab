using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTask1.Logic
{
    public class DataService
    {
        private BusinessLogicApi LogicAPI;

        public DataService(BusinessLogicApi logicAPI)
        {
            LogicAPI = logicAPI;
        }

        public void BorrowBook(String Title, String Author, String Name, String Surname, int idBook, int idUser)
        {
            LogicAPI.dataAPI.Borrow(Title, Author, Name, Surname, idBook, idUser);
        }
        public void ReturnBook(String Author, String Title, String Name, String Surname, int idBook, int idUser) 
        {
            LogicAPI.dataAPI.Return(Title, Author, Name, Surname, idBook, idUser);
        }

        public void dsAddBook(String Author, String Title, int idBook)
        {
            LogicAPI.dataAPI.AddBook(Title, Author, idBook);
        }
        public void dsAddUser(String Name, String Surname, int idUser)
        {
            LogicAPI.dataAPI.AddUser(Name, Surname, idUser);
        }
        public void dsDeleteBook(int idBook)
        {
            LogicAPI.dataAPI.DeleteBook(idBook);
        }

        public bool dsGetAvailability(int id)
        {
            return LogicAPI.dataAPI.GetAvailability(id);
        }
    }
}
