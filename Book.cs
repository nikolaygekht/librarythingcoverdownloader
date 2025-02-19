using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LibraryThingCoverDownloader
{
    public class Book
    {
        [JsonPropertyName("books_id")]
        public string BookId { get; set; } = "";      
        [JsonPropertyName("title")]
        public string? BookTitle { get; set; }
        [JsonPropertyName("authors")]
        public Author?[]? Authors { get; set; }
        [JsonPropertyName("collections_idA")]
        public int[]? CollectionIds { get; set; }
        [JsonPropertyName("collections")]
        public string[]? Collections { get; set; }
        [JsonPropertyName("asin")]
        public string? Asin { get; set; }
        [JsonPropertyName("originalisbn")]
        public string? OriginalISBN { get; set; }
        [JsonPropertyName("lcc")]
        public LibraryOfCongressCard? LibraryOfCongress { get; set; }
        [JsonPropertyName("publication")]
        public string? Publication { get; set; }
        [JsonPropertyName("date")]
        public string? Date { get; set; }
        [JsonPropertyName("language")]
        public string[]? Languages { get; set; }
        [JsonPropertyName("language_codeA")]
        public string[]? LanguageCodes { get; set; }
        [JsonPropertyName("volumes")]
        public string? Volumes { get; set; }
    }
}
