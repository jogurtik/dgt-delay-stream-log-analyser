using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Configuration;

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
                String logFile = Read(logFileName);
                String[] logFileArray = Regex.Split(logFile, "\n");

                int numberOfLoops = CountWords(logFile, @"=== Start of loop ===");
                int numberErrors = CountWords(logFile, @"[main] ERROR");

                String lastFileUpload = "N/A";
                String lastLoop = "N/A";
                String lastError = "N/A";
                for (int i = logFileArray.Count() - 1; i >= 0; i--)
                {
                    if (lastFileUpload == "N/A")
                    {
                        if (logFileArray[i].Contains("com.jogo.MainRunningClass.upload - FTP publishing"))
                        {
                            lastFileUpload = logFileArray[i].Substring(0, logFileArray[i].IndexOf("[main]"));
                        }
                    }
                    if (lastLoop == "N/A")
                    {
                        if (logFileArray[i].Contains("=== Start of loop ==="))
                        {
                            lastLoop = logFileArray[i].Substring(0, logFileArray[i].IndexOf("[main]"));
                        }
                    }
                    if (lastError == "N/A")
                    {
                        if (logFileArray[i].Contains("[main] ERROR"))
                        {
                            lastError = logFileArray[i].Substring(0, logFileArray[i].IndexOf("[main]"));
                        }
                    }
                    if ((lastFileUpload != "N/A") && (lastLoop != "N/A") && (lastError != "N/A"))
                    {
                        break;
                    }
                }

                String loopStatus = CheckStatus(date, lastLoop, 1 * 60);
                String fileUploadStatus = CheckStatus(date, lastFileUpload, 1 * 60);
                String errorStatus = CheckStatus(date, lastError, 15 * 60);

                aobj.LastRun = date.ToString();
                aobj.LogFileName = logFileName;

                aobj.LastLoop = lastLoop;
                aobj.LastFileUpload = lastFileUpload;
                aobj.LastError = lastError;

                aobj.LoopStatus = loopStatus;
                aobj.FileUploadStatus = fileUploadStatus;
                aobj.ErrorStatus = errorStatus;

                aobj.CountErrors = numberErrors.ToString();
                aobj.CountLoops = numberOfLoops.ToString();
                aobj.ErrorMessage = "";
            } catch (Exception ex){
                aobj.LastRun = date.ToString();
                aobj.LogFileName = @"Error";

                aobj.LastLoop = @"";
                aobj.LastFileUpload = @"";
                aobj.LastError = @"";

                aobj.LoopStatus = @"";
                aobj.FileUploadStatus = @"";
                aobj.ErrorStatus = @"";

                aobj.CountErrors = @"";
                aobj.CountLoops = @"";

                aobj.ErrorMessage = ex.ToString();  
            }
            return aobj;
        }

        private string CheckStatus(DateTime date, String dateFromLog, Int16 seconds) {
            String status = "";
            if (dateFromLog != "N/A")
            {
                DateTime dt = DateTime.Parse(dateFromLog);

                if ((ToUnixTimeStamp(date) - ToUnixTimeStamp(dt)) > seconds)
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
            string fileString = System.IO.File.ReadAllText(file);

            return fileString;
        }
    }
}
