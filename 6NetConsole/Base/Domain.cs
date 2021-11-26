using System.Collections.Generic;
namespace NetConsole;

public class Domain
{

    public Level? LevelDomain { get; set; }
    private DataSource? DataSource { get; set; } 

    public Domain()
    {
        DataSource = new DataSource();
    }

    public async Task ManagerDomain()
    {
        Console.WriteLine("Manager Domain!");
        InitLevel(1);
        ShowLevelData();
    }

    private async Task<List<string>> LoadDataConfiguration()
    {
        Console.WriteLine("Load Data!");
        return DataSource.ReadData("theme");        
    }

    private string SelectElement(List<string> elements){
        Random rand = new Random();
        int selectedIndex = rand.Next(elements.Count);
        System.Console.WriteLine($"Topic: {elements[selectedIndex]}");
        return elements[selectedIndex];
    }

    private void InitLevel(int levelId)
    {
        LevelDomain = new Level(levelId);
    }

    private void ShowLevelData()
    {
        Console.WriteLine("Show Data!");

        foreach (var item in LevelDomain.SoundTrack)
        {
            System.Console.WriteLine($"Soundtracks: {item}");
        }
    }
}

