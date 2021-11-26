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

    public async Task ManagerDomain(int levelId)
    {        
        InitLevel(levelId);
        ShowLevelData();
    }

    private void InitLevel(int levelId)
    {
        LevelDomain = new Level(levelId);
    }

    private void ShowLevelData()
    {

        foreach (var item in LevelDomain.SoundTrack)
        {
            System.Console.WriteLine($"Soundtracks: {item}");
        }

        foreach (var item in LevelDomain.CompositionElements)
        {
            System.Console.WriteLine($"Composition Elements: {item}");
        }

        foreach (var item in LevelDomain.Themes)
        {
            System.Console.WriteLine($"Theme: {item}");
        }
    }
}

