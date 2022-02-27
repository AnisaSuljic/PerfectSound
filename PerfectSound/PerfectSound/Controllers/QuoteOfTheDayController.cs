using Microsoft.AspNetCore.Mvc;
using PerfectSound.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectSound.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteOfTheDayController : ControllerBase
    {
        private readonly IDailyQuoteService _service;

        public QuoteOfTheDayController(IDailyQuoteService _service)
        {
            this._service = _service;
        }

        [HttpGet]
        public Model.Model.Quote GetRandomQuote()
        {
            return _service.GetRandom();
        }

        [NonAction]
        public Model.Model.Quote GenerateRandomQuote()
        {
            return _service.GenerateRandomQuote();
        }
    }
}
