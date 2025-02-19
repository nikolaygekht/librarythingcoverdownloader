namespace LibraryThingCoverDownloader
{
    public static class ImageNameTools
    {
        public static bool DoesImageExist(string folder, string id, bool large)
            => File.Exists(GetImageName(folder, id, large));

        public static string GetImageName(string folder, string id, bool large)
            => Path.Combine(folder, id + (large ? "-l" : "-s") + ".jpg");
    }
}
