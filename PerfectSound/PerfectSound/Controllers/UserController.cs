using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PerfectSound.Interfaces;
using PerfectSound.Model.Requests;
using PerfectSound.Model.Requests.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectSound.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UserController : ControllerBase
    {
        private IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }
        [Authorize]
        [HttpGet]
        public List<Model.Model.User> GetAll([FromQuery] UserSearchRequest search)
        {
            return _service.Get(search);
        }

        [Authorize]
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

        [Authorize]
        [HttpPut("{Id}")]
        public Model.Model.User Update(int Id, [FromBody] UserUpsertRequest request)
        {
            return _service.Update(Id, request);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{Id}")]
        public Model.Model.User Delete(int Id)
        {
            return _service.Delete(Id);
        }

        [HttpGet("Login")]
        public async Task<Model.Model.User> Login()
        {
            string authorization = HttpContext.Request.Headers["Authorization"];

            string encodedHeader = authorization["Basic ".Length..].Trim();

            Encoding encoding = Encoding.GetEncoding("iso-8859-1");
            string usernamePassword = encoding.GetString(Convert.FromBase64String(encodedHeader));

            int seperatorIndex = usernamePassword.IndexOf(':');
            return await _service.Login(usernamePassword.Substring(0, seperatorIndex), usernamePassword[(seperatorIndex + 1)..]);
        }

        [HttpPost("SignUp")]
        public Model.Model.User SignUp(UserUpsertRequest request)
        {
            return _service.SignUp(request);
        }
    }
}
