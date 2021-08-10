using System;
using System.Collections.Generic;
using System.Text;

namespace PerfectSound.Model.Requests.Person
{
    public class PersonUpsertRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] Photo { get; set; }
        public string Biography { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }
        public int? GenderId { get; set; }
    }
}
