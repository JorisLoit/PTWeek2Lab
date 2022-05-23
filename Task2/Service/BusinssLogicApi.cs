using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Data;
using Task2.Service;

namespace Task2.Service
{
    public class BusinessLogicApi
    {
        public AbstractDataApi dataAPI;
        public DataService service { get; set; }

        public BusinessLogicApi(AbstractDataApi dataAPI)
        {
            this.dataAPI = dataAPI;
            service = new DataService(this);
        }
    }
}
