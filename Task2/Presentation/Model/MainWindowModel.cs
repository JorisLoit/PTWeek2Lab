using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.DataLayer;
using Task2.Service;
using Task2.Data;

namespace Task2.Presentation.Model
{
    public class MainWindowModel
    {
        public MyLibrary myLibrary;

        public MainWindowModel()
        {
            myLibrary = new MyLibrary();
        }

    }
}