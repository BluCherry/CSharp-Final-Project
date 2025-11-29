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
        }

        public override string ToString()
        {
            return $"{Title} - S{SeasonNumber:D2} E{EpisodeNumber:D2} of {ShowTitle}, created by {Creator} in {Year}, Duration: {Duration} mins, Rating: {Rating}/10";
        }

        public string ShowTitle
        {
            get => showTitle;
            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Show Title cannot be null or empty");
                }
                showTitle = value; 
            }
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





