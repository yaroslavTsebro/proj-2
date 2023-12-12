using Newtonsoft.Json;

namespace Practice_Linq
{
    public class Program
    {
        static void Main(string[] args)
        {

            string path = @"../../../data/results_2010.json";

            List<FootballGame> games = ReadFromFileJson(path);

            int test_count = games.Count();
            Console.WriteLine($"Test value = {test_count}.");    // 13049

            Query1(games);
            Query2(games);
            Query3(games);
            Query4(games);
            Query5(games);
            Query6(games);
            Query7(games);
            Query8(games);
            Query9(games);
            Query10(games);

        }


        // Десеріалізація json-файлу у колекцію List<FootballGame>
        static List<FootballGame> ReadFromFileJson(string path)
        {

            var reader = new StreamReader(path);
            string jsondata = reader.ReadToEnd();

            List<FootballGame> games = JsonConvert.DeserializeObject<List<FootballGame>>(jsondata);


            return games;

        }


        // Запит 1
        static void Query1(List<FootballGame> games)
        {
            var selectedGames = games.Where(g => g.Country == "Ukraine" && g.Date.Year == 2012);

            Console.WriteLine("\n======================== QUERY 1 ========================");
            foreach (var game in selectedGames)
            {
                Console.WriteLine($"{game.Date.ToString("dd.MM.yyyy")} - {game.Home_team} vs {game.Away_team} ({game.Home_score}:{game.Away_score})");
            }
        }


        // Запит 2
        static void Query2(List<FootballGame> games)
        {
            var selectedGames = games.Where(g => (g.Home_team == "Italy" || g.Away_team == "Italy") && g.Tournament == "Friendly" && g.Date.Year >= 2020);

            Console.WriteLine("\n======================== QUERY 2 ========================");
            foreach (var game in selectedGames)
            {
                Console.WriteLine($"{game.Date.ToString("dd.MM.yyyy")} - {game.Home_team} vs {game.Away_team} ({game.Home_score}:{game.Away_score})");
            }
        }


        // Запит 3
        static void Query3(List<FootballGame> games)
        {
            var selectedGames = games.Where(g => g.Home_team == "France" && g.Date.Year == 2021 && g.Home_score == g.Away_score);

            Console.WriteLine("\n======================== QUERY 3 ========================");
            foreach (var game in selectedGames)
            {
                Console.WriteLine($"{game.Date.ToString("dd.MM.yyyy")} - {game.Home_team} vs {game.Away_team} ({game.Home_score}:{game.Away_score})");
            }
        }


        // Запит 4
        static void Query4(List<FootballGame> games)
        {
            var selectedGames = games.Where(g => g.Away_team == "Germany" && g.Date.Year >= 2018 && g.Date.Year <= 2020 && g.Home_score > g.Away_score);

            Console.WriteLine("\n======================== QUERY 4 ========================");
            foreach (var game in selectedGames)
            {
                Console.WriteLine($"{game.Date.ToString("dd.MM.yyyy")} - {game.Home_team} vs {game.Away_team} ({game.Home_score}:{game.Away_score})");
            }
        }

        // Запит 5
        static void Query5(List<FootballGame> games)
        {
            var selectedGames = games.Where(g => g.Tournament == "UEFA Euro qualification" &&
                                                 (g.City == "Kyiv" || g.City == "Kharkiv") &&
                                                 ((g.Home_team == "Ukraine" && g.Home_score > g.Away_score) ||
                                                  (g.Away_team == "Ukraine" && g.Away_score > g.Home_score)));

            Console.WriteLine("\n======================== QUERY 5 ========================");
            foreach (var game in selectedGames)
            {
                Console.WriteLine($"{game.Date.ToString("dd.MM.yyyy")} - {game.Home_team} vs {game.Away_team} ({game.Home_score}:{game.Away_score})");
            }
        }


        // Запит 6
        static void Query6(List<FootballGame> games)
        {
            var worldCupGames = games.Where(g => g.Tournament == "FIFA World Cup" && g.Date.Year == 2022);
            var selectedGames = worldCupGames.OrderByDescending(g => g.Date).Take(8);

            Console.WriteLine("\n======================== QUERY 6 ========================");
            foreach (var game in selectedGames)
            {
                Console.WriteLine($"{game.Date.ToString("dd.MM.yyyy")} - {game.Home_team} vs {game.Away_team} ({game.Home_score}:{game.Away_score})");
            }
        }


        // Запит 7
        static void Query7(List<FootballGame> games)
        {
            var firstWinGame = games.FirstOrDefault(g => g.Date.Year == 2023 &&
                                                         ((g.Home_team == "Ukraine" && g.Home_score > g.Away_score) ||
                                                          (g.Away_team == "Ukraine" && g.Away_score > g.Home_score)));

            Console.WriteLine("\n======================== QUERY 7 ========================");
            if (firstWinGame != null)
            {
                Console.WriteLine($"{firstWinGame.Date.ToString("dd.MM.yyyy")} - {firstWinGame.Home_team} vs {firstWinGame.Away_team} ({firstWinGame.Home_score}:{firstWinGame.Away_score})");
            }
        }


        // Запит 8
        static void Query8(List<FootballGame> games)
        {
            var selectedGames = games.Where(g => g.Tournament == "UEFA Euro" &&
                                                 g.Date.Year == 2012 &&
                                                 g.Country == "Ukraine")
                                     .Select(g => new
                                     {
                                         MatchYear = g.Date.Year,
                                         Team1 = g.Home_team,
                                         Team2 = g.Away_team,
                                         Goals = g.Home_score + g.Away_score
                                     });

            Console.WriteLine("\n======================== QUERY 8 ========================");
            foreach (var game in selectedGames)
            {
                Console.WriteLine($"Year: {game.MatchYear}, Teams: {game.Team1} vs {game.Team2}, Goals: {game.Goals}");
            }
        }



        // Запит 9
        static void Query9(List<FootballGame> games)
        {
            var selectedGames = games.Where(g => g.Tournament == "UEFA Nations League" && g.Date.Year == 2023)
                                     .Select(g => new
                                     {
                                         MatchYear = g.Date.Year,
                                         Game = $"{g.Home_team} - {g.Away_team}",
                                         Result = g.Home_score > g.Away_score ? "Win" :
                                                  g.Home_score < g.Away_score ? "Loss" : "Draw"
                                     });

            Console.WriteLine("\n======================== QUERY 9 ========================");
            foreach (var game in selectedGames)
            {
                Console.WriteLine($"Year: {game.MatchYear}, Game: {game.Game}, Result: {game.Result}");
            }
        }


        // Запит 10
        static void Query10(List<FootballGame> games)
        {
            var selectedGames = games.Where(g => g.Tournament == "Gold Cup" &&
                                                 g.Date.Year == 2023 &&
                                                 g.Date.Month == 7)
                                     .Skip(4).Take(6);

            Console.WriteLine("\n======================== QUERY 10 ========================");
            foreach (var game in selectedGames)
            {
                Console.WriteLine($"{game.Date.ToString("dd.MM.yyyy")} - {game.Home_team} vs {game.Away_team} ({game.Home_score}:{game.Away_score})");
            }
        }


    }
}