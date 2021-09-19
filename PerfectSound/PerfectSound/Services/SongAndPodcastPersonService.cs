using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PerfectSound.Model.Model;
using Microsoft.EntityFrameworkCore;
using PerfectSound.Model.Requests.SongAndPodcastPerson;

namespace PerfectSound.Services
{
    public class SongAndPodcastPersonService : BaseCRUDService<SongAndPodcastPerson, SongAndPodcastPersonSearchRequest, SongAndPodcastPersonUpsertRequest, SongAndPodcastPersonUpsertRequest, Database.SongAndPodcastPerson>
    {
        public SongAndPodcastPersonService(Database.PerfectSoundContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override List<SongAndPodcastPerson> Get(SongAndPodcastPersonSearchRequest search)
        {
            var _searchSet = _context.SongAndPodcastPeople
                .Include(x=>x.Role)
                .Include(x => x.Person)
                .Include(x => x.SongAndPodcast)
                .AsQueryable();

            if (search?.PersonId!=null && search.PersonId != 0)
            {
                _searchSet = _searchSet.Where(x => x.PersonId == search.PersonId);
            }
            if (search.GenderId != 0)
            {
                _searchSet = _searchSet.Where(x => x.Person.GenderId == search.GenderId);
            }
            if (search.RoleId != 0)
            {
                _searchSet = _searchSet.Where(x => x.RoleId == search.RoleId);
            }
            if (search.SongAndPodcastId != 0)
            {
                _searchSet = _searchSet.Where(x => x.SongAndPodcastId == search.SongAndPodcastId);
            }

            return _mapper.Map<List<SongAndPodcastPerson>>(_searchSet.ToList());

           
        }
    }
}
