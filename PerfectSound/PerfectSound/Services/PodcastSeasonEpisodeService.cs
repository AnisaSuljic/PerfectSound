using AutoMapper;
using PerfectSound.Model.Model;
using PerfectSound.Model.Requests.PodcastSeasonEpisode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectSound.Services
{
    public class PodcastSeasonEpisodeService : BaseCRUDService<PodcastSeasonEpisode, PodcastSeasonEpisodeSearchRequest,
                                                             PodcastSeasonEpisodeUpsertRequest, PodcastSeasonEpisodeUpsertRequest, Database.PodcastSeasonEpisode>
    {
        public PodcastSeasonEpisodeService(Database.PerfectSoundContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override List<PodcastSeasonEpisode> Get(PodcastSeasonEpisodeSearchRequest search)
        {
            var _searchSet = _context.PodcastSeasonEpisodes.AsQueryable();

            if (search?.PodcastSeasonId!=null &&  search.PodcastSeasonId!=0)
            {
                _searchSet = _searchSet.Where(x => x.PodcastSeasonId==search.PodcastSeasonId);
            }
            if (!string.IsNullOrWhiteSpace(search.EpisodeName))
            {
                _searchSet = _searchSet.Where(x => x.EpisodeName.ToLower().StartsWith(search.EpisodeName.ToLower()));
            }
            if (search.EpisodeNumber.HasValue)
            {
                _searchSet = _searchSet.Where(x => x.EpisodeNumber == search.EpisodeNumber);
            }

            return _mapper.Map<List<PodcastSeasonEpisode>>(_searchSet.ToList());
        }
    }
}
