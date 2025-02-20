namespace LibraryThingCoverDownloader
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxJson = new TextBox();
            textBoxImageFolder = new TextBox();
            buttonJsonSelect = new Button();
            buttonOutputFolderSelect = new Button();
            listViewBook = new ListView();
            columnHeaderId = new ColumnHeader();
            columnHeaderTitle = new ColumnHeader();
            columnHeaderAuthor = new ColumnHeader();
            columnHeaderImage = new ColumnHeader();
            textBoxLibraryThingUser = new TextBox();
            textBoxLibraryThingPassword = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            buttonImage = new Button();
            buttonLoadAll = new Button();
            buttonClear = new Button();
            buttonClearAll = new Button();
            label4 = new Label();
            label5 = new Label();
            buttonLogin = new Button();
            webView = new Microsoft.Web.WebView2.WinForms.WebView2();
            buttonLoad = new Button();
            buttonLoadBackup = new Button();
            buttonScanImages = new Button();
            pictureBoxCover = new PictureBox();
            labelImageSize = new Label();
            checkBoxUseLargeImage = new CheckBox();
            labelAllProgress = new Label();
            buttonCancelAll = new Button();
            label6 = new Label();
            label7 = new Label();
            numericTimeout = new NumericUpDown();
            numericBatch = new NumericUpDown();
            label8 = new Label();
            label9 = new Label();
            buttonLookupPassword = new Button();
            ((System.ComponentModel.ISupportInitialize)webView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCover).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericTimeout).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericBatch).BeginInit();
            SuspendLayout();
            // 
            // textBoxJson
            // 
            textBoxJson.Location = new Point(248, 12);
            textBoxJson.Name = "textBoxJson";
            textBoxJson.Size = new Size(1203, 35);
            textBoxJson.TabIndex = 0;
            // 
            // textBoxImageFolder
            // 
            textBoxImageFolder.Location = new Point(248, 53);
            textBoxImageFolder.Name = "textBoxImageFolder";
            textBoxImageFolder.Size = new Size(1203, 35);
            textBoxImageFolder.TabIndex = 3;
            // 
            // buttonJsonSelect
            // 
            buttonJsonSelect.Location = new Point(1457, 12);
            buttonJsonSelect.Name = "buttonJsonSelect";
            buttonJsonSelect.Size = new Size(49, 35);
            buttonJsonSelect.TabIndex = 1;
            buttonJsonSelect.Text = "...";
            buttonJsonSelect.UseVisualStyleBackColor = true;
            buttonJsonSelect.Click += buttonJsonSelect_Click;
            // 
            // buttonOutputFolderSelect
            // 
            buttonOutputFolderSelect.Location = new Point(1457, 51);
            buttonOutputFolderSelect.Name = "buttonOutputFolderSelect";
            buttonOutputFolderSelect.Size = new Size(49, 35);
            buttonOutputFolderSelect.TabIndex = 4;
            buttonOutputFolderSelect.Text = "...";
            buttonOutputFolderSelect.UseVisualStyleBackColor = true;
            buttonOutputFolderSelect.Click += buttonOutputFolderSelect_Click;
            // 
            // listViewBook
            // 
            listViewBook.AutoArrange = false;
            listViewBook.Columns.AddRange(new ColumnHeader[] { columnHeaderId, columnHeaderTitle, columnHeaderAuthor, columnHeaderImage });
            listViewBook.FullRowSelect = true;
            listViewBook.GridLines = true;
            listViewBook.Location = new Point(248, 102);
            listViewBook.Name = "listViewBook";
            listViewBook.Size = new Size(1361, 268);
            listViewBook.TabIndex = 6;
            listViewBook.UseCompatibleStateImageBehavior = false;
            listViewBook.View = View.Details;
            listViewBook.SelectedIndexChanged += listViewBook_SelectedIndexChanged;
            // 
            // columnHeaderId
            // 
            columnHeaderId.Text = "Id";
            columnHeaderId.Width = 120;
            // 
            // columnHeaderTitle
            // 
            columnHeaderTitle.Text = "Title";
            columnHeaderTitle.Width = 600;
            // 
            // columnHeaderAuthor
            // 
            columnHeaderAuthor.Text = "Author";
            columnHeaderAuthor.Width = 350;
            // 
            // columnHeaderImage
            // 
            columnHeaderImage.Text = "Cover";
            columnHeaderImage.Width = 100;
            // 
            // textBoxLibraryThingUser
            // 
            textBoxLibraryThingUser.Location = new Point(248, 466);
            textBoxLibraryThingUser.Name = "textBoxLibraryThingUser";
            textBoxLibraryThingUser.Size = new Size(224, 35);
            textBoxLibraryThingUser.TabIndex = 11;
            // 
            // textBoxLibraryThingPassword
            // 
            textBoxLibraryThingPassword.Location = new Point(703, 466);
            textBoxLibraryThingPassword.Name = "textBoxLibraryThingPassword";
            textBoxLibraryThingPassword.PasswordChar = '*';
            textBoxLibraryThingPassword.Size = new Size(349, 35);
            textBoxLibraryThingPassword.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 17);
            label1.Name = "label1";
            label1.Size = new Size(91, 30);
            label1.TabIndex = 8;
            label1.Text = "Json File";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 56);
            label2.Name = "label2";
            label2.Size = new Size(134, 30);
            label2.TabIndex = 9;
            label2.Text = "Image Folder";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 102);
            label3.Name = "label3";
            label3.Size = new Size(68, 30);
            label3.TabIndex = 10;
            label3.Text = "Books";
            // 
            // buttonImage
            // 
            buttonImage.Location = new Point(248, 376);
            buttonImage.Name = "buttonImage";
            buttonImage.Size = new Size(131, 40);
            buttonImage.TabIndex = 7;
            buttonImage.Text = "Load";
            buttonImage.UseVisualStyleBackColor = true;
            buttonImage.Click += buttonImage_Click;
            // 
            // buttonLoadAll
            // 
            buttonLoadAll.Location = new Point(385, 376);
            buttonLoadAll.Name = "buttonLoadAll";
            buttonLoadAll.Size = new Size(131, 40);
            buttonLoadAll.TabIndex = 8;
            buttonLoadAll.Text = "Load All";
            buttonLoadAll.UseVisualStyleBackColor = true;
            buttonLoadAll.Click += buttonLoadAll_Click;
            // 
            // buttonClear
            // 
            buttonClear.Location = new Point(522, 376);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(131, 40);
            buttonClear.TabIndex = 9;
            buttonClear.Text = "Clear Image";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += buttonClear_Click;
            // 
            // buttonClearAll
            // 
            buttonClearAll.Location = new Point(659, 376);
            buttonClearAll.Name = "buttonClearAll";
            buttonClearAll.Size = new Size(131, 40);
            buttonClearAll.TabIndex = 10;
            buttonClearAll.Text = "Clear All";
            buttonClearAll.UseVisualStyleBackColor = true;
            buttonClearAll.Click += buttonClearAll_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 471);
            label4.Name = "label4";
            label4.Size = new Size(174, 30);
            label4.TabIndex = 15;
            label4.Text = "LibraryThing User";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(478, 469);
            label5.Name = "label5";
            label5.Size = new Size(219, 30);
            label5.TabIndex = 16;
            label5.Text = "LibraryThing Password";
            // 
            // buttonLogin
            // 
            buttonLogin.Location = new Point(1229, 464);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(131, 40);
            buttonLogin.TabIndex = 13;
            buttonLogin.Text = "Login";
            buttonLogin.UseVisualStyleBackColor = true;
            buttonLogin.Click += buttonLogin_Click;
            // 
            // webView
            // 
            webView.AllowExternalDrop = true;
            webView.CreationProperties = null;
            webView.DefaultBackgroundColor = Color.White;
            webView.Location = new Point(12, 523);
            webView.Name = "webView";
            webView.Size = new Size(1494, 480);
            webView.TabIndex = 15;
            webView.ZoomFactor = 1D;
            // 
            // buttonLoad
            // 
            buttonLoad.Location = new Point(1375, 464);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(131, 40);
            buttonLoad.TabIndex = 14;
            buttonLoad.Text = "Load";
            buttonLoad.UseVisualStyleBackColor = true;
            buttonLoad.Click += buttonLoad_Click;
            // 
            // buttonLoadBackup
            // 
            buttonLoadBackup.Location = new Point(1512, 9);
            buttonLoadBackup.Name = "buttonLoadBackup";
            buttonLoadBackup.Size = new Size(97, 40);
            buttonLoadBackup.TabIndex = 2;
            buttonLoadBackup.Text = "Load";
            buttonLoadBackup.UseVisualStyleBackColor = true;
            buttonLoadBackup.Click += buttonLoadBackup_Click;
            // 
            // buttonScanImages
            // 
            buttonScanImages.Location = new Point(1512, 48);
            buttonScanImages.Name = "buttonScanImages";
            buttonScanImages.Size = new Size(97, 40);
            buttonScanImages.TabIndex = 5;
            buttonScanImages.Text = "Scan";
            buttonScanImages.UseVisualStyleBackColor = true;
            buttonScanImages.Click += buttonScanImages_Click;
            // 
            // pictureBoxCover
            // 
            pictureBoxCover.Location = new Point(1633, 115);
            pictureBoxCover.Name = "pictureBoxCover";
            pictureBoxCover.Size = new Size(594, 888);
            pictureBoxCover.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxCover.TabIndex = 17;
            pictureBoxCover.TabStop = false;
            // 
            // labelImageSize
            // 
            labelImageSize.AutoSize = true;
            labelImageSize.Location = new Point(1633, 72);
            labelImageSize.Name = "labelImageSize";
            labelImageSize.Size = new Size(55, 30);
            labelImageSize.TabIndex = 18;
            labelImageSize.Text = "Size:";
            // 
            // checkBoxUseLargeImage
            // 
            checkBoxUseLargeImage.AutoSize = true;
            checkBoxUseLargeImage.Location = new Point(1633, 35);
            checkBoxUseLargeImage.Name = "checkBoxUseLargeImage";
            checkBoxUseLargeImage.Size = new Size(201, 34);
            checkBoxUseLargeImage.TabIndex = 21;
            checkBoxUseLargeImage.Text = "User Large Image";
            checkBoxUseLargeImage.UseVisualStyleBackColor = true;
            checkBoxUseLargeImage.CheckedChanged += checkBoxUseLargeImage_CheckedChanged;
            // 
            // labelAllProgress
            // 
            labelAllProgress.AutoSize = true;
            labelAllProgress.Location = new Point(522, 419);
            labelAllProgress.Name = "labelAllProgress";
            labelAllProgress.Size = new Size(19, 30);
            labelAllProgress.TabIndex = 22;
            labelAllProgress.Text = " ";
            // 
            // buttonCancelAll
            // 
            buttonCancelAll.Location = new Point(385, 419);
            buttonCancelAll.Name = "buttonCancelAll";
            buttonCancelAll.Size = new Size(131, 40);
            buttonCancelAll.TabIndex = 23;
            buttonCancelAll.Text = "Cancel";
            buttonCancelAll.UseVisualStyleBackColor = true;
            buttonCancelAll.Click += buttonCancelAll_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(828, 381);
            label6.Name = "label6";
            label6.Size = new Size(235, 30);
            label6.TabIndex = 24;
            label6.Text = "Timeout between pages";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(828, 419);
            label7.Name = "label7";
            label7.Size = new Size(229, 30);
            label7.TabIndex = 25;
            label7.Text = "Pages in Load All Batch";
            // 
            // numericTimeout
            // 
            numericTimeout.Location = new Point(1081, 381);
            numericTimeout.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numericTimeout.Name = "numericTimeout";
            numericTimeout.Size = new Size(116, 35);
            numericTimeout.TabIndex = 26;
            // 
            // numericBatch
            // 
            numericBatch.Location = new Point(1081, 419);
            numericBatch.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericBatch.Name = "numericBatch";
            numericBatch.Size = new Size(116, 35);
            numericBatch.TabIndex = 27;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(1203, 381);
            label8.Name = "label8";
            label8.Size = new Size(40, 30);
            label8.TabIndex = 28;
            label8.Text = "ms";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(1203, 419);
            label9.Name = "label9";
            label9.Size = new Size(83, 30);
            label9.TabIndex = 29;
            label9.Text = "0 for all";
            // 
            // buttonLookupPassword
            // 
            buttonLookupPassword.Location = new Point(1066, 464);
            buttonLookupPassword.Name = "buttonLookupPassword";
            buttonLookupPassword.Size = new Size(131, 40);
            buttonLookupPassword.TabIndex = 30;
            buttonLookupPassword.Text = "Lookup";
            buttonLookupPassword.UseVisualStyleBackColor = true;
            buttonLookupPassword.Click += buttonLookupPassword_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2228, 1015);
            Controls.Add(buttonLookupPassword);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(numericBatch);
            Controls.Add(numericTimeout);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(buttonCancelAll);
            Controls.Add(labelAllProgress);
            Controls.Add(checkBoxUseLargeImage);
            Controls.Add(labelImageSize);
            Controls.Add(pictureBoxCover);
            Controls.Add(buttonScanImages);
            Controls.Add(buttonLoadBackup);
            Controls.Add(buttonLoad);
            Controls.Add(webView);
            Controls.Add(buttonLogin);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(buttonClearAll);
            Controls.Add(buttonClear);
            Controls.Add(buttonLoadAll);
            Controls.Add(buttonImage);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxLibraryThingPassword);
            Controls.Add(textBoxLibraryThingUser);
            Controls.Add(listViewBook);
            Controls.Add(buttonOutputFolderSelect);
            Controls.Add(buttonJsonSelect);
            Controls.Add(textBoxImageFolder);
            Controls.Add(textBoxJson);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            ShowIcon = false;
            Text = "Library Thing Cover Downloader";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)webView).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCover).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericTimeout).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericBatch).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxJson;
        private TextBox textBoxImageFolder;
        private Button buttonJsonSelect;
        private Button buttonOutputFolderSelect;
        private ListView listViewBook;
        private ColumnHeader columnHeaderId;
        private ColumnHeader columnHeaderTitle;
        private ColumnHeader columnHeaderAuthor;
        private TextBox textBoxLibraryThingUser;
        private TextBox textBoxLibraryThingPassword;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button buttonImage;
        private Button buttonLoadAll;
        private Button buttonClear;
        private Button buttonClearAll;
        private Label label4;
        private Label label5;
        private Button buttonLogin;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView;
        private Button buttonLoad;
        private ColumnHeader columnHeaderImage;
        private Button buttonLoadBackup;
        private Button buttonScanImages;
        private PictureBox pictureBoxCover;
        private Label labelImageSize;
        private CheckBox checkBoxUseLargeImage;
        private Label labelAllProgress;
        private Button buttonCancelAll;
        private Label label6;
        private Label label7;
        private NumericUpDown numericTimeout;
        private NumericUpDown numericBatch;
        private Label label8;
        private Label label9;
        private Button buttonLookupPassword;
    }
}