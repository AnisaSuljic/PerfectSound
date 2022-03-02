using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PerfectSound.Database;
using PerfectSound.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectSound.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommendedController : ControllerBase
    {
        private IRecommendedService _service;
        public IMapper _mapper { get; }

        public RecommendedController(IRecommendedService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        /*[AllowAnonymous]
        [HttpGet("Similar/{id}")]
        public List<Model.Model.SongAndPodcast> LoadSimilar(int id)
        {
            return _mapper.Map< List < Model.Model.SongAndPodcast >>( _service.LoadSimilar(id));

        }*/
        [AllowAnonymous]
        [HttpGet("Recommend/{id}")]
        public List<Model.Model.SongAndPodcast> Recommend(int id)
        {
            return _service.Recommend(id);
        }
    }
}
