using Microsoft.AspNetCore.Mvc;
using PerfectSound.Interfaces;
using PerfectSound.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectSound.Controllers
{
    public class GenderController : BaseController<Model.Model.Gender,object>
    {
        public GenderController(IService<Gender, object> service) : base(service)
        {
        }

    }
}
