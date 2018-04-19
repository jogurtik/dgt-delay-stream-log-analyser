using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Threading;
using System.Globalization;
using System.Timers;

namespace dgt_delay_stream_log_analyser
{    
    public partial class formGameDetails : Form
    {
        private Panel[,] _chessBoardPanels;
        private int halfMovePositionShow;
        private AnalyseEngine analyseEngine;
        private string pgnGame;
        private ParsePgn parsePGN;
        private Thread thread;
        private System.Windows.Forms.Timer t;

        public formGameDetails()
        {
            InitializeComponent();
            halfMovePositionShow = 10000;
        }

        ~formGameDetails()
        {
            finishAnalyses();
        }

        public void showGame()
        {
            showGame("");
        }

        public void showGame(string pgnGame1)
        {
            if (pgnGame1 != "") { 
                pgnGame = pgnGame1;
            }
            ParsePgn oldParsePGN = parsePGN;
            parsePGN = new ParsePgn(pgnGame);
            if ((oldParsePGN == null) || (oldParsePGN.Pgn.Round != parsePGN.Pgn.Round))
            {
                finishAnalyses();
                txtAnalyse.Text = "";
                rpAnalyse.Hide();                
                halfMovePositionShow = 10000;
            }
            this.Text = parsePGN.Pgn.Round + ". " + parsePGN.Pgn.White + " " + parsePGN.Pgn.WhiteElo + " vs. " + parsePGN.Pgn.Black + " " + parsePGN.Pgn.BlackElo;
            rlTitle.Text = parsePGN.Pgn.Round + ". " + parsePGN.Pgn.White + " " + parsePGN.Pgn.WhiteElo + " vs. " + parsePGN.Pgn.Black + " " + parsePGN.Pgn.BlackElo;
            rlTitle.Font = new Font("Tahoma", 10, FontStyle.Bold);
            if (rlTitle.Text.Length > 40)
            {
                rlTitle.Font = new Font("Tahoma", 9, FontStyle.Bold);
            }
            if (rlTitle.Text.Length > 50)
            {
                rlTitle.Font = new Font("Tahoma", 8, FontStyle.Bold);
            }
            if (rlTitle.Text.Length > 60)
            {
                rlTitle.Font = new Font("Tahoma", 7, FontStyle.Bold);
            }

            parsePGN.convertToFen();
            String lastFen_orig = parsePGN.Pgn.Moves[parsePGN.Pgn.Moves.Length-1].Fen;
            String lastFen = prepareFenForShowing(lastFen_orig);
            if(halfMovePositionShow < 1000)
            {
                // get fen for halfMovePositionShow
                if (halfMovePositionShow >= 0)
                {
                    lastFen = prepareFenForShowing(parsePGN.Pgn.Moves[halfMovePositionShow].Fen);
                } else
                {
                    lastFen = prepareFenForShowing("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1");
                }
            }
            createBoard(lastFen);
            //this.Width = 8 * 60 + 10 + 25;
            //this.Height = 8 * 60 + 10 + 25 + 300;

            int ads = 0;
            if (parsePGN.Pgn.Moves.Length - 1 > 24)
            {
                ads = int.Parse(Math.Round(double.Parse((parsePGN.Pgn.Moves.Length-1).ToString()) / 2, MidpointRounding.AwayFromZero).ToString());
            }

            String output = "";
            int iCnt = -1;
            foreach(Moves moves in parsePGN.Pgn.Moves)
            {
                iCnt++;
                if ((iCnt % 2) == 0)
                {
                    output += "" + ((iCnt / 2) + 1)  + ". ";
                }
                output += "" + moves.Move + " ";
            }
            output += Environment.NewLine + "Result: " + parsePGN.Pgn.Result;
            if(parsePGN.Pgn.Result == "*") { 
                output += "   |   White time: " + parsePGN.Pgn.WhiteTime + "   |   Black time: " + parsePGN.Pgn.BlackTime;
            }
            txtMoves.Text = output + Environment.NewLine + "FEN: " + lastFen_orig;

            txtMoves.SelectionStart = txtMoves.Text.Length;
            txtMoves.ScrollToCaret();
        }

        private String prepareFenForShowing(String lastFen)
        {
            if (lastFen != null)
            {
                for (int ii = 2; ii <= 8; ii++)
                {
                    lastFen = lastFen.Replace(ii.ToString(), "1".PadLeft(ii, '1'));
                }
                lastFen = lastFen.Replace("/", "");
            }
            else
            {
                lastFen = "";
            }
        
            return lastFen;
        }

        private void createBoard(String LastFen)
        {
            int tileSize = 40;
            if(Screen.PrimaryScreen.Bounds.Height >= 1080) {
                tileSize = 50;
            }
            rpPanelBoard.Height = tileSize * 8 + 10;
            this.MinimumSize = new Size(rpPanelBoard.Height + 40, rpPanelBoard.Height);
            const int gridSize = 8;
            var clr1 = Color.DarkGray;
            var clr2 = Color.White;

            if (_chessBoardPanels == null)
            {
                // initialize the "chess board"
                _chessBoardPanels = new Panel[gridSize, gridSize];
            }

            // double for loop to handle all rows and columns
            for (var n = 0; n < gridSize; n++)
            {
                for (var m = 0; m < gridSize; m++)
                {
                    int position = m * 8 + n;
                    Panel newPanel;

                    if (_chessBoardPanels[n, m] == null)
                    {
                        // create new Panel control which will be one 
                        // chess board tile
                        newPanel = new Panel
                        {
                            Size = new Size(tileSize, tileSize),
                            Location = new Point(tileSize * n + 10, tileSize * m)
                        };

                        // add to Form's Controls so that they show up
                        rpPanelBoard.Controls.Add(newPanel);

                        // add to our 2d array of panels for future use
                        _chessBoardPanels[n, m] = newPanel;
                    }
                    else
                    {
                        newPanel = _chessBoardPanels[n, m];
                    }

                    // color the backgrounds
                    if (n % 2 == 0)
                    {
                        newPanel.BackColor = m % 2 != 0 ? clr1 : clr2;
                    }
                    else
                    {
                        newPanel.BackColor = m % 2 != 0 ? clr2 : clr1;
                    }
                    ShowFigurines(LastFen, position, newPanel, tileSize);
                }
            }
        }

        private void ShowFigurines(String LastFen, int position, Panel newPanel, int tileSize)
        {
            if ((LastFen == "") || (LastFen == ""))
            {
                LastFen = "rnbqkbnr/pppppppp/11111111/11111111/11111111/11111111/PPPPPPPP/RNBQKBNR w KQkq - 0 1";

            }
            Image img = null;
            switch(LastFen[position])
            {
                case '1': img = null;  break;
                case 'K': img = (Image)Image.FromFile("images/wk.png"); break;
                case 'Q': img = (Image)Image.FromFile("images/wq.png"); break;
                case 'N': img = (Image)Image.FromFile("images/wn.png"); break;
                case 'B': img = (Image)Image.FromFile("images/wb.png"); break;
                case 'R': img = (Image)Image.FromFile("images/wr.png"); break;
                case 'P': img = (Image)Image.FromFile("images/wp.png"); break;
                case 'k': img = (Image)Image.FromFile("images/bk.png"); break;
                case 'q': img = (Image)Image.FromFile("images/bq.png"); break;
                case 'n': img = (Image)Image.FromFile("images/bn.png"); break;
                case 'b': img = (Image)Image.FromFile("images/bb.png"); break;
                case 'r': img = (Image)Image.FromFile("images/br.png"); break;
                case 'p': img = (Image)Image.FromFile("images/bp.png"); break;
            }
            if ((img == null) || (tileSize == 60)) { 
                newPanel.BackgroundImage = img;
            } else {
                Image resized = ResizeImage(img, tileSize, tileSize);
                newPanel.BackgroundImage = resized;
            }
        }

        public Image ResizeImage(Image image, int newWidth, int newHeight)
        {
            Image newImage = new Bitmap(newWidth, newHeight);
            using (Graphics graphicsHandle = Graphics.FromImage(newImage))
            {
                graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight);
            }
            return newImage;
        }

        public static string HideInternalNote(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }
            if (input == string.Empty)
            {
                return input;
            }
            var inputWithBracePairsRemoved = RemovePairedBraces(input);
            var result = RemoveAllBraces(inputWithBracePairsRemoved);
            return result;
        }

        private static string RemoveAllBraces(string input)
        {
            return input
                .Replace("{", string.Empty)
                .Replace("}", string.Empty);
        }

        private static string RemovePairedBraces(string input)
        {
            var expression = new Regex("{[^{]*?}");
            // OR
            // var expression = new Regex("{[^{}]*}");

            var previous = input;
            string current;
            while (true)
            {
                current = expression.Replace(previous, string.Empty);
                if (current == previous)
                {
                    break;
                }
                previous = current;
            }
            return current;
        }

        private void rbStart_Click(object sender, EventArgs e)
        {
            halfMovePositionShow = -1;
            showGame();
        }

        private void rbEnd_Click(object sender, EventArgs e)
        {
            halfMovePositionShow = 10000;
            showGame();
        }

        private void rbNext_Click(object sender, EventArgs e)
        {
            halfMovePositionShow += 1;
            if (halfMovePositionShow >= parsePGN.Pgn.Moves.Length)
            {
                halfMovePositionShow = 10000;
            }
            showGame();
        }

        private void rbPrevious_Click(object sender, EventArgs e)
        {
            if (halfMovePositionShow >= parsePGN.Pgn.Moves.Length)
            {
                halfMovePositionShow = parsePGN.Pgn.Moves.Length-1;
            }
            halfMovePositionShow -= 1;
            if (halfMovePositionShow < -1)
            {
                halfMovePositionShow = -1;
            }
            showGame();
        }

        private void rbAnalyse_Click(object sender, EventArgs e)
        {            
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            String engine = ConfigurationManager.AppSettings["engine"];

            if ((engine != null) && (engine != ""))
            {
                String lastFen = "";
                if (halfMovePositionShow < 1000)
                {
                    // get fen for halfMovePositionShow
                    if (halfMovePositionShow >= 0)
                    {
                        //lastFen = prepareFenForShowing(parsePGN.Pgn.Moves[halfMovePositionShow].Fen);
                        lastFen = parsePGN.Pgn.Moves[halfMovePositionShow].Fen;
                    }
                    else
                    {
                        lastFen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
                    }
                } else
                {
                    lastFen = parsePGN.Pgn.Moves[parsePGN.Pgn.Moves.Length - 1].Fen;
                }

                analysePosition(lastFen);
            }
        }

        // Specify what you want to happen when the Elapsed event is raised.
        void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                List<String> outputLines = new List<string>(analyseEngine.outputLines);
                String lastFen = analyseEngine.lastFen;

                List<String> candidates = new List<String>();
                List<String> outputList = new List<String>();
                int lastIndex = 0;
                foreach (string ll in outputLines)
                {
                    if (ll.IndexOf(" multipv 1 ") >= 0)
                    {
                        if (lastIndex == 6)
                        {
                            outputList = candidates;
                        }
                        candidates.Clear();
                    }
                    candidates.Add(ll);
                    lastIndex = 0;
                    if (ll.IndexOf(" multipv 6 ") >= 0)
                    {
                        lastIndex = 6;
                    }
                }

                CultureInfo info = CultureInfo.GetCultureInfo("en-US");
                String maxDeph = "";
                txtAnalyse.Text = "";
                foreach (String line in candidates)
                {
                    if (line.Length == 0)
                    {
                        continue;
                    }
                    string[] arr = line.Split(' ');
                    int iInx = 0;
                    String multipv = "";
                    String moves = "";
                    String cp = "";
                    foreach (String word in arr)
                    {
                        if (word == "depth")
                        {
                            if (iInx > 4)
                            {
                                continue;
                            }
                            if (arr.Length - 1 < iInx)
                            {
                                continue;
                            }
                            maxDeph = arr[iInx + 1];
                        }
                        if (word == "multipv")
                        {
                            if (arr.Length - 1 < iInx)
                            {
                                continue;
                            }
                            multipv = arr[iInx + 1];
                        }
                        if (word == "pv")
                        {
                            for (int iInx1 = iInx + 1; iInx1 <= arr.Length - 1; iInx1++)
                            {
                                if (arr.Length - 1 < iInx)
                                {
                                    continue;
                                }
                                moves += arr[iInx1] + " ";
                            }
                        }
                        if (word == "cp")
                        {
                            cp = arr[iInx + 1];
                        }

                        iInx++;
                    }
                    double eval = -10000;
                    if (cp != "")
                    {
                        eval = double.Parse(cp);
                        if (lastFen.IndexOf(" b ") >= 0)
                        {
                            eval = eval * -1;
                        }
                    }
                    eval = eval / 100;
                    String str = eval.ToString("0.00");
                    str = str.PadLeft(6, ' ') + " | D:" + maxDeph + " | " + moves + Environment.NewLine;
                    txtAnalyse.Text += str;
                }
            } catch
            {

            }
        }

        private void finishAnalyses()
        {
            //rpAnalyse.Hide();
            //stxtAnalyse.Text = "";
            rbAnalyse.BackColor = SystemColors.Control;

            if (t != null)
            {
                t.Stop();
                t = null;
            }

            if (analyseEngine != null)
            {
                analyseEngine.Dispose();
                analyseEngine = null;
            }

            if (thread != null)
            {
                thread.Abort();
                thread = null;
            }
        }

        private void analysePosition(String lastFen)
        {
            if (this.thread == null)          
            {
                rbAnalyse.BackColor = Color.Red;
                rpAnalyse.Show();
                txtAnalyse.Text = " analysing, wait please...";
            } else     
            {
                finishAnalyses();
                return;
            }           

            try
            {
                analyseEngine = new AnalyseEngine();
                thread = new Thread(new ThreadStart(analyseEngine.runEngine));
                analyseEngine.lastFen = lastFen; 
                thread.Start();

                t = new System.Windows.Forms.Timer();
                t.Interval = 1000; // specify interval time as you want
                t.Tick += new EventHandler(timer_Tick);
                t.Start();
            }
            catch
            {
                finishAnalyses();
                return;
            }
        }
    }
}
