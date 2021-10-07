
namespace FtpDownloader
{
    partial class fMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMain));
            this.tbFtpSource = new System.Windows.Forms.TextBox();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsbtnAbout = new System.Windows.Forms.ToolStripButton();
            this.ssMain = new System.Windows.Forms.StatusStrip();
            this.lblFileSize = new System.Windows.Forms.ToolStripStatusLabel();
            this.pbProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.lblTransferRate = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblEstTimeLeft = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblFtpSource = new System.Windows.Forms.Label();
            this.btnGetFile = new System.Windows.Forms.Button();
            this.bgwDownloader = new System.ComponentModel.BackgroundWorker();
            this.lblSaveTo = new System.Windows.Forms.Label();
            this.tbSaveTo = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.tsMain.SuspendLayout();
            this.ssMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbFtpSource
            // 
            this.tbFtpSource.Location = new System.Drawing.Point(13, 47);
            this.tbFtpSource.Name = "tbFtpSource";
            this.tbFtpSource.Size = new System.Drawing.Size(775, 23);
            this.tbFtpSource.TabIndex = 0;
            this.tbFtpSource.Text = "ftp://speedtest.tele2.net/1MB.zip";
            // 
            // tsMain
            // 
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnAbout});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(800, 25);
            this.tsMain.TabIndex = 1;
            this.tsMain.Text = "toolStrip1";
            // 
            // tsbtnAbout
            // 
            this.tsbtnAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnAbout.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnAbout.Image")));
            this.tsbtnAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnAbout.Name = "tsbtnAbout";
            this.tsbtnAbout.Size = new System.Drawing.Size(44, 22);
            this.tsbtnAbout.Text = "About";
            this.tsbtnAbout.Click += new System.EventHandler(this.tsbtnAbout_Click);
            // 
            // ssMain
            // 
            this.ssMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblFileSize,
            this.pbProgress,
            this.lblTransferRate,
            this.lblEstTimeLeft});
            this.ssMain.Location = new System.Drawing.Point(0, 187);
            this.ssMain.Name = "ssMain";
            this.ssMain.Size = new System.Drawing.Size(800, 22);
            this.ssMain.TabIndex = 2;
            this.ssMain.Text = "statusStrip1";
            // 
            // lblFileSize
            // 
            this.lblFileSize.Name = "lblFileSize";
            this.lblFileSize.Size = new System.Drawing.Size(47, 17);
            this.lblFileSize.Text = "File size";
            this.lblFileSize.ToolTipText = "Source file size";
            // 
            // pbProgress
            // 
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(100, 16);
            this.pbProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbProgress.ToolTipText = "Download progress";
            // 
            // lblTransferRate
            // 
            this.lblTransferRate.Name = "lblTransferRate";
            this.lblTransferRate.Size = new System.Drawing.Size(72, 17);
            this.lblTransferRate.Text = "Transfer rate";
            this.lblTransferRate.ToolTipText = "Transfer rate";
            // 
            // lblEstTimeLeft
            // 
            this.lblEstTimeLeft.Name = "lblEstTimeLeft";
            this.lblEstTimeLeft.Size = new System.Drawing.Size(54, 17);
            this.lblEstTimeLeft.Text = "Time left";
            this.lblEstTimeLeft.ToolTipText = "Estimated time left";
            // 
            // lblFtpSource
            // 
            this.lblFtpSource.AutoSize = true;
            this.lblFtpSource.Location = new System.Drawing.Point(13, 29);
            this.lblFtpSource.Name = "lblFtpSource";
            this.lblFtpSource.Size = new System.Drawing.Size(220, 15);
            this.lblFtpSource.TabIndex = 3;
            this.lblFtpSource.Text = "Link to the source file [via FTP protocol]:";
            // 
            // btnGetFile
            // 
            this.btnGetFile.Location = new System.Drawing.Point(713, 161);
            this.btnGetFile.Name = "btnGetFile";
            this.btnGetFile.Size = new System.Drawing.Size(75, 23);
            this.btnGetFile.TabIndex = 3;
            this.btnGetFile.Text = "Get it!";
            this.btnGetFile.UseVisualStyleBackColor = true;
            this.btnGetFile.Click += new System.EventHandler(this.btnGetFile_Click);
            // 
            // bgwDownloader
            // 
            this.bgwDownloader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwDownloader_DoWork);
            this.bgwDownloader.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwDownloader_ProgressChanged);
            this.bgwDownloader.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwDownloader_RunWorkerCompleted);
            // 
            // lblSaveTo
            // 
            this.lblSaveTo.AutoSize = true;
            this.lblSaveTo.Location = new System.Drawing.Point(12, 88);
            this.lblSaveTo.Name = "lblSaveTo";
            this.lblSaveTo.Size = new System.Drawing.Size(48, 15);
            this.lblSaveTo.TabIndex = 5;
            this.lblSaveTo.Text = "Save to:";
            // 
            // tbSaveTo
            // 
            this.tbSaveTo.Location = new System.Drawing.Point(13, 106);
            this.tbSaveTo.Name = "tbSaveTo";
            this.tbSaveTo.ReadOnly = true;
            this.tbSaveTo.Size = new System.Drawing.Size(694, 23);
            this.tbSaveTo.TabIndex = 1;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(713, 106);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(13, 136);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(41, 15);
            this.lblInfo.TabIndex = 6;
            this.lblInfo.Text = "lblInfo";
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 209);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.tbSaveTo);
            this.Controls.Add(this.lblSaveTo);
            this.Controls.Add(this.btnGetFile);
            this.Controls.Add(this.lblFtpSource);
            this.Controls.Add(this.ssMain);
            this.Controls.Add(this.tsMain);
            this.Controls.Add(this.tbFtpSource);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FTP downloader";
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.ssMain.ResumeLayout(false);
            this.ssMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbFtpSource;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton tsbtnAbout;
        private System.Windows.Forms.StatusStrip ssMain;
        private System.Windows.Forms.Label lblFtpSource;
        private System.Windows.Forms.Button btnGetFile;
        private System.Windows.Forms.ToolStripProgressBar pbProgress;
        private System.Windows.Forms.ToolStripStatusLabel lblTransferRate;
        private System.Windows.Forms.ToolStripStatusLabel lblEstTimeLeft;
        private System.ComponentModel.BackgroundWorker bgwDownloader;
        private System.Windows.Forms.Label lblSaveTo;
        private System.Windows.Forms.TextBox tbSaveTo;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.ToolStripStatusLabel lblFileSize;
        private System.Windows.Forms.Label lblInfo;
    }
}

