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
    class Moves
    {
        private int halfMove;
        private String move;
        private String clockTime;
        private String fen;

        public string Fen { get => fen; set => fen = value; }
        public string ClockTime { get => clockTime; set => clockTime = value; }
        public string Move { get => move; set => move = value; }
        public int HalfMove { get => halfMove; set => halfMove = value; }
    }
}
