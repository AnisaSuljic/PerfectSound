using AutoMapper;
using PerfectSound.Database;
using PerfectSound.Model.Requests;
using PerfectSound.Model.Requests.User;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
            CreateMap<SongAndPodcast, Model.Model.SongAndPodcast>()
                .ForMember(x => x.RatingValue, m => m.MapFrom(src => src.Ratings.Average(x => x.RatingValue)))
                .ForMember(x => x.LastName, m => m.MapFrom(src => src.SongAndPodcastPeople.Where(x => x.RoleId == 1).FirstOrDefault().Person.LastName))
                .ForMember(x => x.FirstName, m => m.MapFrom(src => src.SongAndPodcastPeople.Where(x => x.RoleId == 1).FirstOrDefault().Person.FirstName))
                .ForMember(x => x.ProductionCompanyName, m => m.MapFrom(src => src.ProductionCompany.ProductionCompanyName))
                .ForMember(x => x.SongAndPodcastGenre, m => m.MapFrom(src => src.SongAndPodcastGenres.Where(x => x.SongAndPodcastId == src.SongAndPodcastId).ToList()))
                .ForMember(x => x.Genre, m => m.MapFrom(src => src.SongAndPodcastGenres.Where(x => x.SongAndPodcastId == src.SongAndPodcastId).Select(z => z.Genre).ToList()))
                .ForMember(x => x.PodcastSeason, m => m.MapFrom(src => src.PodcastSeasons.Where(x => x.SongAndPodcastId == src.SongAndPodcastId).ToList())).ReverseMap();
            CreateMap<Model.Requests.SongAndPodcast.SongAndPodcastUpsertRequest, SongAndPodcast>().ReverseMap();

            CreateMap<PodcastSeason, Model.Model.PodcastSeason>().ReverseMap();
            CreateMap<Model.Requests.PodcastSeason.PodcastSeasonUpsertRequest, PodcastSeason>().ReverseMap();

            CreateMap<PodcastSeasonEpisode, Model.Model.PodcastSeasonEpisode>().ReverseMap();
            CreateMap<Model.Requests.PodcastSeasonEpisode.PodcastSeasonEpisodeUpsertRequest, PodcastSeasonEpisode>().ReverseMap();

            CreateMap<News, Model.Model.News>().ReverseMap();
            CreateMap<Model.Requests.News.NewsUpsertRequest, News>().ReverseMap();

            CreateMap<Person, Model.Model.Person>()
                .ForMember(x => x.GenderName, m => m.MapFrom(src => src.Gender.GenderName)).ReverseMap();
            CreateMap<Model.Requests.Person.PersonUpsertRequest, Person>().ReverseMap();

            CreateMap<SongAndPodcastPerson, Model.Model.SongAndPodcastPerson>().ReverseMap();
            CreateMap<Model.Requests.SongAndPodcastPerson.SongAndPodcastPersonUpsertRequest, Database.SongAndPodcastPerson>().ReverseMap();

            CreateMap<Quote, Model.Model.Quote>()
                .ForPath(x=>x.ArtistName,m=>m.MapFrom(src=>src.SongAndPodcast.SongAndPodcastPeople.Where(k=>k.RoleId==1).FirstOrDefault().Person.FirstName+" "+ src.SongAndPodcast.SongAndPodcastPeople.Where(k => k.RoleId == 1).FirstOrDefault().Person.LastName))
                .ReverseMap();

            CreateMap<Model.Requests.Quote.QuoteUpsertRequest, Database.Quote>().ReverseMap();

            CreateMap<Comment, Model.Model.Comment>()
                .ForMember(x => x.Username, m => m.MapFrom(src => src.User.UserName)).ReverseMap();

            CreateMap<Model.Requests.Comment.CommentUpsertRequest, Database.Comment>().ReverseMap();

            CreateMap<Rating, Model.Model.Rating>().ReverseMap();
            CreateMap<Model.Requests.Rating.RatingUpsertRequest, Database.Rating>().ReverseMap();

            CreateMap<SongAndPodcastGenre, Model.Model.SongAndPodcastGenre>().ReverseMap();
            CreateMap<Model.Requests.SongAndPodcastGenre.SongAndPodcastGenreUpsertRequest, Database.SongAndPodcastGenre>().ReverseMap();

        }
    }
}
