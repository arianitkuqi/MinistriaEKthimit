using MinistriaEKthimit.Service.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using MinistriaEKthimit.Models.Messaging.Requests;
using MinistriaEKthimit.Models.Messaging.Responses;

namespace MinistriaEKthimit.Service.Implementation
{
    public class PersonService : IPersonService
    {
        public PersonResponse GetPerson(PersonRequest request)
        {
            return new PersonResponse(1, "Liridon", "PArduzi", "TechVision", new DateTime());
        }

        string IPersonService.DisplayAll()
        {
            return "Tentimi i pare";
        }
    }
}
