using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PerfectSound.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectSound.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BaseController<TModel, TSearch> : ControllerBase
    {
        protected readonly IService<TModel, TSearch> _service;

        public BaseController(IService<TModel, TSearch> service)
        {
            _service = service;
        }

        [HttpGet]
        public virtual List<TModel> GetAll([FromQuery] TSearch search)
        {
            return _service.Get(search);
        }

        [HttpGet("{Id}")]
        public virtual TModel GetById(int Id)
        {
            return _service.GetById(Id);
        }

    }
}
