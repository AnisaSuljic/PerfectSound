﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PerfectSound.Model.Model;
using PerfectSound.Model.Requests.Comment;

namespace PerfectSound.Services
{
    public class CommentService : BaseCRUDService<Comment, CommentSearchRequest, CommentUpsertRequest, CommentUpsertRequest, Database.Comment>
    {
        public CommentService(Database.PerfectSoundContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override List<Comment> Get(CommentSearchRequest search)
        {
            var _searchSet = _context.Comments.Include(x=>x.User).ThenInclude(x=>x.UserType).AsQueryable();

            if (search.SongAndPodcastId != null)
            {
                _searchSet = _searchSet.Where(x => x.SongAndPodcastId==search.SongAndPodcastId);
            }

            return _mapper.Map<List<Comment>>(_searchSet.ToList());
        }

        public override Comment GetById(int Id)
        {
            var entity = _context.Comments
                .Include(x => x.User).ThenInclude(x => x.UserType)
                .AsQueryable().Where(x => x.CommentId == Id).FirstOrDefault();


            return _mapper.Map<Comment>(entity);
        }
    }
}
