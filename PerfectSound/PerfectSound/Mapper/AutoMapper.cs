using AutoMapper;
using PerfectSound.Database;
using PerfectSound.Model.Requests;
using PerfectSound.Model.Requests.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectSound.Mapper
{
    public class AutoMapper:Profile
    {
        public AutoMapper()
        {
            // source - destination

            //Onlyread classes
            CreateMap<Genre, Model.Model.Genre>().ReverseMap();
            CreateMap<Gender, Model.Model.Gender>().ReverseMap();
            CreateMap<Role, Model.Model.Role>().ReverseMap(); 
            CreateMap<ProductionCompany, Model.Model.ProductionCompany>().ReverseMap();
            CreateMap<UserType, Model.Model.UserType>().ReverseMap();

            //Onlyread classes (custom services)
            CreateMap<User, Model.Model.User>().ReverseMap();
            CreateMap<UserUpsertRequest, User>().ReverseMap();

            //CRUD
            CreateMap<SongAndPodcast, Model.Model.SongAndPodcast>().ReverseMap();
            CreateMap<Model.Requests.SongAndPodcast.SongAndPodcastUpsertRequest, SongAndPodcast>().ReverseMap();

            CreateMap<PodcastSeason, Model.Model.PodcastSeason>().ReverseMap();
            CreateMap<Model.Requests.PodcastSeason.PodcastSeasonUpsertRequest, PodcastSeason>().ReverseMap();

            CreateMap<PodcastSeasonEpisode, Model.Model.PodcastSeasonEpisode>().ReverseMap();
            CreateMap<Model.Requests.PodcastSeasonEpisode.PodcastSeasonEpisodeUpsertRequest, PodcastSeasonEpisode>().ReverseMap();

            CreateMap<News, Model.Model.News>().ReverseMap();
            CreateMap<Model.Requests.News.NewsUpsertRequest, News>().ReverseMap();

            CreateMap<Person, Model.Model.Person>().ReverseMap();
            CreateMap<Model.Requests.Person.PersonUpsertRequest, Person>().ReverseMap();

            CreateMap<SongAndPodcastPerson, Model.Model.SongAndPodcastPerson>().ReverseMap();
            CreateMap<Model.Requests.SongAndPodcastPerson.SongAndPodcastPersonUpsertRequest, Database.SongAndPodcastPerson>().ReverseMap();

            CreateMap<Quote, Model.Model.Quote>().ReverseMap();
            CreateMap<Model.Requests.Quote.QuoteUpsertRequest, Database.Quote>().ReverseMap();

            CreateMap<Comment, Model.Model.Comment>().ReverseMap();
            CreateMap<Model.Requests.Comment.CommentUpsertRequest, Database.Comment>().ReverseMap();

            CreateMap<SongAndPodcastGenre, Model.Model.SongAndPodcastGenre>().ReverseMap();
            CreateMap<Model.Requests.SongAndPodcastGenre.SongAndPodcastGenreUpsertRequest, Database.SongAndPodcastGenre>().ReverseMap();

        }
    }
}
