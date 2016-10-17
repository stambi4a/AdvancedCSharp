namespace BashSoft.Network
{
    using System;
    using System.Net;
    using System.Threading.Tasks;

    using SimpleJudge;

    public class DownloadManager
    {
        public static void Download(string fileURL)
        {
            WebClient webClient = new WebClient();
            try
            {
                OutputWriter.WriteMessageOnNewLine("Started downloading: ");
                string nameOfFile = ExtractNameOfFile(fileURL);
                string pathToDonwload = SessionData.currentPath + "/" + nameOfFile;
                webClient.DownloadFile(fileURL, pathToDonwload);
                OutputWriter.WriteMessageOnNewLine("Download complete");
            }
            catch (WebException ex)
            {
                OutputWriter.DisplayException(ex.Message);
            }
        }

        public static void DownloadAsync(string fileURL)
        {
            Task.Run(() => Download(fileURL));
        }

        private static string ExtractNameOfFile(string fileURL)
        {
            int indexOfLastBackSlash = fileURL.LastIndexOf("/");
            if (indexOfLastBackSlash != -1)
            {
                return fileURL.Substring(indexOfLastBackSlash + 1);
            }
            else
            {
                throw new WebException(ExceptionMessages.InvalidPath);
            }       
        }
    }
}
