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
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Title cannot be null or empty");
                }
                title = value;
            }
        }

        public string Creator
        {
            get => creator;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Creator cannot be null or empty");
                }
                creator = value;
            }
        }

        public int Year
        {
            get => year;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Year cannot be negative");
                }
                year = value;
            }
        }

        public double Duration
        {
            get => duration;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Duration cannot be negative");
                }
                duration = value;
            }
        }

        public T Rating
        {
            get => rating;
            set 
            { 
                if (typeof(T) == typeof(double))
                {
                    double doubleValue = Convert.ToDouble(value);
                    if (doubleValue < 0 || doubleValue > 5)
                    {
                        throw new ArgumentOutOfRangeException("Rating for Track must be between 0 and 5");
                    }
                }
                else if (typeof(T) == typeof(int))
                {
                    int intValue = Convert.ToInt32(value);
                    if (intValue < 0 || intValue > 10)
                    {
                        throw new ArgumentOutOfRangeException("Rating for TV Episode must be between 0 and 10");
                    }
                }
                else if (typeof(T) == typeof(bool))
                {
                    //I don't know what validation to do here
                }
    
                rating = value; 
}
    }
}

