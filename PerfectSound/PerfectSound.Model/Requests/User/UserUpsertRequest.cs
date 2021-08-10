using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PerfectSound.Model.Requests.User
{
    public class UserUpsertRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        [EmailAddress()]
        [Required(ErrorMessage = "Book name is required")]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password{ get; set; }
        public string PasswordConfirm { get; set; }
        public int? UserTypeId { get; set; }

    }
}
