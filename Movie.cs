using System;
using System.Collections.Generic;

namespace MediaLibrary
{
    public class Movie : Media
    {
        public string director { get; set; }
        public TimeSpan runningTime { get; set; }

        public override string Display()
        {
            return $"Id: {mediaId}\nTitle: {title}\nGenres: {string.Join(", ", genres)}\nDirector: {director}\nRun time: {runningTime}\n";
        }
    }
}