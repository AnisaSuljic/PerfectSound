using System;
using System.Collections.Generic;

#nullable disable

namespace PerfectSound.Database
{
    public partial class Person
    {
        public Person()
        {
            SongAndPodcastPeople = new HashSet<SongAndPodcastPerson>();
        }

        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] Photo { get; set; }
        public string Biography { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }
        public int? GenderId { get; set; }

        public virtual Gender Gender { get; set; }
        public virtual ICollection<SongAndPodcastPerson> SongAndPodcastPeople { get; set; }
    }
}
