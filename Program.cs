using System;
using NLog.Web;
using System.IO;

namespace MediaLibrary
{
    class Program
    {
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
        static void Main(string[] args)
        {
            logger.Info("Program started");

            // create list of movies
            string movieFilePath = Directory.GetCurrentDirectory() + "\\movies.scrubbed.csv";
            MovieFile movieFile = new MovieFile(movieFilePath);

            

            logger.Info("Program ended");
        }
    }
}

// string scrubbedFile = FileScrubber.ScrubMovies("movies.csv");
// logger.Info(scrubbedFile);

