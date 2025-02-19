namespace LibraryThingCoverDownloader
{
    public interface IMainForm
    {
        public string JsonFileName { get; }
        public string ImageFolderName { get; }
        public bool UseLargeImage { get; }
        public string LibraryThingUserName { get; }
        public string LibraryThingPassword { get; }

        public object AddBook(string id, string name, string author);
        public void SetImageInfo(object bookObject, string imageInfo);
        public void SetImagePreview(Image? image);
        public void ClearBooks();

        public Task<string> ExecuteJavaScriptAsync(string script);
        public void Navigate(string url);
    }
}
