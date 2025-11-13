using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermediate_CSharp_Final
{
    public class Audio_Book : Media<string>
    {
        public Audio_Book(string title, string creator, int year, double duration, string rating) : base(title, creator, year, duration, rating)
        {
            if (rating != "thumb up" || rating != "thumb down")
            {
                throw new ArgumentOutOfRangeException("rating for Track must be thumb up or thumb down");
            }
        }
    }
}
