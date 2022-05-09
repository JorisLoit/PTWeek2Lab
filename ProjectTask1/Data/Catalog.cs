using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTask1.Data
{
    internal class Catalog
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public int Id { get; set; }

        public Catalog(string title, string author, int id)
        {
            Author = author;
            Title = title;
            Id = id;

        }
    }
}
