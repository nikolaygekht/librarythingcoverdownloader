using System.Net;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace LibraryThingCoverDownloader;

partial class Program
{

    [STAThread]
    static void Main(string[] args)
    {
        var form = new MainForm();
        form.ShowDialog();

        /*
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: LibraryThingCoverDownloader backupJsonFile outputFolder");
            return;
        }

        if (!File.Exists(args[0]))
        {
            Console.WriteLine("File not found: " + args[0]);
            return;
        }

        if (!Directory.Exists(args[1]))
        {
            Console.WriteLine("Directory should exist: " + args[1]);
            return;
        }

        var file = File.ReadAllText(args[0])
            .Replace("\"authors\": [[]]", "\"authors\": []")
            .Replace("\"lcc\": []", "\"lcc\": {}");
        var books = JsonSerializer.Deserialize<Dictionary<string, Book>>(file);

        var re = new Regex("<meta name=\"small_image\" content=\"(\\S+)\"/>");

        foreach (var book in books)
        {
            var outPath = Path.Combine(args[1], "small" + book.Value.BookId + ".jpg");

            Console.Write(book.Value.BookId + "-" + book.Value.BookTitle);

            if (File.Exists(outPath))
            {
                Console.WriteLine(" - already downloaded");
                continue;
            }
                
            using var client = new HttpClient();

            var response = client.GetAsync("https://www.librarything.com/work/0/book/" + book.Value.BookId).ConfigureAwait(false).GetAwaiter().GetResult();
            var html = response.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            var m = re.Match(html);
            if (m.Success)
            {
                string oldName = null;
                var imageName = m.Groups[1].Value;
                if (imageName.Contains("w200"))
                {
                    oldName = imageName; 
                    imageName = imageName.Replace("w200", "w400");
                }
                byte[]? image = null;
                try
                {
                    image = client.GetByteArrayAsync(imageName).ConfigureAwait(false).GetAwaiter().GetResult();
                }
                catch (Exception )
                {
                    bool error = false;
                    if (oldName != null)
                    {
                        imageName = oldName;
                        try
                        {
                            image = client.GetByteArrayAsync(imageName).ConfigureAwait(false).GetAwaiter().GetResult();
                        }
                        catch (Exception )
                        {
                            error = true;
                        }
                    }
                    else
                    {
                        error = true;
                    }
                    if (error)
                    {
                        Console.WriteLine(" - error");
                        break;
                    }
                }

                if (image != null)
                {
                    File.WriteAllBytes(outPath, image);
                    Console.WriteLine(" - downloaded as" + imageName);
                }
            }
            else
            {
                Console.WriteLine(" - image not found");
                break;
            }
            Thread.Sleep(5000);
        }
        */
    }
}
