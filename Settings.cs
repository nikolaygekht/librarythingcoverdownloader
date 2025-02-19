using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LibraryThingCoverDownloader
{
    public class Settings
    {
        [JsonPropertyName("jsonFileName")]
        public string? JsonFileName { get; set; }

        [JsonPropertyName("imagePath")]
        public string? ImagePath { get; set; }

        [JsonPropertyName("username")]
        public string? LibraryThingUserName { get; set; }

        [JsonPropertyName("columns")]
        public int[]? Columns { get; set; }

        [JsonInclude]
        [JsonPropertyName("password")]
        public string? LibraryThingPasswordEncoded { get; private set; }

        public string? LibraryThingPassword 
        { 
            get
            {
                if (string.IsNullOrEmpty(LibraryThingPasswordEncoded))
                {
                    return string.Empty;
                }

                var bytes = Convert.FromBase64String(LibraryThingPasswordEncoded);
                Decrypt(bytes);
                return Encoding.UTF8.GetString(bytes);
            }
            set
            {
                if (value == null)
                {
                    LibraryThingPasswordEncoded = "";
                    return;
                }

                var bytes = Encoding.UTF8.GetBytes(value);
                Encrypt(bytes);
                LibraryThingPasswordEncoded = Convert.ToBase64String(bytes);
            }
        }

        private static void Encrypt(byte[] bytes)
        {
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] ^= 0x5A;
            }
        }

        private static void Decrypt(byte[] bytes)
        {
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] ^= 0x5A;
            }
        }

        public static Settings? Load()
        {
            var path = Path.Combine(AppContext.BaseDirectory, "setting.json");
            if (File.Exists(path))
            {
                var json = File.ReadAllText(path);
                return JsonSerializer.Deserialize<Settings>(json);
            }
            return null;
        }

        public void Save()
        {
            var path = Path.Combine(AppContext.BaseDirectory, "setting.json");
            var json = JsonSerializer.Serialize(this);
            File.WriteAllText(path, json);
        }
    }
}
