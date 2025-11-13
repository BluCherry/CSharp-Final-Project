using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermediate_CSharp_Final
{
    public abstract class Media<T>
    {
        private string title;
        private string creator;
        private int year;
        private double duration;
        private T rating;

        public Media(string title, string creator, int year, double duration, T rating)
        {
            Title = title;
            Creator = creator;
            Year = year;
            Duration = duration;
            Rating = rating;
        }

        public string Title
        {
            get => title;
            set { title = value; }
        }

        public string Creator
        {
            get => creator;
            set { creator = value; }
        }

        public int Year
        {
            get => year;
            set { year = value; }
        }

        public double Duration
        {
            get => duration;
            set { duration = value; }
        }

        public T Rating
        {
            get => rating;
            set { rating = value; }
        }
    }
}
