using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectTask1.Data;

namespace ProjectTask1.Logic
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
