using MinistriaEKthimit.Models.Messaging.Requests;
using MinistriaEKthimit.Models.Messaging.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinistriaEKthimit.Service.Contract
{
    public interface IPersonService
    {
        string DisplayAll();

        PersonResponse GetPerson(PersonRequest request);
    }
}
