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
        }

        public override string ToString()
        {
            return $"{Title} from the album {Album}, created by {Creator} in {Year}, Duration: {Duration} mins, Rating: {Rating}/5";
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
        
        public string ToCsv()
        {
            return $"Track,{Title},,{Creator},{Album},{Year},,,{Duration},{Rating}";
        }
    }
}




