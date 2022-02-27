﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PerfectSound.Database;
using PerfectSound.Model.Model;
using PerfectSound.Model.Requests.SongAndPodcastGenre;

namespace PerfectSound.Services
{
    public class SongAndPodcastGenreService : BaseCRUDService<Model.Model.SongAndPodcastGenre, SongAndPodcastGenreSearchRequest, SongAndPodcastGenreUpsertRequest, SongAndPodcastGenreUpsertRequest, Database.SongAndPodcastGenre>
    {
        public SongAndPodcastGenreService(Database.PerfectSoundContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override List<Model.Model.SongAndPodcastGenre> Get(SongAndPodcastGenreSearchRequest search)
        {
            var _searchSet = _context.SongAndPodcastGenres.Include(x=>x.Genre).AsQueryable();

            if (search.SongAndPodcastId != 0 && search.SongAndPodcastId!=null)
            {
                _searchSet = _searchSet.Where(x => x.SongAndPodcastId == search.SongAndPodcastId);
            }

            return _mapper.Map<List<Model.Model.SongAndPodcastGenre>>(_searchSet.ToList());
        }
        
        public override Model.Model.SongAndPodcastGenre GetById(int Id)
        {
            var entity = _context.SongAndPodcastGenres
                .Include(x => x.Genre)
                .AsQueryable().Where(x => x.SongAndPodcastGenreId == Id).FirstOrDefault();


            return _mapper.Map<Model.Model.SongAndPodcastGenre>(entity);
        }
    }
}
