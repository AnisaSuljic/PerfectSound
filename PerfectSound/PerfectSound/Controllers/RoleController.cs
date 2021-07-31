using Microsoft.AspNetCore.Mvc;
using PerfectSound.Interfaces;
using PerfectSound.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectSound.Controllers
{
    public class RoleController : BaseController<Model.Model.Role,object>
    {
        public RoleController(IService<Role, object> service) : base(service)
        {
        }
    }
}
