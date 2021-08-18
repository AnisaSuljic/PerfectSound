using System;
using System.Collections.Generic;
using System.Text;

namespace PerfectSound.Model.Model
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; }

        public override string ToString()
        {
            return GenreName;
        }
    }
}
