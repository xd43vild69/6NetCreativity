namespace NetConsole;

internal delegate void RunLevel();

public class Level
{
    public int LevelId { get; set; }
    public List<string>? BodyParts { get; set; }
    public List<string>? SoundTrack { get; set; }
    public List<string>? CompositionElements { get; set; }
    public List<string>? HighReferenceArtist { get; set; }
    public List<string>? LowReferenceArtist { get; set; }
    public List<string>? Materials { get; set; }
    public List<string>? ConflictVerbs { get; set; }
    public List<string>? Themes { get; set; }
    public List<Quote>? Quotes { get; set; }
    private DataSource? DataSource { get; set; }

    public Level(int levelId)
    {
        LevelId = levelId;
        DataSource = new DataSource();
        SelectLevel();
    }
    private List<string> LoadByLevel(string topic, int quantity)
    {
        List<string> topicsTmp = LoadDataConfiguration(topic);
        List<string> topics = new List<string>();
        //Filter by element quantities

        for (var i = 0; i < quantity; i++)
        {
            topics.Add(SelectElement(topicsTmp));
        }

        return topics;
    }

    private List<string> LoadDataConfiguration(string topic)
    {
        return DataSource.ReadData(topic);
    }

    private string SelectElement(List<string> elements)
    {
        Random rand = new Random();
        int selectedIndex = rand.Next(elements.Count);
        return elements[selectedIndex];
    }

    private void SetLevel1()
    {
        LevelId = 1;
        SoundTrack = LoadByLevel("SoundTrack", 1);
        CompositionElements = LoadByLevel("CompositionElements", 1);
        Themes = LoadByLevel("Themes", 1);
    }

    private void SetLevel2()
    {
        LevelId = 2;
        SoundTrack = LoadByLevel("SoundTrack", 1);
        CompositionElements = LoadByLevel("CompositionElements", 2);
        Themes = LoadByLevel("Themes", 2);
        HighReferenceArtist = LoadByLevel("HighReferenceArtist", 2);
    }

    private void SetLevel3()
    {
        LevelId = 3;
        SoundTrack = LoadByLevel("SoundTrack", 1);
        CompositionElements = LoadByLevel("CompositionElements", 3);
        Themes = LoadByLevel("Themes", 3);
        HighReferenceArtist = LoadByLevel("HighReferenceArtist", 3);
        ConflictVerbs = LoadByLevel("ConflictVerbs", 3);
    }

    private void SelectLevel()
    {
        RunLevel runLevel = new RunLevel(SetLevel1);

        switch (LevelId)
        {
            case 1:
                runLevel = new RunLevel(SetLevel1);
                break;
            case 2:
                runLevel = new RunLevel(SetLevel2);
                break;
            case 3:
                runLevel = new RunLevel(SetLevel3);
                break;
            default:
                break;
        }

        runLevel();
    }
}