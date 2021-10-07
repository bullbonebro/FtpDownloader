using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FtpDownloader
{
    public class DownloadInfo
    {
        /// <summary>
        /// KB
        /// </summary>
        public int FileSize { get; set; }
        /// <summary>
        /// 0 - 100
        /// </summary>
        public int Progress { get; set; }
        /// <summary>
        /// KB/s
        /// </summary>
        public int TransferRate { get; set; }
        /// <summary>
        /// String
        /// </summary>
        public string EstimatedTimeLeft { get; set; }

        public string Info { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="file_size"></param>
        /// <param name="progress"></param>
        /// <param name="transfer_rate"></param>
        /// <param name="estimated_time_left"></param>
        /// <param name="info"></param>
        public DownloadInfo(int file_size, int progress, int transfer_rate, string estimated_time_left, string info)
        {
            this.FileSize = file_size;
            this.Progress = progress;
            this.TransferRate = transfer_rate;
            this.EstimatedTimeLeft = estimated_time_left;
            this.Info = info;
        }
    }
}
