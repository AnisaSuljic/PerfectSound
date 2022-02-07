using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PerfectSound.Model.Model;
using PerfectSound.Model.Requests.Rating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectSound.Services
{
    public class RatingService : BaseCRUDService<Rating, RatingSearchRequest, RatingUpsertRequest, RatingUpsertRequest, Database.Rating>
    {
        public RatingService(Database.PerfectSoundContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Rating> Get(RatingSearchRequest request)
        {
            var query = _context.Ratings
                .Include(x => x.SongAndPodcast)
                .Include(x => x.SongAndPodcast.Ratings)
                .AsQueryable();

            if (request.SongAndPodcastId != 0)
            {
                query = query.Where(x => x.SongAndPodcastId == request.SongAndPodcastId);
            }
            if (request.UserId != 0)
            {
                query = query.Where(x => x.UserId == request.UserId);
            }

            return _mapper.Map<List<Rating>>(query.ToList());
        }

        public override Rating Insert(RatingUpsertRequest request)
        {
            var x = _context.Ratings.Where(x => x.UserId == request.UserId && x.SongAndPodcastId == request.SongAndPodcastId).SingleOrDefault();
            if (x != null)
            {
                x.RatingValue = request.RatingValue;
                _context.SaveChanges();
                return _mapper.Map<Rating>(x);
            }
            else
            {
                var entity = _mapper.Map<Database.Rating>(request);
                _context.Ratings.Add(entity);
                _context.SongAndPodcasts.Where(x => x.SongAndPodcastId == request.SongAndPodcastId).SingleOrDefault().NumberOfRatings++;
                _context.SaveChanges();
                return _mapper.Map<Rating>(entity);
            }
        }
    }
}
