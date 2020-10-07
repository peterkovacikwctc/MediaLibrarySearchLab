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
            filePath = movieFilePath;
            Movies = new List<Movie>();

            try {
                StreamReader sr = new StreamReader(filePath);
                while (!sr.EndOfStream)
                {
                    Movie movie = new Movie();
                    string line = sr.ReadLine();
                    string[] infoArray = line.Split(',');

                    
                    movie.mediaId = UInt64.Parse(infoArray[0]);
                    // title (everything between first comma and third to last comma)
                    string title = ""; 
                    for (int i = 1; i < (infoArray.Length - 3); i++) {
                        // reinsert any missing commas into title
                        if (i != (infoArray.Length - 4)) 
                            title += infoArray[i] + ",";
                        else
                            title += infoArray[i]; // no extra comma to the end of the title
                    }
                    movie.title = title;
                    movie.genres = infoArray[(infoArray.Length - 3)].Split('|').ToList();
                    movie.director = infoArray[(infoArray.Length - 2)];
                    movie.runningTime = TimeSpan.Parse(infoArray[(infoArray.Length - 1)]);

                    Movies.Add(movie);
                }
                sr.Close();
                logger.Info("Movies in file {Count}", Movies.Count);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }

        public bool isUniqueTitle(string title)
        {
             if (Movies.ConvertAll(m => m.title.ToLower()).Contains(title.ToLower()))
            {
                logger.Info("Duplicate movie title {Title}", title);
                return false;
            }
            return true;
        }

        public void AddMovie(Movie movie)
        {
            try
            {
                movie.mediaId = Movies.Max(m => m.mediaId) + 1;
                StreamWriter sw = new StreamWriter(filePath, true);
                sw.WriteLine($"{movie.mediaId},{movie.title},{string.Join("|", movie.genres)},{movie.director},{movie.runningTime}");
                sw.Close();
                // add movie details to Lists
                Movies.Add(movie);
                // log transaction
                logger.Info("Movie id {Id} added", movie.mediaId);
            } 
            catch(Exception ex)
            {
                logger.Error(ex.Message);
            }
        }
    }
}



