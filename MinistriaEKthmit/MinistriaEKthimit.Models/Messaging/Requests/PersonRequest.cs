using System;
using System.Collections.Generic;
using System.Text;

namespace MinistriaEKthimit.Models.Messaging.Requests
{
    public class PersonRequest
    {
        public PersonRequest(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }


    }
}
