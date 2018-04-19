using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Configuration;
using System.IO;
using System.Net;

namespace dgt_delay_stream_log_analyser
{
    class analyses
    {
        public AnalyseObject Refresh()
        {
            AnalyseObject aobj = new AnalyseObject();
            DateTime date = DateTime.Now;
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);                
                String logFileName = ConfigurationManager.AppSettings["logFileName"];                
                if (ConfigurationManager.AppSettings["logFileName"] == "*") {
                    logFileName = "dgt-delay-stream." + date.ToString("yyyy-MM-dd") + ".log";
                }
                aobj.Title = ConfigurationManager.AppSettings["title"];
                String liveChessPgn = ConfigurationManager.AppSettings["gamesFileName"];
                if (ConfigurationManager.AppSettings["gamesFileName"] == "*")
                {
                    liveChessPgn = Directory.GetCurrentDirectory() + "\\livechess\\games.pgn";
                }
                aobj.LiveChessPgn = liveChessPgn;
                String logFile = @"";
                if (logFileName.StartsWith("ftp://"))
                {
                    
                    this.ReadFromFtp(logFileName);
                }
                else
                {
                    logFile = Read(logFileName);                    
                }                                
                String[] logFileArray = Regex.Split(logFile, "\n");

                int numberOfLoops = CountWords(logFile, @"=== Start of loop");
                int numberErrors = CountWords(logFile, @"[main] ERROR");

                String lastFileUpload = "N/A";
                String lastLiveChessUpload = "N/A";
                String lastLoop = "N/A";
                String lastError = "N/A";
                String statistic = "N/A";                
                for (int i = logFileArray.Count() - 1; i >= 0; i--)
                {
                    if (lastLiveChessUpload == "N/A")
                    {
                        if (logFileArray[i].Contains("Livechess games.pgn dateTime:"))
                        {
                            lastLiveChessUpload = logFileArray[i].Substring(logFileArray[i].IndexOf(": ") + 1).Replace("#", "").Trim();
                        }
                    }
                    if (lastFileUpload == "N/A")
                    {
                        if (logFileArray[i].Contains("com.jogo.MainRunningClass.upload - FTP publishing"))
                        {
                            lastFileUpload = logFileArray[i].Substring(0, logFileArray[i].IndexOf("."));
                        }
                        if (logFileArray[i].Contains("com.jogo.MainRunningClass.upload - FTP ignored, not changed:"))
                        {
                            lastFileUpload = logFileArray[i].Substring(0, logFileArray[i].IndexOf("."));
                        } 
                    }
                    if (lastLoop == "N/A")
                    {
                        if (logFileArray[i].Contains("=== Start of loop"))
                        {
                            lastLoop = logFileArray[i].Substring(0, logFileArray[i].IndexOf("."));
                        }
                    }
                    if (lastError == "N/A")
                    {
                        if (logFileArray[i].Contains("[main] ERROR"))
                        {
                            lastError = logFileArray[i].Substring(0, logFileArray[i].IndexOf("."));
                        }
                    }
                    if (statistic == "N/A")
                    {
                        if (logFileArray[i].Contains("LogStatistic - Playing"))
                        {
                            statistic = logFileArray[i].Substring(logFileArray[i].IndexOf("Playing"));
                            //Playing 7 # White win 5 # Draw 8 # Black win 0 # 
                        }
                    }
                    if ((lastFileUpload != "N/A") && (lastLoop != "N/A") && (lastError != "N/A") && (statistic != "N/A"))
                    {
                        break;
                    }
                }

                String loopStatus = CheckStatus(date, lastLoop, Convert.ToInt16(ConfigurationManager.AppSettings["loopStatusErrorTime"]));
                String fileUploadStatus = CheckStatus(date, lastFileUpload, Convert.ToInt16(ConfigurationManager.AppSettings["lastFileUploadErrorTime"]));
                String errorStatus = CheckStatus(date, lastError, Convert.ToInt16(ConfigurationManager.AppSettings["errorStatusErrorTime"]), '<');
                String livechessRunStatus = CheckStatus(date, lastLiveChessUpload, Convert.ToInt16(ConfigurationManager.AppSettings["livechessUploadErrorTime"]));
                
                aobj.LastRun = date.ToString();
                aobj.LogFileName = logFileName;

                aobj.LastLoop = lastLoop;
                aobj.LastFileUpload = lastFileUpload;
                aobj.LastError = lastError;
                aobj.LiveChessRun = lastLiveChessUpload;
                aobj.LiveChessRunStatus = livechessRunStatus;
                

                aobj.LoopStatus = loopStatus;
                aobj.FileUploadStatus = fileUploadStatus;
                aobj.ErrorStatus = errorStatus;

                aobj.CountErrors = numberErrors.ToString();
                aobj.CountLoops = numberOfLoops.ToString();
                aobj.ErrorMessage = "";

                if (statistic != "N/A") {
                    aobj.Playing = statistic.Substring(0, statistic.IndexOf("#")).Replace("Playing", "").Trim();
                    aobj.Wins = statistic.Substring(statistic.IndexOf("White win"));
                    aobj.Wins = aobj.Wins.Substring(0, aobj.Wins.IndexOf("#")).Replace("White win", "").Trim();
                    aobj.Draw = statistic.Substring(statistic.IndexOf("Draw"));
                    aobj.Draw = aobj.Draw.Substring(0, aobj.Draw.IndexOf("#")).Replace("Draw", "").Trim();
                    aobj.Loses = statistic.Substring(statistic.IndexOf("Black win"));
                    aobj.Loses = aobj.Loses.Substring(0, aobj.Loses.IndexOf("#")).Replace("Black win", "").Trim();
                }
            } catch (Exception ex){
                aobj.LastRun = date.ToString();
                
                aobj.LogFileName = @"Error";

                aobj.LastLoop = @"";
                aobj.LastFileUpload = @"";
                aobj.LastError = @"";

                aobj.LoopStatus = @"";
                aobj.FileUploadStatus = @"";
                aobj.ErrorStatus = @"N/A";

                aobj.CountErrors = @"";
                aobj.CountLoops = @"";
                
                aobj.ErrorMessage = ex.ToString();                  
            }
            return aobj;
        }

        public string ReadFromFtp(String link)
        {
            var u = new Uri(link);
            var host = u.Host;
            var ui = u.UserInfo.Split(':');
            var user = ui[0];
            var pwd = ui[1];

            WebClient request = new WebClient();
            string url = link;
            request.Credentials = new NetworkCredential(user, pwd);

            try
            {
                byte[] newFileData = request.DownloadData(url);
                string fileString = System.Text.Encoding.UTF8.GetString(newFileData);
                return fileString;
            }
            catch
            {
                return "Error ftp";
                // Do something such as log error, but this is based on OP's original code
                // so for now we do nothing.
            }
        }

        private string CheckStatus(DateTime date, String dateFromLog, Int16 seconds) {
            return CheckStatus(date, dateFromLog, seconds, '>');
        }

        private string CheckStatus(DateTime date, String dateFromLog, Int16 seconds, Char sign)
        {
            String status = "";
            if (dateFromLog != "N/A")
            {
                try { 
                    DateTime dt = DateTime.Parse(dateFromLog);
                    if ((sign == '>') && ((ToUnixTimeStamp(date) - ToUnixTimeStamp(dt)) > seconds))
                    {
                        status = "error";
                    }
                    else if ((sign == '<') && ((ToUnixTimeStamp(date) - ToUnixTimeStamp(dt)) < seconds))
                    {
                        status = "error";
                    }
                }
                catch
                {
                    status = "error";
                }
            }
            return status;
        }

        private double ToUnixTimeStamp(DateTime dt)
        {
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            double unixDateTime = (dt.ToUniversalTime() - epoch).TotalSeconds;
            return unixDateTime;
        }

        private int CountWords(string text, string word) {
            int count = (text.Length - text.Replace(word, "").Length) / word.Length;
            return count;
        }

        private String Read(String file) {
            try
            {
                using (FileStream fileStream = new FileStream(
                    file,
                    FileMode.Open,
                    FileAccess.Read,
                    FileShare.ReadWrite))
                {
                    using (StreamReader streamReader = new StreamReader(fileStream))
                    {
                        return streamReader.ReadToEnd();
                    }
                }
            }
            catch 
            {
                return "Error read log";
            }
        }
    }
}
