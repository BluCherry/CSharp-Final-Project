using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermediate_CSharp_Final
{
    public class Audio_Book : Media<bool>
    {
        public Audio_Book(string title, string creator, int year, double duration, bool rating) : base(title, creator, year, duration, rating)
        {
            
        }

        public override string ToString()
        {
            string ratingString = Rating ? "Thumbs Up" : "Thumbs Down";
            return $"{Title}, created by {Creator} in {Year}, Duration: {Duration} mins, Rating: {ratingString}";
        }
    }
}




