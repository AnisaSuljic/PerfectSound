using AutoMapper;
using PerfectSound.Model.Model;
using PerfectSound.Model.Requests.PodcastSeason;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectSound.Services
{
    public class PodcastSeasonService : BaseCRUDService<PodcastSeason, PodcastSeasonSearchRequest,
                                    PodcastSeasonUpsertRequest, PodcastSeasonUpsertRequest, Database.PodcastSeason>
    {
        public PodcastSeasonService(Database.PerfectSoundContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override List<PodcastSeason> Get(PodcastSeasonSearchRequest search)
        {
            var _searchSet = _context.PodcastSeasons.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search.SeasonName))
            {
                _searchSet = _searchSet.Where(x => x.SeasonName.ToLower().StartsWith(search.SeasonName.ToLower()));
            }
            return _mapper.Map<List<PodcastSeason>>(_searchSet.ToList());
        }
    }
}
