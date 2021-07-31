using Microsoft.AspNetCore.Mvc;
using PerfectSound.Interfaces;
using PerfectSound.Model.Model;
using PerfectSound.Model.Requests.SongAndPodcast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectSound.Controllers
{
    public class SongAndPodcastController : BaseCRUDController<SongAndPodcast,SongAndPodcastSearchRequest,
                                                        SongAndPodcastUpsertRequest,SongAndPodcastUpsertRequest>
    {
        public SongAndPodcastController(ICRUDService<SongAndPodcast, SongAndPodcastSearchRequest, 
            SongAndPodcastUpsertRequest, SongAndPodcastUpsertRequest> service) : base(service)
        {
        }
    }
}
