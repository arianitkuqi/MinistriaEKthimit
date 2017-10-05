using MinistriaEKthimit.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinistriaEKthimit.Services.Implementation
{
    public class PersonService:IPersonService
    {
        public void hh()
        {
            Factory.Perform.GetAll<Object>("usp_PersonRoles_GetAll");
                    
            Factory.Perform.GetSingle<Object>("");
        }
    }
}
