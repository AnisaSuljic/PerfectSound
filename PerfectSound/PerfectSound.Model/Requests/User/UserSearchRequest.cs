using System;
using System.Collections.Generic;
using System.Text;

namespace PerfectSound.Model.Requests.User
{
    public class UserSearchRequest
    {
        public string UserName { get; set; }
        public int? UserTypeId { get; set; }
    }
}
