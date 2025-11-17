using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermediate_CSharp_Final
{
    public class TV_Episode : Media<int>
    {
        private string showTitle;
        private int seasonNumber;
        private int episodeNumber;

        public TV_Episode(string title, string showTitle, string creator, int year, int seasonNumber, int episodeNumber, double duration, int rating) : base(title, creator, year, duration, rating)
        {
            ShowTitle = showTitle;
            SeasonNumber = seasonNumber;
            EpisodeNumber = episodeNumber;
            
            if (rating < 1 || rating > 10)
            {
                throw new ArgumentOutOfRangeException("rating for Track must be thumb up or thumb down");
            }
        }

        public string ShowTitle
        {
            get => showTitle;
            set { showTitle = value; } //Can be null or not
        }

        public int SeasonNumber
        {
            get => seasonNumber;
            set
            {
                if (value < 0)
                {
                    throw new Exception("Season number cannot be negative");
                }
                seasonNumber = value;
            }
        }

        public int EpisodeNumber
        {
            get => episodeNumber;
            set
            {
                if (value < 0)
                {
                    throw new Exception("Episode number cannot be negative");
                }
                episodeNumber = value;
            }
        }
    }
}
