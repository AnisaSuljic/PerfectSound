using System;
using System.Collections.Generic;
using System.Text;

namespace PerfectSound.Model.Model
{
    public class Gender
    {
        public int GenderId { get; set; }
        public string GenderName { get; set; }

        public override string ToString()
        {
            return GenderName;
        }
    }
}
