using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

#pragma warning disable IDE1006 // Naming Styles

namespace LibraryThingCoverDownloader
{
    public partial class MainForm : Form, IMainForm
    {
        private bool mLoaded = false;
        private readonly MainFormController mBookController;
        private readonly LibraryThingController mLibraryThingController;

        public MainForm()
        {
            mBookController = new MainFormController(this);
            mLibraryThingController = new LibraryThingController(this);

            InitializeComponent();

            var settings = Settings.Load();
            if (settings != null)
            {
                textBoxLibraryThingUser.Text = settings.LibraryThingUserName ?? "";
                textBoxLibraryThingPassword.Text = settings.LibraryThingPassword ?? "";
                textBoxJson.Text = settings.JsonFileName ?? "";
                textBoxImageFolder.Text = settings.ImagePath ?? "";

                if (settings.Columns != null)
                {
                    for (int i = 0; i < settings.Columns.Length; i++)
                    {
                        if (settings.Columns[i] > 0)
                            listViewBook.Columns[i].Width = settings.Columns[i];
                    }
                }
            }
        }

        #region IMainForm implementation
        public string JsonFileName => textBoxJson.Text;

        public string ImageFolderName => textBoxImageFolder.Text;

        public bool UseLargeImage => checkBoxUseLargeImage.Checked;

        public string LibraryThingUserName => textBoxLibraryThingUser.Text;

        public string LibraryThingPassword => textBoxLibraryThingPassword.Text;

        public object AddBook(string id, string name, string author)
        {
            return listViewBook.Items.Add(new ListViewItem(new string[] { id, name, author, "?,?" }));
        }

        public void SetImageInfo(object bookObject, string imageInfo)
        {
            var lvi = bookObject as ListViewItem;
            if (lvi == null)
                return;
            lvi.SubItems[3].Text = imageInfo;
        }

        public void SetImagePreview(Image? image)
        {
            pictureBoxCover.Image?.Dispose();
            pictureBoxCover.Image = image;
            if (image != null)
            {
                labelImageSize.Text = image.Width + "x" + image.Height;
            }
        }

        public void ClearBooks()
        {
            listViewBook.Items.Clear();
        }

        public async Task<string> ExecuteJavaScriptAsync(string script)
        {
            return await webView.ExecuteScriptAsync(script);
        }

        public void Navigate(string url)
        {
            webView.CoreWebView2.Navigate(url);
        }
        #endregion

        private void LoadWebsite()
        {
            mLoaded = false;
            webView.CoreWebView2.Navigate("https://www.librarything.com/");
            webView.CoreWebView2.DOMContentLoaded += (_, _) => { mLoaded = true; };
        }

        private async void buttonLogin_Click(object sender, EventArgs e)
        {
            if (!mLoaded)
                LoadWebsite();

            await mLibraryThingController.WaitLoaded(2000);

            try
            {
                await mLibraryThingController.Login();
            }
            catch (LibraryThingControllerException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            await webView.EnsureCoreWebView2Async(null);
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            mLoaded = false;
            webView.CoreWebView2.Navigate("https://www.librarything.com/");
            webView.CoreWebView2.DOMContentLoaded += (_, _) => { mLoaded = true; };

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var settings = new Settings()
            {
                LibraryThingUserName = textBoxLibraryThingUser.Text,
                LibraryThingPassword = textBoxLibraryThingPassword.Text,
                JsonFileName = textBoxJson.Text,
                ImagePath = textBoxImageFolder.Text,
                Columns = listViewBook.Columns.Cast<ColumnHeader>().Select(c => c.Width).ToArray(),
            };
            settings.Save();
        }

        private void buttonJsonSelect_Click(object sender, EventArgs e)
        {
            var defaultPath = "";

            if (!string.IsNullOrEmpty(textBoxJson.Text))
            {
                var fi = new FileInfo(textBoxJson.Text);
                if (Directory.Exists(fi.DirectoryName))
                    defaultPath = fi.DirectoryName;
            }

            if (string.IsNullOrEmpty(defaultPath))
                defaultPath = AppContext.BaseDirectory;


            var openFileDialog = new OpenFileDialog()
            {
                InitialDirectory = defaultPath,
                Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
                AddExtension = true,
                CheckFileExists = true,
                CheckPathExists = true,
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxJson.Text = openFileDialog.FileName;
                buttonLoadBackup_Click(sender, e);
            }
        }

        private void buttonLoadBackup_Click(object sender, EventArgs e)
        {
            mBookController.LoadBooks();
            mBookController.ScanImages();
        }

        private void listViewBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelImageSize.Text = "No Image";
            if (pictureBoxCover.Image != null)
            {
                pictureBoxCover.Image.Dispose();
                pictureBoxCover.Image = null;
            }
            var id = listViewBook.SelectedItems.Count > 0 ? listViewBook.SelectedItems[0].Text : null;

            if (!string.IsNullOrEmpty(id))
                mBookController.LoadImageForBook(id);
        }

        private void buttonOutputFolderSelect_Click(object sender, EventArgs e)
        {
            var defaultPath = textBoxImageFolder.Text;
            if (string.IsNullOrEmpty(defaultPath))
                defaultPath = AppContext.BaseDirectory;

            var dialog = new FolderBrowserDialog()
            {
                SelectedPath = defaultPath,
            };

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                textBoxImageFolder.Text = dialog.SelectedPath;
            }
        }

        private void buttonScanImages_Click(object sender, EventArgs e)
        {
            mBookController.ScanImages();
        }

        private void checkBoxUseLargeImage_CheckedChanged(object sender, EventArgs e)
        {
            listViewBook_SelectedIndexChanged(sender, e);
        }

        private async void buttonDebug1_Click(object sender, EventArgs e)
        {
        }

        private async Task LoadOne(ListViewItem lvi, bool reload = false)
        {
            var id = lvi.Text;

            if (!string.IsNullOrEmpty(id))
            {
                await mLibraryThingController.SaveImages(id);
                mBookController.UpdateImages(id, lvi);
                if (reload)
                    mBookController.LoadImageForBook(id);
            }
        }

        private async void buttonImage_Click(object sender, EventArgs e)
        {
            var lvi = listViewBook.SelectedItems.Count > 0 ? listViewBook.SelectedItems[0] : null;
            if (lvi == null)
                return;

            await LoadOne(lvi, true);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            var lvi = listViewBook.SelectedItems.Count > 0 ? listViewBook.SelectedItems[0] : null;
            if (lvi == null)
                return;

            pictureBoxCover.Image?.Dispose();
            pictureBoxCover.Image = null;

            mBookController.RemoveImages(lvi.Text);
            mBookController.UpdateImages(lvi.Text, lvi);
            mBookController.LoadImageForBook(lvi.Text);
        }

        private void buttonClearAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear all images?", "Clear All Images", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            pictureBoxCover.Image?.Dispose();
            pictureBoxCover.Image = null;

            foreach (ListViewItem lvi in listViewBook.Items)
            {
                mBookController.RemoveImages(lvi.Text);
                mBookController.UpdateImages(lvi.Text, lvi);
            }
            listViewBook_SelectedIndexChanged(sender, e);
        }

        private bool mCancel = false;

        private void buttonLoadAll_Click(object sender, EventArgs e)
        {
            int max = 0;
            mCancel = false;
            var lvis = listViewBook.Items.Cast<ListViewItem>().ToList();
            Task.Run(async () =>
            {
                int i = 0;
                foreach (var lvi in lvis)
                {
                    if (mCancel)
                        break;
                    if (lvi.SubItems[3].Text == "y,y")
                        continue;
                    
                    await LoadOneStep(lvi);
                    Thread.Sleep(3000);
                    i++;
                    if (i > max && max > 0)
                        break;
                }
                this.Invoke(() => labelAllProgress.Text = "done");
            });
        }

        private async Task LoadOneStep(ListViewItem lvi)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(async () => await LoadOneStep(lvi)));
                return;
            }
            labelAllProgress.Text = "Loading:..." + lvi.Text;
            try
            {
                await LoadOne(lvi);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mCancel = true;
            }
        }

        private void buttonCancelAll_Click(object sender, EventArgs e)
        {
            mCancel = true;
        }
    }
}
