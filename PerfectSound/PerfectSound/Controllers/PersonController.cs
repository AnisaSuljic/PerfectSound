using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PerfectSound.Model.Model;
using PerfectSound.Model.Requests.Person;
using PerfectSound.Interfaces;
using PerfectSound.Services;

namespace PerfectSound.Controllers
{
    public class PersonController : BaseCRUDController<Person, PersonSearchRequest, PersonUpsertRequest, PersonUpsertRequest>
    {
        protected PersonService _servicePerson;
        public PersonController(ICRUDService<Person, PersonSearchRequest, PersonUpsertRequest, PersonUpsertRequest> service) : base(service)
        {
            _servicePerson=(PersonService)service;
        }

        [Route("Last3")]
        [HttpGet]
        public List<Person> GetLast3()
        {
            return _servicePerson.GetLast3();
        }
    }
}
