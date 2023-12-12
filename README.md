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
