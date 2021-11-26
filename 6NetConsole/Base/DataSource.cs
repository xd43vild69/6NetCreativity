using Newtonsoft.Json;

namespace NetConsole;

public class DataSource
{
    public List<string> ReadData()
    {
        List<string>? listTopics;
        using (StreamReader r = new StreamReader("JsonFiles/Theme.json"))
        {
            string json = r.ReadToEnd();
            listTopics = JsonConvert.DeserializeObject<List<string>>(json);
        }
        return listTopics ?? new List<string>();
    }
}