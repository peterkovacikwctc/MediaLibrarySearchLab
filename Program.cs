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
            string movieFilePath = Directory.GetCurrentDirectory() + "\\movies.scrubbed.csv";

            logger.Info("Program started");

           

            // string scrubbedFile = FileScrubber.ScrubMovies("movies.csv");
            // logger.Info(scrubbedFile);


            logger.Info("Program ended");
        }
    }
}
