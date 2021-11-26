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
        List<string> topics1 =  await LoadDataConfiguration();

        string selectedTopic = SelectElement(topics1);

        InitLevel(1);
        ShowData();
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

    private async Task InitLevel(int levelId)
    {
        Console.WriteLine("InitLevel!");
        LevelDomain = new Level();
        await LevelDomain.SelectLevel(1);
    }

    private void ShowData()
    {
        Console.WriteLine("Show Data!");
    }
}

