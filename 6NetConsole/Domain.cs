using Newtonsoft.Json;
using System.Collections.Generic;

namespace NetConsole;
public class Domain
{

    public Level? LevelDomain { get; set; }
    public int LevelId { get; set; }

    public Domain(int levelId)
    {
        LevelId = levelId;
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
        List<string> topics = ReadData();
    }

    private List<string> ReadData()
    {
        List<string>? listTopics;
        using (StreamReader r = new StreamReader("JsonFiles/Theme.json"))
        {
            string json = r.ReadToEnd();
             listTopics = JsonConvert.DeserializeObject<List<string>>(json);
        }
        return listTopics ?? new List<string>();
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

