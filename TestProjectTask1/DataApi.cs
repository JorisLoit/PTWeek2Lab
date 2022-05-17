using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectTask1.Logic;
using ProjectTask1.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace TestProjectTask1
{
    public class DataAPI : AbstractDataApi

    {
         public override void daBorrow(String Title, String Author, String Name, String Surname, int idBook, int idUser)
        {
            try
            {
                Borrow(Title, Author, Name, Surname, idBook, idUser);
                ChangeAvailability(false, idBook);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

        }

        public override void daReturn(String Title, String Author, String Name, String Surname, int idBook, int idUser)
        {
            try
            {
                Return(Title, Author, Name, Surname, idBook, idUser);
                ChangeAvailability(true, idBook);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
    public class DataAPI2 : AbstractDataApi

    {
        public override void daBorrow(String Title, String Author, String Name, String Surname, int idBook, int idUser)
        {
            throw new NotImplementedException();

        }

        public override void daReturn(String Title, String Author, String Name, String Surname, int idBook, int idUser)
        {
            throw new NotImplementedException();

        }
    }
}