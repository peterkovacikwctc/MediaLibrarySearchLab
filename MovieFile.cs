using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NLog.Web;

namespace MediaLibrary
{
    public class MovieFile {

        public string filePath { get; set; }
        public List<Movie> Movies { get; set; }
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();

        public MovieFile(string movieFilePath) {

        }

        public bool isUniqueTitle(string title)
        {
            return true;
        }

        public void AddMovie(Movie movie)
        {
            try
            {
                // // first generate movie id
                // movie.movieId = Movies.Max(m => m.movieId) + 1;
                // StreamWriter sw = new StreamWriter(filePath, true);
                // sw.WriteLine($"{movie.movieId},{movie.title},{string.Join("|", movie.genres)}");
                // sw.Close();
                // // add movie details to Lists
                // Movies.Add(movie);
                // // log transaction
                // logger.Info("Movie id {Id} added", movie.movieId);
            } 
            catch(Exception ex)
            {
                logger.Error(ex.Message);
            }
        }
    }
}



