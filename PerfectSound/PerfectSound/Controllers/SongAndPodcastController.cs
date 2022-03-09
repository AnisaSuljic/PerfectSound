using Microsoft.AspNetCore.Mvc;
using PerfectSound.Interfaces;
using PerfectSound.Model.Model;
using PerfectSound.Model.Requests.SongAndPodcast;
using PerfectSound.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectSound.Controllers
{
    public class SongAndPodcastController : BaseCRUDController<SongAndPodcast,SongAndPodcastSearchRequest,
                                                        SongAndPodcastUpsertRequest,SongAndPodcastUpsertRequest>
    {
        protected SongAndPodcastService _serviceSAP;
        public SongAndPodcastController(ICRUDService<SongAndPodcast, SongAndPodcastSearchRequest, 
            SongAndPodcastUpsertRequest, SongAndPodcastUpsertRequest> service) : base(service)
        {
            _serviceSAP = (SongAndPodcastService)service;
        }

        [Route("Last3")]
        [HttpGet]
        public List<SongAndPodcast> GetLast3()
        {
            return _serviceSAP.GetLast3();
        }
    }
}
