namespace NetConsole;

internal delegate void RunLevel();

public enum Levels
{
    Level1 = 1, 
    Level2 = 2, 
    Level3 = 3
}

public class Level
{
    #region properties     
    public Levels LevelId { get; set; }
    public List<string>? BodyParts { get; set; } = new List<string>();
    public List<string> SoundTrack { get; set; } = new List<string>();
    public List<string>? CompositionElements { get; set; } = new List<string>();
    public List<string>? HighReferenceArtist { get; set; } = new List<string>();
    public List<string>? LowReferenceArtist { get; set; } = new List<string>();
    public List<string>? Materials { get; set; } = new List<string>();
    public List<string>? ConflictVerbs { get; set; } = new List<string>();
    public List<string>? Themes { get; set; } = new List<string>();
    public List<Quote>? Quotes { get; set; } = new List<Quote>();
    private DataSource DataSource { get; set; } = new DataSource();
    #endregion
    public Level(Levels levelId)
    {
        LevelId = levelId;
        SelectLevel();
    }
    private List<string> LoadByLevel(string topic, int quantity)
    {
        List<string>? topicsTmp = LoadDataConfiguration(topic).ToList();
        List<string> topics = new List<string>();

        if (topicsTmp == null) return new List<string>();

        for (var i = 0; i < quantity; i++)
        {
            topics.Add(SelectElement(topicsTmp));
        }

        return topics;
    }

    private IEnumerable<string> LoadDataConfiguration(string topic)
    {
        List<string>? data = DataSource.ReadData(topic).ToList();
        return data ?? new List<string>();
    }

    private string SelectElement(List<string> elements)
    {
        Random rand = new Random();
        int selectedIndex = rand.Next(elements.Count);
        return elements[selectedIndex];
    }

    private void SetLevel1()
    {
        LevelId = Levels.Level1;
        List<Task<string>> tasks = new List<Task<string>>();
        SoundTrack = LoadByLevel("SoundTrack", 1);
        CompositionElements = LoadByLevel("CompositionElements", 1);
        Themes = LoadByLevel("Themes", 1);
    }

    private void SetLevel2()
    {
        LevelId = Levels.Level2;
        SoundTrack = LoadByLevel("SoundTrack", 1);
        CompositionElements = LoadByLevel("CompositionElements", 2);
        Themes = LoadByLevel("Themes", 2);
        HighReferenceArtist = LoadByLevel("HighReferenceArtist", 2);
    }

    private void SetLevel3()
    {
        LevelId = Levels.Level3;
        SoundTrack = LoadByLevel("SoundTrack", 1);
        CompositionElements = LoadByLevel("CompositionElements", 3);
        Themes = LoadByLevel("Themes", 3);
        HighReferenceArtist = LoadByLevel("HighReferenceArtist", 3);
        ConflictVerbs = LoadByLevel("ConflictVerbs", 3);
    }

    private void SelectLevel()
    {
        var runLevel = LevelId switch{ 
            Levels.Level1 => new RunLevel(SetLevel1),
            Levels.Level2 => new RunLevel(SetLevel2),
            Levels.Level3 => new RunLevel(SetLevel3),
            _ => throw new ArgumentOutOfRangeException(nameof(LevelId)),
        };

        runLevel();
    }
}