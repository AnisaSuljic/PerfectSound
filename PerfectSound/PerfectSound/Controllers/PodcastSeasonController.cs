using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PerfectSound.Model.Model;
using PerfectSound.Model.Requests.PodcastSeason;
using PerfectSound.Interfaces;

namespace PerfectSound.Controllers
{
    public class PodcastSeasonController : BaseCRUDController<PodcastSeason, PodcastSeasonSearchRequest, PodcastSeasonUpsertRequest, PodcastSeasonUpsertRequest>
    {
        public PodcastSeasonController(ICRUDService<PodcastSeason, PodcastSeasonSearchRequest, PodcastSeasonUpsertRequest, PodcastSeasonUpsertRequest> service) : base(service)
        {
        }
    }
}
