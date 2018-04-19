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
using System.Diagnostics;

namespace dgt_delay_stream_log_analyser
{
    class ParsePgn
    {
        private PGN pgn;
        public PGN Pgn { get => pgn; set => pgn = value; }

        public ParsePgn(String stringPGN)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            
            string[] lines = stringPGN.Split(new string[] { "\n" }, StringSplitOptions.None);

            this.Pgn = new PGN();
            this.Pgn.Pgn = stringPGN;
            this.Pgn.EventTag = getTag(lines, "Event");
            this.Pgn.Site = getTag(lines, "Site");
            this.Pgn.Date = getTag(lines, "Date");
            this.Pgn.Round = getTag(lines, "Round");
            this.Pgn.White = getTag(lines, "White");
            this.Pgn.Black = getTag(lines, "Black");
            this.Pgn.Result = getTag(lines, "Result");
            this.Pgn.WhiteElo = getTag(lines, "WhiteElo");
            this.Pgn.BlackElo = getTag(lines, "BlackElo");
            this.Pgn.LiveChessVersion = getTag(lines, "LiveChessVersion");
            this.Pgn.Eco = getTag(lines, "ECO");
            parseMoves();
            double halfmoves = this.Pgn.Moves.Count();            
            for(int ii = 0; ii < this.Pgn.Moves.Length; ii = ii + 2) 
            {
                if ((this.Pgn.Moves.Length-1 >= ii) && (this.Pgn.Moves[ii] != null) && (this.Pgn.Moves[ii].Move != "") && (this.Pgn.Moves[ii].Move != null))
                {
                    this.Pgn.NrMoves = (Math.Round((double.Parse(ii.ToString()) + 1) / 2, MidpointRounding.AwayFromZero)).ToString();
                    this.Pgn.NrMoves = this.Pgn.NrMoves + "w";
                }
                else
                {
                    break;
                }
                if ((this.Pgn.Moves.Length - 1 >= (ii+1)) && (this.Pgn.Moves[ii+1] != null) && (this.Pgn.Moves[ii+1].Move != "") && (this.Pgn.Moves[ii+1].Move != null))
                {
                    this.Pgn.NrMoves = (Math.Round((double.Parse(ii.ToString()) + 1) / 2, MidpointRounding.AwayFromZero)).ToString();
                    this.Pgn.NrMoves = this.Pgn.NrMoves + "b";
                }
                if ((this.Pgn.Moves.Length - 1 >= ii) && (this.Pgn.Moves[ii] != null) && (this.Pgn.Moves[ii].ClockTime != "") && (this.Pgn.Moves[ii].ClockTime != null))
                {
                    this.Pgn.WhiteTime = this.Pgn.Moves[ii].ClockTime;
                }
                if ((this.Pgn.Moves.Length - 1 >= (ii + 1)) && (this.Pgn.Moves[ii+1] != null) && (this.Pgn.Moves[ii+1].ClockTime != "") && (this.Pgn.Moves[ii + 1].ClockTime != null))
                {
                    this.Pgn.BlackTime = this.Pgn.Moves[ii+1].ClockTime;                    
                }
            }

            // checking overtimes
            this.Pgn.WhiteOverTime = false;
            this.Pgn.BlackOverTime = false;
            if (ConfigurationManager.AppSettings["timeControls"] != "")
            {
                this.Pgn.WhiteOverTime = checkingOvertime(2);
                this.Pgn.BlackOverTime = checkingOvertime(3);

            }
        }

        private bool checkingOvertime(int startIndex)
        {
            string[] timeControlsArr = ConfigurationManager.AppSettings["timeControls"].Split(',');
            string[] addingTimeArr = ConfigurationManager.AppSettings["addingTime"].Split(',');
            int addingTime = 0;
            for (int ii = startIndex; ii < this.Pgn.Moves.Length; ii = ii + 2)
            {
                if ((this.Pgn.Moves[ii] == null) || (this.Pgn.Moves[ii].Move == "") && (this.Pgn.Moves[ii].Move == null))
                {
                    break;
                }
                if ((this.Pgn.Moves[ii - 2].ClockTime != null) && (this.Pgn.Moves[ii].ClockTime != null) &&
                        (this.Pgn.seconds(this.Pgn.Moves[ii].ClockTime) > this.Pgn.seconds(this.Pgn.Moves[ii - 2].ClockTime) + 5 * 60))
                {
                    int iCnt = -1;
                    foreach (string ot in timeControlsArr)
                    {
                        iCnt++;
                        if ((((ii+2)/2) < (int.Parse(ot))) && (iCnt == addingTime))
                        {
                            return true;
                        }
                        if ((((ii + 2) / 2) == (int.Parse(ot))) && (iCnt == addingTime))
                        {
                            if (this.Pgn.seconds(this.Pgn.Moves[ii].ClockTime) < int.Parse(addingTimeArr[iCnt]) * 60)
                            {
                                return true;
                            }
                            
                        }
                        addingTime++;
                    }
                }
            }
            return false;
        }

        public String getTag(String[] PGNlines, String tagName)
        {
            string value = @"";
            foreach (String ll in PGNlines)
            {
                if (ll.IndexOf("[" + tagName + " \"") >= 0)
                {
                    value = ll.Replace("[" + tagName + " \"", "");
                    value = value.Replace("\"]", "");
                    return value.Replace("\r", " ").Replace("\n", " ").Replace("\t", " ").Trim();
                }
            }
            return value;
        }

        public void convertToFen()
        {
            this.pgn.PgnGameFen = convertPGNtoFEN(this.pgn.Pgn);
            parseMoves();
        }

        private String convertPGNtoFEN(String pgnGame)
        {
            String output = "";
            try
            {
                System.IO.File.WriteAllText(@"game.pgn", pgnGame);

                Process cmd = new Process();
                cmd.StartInfo.FileName = "pgn-extract.exe";
                cmd.StartInfo.Arguments = "game.pgn --fencomments";
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.RedirectStandardError = true;
                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.UseShellExecute = false;
                cmd.Start();

                output = cmd.StandardOutput.ReadToEnd();
                String errors = cmd.StandardError.ReadToEnd();
                cmd.WaitForExit();
            }
            catch
            {

            }
            return output;
        }
        private void parseMoves()
        {
            String usingPGN = this.pgn.Pgn;
            if((this.pgn.PgnGameFen != null) && (this.pgn.PgnGameFen != ""))
            {
                usingPGN = this.pgn.PgnGameFen;
            }
            usingPGN = usingPGN.Substring(usingPGN.LastIndexOf("\"]") + 2).Trim();
            usingPGN = usingPGN.Replace("\r", " ");
            usingPGN = usingPGN.Replace("\n", " ");
            usingPGN = usingPGN.Replace("  ", " ");
            usingPGN = usingPGN.Replace("  ", " ");
            usingPGN = usingPGN.Replace("  ", " ");
            usingPGN = usingPGN.Replace("} ", "}@");
            usingPGN = usingPGN.Replace(". ", ".@");
            usingPGN = usingPGN.Replace(" {", "@{");
            usingPGN = usingPGN.Replace("} {", "}@{");
            usingPGN = usingPGN.Replace(" *", "@END");
            usingPGN = usingPGN.Replace("@*", "@END");
            usingPGN = usingPGN.Replace(" 1-0", "@END");
            usingPGN = usingPGN.Replace("@1-0", "@END");
            usingPGN = usingPGN.Replace(" 1/2-1/2", "@END");
            usingPGN = usingPGN.Replace("@1/2-1/2", "@END");
            usingPGN = usingPGN.Replace(" 0-1", "@END");
            usingPGN = usingPGN.Replace("@0-1", "@END");
            for(int ii = 1; ii < 500; ii++)
            {
                usingPGN = usingPGN.Replace(ii+". ", ii+".@");
                usingPGN = usingPGN.Replace(" " + ii + ".", "@" + ii + ".");
            }
            String[] pgnArray = usingPGN.Split('@');
            int halfMove = -1;
            this.pgn.Moves = new Moves[0];
            foreach(String item in pgnArray)
            {
                if (item.IndexOf("%clk") >= 0)
                {
                    // clock time 
                    // { [%clk 1:30:58] }
                    this.pgn.Moves[halfMove].ClockTime = item.Trim().Replace("{[%clk ", "").Replace("]}", "").Replace("{ [%clk ", "").Replace("] }", "");
                }
                else if (item.IndexOf("/") >= 0)
                {
                    // FEN
                    // {rnbqkbnr/pp1ppppp/8/2p5/4P3/8/PPPP1PPP/RNBQKBNR w KQkq c6 0 2 }
                    this.pgn.Moves[halfMove].Fen = item.Trim().Replace("{", "").Replace("}", "").Trim();
                }
                else if (item.IndexOf("END") >= 0)
                {
                    // END
                    break;
                }
                else if (item.IndexOf(".") >= 0)
                {
                    // move number
                    // 1.
                    // 1...
                }
                else
                {
                    // move
                    String[] move_arr = item.Trim().Split(' ');
                    foreach(string move in move_arr) { 
                        halfMove++;
                    
                        Moves[] movesArr = this.pgn.Moves;
                        Array.Resize<Moves>(ref movesArr, movesArr.Length + 1);
                        this.pgn.Moves = movesArr;
                        this.pgn.Moves[halfMove] = new Moves();
                        this.pgn.Moves[halfMove].HalfMove = halfMove;
                        this.pgn.Moves[halfMove].Move = move;
                    }
                }
            }
        }
    }
}
