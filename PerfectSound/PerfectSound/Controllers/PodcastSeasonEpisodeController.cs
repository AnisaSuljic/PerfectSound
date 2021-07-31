using Microsoft.AspNetCore.Mvc;
using PerfectSound.Interfaces;
using PerfectSound.Model.Model;
using PerfectSound.Model.Requests.PodcastSeasonEpisode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectSound.Controllers
{
    public class PodcastSeasonEpisodeController : BaseCRUDController<PodcastSeasonEpisode, PodcastSeasonEpisodeSearchRequest,
                                                   PodcastSeasonEpisodeUpsertRequest, PodcastSeasonEpisodeUpsertRequest>
    {
        public PodcastSeasonEpisodeController(ICRUDService<PodcastSeasonEpisode, PodcastSeasonEpisodeSearchRequest, PodcastSeasonEpisodeUpsertRequest, PodcastSeasonEpisodeUpsertRequest> service) : base(service)
        {
        }
    }
}
