using System;
using System.Collections.Generic;
using System.Linq;

namespace NinetiesTV
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Show> shows = DataLoader.GetShows();

            Print("All Names", Names(shows));
            Print("Alphabetical Names", NamesAlphabetically(shows));
            Print("Ordered by Popularity", ShowsByPopularity(shows));
            Print("Shows with an '&'", ShowsWithAmpersand(shows));
            // Print("Latest year a show aired", MostRecentYear(shows));
            // Print("Average Rating", AverageRating(shows));
            // Print("Shows only aired in the 90s", OnlyInNineties(shows));
            // Print("Top Three Shows", TopThreeByRating(shows));
            // Print("Shows starting with 'The'", TheShows(shows));
            // Print("All But the Worst", AllButWorst(shows));
            // Print("Shows with Few Episodes", FewEpisodes(shows));
            // Print("Shows Sorted By Duration", ShowsByDuration(shows));
            // Print("Comedies Sorted By Rating", ComediesByRating(shows));
            // Print("More Than One Genre, Sorted by Start", WithMultipleGenresByStartYear(shows));
            // Print("Most Episodes", MostEpisodes(shows));
            // Print("Ended after 2000", EndedFirstAfterTheMillennium(shows));
            // Print("Best Drama", BestDrama(shows));
            // Print("All But Best Drama", AllButBestDrama(shows));
            // Print("Good Crime Shows", GoodCrimeShows(shows));
            // Print("Long-running, Top-rated", FirstLongRunningTopRated(shows));
            // Print("Most Words in Title", WordieastName(shows));
            // Print("All Names", AllNamesWithCommas(shows));
            // Print("All Names with And", AllNamesWithCommasPlsAnd(shows));
            // Challenges
            // GenresOfShowsInThe80s(shows);
            Print("The genres of the shows that started in the 80s", GenresOfShowsInThe80s(shows));
            Print("Shows By Year", PrintShowsForEachYear(shows));
            // PrintShowsForEachYear(shows);
            Print("Time it would take to watch every show, every episode", DurationOfEveryShow(shows));
            // DurationOfEveryShow(shows);
            Print("Year with the highest total ratings", YearWithHighestRating(shows));
            // YearWithHighestRating(shows);
        }

        /**************************************************************************************************
         The Exercises

         Above each method listed below, you'll find a comment that describes what the method should do.
         Your task is to write the appropriate LINQ code to make each method return the correct result.

        **************************************************************************************************/

        // 1. Return a list of each of show names.
        static List<string> Names(List<Show> shows)
        {
            return shows.Select(s => s.Name).ToList(); // Looks like this one's already done!
        }

        // 2. Return a list of show names ordered alphabetically.
        static List<string> NamesAlphabetically(List<Show> shows)
        {
            return shows.OrderBy(show => show.Name).Select(s => s.Name).ToList();
        }

        // 3. Return a list of shows ordered by their IMDB Rating with the highest rated show first.
        static List<Show> ShowsByPopularity(List<Show> shows)
        {
            return shows.OrderByDescending(show => show.ImdbRating).ToList();
        }

        // 4. Return a list of shows whose title contains an & character.
        static List<Show> ShowsWithAmpersand(List<Show> shows)
        {
            return shows.Where(show => show.Name.Contains('&')).ToList();
        }

        // 5. Return the most recent year that any of the shows aired.
        static int MostRecentYear(List<Show> shows)
        {
            return shows.OrderByDescending(show => show.EndYear).First().EndYear;
        }

        // 6. Return the average IMDB rating for all the shows.
        static double AverageRating(List<Show> shows)
        {
            return shows.Select(show => show.ImdbRating).Sum() / shows.Count;
        }

        // 7. Return the shows that started and ended in the 90s.
        static List<Show> OnlyInNineties(List<Show> shows)
        {
            return shows.Where(show => show.StartYear >= 1990 && show.EndYear <= 1999).ToList();
        }

        // 8. Return the top three highest rated shows.
        static List<Show> TopThreeByRating(List<Show> shows)
        {
            return shows.OrderByDescending(show => show.ImdbRating).Take(3).ToList();
        }

        // 9. Return the shows whose name starts with the word "The".
        static List<Show> TheShows(List<Show> shows)
        {
            return shows.Where(show => show.Name.StartsWith("The")).ToList();
        }

        // 10. Return all shows except for the lowest rated show.
        static List<Show> AllButWorst(List<Show> shows)
        {
            return shows.OrderBy(show => show.ImdbRating).Skip(1).ToList();
        }

        // 11. Return the names of the shows that had fewer than 100 episodes.
        static List<string> FewEpisodes(List<Show> shows)
        {
            return shows.Where(show => show.EpisodeCount < 100).Select(s => s.Name).ToList();
        }

        // 12. Return all shows ordered by the number of years on air.
        //     Assume the number of years between the start and end years is the number of years the show was on.
        static List<Show> ShowsByDuration(List<Show> shows)
        {
            return shows.OrderBy(show => show.EndYear - show.StartYear).ToList();
        }

        // 13. Return the names of the comedy shows sorted by IMDB rating.
        static List<string> ComediesByRating(List<Show> shows)
        {
            return shows.Where(show => show.Genres.Contains("Comedy"))
                        .OrderByDescending(show => show.ImdbRating)
                        .Select(show => show.Name)
                        .ToList();
        }

        // 14. Return the shows with more than one genre ordered by their starting year.
        static List<Show> WithMultipleGenresByStartYear(List<Show> shows)
        {
            return shows.Where(show => show.Genres.Count > 1)
                        .OrderBy(show => show.StartYear)
                        .ToList();
        }

        // 15. Return the show with the most episodes.
        static Show MostEpisodes(List<Show> shows)
        {
            return shows.OrderByDescending(show => show.EpisodeCount).First();
        }

        // 16. Order the shows by their ending year then return the first 
        //     show that ended on or after the year 2000.
        static Show EndedFirstAfterTheMillennium(List<Show> shows)
        {
            return shows.OrderBy(show => show.EndYear).FirstOrDefault(shows => shows.EndYear >= 2000);
        }

        // 17. Order the shows by rating (highest first) 
        //     and return the first show with genre of drama.
        static Show BestDrama(List<Show> shows)
        {
            return shows.OrderByDescending(show => show.ImdbRating)
                        .FirstOrDefault(show => show.Genres.Contains("Drama"));
        }

        // 18. Return all dramas except for the highest rated.
        static List<Show> AllButBestDrama(List<Show> shows)
        {
            return shows.Where(show => show.Genres.Contains("Drama"))
            .OrderByDescending(show => show.ImdbRating)
            .Skip(1)
            .ToList();
        }

        // 19. Return the number of crime shows with an IMDB rating greater than 7.0.
        static int GoodCrimeShows(List<Show> shows)
        {
            return shows.Where(show => show.Genres.Contains("Crime"))
            .OrderByDescending(show => show.ImdbRating)
            .TakeWhile(show => show.ImdbRating > 7).Count();
        }

        // 20. Return the first show that ran for more than 10 years 
        //     with an IMDB rating of less than 8.0 ordered alphabetically.
        static Show FirstLongRunningTopRated(List<Show> shows)
        {
            return shows.Where(show => show.EndYear - show.StartYear > 10 && show.ImdbRating < 8)
            .OrderBy(show => show.Name).First();
        }

        // 21. Return the show with the most words in the name.
        static Show WordieastName(List<Show> shows)
        {
            return shows.OrderByDescending(show => show.Name.Length).First();
        }

        // 22. Return the names of all shows as a single string seperated by a comma and a space.
        static string AllNamesWithCommas(List<Show> shows)
        {
            return shows.Select(show => show.Name).Aggregate((a, b) => a + ", " + b);
        }

        // 23. Do the same as above, but put the word "and" between the second-to-last and last show name.
        static string AllNamesWithCommasPlsAnd(List<Show> shows)
        {
            string last = shows.Select(show => show.Name).Last();
            string rest = shows.Select(show => show.Name).Take(shows.Count - 1).Aggregate((a, b) => a + ", " + b);
            return String.Join(" and ", rest, last);
        }


        /**************************************************************************************************
         CHALLENGES

         These challenges are very difficult and may require you to research LINQ methods that we haven't
         talked about. Such as:

            GroupBy()
            SelectMany()
            Count()

        **************************************************************************************************/

        // 1. Return the genres of the shows that started in the 80s.
        // 2. Print a unique list of geners.

        static List<string> GenresOfShowsInThe80s(List<Show> shows)
        {
            return shows.Where(show => show.StartYear < 1990)
                .SelectMany(show => show.Genres, (key, value) => value)
                .Distinct()
                .ToList();
        }

        // 3. Print the years 1987 - 2018 along with the number of shows that started in each year (note many years will have zero shows)
        static List<string> PrintShowsForEachYear(List<Show> shows)
        {
            return shows.SelectMany(show => Enumerable.Range(show.StartYear, show.EndYear - show.StartYear + 1), (show, year) => new { show, year })
            .GroupBy(yearAndShow => yearAndShow.year)
            .OrderBy(group => group.Key)
            .Select(group => $"{group.Key}: {group.ToArray().Length}").ToList();
            // return shows
            //     .Where(s => s.StartYear > 1986 && < 2019)
            //     .GroupBy(s => s.StartYear).OrderBy(yg => yg.Key)
            //     .Select(yg => new { Year =yg.Key, Count = yg.Count()})
        }
        // 4. Assume each episode of a comedy is 22 minutes long and each episode of a show that isn't a comedy is 42 minutes. How long would it take to watch every episode of each show?
        static int DurationOfEveryShow(List<Show> shows)
        {
            return shows.Select(show =>
            {
                if (show.Genres.Contains("Comedy")) return show.EpisodeCount * 22;
                else return show.EpisodeCount * 42;
            }).Sum();
        }
        // 5. Assume each show ran each year between its start and end years (which isn't true), which year had the highest average IMDB rating.
        static double YearWithHighestRating(List<Show> shows)
        {
            var years = Enumerable.Range(1987, 21);

            var showsByYear = shows.SelectMany(show => Enumerable.Range(show.StartYear, show.EndYear - show.StartYear + 1), (show, year) => new { show, year })
            .GroupBy(yearAndShow => yearAndShow.year)
            .Select(showGroup => new { key = showGroup, avgRating = showGroup.Select(show => show.show.ImdbRating).Average() })
            .OrderByDescending(yearRating => yearRating.avgRating) //, yearandShow => yearandShow.show, (year, showsByYear)=> )
            .First().key.Key;

            return showsByYear;
        }


        /**************************************************************************************************
         There is no code to write or change below this line, but you might want to read it.
        **************************************************************************************************/

        static void Print(string title, List<Show> shows)
        {
            PrintHeaderText(title);
            foreach (Show show in shows)
            {
                Console.WriteLine(show);
            }

            Console.WriteLine();
        }

        static void Print(string title, List<string> strings)
        {
            PrintHeaderText(title);
            foreach (string str in strings)
            {
                Console.WriteLine(str);
            }

            Console.WriteLine();
        }

        static void Print(string title, Show show)
        {
            PrintHeaderText(title);
            Console.WriteLine(show);
            Console.WriteLine();
        }

        static void Print(string title, string str)
        {
            PrintHeaderText(title);
            Console.WriteLine(str);
            Console.WriteLine();
        }

        static void Print(string title, int number)
        {
            PrintHeaderText(title);
            Console.WriteLine(number);
            Console.WriteLine();
        }

        static void Print(string title, double number)
        {
            PrintHeaderText(title);
            Console.WriteLine(number);
            Console.WriteLine();
        }

        static void PrintHeaderText(string title)
        {
            Console.WriteLine("============================================");
            Console.WriteLine(title);
            Console.WriteLine("--------------------------------------------");
        }
    }
}