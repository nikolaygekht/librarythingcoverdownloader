using System.Text.Json.Serialization;

namespace LibraryThingCoverDownloader
{
    public class Author
    {
        [JsonPropertyName("lf")]
        public string? Name { get; set; }
        [JsonPropertyName("role")]
        public string? Role { get; set; }
    }
}
