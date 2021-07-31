using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PerfectSound.Model.Model;
using PerfectSound.Model.Requests.Comment;

namespace PerfectSound.Services
{
    public class CommentService : BaseCRUDService<Comment, object, CommentUpsertRequest, CommentUpsertRequest, Database.Comment>
    {
        public CommentService(Database.PerfectSoundContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
