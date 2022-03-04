using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using PerfectSound.Database;
using PerfectSound.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectSound.Services
{
    public class RecommendedService : IRecommendedService
    {
        public PerfectSoundContext _context { get; }
        public IMapper _mapper { get; }
        public RecommendedService(PerfectSoundContext _context, IMapper _mapper)
        {
            this._context = _context;
            this._mapper = _mapper;
        }

       /* private static MLContext mlContext = null;
        private static ITransformer modeltr { get; set; }
        
        public List<Model.Model.SongAndPodcast>Recommend(int SaPId)
        {
            if (mlContext == null)
            {
                mlContext = new MLContext();
                var tempData = _context.Ratings.ToList();
                var data = new List<RatingEntry>();
                if (tempData.Count > 1)
                {
                    var distinctItemId = tempData.Select(x => x.SongAndPodcastId).ToList();

                    distinctItemId.ForEach(y =>
                    {
                        var relatedItem = tempData.Where(x => x.SongAndPodcastId != y).ToList();

                        foreach (var item in relatedItem)
                        {
                            data.Add(new RatingEntry()
                            {
                                RatingId=(uint)y,
                                CoRatingId=(uint)item.SongAndPodcastId
                            });
                        }
                    });
                }

                var traindata = mlContext.Data.LoadFromEnumerable(data);

                MatrixFactorizationTrainer.Options options = new MatrixFactorizationTrainer.Options();
                options.MatrixColumnIndexColumnName = nameof(RatingEntry.RatingId);
                options.MatrixRowIndexColumnName = nameof(RatingEntry.CoRatingId);
                options.LabelColumnName = "Label";
                options.LossFunction = MatrixFactorizationTrainer.LossFunctionType.SquareLossOneClass;
                options.Alpha = 0.01;
                options.Lambda = 0.025;
                // For better results use the following parameters
                //options.K = 100;
                options.C = 0.00001;

                var est = mlContext.Recommendation().Trainers.MatrixFactorization(options);

                modeltr = est.Fit(traindata);
            }

            var allitems = _context.SongAndPodcasts.Where(x => x.SongAndPodcastId != SaPId).ToList();
            var predictionResult = new List<Tuple<Database.SongAndPodcast, float>>();

            foreach (var item in allitems)
            {
                var predEngine = mlContext.Model.CreatePredictionEngine<RatingEntry, CoRating_prediction>(modeltr);

                var prediction=predEngine.Predict(new RatingEntry()
                {
                    RatingId = (uint)SaPId,
                    CoRatingId = (uint)item.SongAndPodcastId
                });

                predictionResult.Add(new Tuple<SongAndPodcast, float>(item, prediction.Score));
            }
            var finalResult = predictionResult.OrderByDescending(x => x.Item2).Select(x => x.Item1).ToList();

            return _mapper.Map<List<Model.Model.SongAndPodcast>>(finalResult);

        }*/
        
        Dictionary<decimal, List<Rating>> songs_podcasts = new Dictionary<decimal, List<Rating>>();
        Dictionary<User, List<Rating>> user_rates = new Dictionary<User, List<Rating>>();

        public List<SongAndPodcast> LoadSimilar(int kokrisnikID)
        {
            List<User> users = _context.Users.Include(x => x.UserType).Where(y => y.UserId != kokrisnikID && y.UserType.UserTypeId == 2).ToList();

            foreach (User item in users)
            {
                var rates = _context.Ratings.Where(x => x.UserId == item.UserId && x.RatingValue>=3.0).ToList();
                user_rates.Add(item, rates);
            }

            List<Rating> baseRating = _context.Ratings.Where(x => x.UserId == kokrisnikID).ToList();

            List<Rating> ratingsCurrentUser = new List<Rating>();
            List<Rating> ratingsOther = new List<Rating>();

            List<int> recomendedSapsID = new List<int>();
            List<SongAndPodcast> recomendedSaps = new List<SongAndPodcast>();

            var listOfAlreadyRatedSaPID = _context.Ratings.Where(x => x.UserId == kokrisnikID ).Select(x=>x.SongAndPodcastId).ToList();

            foreach (var item in user_rates)
            {
                int sapid = (int)item.Value.Select(x=>x.SongAndPodcastId).FirstOrDefault();
                foreach (Rating rating in baseRating)
                {
                    if (item.Value.Any(x=>x.SongAndPodcastId==rating.SongAndPodcastId))
                    {
                        ratingsCurrentUser.Add(rating);
                        ratingsOther.Add(item.Value.Where(x => x.SongAndPodcastId == rating.SongAndPodcastId).FirstOrDefault());
                    }
                }
                double similarity = GetSimilarity(ratingsCurrentUser, ratingsOther);
                if (similarity > 0.5)
                {
                    var d = user_rates.Select(x => x.Value).SelectMany(x => x).Where(x => x.RatingValue >= 3.0).Select(x => x.SongAndPodcastId).Where(x => !listOfAlreadyRatedSaPID.Contains(x)).ToList();

                    d.ForEach(e => {
                        var s = _context.SongAndPodcasts.Where(x => x.SongAndPodcastId == (int)e).FirstOrDefault();
                        if (!recomendedSaps.Contains(s))
                            recomendedSaps.Add(s);
                    });
                    

                }
                ratingsCurrentUser.Clear();
                ratingsOther.Clear();
            }

            return recomendedSaps.Take(6).ToList();
        }

        private double GetSimilarity(List<Rating> ratings1, List<Rating> ratings2)
        {
            if (ratings1.Count != ratings2.Count)
            {
                return 0;
            }

            double x = 0, y1 = 0, y2 = 0;
            for (int i = 0; i < ratings1.Count; i++)
            {
                x = (double)(ratings1[i].RatingValue * ratings2[i].RatingValue);
                y1 = (double)(ratings1[i].RatingValue * ratings1[i].RatingValue);
                y2 = (double)(ratings2[i].RatingValue * ratings2[i].RatingValue);
            }
            y1 = Math.Sqrt(y1);
            y2 = Math.Sqrt(y2);

            double y = y1 * y2;
            if (y == 0)
                return 0;
            return x / y;
        }

    }

    public class CoRating_prediction
    {
        public float Score{ get; set; }
    }
    public class RatingEntry
    {
        [KeyType(count:10)]
        public uint RatingId { get; set; }
        [KeyType(count: 10)]
        public uint CoRatingId { get; set; }
        public float Label { get; set; }

    }
}
