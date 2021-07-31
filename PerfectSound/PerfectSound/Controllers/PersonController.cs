using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PerfectSound.Model.Model;
using PerfectSound.Model.Requests.Person;
using PerfectSound.Interfaces;

namespace PerfectSound.Controllers
{
    public class PersonController : BaseCRUDController<Person, PersonSearchRequest, PersonUpsertRequest, PersonUpsertRequest>
    {
        public PersonController(ICRUDService<Person, PersonSearchRequest, PersonUpsertRequest, PersonUpsertRequest> service) : base(service)
        {
        }
    }
}
