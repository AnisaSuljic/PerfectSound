using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PerfectSound.Model.Model;
using PerfectSound.Model.Requests.Comment;
using PerfectSound.Interfaces;

namespace PerfectSound.Controllers
{
    public class CommentController : BaseCRUDController<Comment, CommentSearchRequest, CommentUpsertRequest, CommentUpsertRequest>
    {
        public CommentController(ICRUDService<Comment, CommentSearchRequest, CommentUpsertRequest, CommentUpsertRequest> service) : base(service)
        {
        }
    }
}
