using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerfectSound.Interfaces;
using PerfectSound.Model.Model;
using PerfectSound.Model.Requests.Quote;

namespace PerfectSound.Services
{
    public class QuoteService : BaseCRUDService<Quote, object, QuoteUpsertRequest, QuoteUpsertRequest, Database.Quote>
    {
        protected static Quote _quoteOfTheDay;
        public QuoteService(Database.PerfectSoundContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public Quote GetRandom()
        {
            return GenerateRandomQuote();
        }
        public Quote GenerateRandomQuote()
        {
            List<Database.Quote> list = _context.Quotes.Include(x => x.SongAndPodcast).ToList();
            int[] listOfIds = list.Select(x => x.QuoteId).ToArray();

            Random random = new Random();
            int position = random.Next(0, listOfIds.Count());

            _quoteOfTheDay = _mapper.Map<Quote>(list[position]);

            return _quoteOfTheDay;
        }
    }
}
