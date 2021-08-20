using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PerfectSound.Interfaces;
using PerfectSound.Model.Requests;
using PerfectSound.Model.Requests.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectSound.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }
        [HttpGet]
        public List<Model.Model.User> GetAll([FromQuery] UserSearchRequest search)
        {
            return _service.Get(search);
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet("{Id}")]
        public Model.Model.User GetById(int Id)
        {
            return _service.GetById(Id);
        }

        [Authorize(Roles ="Admin")]
        [HttpPost]
        public Model.Model.User Post(UserUpsertRequest request)
        {
            return _service.Insert(request);
        }

        //[Authorize]
        [HttpPut("{Id}")]
        public Model.Model.User Update(int Id, [FromBody] UserUpsertRequest request)
        {
            return _service.Update(Id, request);
        }

        //[Authorize(Roles = "Admin")]
        [HttpDelete("{Id}")]
        public Model.Model.User Delete(int Id)
        {
            return _service.Delete(Id);
        }
    }
}
