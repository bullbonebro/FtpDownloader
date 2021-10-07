using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FtpDownloader
{
    public partial class fMain : Form
    {
        private delegate void DelegateShowDownloadInfo(DownloadInfo download_info);

        public fMain()
        {
            InitializeComponent();
            this.Text = Settings.AssemblyProduct;
            tbSaveTo.Text = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Upload");
            lblInfo.Text = "";
        }

        private void ShowDownloadInfo(DownloadInfo download_info)
        {
            lblFileSize.Text = download_info.FileSize.ToString() + " KB";
            pbProgress.Value = download_info.Progress;
            lblTransferRate.Text = download_info.TransferRate.ToString() + " KB/s";
            lblEstTimeLeft.Text = download_info.EstimatedTimeLeft + " s";
            lblInfo.Text = download_info.Info;
            this.Refresh();
        }

        private void tsbtnAbout_Click(object sender, EventArgs e)
        {
            using (fAbout f = new())
            {
                f.ShowDialog();
            }
        }

        /// <summary>
        /// BackGround Worker realization
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwDownloader_DoWork(object sender, DoWorkEventArgs e)
        {
            byte[] buffer = new byte[1024];
            int total_bytes = 0;
            int bytes;
            System.IO.Stream file_stream;
            int file_length;
            int transfer_rate; //KB/s
            string est_time_left = "";
            DateTime start_dt;
            DateTime now;
            int seconds_from_start = 0;
            DownloadInfo download_info;
            DelegateShowDownloadInfo delegate_show_info = new DelegateShowDownloadInfo(ShowDownloadInfo);
            try
            {
                //Gathering file information...
                download_info = new DownloadInfo(0, 0, 0, "Gathering file information...", "Gathering file information...");
                this.Invoke(delegate_show_info, new object[] { download_info });

                //Calculating total size...
                FtpWebRequest ftp_request = (FtpWebRequest)WebRequest.Create(tbFtpSource.Text);
                ftp_request.Method = WebRequestMethods.Ftp.GetFileSize;
                file_length = (int)ftp_request.GetResponse().ContentLength;

                //Displaying file size...
                download_info = new DownloadInfo(file_length / 1024, 0, 0, "Calculating estimated time left...", "Calculating estimated time left...");
                this.Invoke(delegate_show_info, new object[] { download_info });

                //Downloading file...
                ftp_request = (FtpWebRequest)WebRequest.Create(tbFtpSource.Text);
                ftp_request.Method = WebRequestMethods.Ftp.DownloadFile;
                System.IO.Stream download_stream = ftp_request.GetResponse().GetResponseStream();
                string downloaded_file_path = Path.Combine(tbSaveTo.Text, ftp_request.RequestUri.LocalPath.Replace("/", ""));
                file_stream = System.IO.File.Create(downloaded_file_path);
                bytes = 1;
                start_dt = DateTime.Now;
                do
                {
                    bytes = download_stream.Read(buffer, 0, 1024);
                    if (bytes > 0)
                    {
                        file_stream.Write(buffer, 0, bytes);
                        total_bytes += bytes;
                    }
                    now = DateTime.Now;
                    seconds_from_start = (int)System.Math.Abs((start_dt - now).TotalSeconds);
                    //KB/s
                    transfer_rate = (total_bytes) / (seconds_from_start > 0 ? seconds_from_start : 1) / 1000;
                    if (file_length > 0)
                    {
                        est_time_left = ((file_length - total_bytes) / transfer_rate / 1000).ToString();
                    }
                    float current_progress = ((float)total_bytes / file_length) * 100;

                    //Displaying progress...
                    download_info = new DownloadInfo(file_length / 1024, (int)current_progress, transfer_rate, est_time_left, "Downloading...");
                    this.Invoke(delegate_show_info, new object[] { download_info });
                } while (bytes > 0);
                file_stream.Close();
                download_stream.Close();

                //Displaying Download complete...
                download_info = new DownloadInfo(file_length / 1024, 100, 0, "0", "Download complete!");
                this.Invoke(delegate_show_info, new object[] { download_info });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Async streams realization
        /// </summary>
        /// <returns></returns>
        private async Task DownloadFile()
        {
            byte[] buffer = new byte[1024];
            int total_bytes = 0;
            int bytes;
            System.IO.Stream file_stream;
            int file_length;
            int transfer_rate; //KB/s
            string est_time_left = "";
            DateTime start_dt;
            DateTime now;
            int seconds_from_start = 0;
            DownloadInfo download_info;
            DelegateShowDownloadInfo delegate_show_info = new DelegateShowDownloadInfo(ShowDownloadInfo);
            WebResponse response;
            try
            {
                //Gathering file information...
                download_info = new DownloadInfo(0, 0, 0, "Gathering file information...", "Gathering file information...");
                this.Invoke(delegate_show_info, new object[] { download_info });

                //Calculating total size...
                FtpWebRequest ftp_request = (FtpWebRequest)WebRequest.Create(tbFtpSource.Text);
                ftp_request.Method = WebRequestMethods.Ftp.GetFileSize;
                response = await ftp_request.GetResponseAsync();
                file_length = (int)response.ContentLength;

                //Displaying file size...
                download_info = new DownloadInfo(file_length / 1024, 0, 0, "Calculating estimated time left...", "Calculating estimated time left...");
                this.Invoke(delegate_show_info, new object[] { download_info });

                //Downloading file...
                ftp_request = (FtpWebRequest)WebRequest.Create(tbFtpSource.Text);
                ftp_request.Method = WebRequestMethods.Ftp.DownloadFile;
                response = await ftp_request.GetResponseAsync();
                System.IO.Stream download_stream = response.GetResponseStream();
                string downloaded_file_path = Path.Combine(tbSaveTo.Text, ftp_request.RequestUri.LocalPath.Replace("/", ""));
                file_stream = System.IO.File.Create(downloaded_file_path);
                bytes = 1;
                start_dt = DateTime.Now;
                do
                {
                    bytes = await download_stream.ReadAsync(buffer, 0, 1024);
                    if (bytes > 0)
                    {
                        await file_stream.WriteAsync(buffer, 0, bytes);
                        total_bytes += bytes;
                    }
                    now = DateTime.Now;
                    seconds_from_start = (int)System.Math.Abs((start_dt - now).TotalSeconds);
                    //KB/s
                    transfer_rate = (total_bytes) / (seconds_from_start > 0 ? seconds_from_start : 1) / 1000;
                    if (file_length > 0)
                    {
                        est_time_left = ((file_length - total_bytes) / transfer_rate / 1000).ToString();
                    }
                    float current_progress = ((float)total_bytes / file_length) * 100;

                    //Displaying progress...
                    download_info = new DownloadInfo(file_length / 1024, (int)current_progress, transfer_rate, est_time_left, "Downloading...");
                    this.Invoke(delegate_show_info, new object[] { download_info });
                } while (bytes > 0);
                file_stream.Close();
                download_stream.Close();

                //Displaying Download complete...
                download_info = new DownloadInfo(file_length / 1024, 100, 0, "0", "Download complete!");
                this.Invoke(delegate_show_info, new object[] { download_info });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog f = new())
            {
                try
                {
                    f.SelectedPath = tbSaveTo.Text;
                }
                catch (Exception)
                {
                }
                if (f.ShowDialog() == DialogResult.OK)
                {
                    tbSaveTo.Text = f.SelectedPath;
                }
            }
        }

        private void btnGetFile_Click(object sender, EventArgs e)
        {
            tbFtpSource.ReadOnly = true;
            btnGetFile.Enabled = false;
            btnBrowse.Enabled = false;

            //BackGround Worker realization:
            //bgwDownloader.RunWorkerAsync();

            //Async streams realization
            DownloadFileAsync();
        }

        private async void DownloadFileAsync()
        {
            try
            {
                await DownloadFile();
                tbFtpSource.ReadOnly = false;
                btnGetFile.Enabled = true;
                btnBrowse.Enabled = true;
            }
            catch (Exception)
            {
            }
        }

        private void bgwDownloader_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbProgress.Value = e.ProgressPercentage;
        }

        private void bgwDownloader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            tbFtpSource.ReadOnly = false;
            btnGetFile.Enabled = true;
            btnBrowse.Enabled = true;
        }
    }
}
