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
            string file = "movies.scrubbed.csv";

            // check if file exists
            if(!File.Exists(file)) {
                logger.Info("The file " + file + " does not exist.");
            }
            else {
                string choice;
                do {
                    Console.WriteLine("Enter 1 to add movie.");
                    Console.WriteLine("Enter 2 to display all movies.");
                    Console.WriteLine("Enter anything else to quit.");
                    choice = Console.ReadLine();

                    if (choice == "1") {
                        try {
                            Movie movie = new Movie();
                            MovieManager movieManager = new MovieManager();

                            // ask user for name of title
                            movie.title = movieManager.enterTitle();

                            // check to see if the same movie exists in library
                            Boolean isUnique = movieFile.isUniqueTitle(movie.title);

                            if (isUnique) {
                                // movie.mediaId is calculated in movieFile.AddMovie(movie);
                                movie.genres = movieManager.enterGenres();
                                movie.director = movieManager.enterDirector();
                                movie.runningTime = movieManager.enterRunningTime();
                                movieFile.AddMovie(movie);
                            }

                        }
                        catch (Exception e) {
                            logger.Error(e.Message);
                        }
                    }
                    // display movies
                    else if (choice == "2") {
                        try {
                             // Display All Movies
                            foreach(Movie m in movieFile.Movies)
                            {
                                Console.WriteLine(m.Display());
                            }
                        }
                        catch (Exception e) {
                            logger.Error(e.Message);
                        }
                    }
                } while (choice == "1" || choice == "2");
            }

            logger.Info("Program ended");
        }
    }
}

// string scrubbedFile = FileScrubber.ScrubMovies("movies.csv");
// logger.Info(scrubbedFile);

