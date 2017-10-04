using System;
using System.Collections.Generic;
using System.Text;

namespace MinistriaEKthimit.Models.Messaging.Responses
{
    public class PersonResponse
    {
        public PersonResponse(int id, string name, string lastName, string company, DateTime birthDate)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Company = company;
            BirthDate = birthDate;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
