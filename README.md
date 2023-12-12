# Проєкт Аналізу Футбольних Ігор

Цей проєкт використовує LINQ для аналізу даних про футбольні ігри, збережених у форматі JSON. Програма включає десять запитів, які витягують різноманітну інформацію з файлу даних.

## Запити і Код

### 1. Query1: Вибір ігор, які відбулися в Україні в 2012 році
```csharp
static void Query1(List<FootballGame> games)
{
    var selectedGames = games.Where(g => g.Country == "Ukraine" && g.Date.Year == 2012);

    Console.WriteLine("\n======================== QUERY 1 ========================");
    foreach (var game in selectedGames)
    {
        Console.WriteLine($"{game.Date.ToString("dd.MM.yyyy")} - {game.Home_team} vs {game.Away_team} ({game.Home_score}:{game.Away_score})");
    }
}
```

### 2. Query2: Вибір товариських ігор з участю Італії з 2020 року
```csharp
static void Query2(List<FootballGame> games)
{
    var selectedGames = games.Where(g => (g.Home_team == "Italy" || g.Away_team == "Italy") && g.Tournament == "Friendly" && g.Date.Year >= 2020);

    Console.WriteLine("\n======================== QUERY 2 ========================");
    foreach (var game in selectedGames)
    {
        Console.WriteLine($"{game.Date.ToString("dd.MM.yyyy")} - {game.Home_team} vs {game.Away_team} ({game.Home_score}:{game.Away_score})");
    }
}
```

### 3. Query3: Вибір ігор, де збірна Франції грала вдома в 2021 році і матч закінчився нічиєю
```csharp
static void Query3(List<FootballGame> games)
{
    var selectedGames = games.Where(g => g.Home_team == "France" && g.Date.Year == 2021 && g.Home_score == g.Away_score);

    Console.WriteLine("\n======================== QUERY 3 ========================");
    foreach (var game in selectedGames)
    {
        Console.WriteLine($"{game.Date.ToString("dd.MM.yyyy")} - {game.Home_team} vs {game.Away_team} ({game.Home_score}:{game.Away_score})");
    }
}
```

### 4.Query4: Вибір ігор, де збірна Німеччини грала в гостях між 2018 і 2020 роками і програла
```csharp
static void Query4(List<FootballGame> games)
{
    var selectedGames = games.Where(g => g.Away_team == "Germany" && g.Date.Year >= 2018 && g.Date.Year <= 2020 && g.Home_score > g.Away_score);

    Console.WriteLine("\n======================== QUERY 4 ========================");
    foreach (var game in selectedGames)
    {
        Console.WriteLine($"{game.Date.ToString("dd.MM.yyyy")} - {game.Home_team} vs {game.Away_team} ({game.Home_score}:{game.Away_score})");
    }
}
```

### 5. Query5: Вибір ігор кваліфікації Євро, які відбулися в Києві або Харкові, де Україна перемогла
```csharp
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
```

### 6. Query6: Останні 8 ігор Чемпіонату світу FIFA 2022
```csharp
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
```

### 7. Query7: Перша перемога України в 2023 році
```csharp
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
```

### 8. Query8: Ігри Євро 2012, що відбулися в Україні
```csharp
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
```
### 9. Query9: Ігри Ліги Націй УЄФА 2023
```csharp
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
```
### 10. Query10: Ігри Gold Cup 2023, починаючи з п'ятої ігри і включаючи наступні шість
```csharp
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
```
