namespace NetConsole;
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

    public Level(int levelId)
    {
        LevelId = levelId;
    }

    public async Task SelectLevel()
    {
        Console.WriteLine($"Select Level: {LevelId}!");
    }
}