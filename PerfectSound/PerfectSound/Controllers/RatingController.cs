using Microsoft.AspNetCore.Mvc;
using PerfectSound.Interfaces;
using PerfectSound.Model.Model;
using PerfectSound.Model.Requests.Rating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectSound.Controllers
{
    public class RatingController : BaseCRUDController<Rating, RatingSearchRequest, RatingUpsertRequest, RatingUpsertRequest>
    {
        public RatingController(ICRUDService<Rating, RatingSearchRequest, RatingUpsertRequest, RatingUpsertRequest> service) : base(service)
        {
        }
    }
}
