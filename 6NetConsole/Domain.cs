namespace NetConsole;
public class Domain
{

    public Level? LevelDomain { get; set; }
    public int LevelId { get; set; }

    public Domain(int levelId)
    {
        LevelId = levelId;
    }

    public async Task LoadDataConfiguration()
    {
        Console.WriteLine("Load Data!");
        await InitLevel();
    }

    private async Task InitLevel()
    {
        LevelDomain = new Level(LevelId);
        await LevelDomain.SelectLevel();
    }
}

