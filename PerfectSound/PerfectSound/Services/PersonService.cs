using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PerfectSound.Model.Requests.Person;
using PerfectSound.Model.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace PerfectSound.Services
{
    public class PersonService : BaseCRUDService<Person, PersonSearchRequest, PersonUpsertRequest, PersonUpsertRequest, Database.Person>
    {
        public PersonService(Database.PerfectSoundContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override List<Person> Get(PersonSearchRequest search)
        {
           var _searchSet = _context.People.Include(x=>x.Gender).AsQueryable();

            if(!string.IsNullOrWhiteSpace(search.FirstName))
            {
                _searchSet = _searchSet.Where(x => x.FirstName.ToLower().StartsWith(search.FirstName.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(search.LastName))
            {
                _searchSet = _searchSet.Where(x => x.LastName.ToLower().StartsWith(search.LastName.ToLower()));
            }
            if(search?.GenderId != null && search?.GenderId != 0)
            {
                _searchSet = _searchSet.Where(x => x.GenderId == search.GenderId);
            }
            return _mapper.Map<List<Person>>(_searchSet.ToList());

        }

    
    }
}
