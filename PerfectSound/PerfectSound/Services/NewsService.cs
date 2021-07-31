using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PerfectSound.Model.Model;
using PerfectSound.Model.Requests.News;

namespace PerfectSound.Services
{
    public class NewsService : BaseCRUDService<News, NewsSearchRequest, NewsUpsertRequest, NewsUpsertRequest, Database.News>
    {
        public NewsService(Database.PerfectSoundContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override List<News> Get(NewsSearchRequest search)
        {
            var _searchSet = _context.News.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search.Title))
            {
                _searchSet = _searchSet.Where(x => x.Title.ToLower().StartsWith(search.Title.ToLower()));
            }
            if (search.PublicationDate!=null)
            {
                _searchSet = _searchSet.Where(x => x.PublicationDate.Value.Year ==search.PublicationDate.Value.Year &&
                x.PublicationDate.Value.Month==search.PublicationDate.Value.Month && x.PublicationDate.Value.Day==search.PublicationDate.Value.Day);
            }
            
            return _mapper.Map<List<News>>(_searchSet.ToList());
        }
    }
}
