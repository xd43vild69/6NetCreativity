using System.Collections.Generic;
namespace NetConsole;

public class Domain
{

    public Level? LevelDomain { get; set; }
    public int LevelId { get; set; }
    private DataSource? DataSource { get; set; } 

    public Domain(int levelId)
    {
        LevelId = levelId;
        DataSource = new DataSource();
    }

    public void ManagerDomain()
    {
        Console.WriteLine("Manager Domain!");
        LoadDataConfiguration();
        InitLevel();
        ShowData();
    }

    private async Task LoadDataConfiguration()
    {
        Console.WriteLine("Load Data!");
        List<string> topics1 = DataSource.ReadData();
    }

    private async Task InitLevel()
    {
        Console.WriteLine("InitLevel!");
        LevelDomain = new Level(LevelId);
        await LevelDomain.SelectLevel();
    }

    private void ShowData()
    {
        Console.WriteLine("Show Data!");
    }
}

