using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PerfectSound.Model.Model;
using PerfectSound.Model.Requests.News;
using PerfectSound.Interfaces;
using PerfectSound.Services;

namespace PerfectSound.Controllers
{
    public class NewsController : BaseCRUDController<News, NewsSearchRequest, NewsUpsertRequest, NewsUpsertRequest>
    {
        protected NewsService _serviceNews;

        public NewsController(ICRUDService<News, NewsSearchRequest, NewsUpsertRequest, NewsUpsertRequest> service) : base(service)
        {
            _serviceNews = (NewsService)service;
        }

        [Route("Last3")]
        [HttpGet]
        public List<News> GetLast3()
        {
            return _serviceNews.GetLast3();
        }
    }
}
