using System.Reflection.Metadata;
using System.Xml.Linq;

namespace LibraryThingCoverDownloader
{
    public class LibraryThingController
    {
        private readonly IMainForm mMainForm;

        public LibraryThingController(IMainForm mainForm)
        {
            mMainForm = mainForm;
        }

        private static async Task<bool> WaitForAsync(Func<Task<bool>> asyncPredicate, int timeout)
        {
            long ticks = DateTime.Now.Ticks;
            return await Task.Run(async () =>
            {
                while (true)
                {
                    var result = await asyncPredicate();
                    if (result)
                        return true;

                    if ((DateTime.Now.Ticks - ticks) / TimeSpan.TicksPerMillisecond >= timeout)
                        break;
                    await Task.Delay(100);
                }
                return false;
            });
        }

        private async Task<bool> ExecuteJavaPredicateAsync(string predicate)
            => string.Compare(await mMainForm.ExecuteJavaScriptAsync(predicate), "true", StringComparison.InvariantCultureIgnoreCase) == 0;

        public Task<bool> HasLoginButton()
            => ExecuteJavaPredicateAsync("document.getElementsByName('index_signin_already').length > 0");

        public Task<bool> IsLoggedIn()
            => ExecuteJavaPredicateAsync("document.getElementById('masttab_books') !== null");

        public Task<bool> Loaded()
            => ExecuteJavaPredicateAsync("document.readyState === 'complete'");

        public Task WaitLoaded(int timeout) => WaitForAsync(Loaded, timeout);

        public async Task Login()
        {
            if (await IsLoggedIn())
                throw new LibraryThingControllerException("Already logged in");

            if (!await HasLoginButton())
                throw new LibraryThingControllerException("No login form found");

            await mMainForm.ExecuteJavaScriptAsync("document.getElementById('already_formusername').value = '" + mMainForm.LibraryThingUserName + "'");
            await mMainForm.ExecuteJavaScriptAsync("document.getElementById('formpassword_field').value = '" + mMainForm.LibraryThingPassword + "'");
            await mMainForm.ExecuteJavaScriptAsync("document.getElementsByName('index_signin_already')[0].click()");
        }

        public async Task SaveImages(string id)
        {
            var folder = mMainForm.ImageFolderName;

            if (string.IsNullOrEmpty(folder))
                throw new LibraryThingControllerException("No image folder specified");

            if (!Directory.Exists(folder))
                throw new LibraryThingControllerException("Folder directory doesn't exist");

            await mMainForm.ExecuteJavaScriptAsync("window.location.href='https://www.librarything.com/work/0/book/" + id + "'");

            if (!await WaitForAsync(() => ExecuteJavaPredicateAsync("document.getElementById('lt2_mainimage_container') !== null"), 3000))
                throw new LibraryThingControllerException("No image folder specified");

            var small = await mMainForm.ExecuteJavaScriptAsync("document.getElementById('lt2_mainimage_container').getElementsByTagName('img')[0].src");
            var large = "";
            var srcset = (await mMainForm.ExecuteJavaScriptAsync("document.getElementById('lt2_mainimage_container').getElementsByTagName('img')[0].srcset")).Split(',');
            if (srcset.Length > 1)
                large = (srcset[^1].Trim().Split(' '))[0];

            await SaveImage(small, id, folder, false);
            await SaveImage(large, id, folder, true);
        }

        public static async Task SaveImage(string url, string id, string folder, bool large)
        {
            if (string.IsNullOrEmpty(url))
                return;

            var path = ImageNameTools.GetImageName(folder, id, large);
            if (File.Exists(path))
                return;

            url = url.Replace("\"", "");

            using var client = new HttpClient();
            try
            {
                var image = await client.GetByteArrayAsync(url);
                await File.WriteAllBytesAsync(path, image);
            }
            catch (Exception)
            {
                // ignored
                ;
            }
        }
    }
}
