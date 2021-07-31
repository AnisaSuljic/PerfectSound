using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PerfectSound.Model.Model;
using PerfectSound.Model.Requests.SongAndPodcastGenre;

namespace PerfectSound.Services
{
    public class SongAndPodcastGenreService : BaseCRUDService<SongAndPodcastGenre, SongAndPodcastGenreSearchRequest, SongAndPodcastGenreUpsertRequest, SongAndPodcastGenreUpsertRequest, Database.SongAndPodcastGenre>
    {
        public SongAndPodcastGenreService(Database.PerfectSoundContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
