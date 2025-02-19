# Library Thing Cover Downloader

An application to download covers from LibraryThing for a personal collection, exported to json.

# Problem To Solve

The [librarything](https://www.librarything.com) is the most popular book catalog for personal collection. It is
almost perfect with one exclusion: it doesn't saves either links to covers. In my personal case a good 90% percents
of covers for my collection are uploaded by me, so literally, if something went wrong, I would lost results of
quite a few efforts.

# How It Works

The application requires:

* JSON file with collection of the books (use more -> export -> JSON file)
* LibraryThing login and password (you may skip this, but it will be way slower)

The application opens each book in the embedded browser, finds links to a minimal and 3x size image, and downloads them.
The images will be **bookid**-**s|l**.jpg.

# How to use

* Download and build the app (.NET 8.0 SDK is required)
* Download JSON file from library thing
* Load JSON file into application
* Create and choose a folder for images
* Now you can load one image or all images (that aren't loaded yet).
* The application loads 1 book in 3 seconds, which is fastest pace for a logged in
  instance that doesn't trigger robot protection.




