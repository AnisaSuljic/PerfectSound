using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PerfectSound.Model.Model;
using PerfectSound.Model.Requests.SongAndPodcast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectSound.Services
{
    public class SongAndPodcastService : BaseCRUDService<SongAndPodcast, SongAndPodcastSearchRequest,
                                    SongAndPodcastUpsertRequest, SongAndPodcastUpsertRequest, Database.SongAndPodcast>
    {
        public SongAndPodcastService(Database.PerfectSoundContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override List<SongAndPodcast> Get(SongAndPodcastSearchRequest search)
        {
            var _searchSet = _context.SongAndPodcasts
                .Include(x=>x.ProductionCompany)
                .Include(x=>x.SongAndPodcastGenres)
                .ThenInclude(x=>x.Genre)
                .Include(x => x.SongAndPodcastPeople)
                .ThenInclude(x=>x.Person)
                .Include(x => x.Ratings)
                .AsQueryable();

            if (search.GenreId != 0)
            {
                _searchSet = _searchSet.Where(x => x.SongAndPodcastGenres.Select(y=>y.GenreId).Contains(search.GenreId));
            }
            if (!string.IsNullOrWhiteSpace(search.Title))
            {
                _searchSet = _searchSet.Where(x => x.Title.ToLower().StartsWith(search.Title.ToLower()));
            }
            if (search.ReleaseDate != null)
            {
                _searchSet = _searchSet.Where(x => x.ReleaseDate.Value.Year == search.ReleaseDate.Value.Year &&
                x.ReleaseDate.Value.Month == search.ReleaseDate.Value.Month && x.ReleaseDate.Value.Day == search.ReleaseDate.Value.Day);
            }
            if(search?.IsPodcast!=null)
            {
                _searchSet = _searchSet.Where(x => x.IsPodcast == search.IsPodcast);
            }

            if(search.FeelingId!=0)
            {
                _searchSet = _searchSet.Where(x => x.SongAndPodcastGenres.Select(y => y.GenreId).Contains(search.FeelingId));
            }
            if(search.ArtistId!=0)
            {
                _searchSet = _searchSet.Where(x => x.SongAndPodcastPeople.Select(y => y.Person.PersonId).Contains(search.ArtistId));
            }
            if (search.Year != 0)
            {
                _searchSet = _searchSet.Where(x => x.ReleaseDate.Value.Year==search.Year );
            }

            var _searchSetList = _mapper.Map<List<SongAndPodcast>>(_searchSet);
            return _searchSetList;
        }

        public override SongAndPodcast Insert(SongAndPodcastUpsertRequest request)
        {
            var entity = _mapper.Map<Database.SongAndPodcast>(request);

            _context.SongAndPodcasts.Add(entity);
            _context.SaveChanges();

            foreach (var genre in request.GenreIDList)
            {
                Database.SongAndPodcastGenre _songPodcastGenre = new Database.SongAndPodcastGenre();
                _songPodcastGenre.SongAndPodcastId = entity.SongAndPodcastId;
                _songPodcastGenre.GenreId = genre;
                _context.SongAndPodcastGenres.Add(_songPodcastGenre);
            }
            _context.SaveChanges();
            return _mapper.Map<SongAndPodcast> (entity);
        }

        public override SongAndPodcast Update(int Id, SongAndPodcastUpsertRequest request)
        {
            var entity = _context.SongAndPodcasts.Find(Id);


            _context.SongAndPodcasts.Attach(entity);
            _context.SongAndPodcasts.Update(entity);
            _context.SaveChanges();

            var SAPGenreList = _context.SongAndPodcastGenres.Include(x=>x.Genre).AsQueryable().Where(x=>x.SongAndPodcastId==Id);

            foreach (var item in SAPGenreList)
            {
                _context.SongAndPodcastGenres.Remove(item);
            }

            foreach (var genre in request.GenreIDList)
            {
                Database.SongAndPodcastGenre _songPodcastGenre = new Database.SongAndPodcastGenre();
                _songPodcastGenre.SongAndPodcastId = entity.SongAndPodcastId;
                _songPodcastGenre.GenreId = genre;
                _context.SongAndPodcastGenres.Add(_songPodcastGenre);
            }
            _mapper.Map(request, entity);

            _context.SaveChanges();
            return _mapper.Map<SongAndPodcast>(entity);


        }

        public override Model.Model.SongAndPodcast GetById(int Id)
        {
            var entity = _context.SongAndPodcasts
                .Include(x => x.ProductionCompany)
                .Include(x => x.SongAndPodcastGenres)
                .ThenInclude(x => x.Genre)
                .Include(x => x.SongAndPodcastPeople)
                .ThenInclude(x => x.Person)
                .Include(x => x.Ratings)
                .AsQueryable().Where(x => x.SongAndPodcastId == Id).FirstOrDefault();


            return _mapper.Map<SongAndPodcast>(entity);
        }

    }
}
