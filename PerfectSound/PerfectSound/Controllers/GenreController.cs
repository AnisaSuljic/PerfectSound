using Microsoft.AspNetCore.Mvc;
using PerfectSound.Interfaces;
using PerfectSound.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectSound.Controllers
{
    public class GenreController : BaseController<Model.Model.Genre,object>
    {
        public GenreController(IService<Genre, object> service) : base(service){}
    }
}
