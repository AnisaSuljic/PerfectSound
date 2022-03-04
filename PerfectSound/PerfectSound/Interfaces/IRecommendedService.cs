using PerfectSound.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectSound.Interfaces
{
    public interface IRecommendedService
    {
        //public List<Model.Model.SongAndPodcast> Recommend(int SaPId);
        public List<SongAndPodcast> LoadSimilar(int titleId);


    }
}
