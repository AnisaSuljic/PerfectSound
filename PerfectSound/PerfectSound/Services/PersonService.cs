using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PerfectSound.Model.Requests.Person;
using PerfectSound.Model.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PerfectSound.Interfaces;

namespace PerfectSound.Services
{
    public class PersonService : BaseCRUDService<Person, PersonSearchRequest, PersonUpsertRequest, PersonUpsertRequest, Database.Person>,IArtistsService
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
        public override Person GetById(int Id)
        {
            var entity = _context.People
                .Include(x => x.Gender)
                .AsQueryable().Where(x => x.PersonId == Id).FirstOrDefault();


            return _mapper.Map<Person>(entity);
        }

        public List<Person> GetLast3()
        {
            var _searchSet = _context.People.Include(x => x.Gender).Take(3).AsQueryable();
            return _mapper.Map<List<Person>>(_searchSet.ToList());

        }
    }
}
