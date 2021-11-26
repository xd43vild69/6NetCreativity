using Newtonsoft.Json;

namespace NetConsole;

public class DataSource
{
    public List<string> ReadData(string topic)
    {
        List<string>? listTopics;
        using (StreamReader r = new StreamReader($"JsonFiles/{topic}.json"))
        {
            string json = r.ReadToEnd();
            listTopics = JsonConvert.DeserializeObject<List<string>>(json);
        }
        return listTopics ?? new List<string>();
    }
}