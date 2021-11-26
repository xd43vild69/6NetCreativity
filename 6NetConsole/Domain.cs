namespace NetConsole;
public class Domain
{

    public Level? LevelDomain { get; set; }
    public int LevelId { get; set; }

    public Domain(int levelId)
    {
        LevelId = levelId;
    }

    public void ManagerDomain(){ 
        Console.WriteLine("Manager Domain!");
        LoadDataConfiguration();
        InitLevel();
        ShowData();
    }

    public async Task LoadDataConfiguration()
    {
        Console.WriteLine("Load Data!");        
    }

    private async Task InitLevel()
    {
        Console.WriteLine("InitLevel!");        
        LevelDomain = new Level(LevelId);
        await LevelDomain.SelectLevel();
    }

    private void ShowData(){ 
        Console.WriteLine("Show Data!");        
    }
}

