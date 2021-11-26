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

    public void ManagerDomain(int levelId)
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
        if (LevelDomain?.SoundTrack != null)
        {
            foreach (var item in LevelDomain.SoundTrack)
            {
                System.Console.WriteLine($"Soundtracks: {item}");
            }
        }

        if (LevelDomain?.CompositionElements != null)
        {
            foreach (var item in LevelDomain.CompositionElements)
            {
                System.Console.WriteLine($"Composition Elements: {item}");
            }
        }

        if (LevelDomain?.Themes != null)
        {
            foreach (var item in LevelDomain.Themes)
            {
                System.Console.WriteLine($"Theme: {item}");
            }
        }
    }
}

