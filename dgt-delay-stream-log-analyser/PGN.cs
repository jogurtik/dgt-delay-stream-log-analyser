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
    class PGN
    {
        private String pgn;
        private String eventTag;
        private String site;
        private String date;
        private String round;
        private String white;
        private String black;
        private String result;
        private String whiteElo;
        private String blackElo;
        private String liveChessVersion;
        private String eco;
        private String nrMoves;
        private String whiteTime;
        private String blackTime;
        private String pgnGameFen;
        private Moves[] moves;
        private bool whiteOverTime;
        private bool blackOverTime;

        public string Pgn { get => pgn; set => pgn = value; }
        public string EventTag { get => eventTag; set => eventTag = value; }
        public string Site { get => site; set => site = value; }
        public string Date { get => date; set => date = value; }
        public string Round { get => round; set => round = value; }
        public string White { get => white; set => white = value; }
        public string Black { get => black; set => black = value; }
        public string Result { get => result; set => result = value; }
        public string WhiteElo { get => whiteElo; set => whiteElo = value; }
        public string BlackElo { get => blackElo; set => blackElo = value; }
        public string LiveChessVersion { get => liveChessVersion; set => liveChessVersion = value; }
        public string Eco { get => eco; set => eco = value; }
        public string NrMoves { get => nrMoves; set => nrMoves = value; }
        public string WhiteTime { get => whiteTime; set => whiteTime = value; }
        public string BlackTime { get => blackTime; set => blackTime = value; }
        public string PgnGameFen { get => pgnGameFen; set => pgnGameFen = value; }
        public bool WhiteOverTime { get => whiteOverTime; set => whiteOverTime = value; }
        public bool BlackOverTime { get => blackOverTime; set => blackOverTime = value; }
        public int whiteTimeSecondsTag { get => seconds(WhiteTime); }
        public int blackTimeSecondsTag { get => seconds(BlackTime); }
        internal Moves[] Moves { get => moves; set => moves = value; }

        public int seconds(String time)
        {
            int seconds1 = -1;
            if ((time != null) && (time != "--:--:--") && (time.Length > 0))
            {
                string[] timeArr = time.Split(':');
                seconds1 = int.Parse(timeArr[0]) * 60 * 60 + int.Parse(timeArr[1]) * 60 + int.Parse(timeArr[2]);
            }
            return seconds1;
        }
    }
}
