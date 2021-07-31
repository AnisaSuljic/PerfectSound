using System;
using System.Collections.Generic;
using System.Text;

namespace PerfectSound.Model.Requests.Person
{
    public class PersonSearchRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }        
        public int? GenderId { get; set; }
    }
}
