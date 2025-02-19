using System.Text.Json.Serialization;

namespace LibraryThingCoverDownloader
{
    public class LibraryOfCongressCard
    {
        [JsonPropertyName("code")]
        public string? Code { get; set; }
    }
}
