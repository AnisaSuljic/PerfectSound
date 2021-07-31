using System;
using System.Collections.Generic;

#nullable disable

namespace PerfectSound.Database
{
    public partial class User
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            News = new HashSet<News>();
            Ratings = new HashSet<Rating>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public int? UserTypeId { get; set; }

        public virtual UserType UserType { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<News> News { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
