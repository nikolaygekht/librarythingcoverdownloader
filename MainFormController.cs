using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryThingCoverDownloader
{
    public class MainFormController
    {
        private readonly IMainForm mMainForm;
        private readonly Dictionary<string, BookTag> mBooks = new();

        public MainFormController(IMainForm mainForm)
        {
            mMainForm = mainForm;
        }

        public void LoadBooks()
        {
            mBooks.Clear();
            mMainForm.ClearBooks();

            var jsonFile = mMainForm.JsonFileName;
            if (string.IsNullOrEmpty(jsonFile) || !File.Exists(jsonFile))
                return;

            var books = LibraryThingExportJsonLoader.LoadBooks(jsonFile);
            if (books == null)
                return;

            foreach (var book in books)
            {
                var bookTag = new BookTag { Book = book };
                var author = "";
                if (book.Authors != null && book.Authors.Length > 0)
                    author = book.Authors[0]?.Name ?? "";
                bookTag.BookViewObject = mMainForm.AddBook(book.BookId, book.BookTitle ?? "", author);
                mBooks[book.BookId] = bookTag;
            }
        }

        public void ScanImages()
        {
            var books = mBooks.Values.ToArray();
            if (books == null || books.Length == 0)
            {
                mMainForm.ClearBooks();
                return;
            }

            var folder = mMainForm.ImageFolderName;
            if (string.IsNullOrEmpty(folder) || !Directory.Exists(folder))
                return;

            foreach (var bookTag in books)
            {
                var cv = UpdateImages(bookTag, folder);
                mMainForm.SetImageInfo(bookTag.BookViewObject, cv);
            }
        }

        public void LoadImageForBook(string id)
        {
            mMainForm.SetImagePreview(null);

            if (!mBooks.TryGetValue(id, out var bookTag))
                return;

            var folder = mMainForm.ImageFolderName;
            if (string.IsNullOrEmpty(folder) || !Directory.Exists(folder))
                return;

            var imageName = ImageNameTools.GetImageName(folder, bookTag.Book.BookId, mMainForm.UseLargeImage);
            
            if (!File.Exists(imageName))
                return;

            try
            {
                var image = Image.FromFile(imageName);
                mMainForm.SetImagePreview(image);
            }
            catch (Exception )
            {
                // ignored
            }
        }

        public void UpdateImages(string id, object viewItem)
        {
            if (!mBooks.TryGetValue(id, out var bookTag))
                return;
            
            var folder = mMainForm.ImageFolderName;
            if (string.IsNullOrEmpty(folder) || !Directory.Exists(folder))
                return;

            var cv = UpdateImages(bookTag, folder);
            mMainForm.SetImageInfo(bookTag.BookViewObject, cv);
        }

        private static string UpdateImages(BookTag bookTag, string folder)
        {
            var cv = "";
            if (ImageNameTools.DoesImageExist(folder, bookTag.Book.BookId, false))
                cv += "y,";
            else
                cv += "n,";

            if (ImageNameTools.DoesImageExist(folder, bookTag.Book.BookId, true))
                cv += "y";
            else
                cv += "n";
            return cv; 
        }

        internal void RemoveImages(string id)
        {
            var folder = mMainForm.ImageFolderName;
            if (string.IsNullOrEmpty(folder) || !Directory.Exists(folder))
                return;

            File.Delete(ImageNameTools.GetImageName(folder, id, false));
            File.Delete(ImageNameTools.GetImageName(folder, id, true));
        }
    }
}
