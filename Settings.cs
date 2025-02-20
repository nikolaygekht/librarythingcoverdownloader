using System.Security.Cryptography;
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

        [JsonInclude]
        [JsonPropertyName("username")]
        private string? LibraryThingUserNamePrivate { get; set; }

        [JsonIgnore]
        public string? LibraryThingUserName 
        { 
            get
            {
                return LibraryThingUserNamePrivate;
            }
            set
            {
                var password = (string)null;
                if (LibraryThingPasswordEncoded != null)
                    password = LibraryThingPassword;
                LibraryThingUserNamePrivate = value;
                LibraryThingPassword = password;
            }
        }

        [JsonPropertyName("columns")]
        public int[]? Columns { get; set; }

        [JsonPropertyName("timeout")]
        public int? Timeout { get; set; }

        [JsonPropertyName("batchsize")]
        public int? BatchSize { get; set; }

        [JsonInclude]
        [JsonPropertyName("password")]
        private string? LibraryThingPasswordEncoded { get; set; }

        [JsonIgnore]
        public string? LibraryThingPassword 
        { 
            get
            {
                if (string.IsNullOrEmpty(LibraryThingPasswordEncoded))
                {
                    return string.Empty;
                }
                return Decrypt(LibraryThingPasswordEncoded, LibraryThingUserName ?? "");
            }
            set
            {
                if (value == null)
                {
                    LibraryThingPasswordEncoded = "";
                    return;
                }               
                LibraryThingPasswordEncoded = Encrypt(value, LibraryThingUserName ?? "");
            }
        }

        private static void InitializeAes(Aes? aes, string username)
        {
            if (aes == null)
                return;
            using SHA256 sha256 = SHA256.Create();
            aes.Key = sha256.ComputeHash(Encoding.UTF8.GetBytes("librarything:" + username)).AsSpan().Slice(0, 32).ToArray();
            aes.IV = sha256.ComputeHash(Encoding.UTF8.GetBytes("imagedownloader:" + username)).AsSpan().Slice(0, 16).ToArray();
        }

        private static string Encrypt(string password, string username)
        {
            using var aes = Aes.Create();
            InitializeAes(aes, username);
            using var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
           
            using (var msEncrypt = new MemoryStream())
            {
                using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (var swEncrypt = new StreamWriter(csEncrypt))
                    {
                        //Write all data to the stream.
                        swEncrypt.Write(username + "," + password);
                    }
                    csEncrypt.Flush();
                }
                return Convert.ToBase64String(msEncrypt.ToArray());
            }
            
        }

        private static string Decrypt(string password, string username)
        {
            using var aes = Aes.Create();
            using SHA256 sha256 = SHA256.Create();
            InitializeAes(aes, username);
            using var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            var bytes = Convert.FromBase64String(password);
            string s = "";
            using (MemoryStream msDecrypt = new MemoryStream(bytes))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (var sr = new StreamReader(csDecrypt))
                    {
                        try
                        {
                            s = sr.ReadToEnd();
                        }
                        catch (Exception)
                        {
                            return null;
                        }
                    }
                }
            }

            if (!s.StartsWith(username + ","))
                return null;
            return s.Substring(username.Length + 1);
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
