using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermediate_CSharp_Final
{
    public class Track : Media<double>
    {
        private string album;

        public Track(string title, string creator, string album, int year, double duration, double rating) : base(title, creator, year, duration, rating)
        {
            Album = album;
            
            if (rating < 0 || rating > 5)
            {
                throw new ArgumentOutOfRangeException("rating for Track must be between 0 and 5");
            }
        }

        public string Album
        {
            get => album;
            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Album cannot be null or empty");
                }
                album = value; 
            }
        }
    }
}

