using System.Text.Json;

namespace LibraryThingCoverDownloader;

public static class LibraryThingExportJsonLoader
{
    static public Book[]? LoadBooks(string jsonFile)
    {
        var file = File.ReadAllText(jsonFile)
            .Replace("\"authors\": [[]]", "\"authors\": []")
            .Replace("\"lcc\": []", "\"lcc\": {}");
        return JsonSerializer.Deserialize<Dictionary<string, Book>>(file)?.Values.ToArray();
    }
}
