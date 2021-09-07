using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PerfectSound.Model.Model;
using PerfectSound.Model.Requests.Quote;
using PerfectSound.Interfaces;
using PerfectSound.Services;

namespace PerfectSound.Controllers
{
    public class QuoteController : BaseCRUDController<Quote, object, QuoteUpsertRequest, QuoteUpsertRequest>
    {
        protected QuoteService _serviceQuote;
        public QuoteController(ICRUDService<Quote, object, QuoteUpsertRequest, QuoteUpsertRequest> service) : base(service)
        {
            _serviceQuote = (QuoteService)service;
        }

        [Route("[action]")]
        [HttpGet]
        public Quote GetRandomQuote()
        {
            return _serviceQuote.GetRandom();
        }

    }
}
