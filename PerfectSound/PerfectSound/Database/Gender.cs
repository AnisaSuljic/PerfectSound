using System;
using System.Collections.Generic;

#nullable disable

namespace PerfectSound.Database
{
    public partial class Gender
    {
        public Gender()
        {
            People = new HashSet<Person>();
        }

        public int GenderId { get; set; }
        public string GenderName { get; set; }

        public virtual ICollection<Person> People { get; set; }
    }
}
