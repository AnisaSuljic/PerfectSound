using Microsoft.AspNetCore.Mvc;
using PerfectSound.Interfaces;
using PerfectSound.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectSound.Controllers
{
    public class UserTypeController : BaseController<Model.Model.UserType,object>
    {
        public UserTypeController(IService<UserType, object> service) : base(service)
        {
        }
    }
}
