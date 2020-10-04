using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NLog.Web;

namespace MediaLibrary
{
    public class MovieManager {

        public string enterTitle() {
            // ask user for name of title
            Console.WriteLine("Enter the title of the movie: ");
            string title = Console.ReadLine();
            return title;
        }

        public List<string> enterGenres() {
            // ask user for genres
            Console.WriteLine("Enter the genre of the movie: ");
            string input = Console.ReadLine();
            List<string> genres = new List<string>();

            if (input.Length == 0) {
                genres.Add("(no genres listed)");
            }
            else {
                genres.Add(input);
                // add additional genres
                string addGenre;
                do {
                    Console.WriteLine("\nWould you like to add another movie genre?");
                    Console.WriteLine("1) yes");
                    Console.WriteLine("2) no");
                    addGenre = Console.ReadLine();

                    if (addGenre == "1") {
                        // ask user for additional genres
                        Console.WriteLine("Enter the next genre of the movie: ");
                        input = Console.ReadLine();
                        genres.Add(input);
                    }
                } while (addGenre == "1");
            }
            return genres;
        }
    }
}