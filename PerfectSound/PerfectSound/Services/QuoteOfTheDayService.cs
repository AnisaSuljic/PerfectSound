using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PerfectSound.Database;
using PerfectSound.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectSound.Services
{
    public class QuoteOfTheDayService:IDailyQuoteService
    {
        protected PerfectSoundContext _context;
        private static Model.Model.Quote _quoteOfTheDay;
        private IMapper _mapper;

        public QuoteOfTheDayService(PerfectSoundContext context, IMapper _mapper)
        {
            _context = context;
            this._mapper = _mapper;
        }

        public Model.Model.Quote GetRandom()
        {
            return _quoteOfTheDay;
        }

        public Model.Model.Quote GenerateRandomQuote()
        {
            List<Quote> list = _context.Quotes
                .Include(x => x.SongAndPodcast).ThenInclude(x => x.ProductionCompany)
                .Include(x => x.SongAndPodcast).ThenInclude(x => x.SongAndPodcastPeople).ThenInclude(x => x.Person)
                .Include(x => x.SongAndPodcast).ThenInclude(x => x.Ratings)
                .Include(x => x.SongAndPodcast).ThenInclude(x => x.SongAndPodcastGenres).ThenInclude(x => x.Genre)
                .Include(x => x.SongAndPodcast).ThenInclude(x => x.PodcastSeasons)
                .ToList();
            int[] listOfIds = list.Select(x => x.QuoteId).ToArray();

            Random random = new Random();
            int position = random.Next(0, listOfIds.Count());

            _quoteOfTheDay = _mapper.Map<Model.Model.Quote>(list[position]);

            return _quoteOfTheDay;
        }
    }
}
