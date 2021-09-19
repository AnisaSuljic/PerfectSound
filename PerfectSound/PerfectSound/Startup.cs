using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PerfectSound.Database;
using PerfectSound.Filters;
using PerfectSound.Interfaces;
using PerfectSound.Model.Requests.Comment;
using PerfectSound.Model.Requests.News;
using PerfectSound.Model.Requests.Person;
using PerfectSound.Model.Requests.PodcastSeason;
using PerfectSound.Model.Requests.PodcastSeasonEpisode;
using PerfectSound.Model.Requests.Quote;
using PerfectSound.Model.Requests.SongAndPodcast;
using PerfectSound.Model.Requests.SongAndPodcastGenre;
using PerfectSound.Model.Requests.SongAndPodcastPerson;
using PerfectSound.Security;
using PerfectSound.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectSound
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(x=>
            {
                x.Filters.Add<ErrorFilter>();
            });

            // basic auth
            services.AddAuthentication("BasicAuthentication").AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PerfectSound API", Version = "v1" });

                c.AddSecurityDefinition("basicAuth", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "basicAuth" }
                        },
                        new string[]{}
                    }
                });
            });

            //Context
            services.AddDbContext<PerfectSoundContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //Automapper
            services.AddAutoMapper(typeof(Startup));

           


            #region dependency injection
            //Onlyread classes 
            services.AddScoped<IService<Model.Model.Genre, object>, BaseService<Model.Model.Genre, object, Database.Genre>>();
            services.AddScoped<IService<Model.Model.Gender, object>, BaseService<Model.Model.Gender, object, Database.Gender>>();
            services.AddScoped<IService<Model.Model.Role, object>, BaseService<Model.Model.Role, object, Database.Role>>();
            services.AddScoped<IService<Model.Model.UserType, object>, BaseService<Model.Model.UserType, object, Database.UserType>>();
            services.AddScoped<IService<Model.Model.ProductionCompany, object>, BaseService<Model.Model.ProductionCompany, object, ProductionCompany>>();

            //Onlyread classes (custom services)
            services.AddScoped<IUserService, UserService>();

            //CRUD
            services.AddScoped<ICRUDService<Model.Model.SongAndPodcast, SongAndPodcastSearchRequest, SongAndPodcastUpsertRequest, SongAndPodcastUpsertRequest>, SongAndPodcastService>();
            services.AddScoped<ICRUDService<Model.Model.PodcastSeason, PodcastSeasonSearchRequest, PodcastSeasonUpsertRequest, PodcastSeasonUpsertRequest>,PodcastSeasonService>();
            services.AddScoped<ICRUDService<Model.Model.PodcastSeasonEpisode,PodcastSeasonEpisodeSearchRequest, PodcastSeasonEpisodeUpsertRequest, PodcastSeasonEpisodeUpsertRequest>,PodcastSeasonEpisodeService>();
            services.AddScoped<ICRUDService<Model.Model.News,NewsSearchRequest, NewsUpsertRequest, NewsUpsertRequest>,NewsService>();
            services.AddScoped<ICRUDService<Model.Model.Person,PersonSearchRequest,PersonUpsertRequest, PersonUpsertRequest>,PersonService>();
            services.AddScoped<ICRUDService<Model.Model.SongAndPodcastPerson, SongAndPodcastPersonSearchRequest, SongAndPodcastPersonUpsertRequest, SongAndPodcastPersonUpsertRequest>,SongAndPodcastPersonService>();
            services.AddScoped<ICRUDService<Model.Model.Quote, object, QuoteUpsertRequest, QuoteUpsertRequest>,QuoteService>();
            services.AddScoped<ICRUDService<Model.Model.Comment, CommentSearchRequest, CommentUpsertRequest, CommentUpsertRequest>,CommentService>();
            services.AddScoped<ICRUDService<Model.Model.SongAndPodcastGenre, SongAndPodcastGenreSearchRequest, SongAndPodcastGenreUpsertRequest, SongAndPodcastGenreUpsertRequest>,SongAndPodcastGenreService>();


            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseHttpsRedirection();

            app.UseRouting();
            
            
            app.UseAuthentication();
            
            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
