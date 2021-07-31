using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PerfectSound.Model.Model;
using PerfectSound.Model.Requests.SongAndPodcastPerson;
using PerfectSound.Interfaces;

namespace PerfectSound.Controllers
{
    public class SongAndPodcastPersonController : BaseCRUDController<SongAndPodcastPerson,SongAndPodcastPersonSearchRequest,SongAndPodcastPersonUpsertRequest,SongAndPodcastPersonUpsertRequest>
    {
        public SongAndPodcastPersonController(ICRUDService<SongAndPodcastPerson, SongAndPodcastPersonSearchRequest, SongAndPodcastPersonUpsertRequest, SongAndPodcastPersonUpsertRequest> service) : base(service)
        {
        }

    }
}
