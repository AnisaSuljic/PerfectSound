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
    public class CommentController : BaseCRUDController<Comment, object, CommentUpsertRequest, CommentUpsertRequest>
    {
        public CommentController(ICRUDService<Comment, object, CommentUpsertRequest, CommentUpsertRequest> service) : base(service)
        {
        }
    }
}
