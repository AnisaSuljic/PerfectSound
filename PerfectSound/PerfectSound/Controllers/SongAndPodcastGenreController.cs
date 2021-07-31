using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PerfectSound.Model.Model;
using PerfectSound.Model.Requests.SongAndPodcastGenre;
using PerfectSound.Interfaces;

namespace PerfectSound.Controllers
{
    public class SongAndPodcastGenreController : BaseCRUDController<SongAndPodcastGenre, SongAndPodcastGenreSearchRequest, SongAndPodcastGenreUpsertRequest, SongAndPodcastGenreUpsertRequest>
    {
        public SongAndPodcastGenreController(ICRUDService<SongAndPodcastGenre, SongAndPodcastGenreSearchRequest, SongAndPodcastGenreUpsertRequest, SongAndPodcastGenreUpsertRequest> service) : base(service)
        {
        }
    }
}
