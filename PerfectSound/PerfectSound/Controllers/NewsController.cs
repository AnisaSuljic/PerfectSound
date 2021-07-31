using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PerfectSound.Model.Model;
using PerfectSound.Model.Requests.News;
using PerfectSound.Interfaces;

namespace PerfectSound.Controllers
{
    public class NewsController : BaseCRUDController<News, NewsSearchRequest, NewsUpsertRequest, NewsUpsertRequest>
    {
        public NewsController(ICRUDService<News, NewsSearchRequest, NewsUpsertRequest, NewsUpsertRequest> service) : base(service)
        {
        }
    }
}
