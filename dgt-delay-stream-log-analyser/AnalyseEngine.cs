using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dgt_delay_stream_log_analyser
{
    class AnalyseEngine
    {
        private Process cmd;
        public String lastFen;
        public List<String> outputLines;

        public AnalyseEngine()
        {
            outputLines = new List<String>();
        }

        ~AnalyseEngine()  // destructor
        {
            this.Dispose();
        }

        /// <summary>
        /// Dispose all used resources.
        /// </summary>
        public void Dispose()
        {
            if ((cmd != null) && (!cmd.HasExited))
            {
                SendLine(cmd, "stop");
                SendLine(cmd, "quit");
                cmd.Kill();
            }
        }

        // http://wbec-ridderkerk.nl/html/UCIProtocol.html
        // http://support.stockfishchess.org/kb/advanced-topics/uci-protocol
        public void runEngine()
        {
            try
            {
                int use_processors = Environment.ProcessorCount / 2;
                cmd = new Process();
                cmd.StartInfo.FileName = "stockfish_9_x64.exe";
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.RedirectStandardError = true;
                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.UseShellExecute = false;
                cmd.Start();

                SendLine(cmd, "position fen " + lastFen);
                SendLine(cmd, "setoption name MultiPV value 6");
                SendLine(cmd, "setoption name Threads value " + use_processors);
                SendLine(cmd, "go infinite");

                while (!cmd.StandardOutput.EndOfStream)
                {
                    outputLines.Add(cmd.StandardOutput.ReadLine());
                }               
            }
            catch
            {
                // log errors
            }
        }

        private void SendLine(Process cmd, string command)
        {
            cmd.StandardInput.WriteLine(command);
            cmd.StandardInput.Flush();
        }
    }
}
