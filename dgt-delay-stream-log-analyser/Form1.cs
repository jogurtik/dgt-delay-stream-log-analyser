using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace dgt_delay_stream_log_analyser
{
    public partial class frmMainForm : Form
    {
        private Size thisFormSize;
        private analyses analyse;
        private formGameDetails formGameDetail;
        private string[] games;
        private String lastIdent;
        bool ignoreLog;

        public frmMainForm()
        {
            formGameDetail = null;
            InitializeComponent();
        }

        private void frmMainForm_Load(object sender, EventArgs e)
        {
            thisFormSize = this.Size;
            this.Text = "DGT Delay Stream Log Analyser";

            Timer timer = new Timer();
            timer.Interval = (10 * 1000); // 30 secs
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
            
            timer_Tick(sender, e);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            AnalyseObject aobj = new AnalyseObject();
            analyse = new analyses();
            aobj = analyse.Refresh();

            this.Text = "DGT Delay Stream Log Analyser - " + aobj.Title;

            this.rbLastFileLiveChess.Text = aobj.LiveChessRun;
            
            this.txtErrors.Text = aobj.CountErrors;
            this.txtLoops.Text = aobj.CountLoops;

            this.txtPlaying.Text = aobj.Playing;
            this.txtWinDrawLose.Text = aobj.Wins + " - " + aobj.Draw + " - " + aobj.Loses;
            this.rbLastLoop.Text = aobj.LastLoop.Replace(" ",  Environment.NewLine);
            this.rbLastFileUpload.Text = aobj.LastFileUpload.Replace(" ", Environment.NewLine);
            this.rbLastError.Text = aobj.LastError.Replace(" ", Environment.NewLine);

            Color colorOK = Color.FromArgb(119, 221, 119);
            Color colorError = Color.FromArgb(221, 119, 119);           

            this.rbLastFileUpload.BackColor = colorOK;
            if (aobj.FileUploadStatus == "error")
            {
                this.rbLastFileUpload.BackColor = colorError;
            }

            this.rbLastFileLiveChess.BackColor = colorOK;
            if (aobj.LiveChessRunStatus == "error")
            {
                this.rbLastFileLiveChess.BackColor = colorError;
            }            
            
            this.rbLastLoop.BackColor = colorOK;
            if (aobj.LoopStatus == "error")
            {
                this.rbLastLoop.BackColor = colorError;
            }

            this.rbLastError.BackColor = colorOK;
            if (aobj.ErrorStatus == "error")
            {
                this.rbLastError.BackColor = colorError;
            }

            if (!String.IsNullOrEmpty(aobj.ErrorMessage)) {
                MessageBox.Show(aobj.ErrorMessage, "Internal error");
            }                        

            RefreshDataGrid(aobj);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.Size.Height > thisFormSize.Height)
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                dataGridView1.Visible = false;
                rcbOnlyPlayed.Visible = false;
                //dataGridView1.Location = new Point(0, 0);
                //rcbOnlyPlayed.Location = new Point(0, 0);
                Point locationOnForm = button1.FindForm().PointToClient(button1.Parent.PointToScreen(button1.Location));
                //this.Size = new Size(locationOnForm.X + button1.Size.Width + 22, locationOnForm.Y + button1.Size.Height + 49);
                this.Size = thisFormSize;
                button1.Text = @"▼";
            }
            else
            {
                this.Size = new Size(685, 903);
                button1.Text = @"▲";
                //dataGridView1.Location = new Point(0, 252);
                //rcbOnlyPlayed.Location = new Point(472, 230);
                rcbOnlyPlayed.Visible = true;
                dataGridView1.Visible = true;
            }
            timer_Tick(sender, e);
        }

        private void RefreshDataGrid(AnalyseObject aobj)
        {
            if (this != null)
            {
                if (this.Size.Height > thisFormSize.Height)
                {
                    string readText = @"";
                    try
                    {
                        if (aobj.LiveChessPgn.StartsWith("ftp://"))
                        {
                            readText = analyse.ReadFromFtp(aobj.LiveChessPgn);
                        }
                        else
                        {
                            readText = File.ReadAllText(aobj.LiveChessPgn);
                        }
                        if (readText.Trim().Length == 0)
                        {
                            return;
                        }
                    }
                    catch {
                        return;
                    }

                    DataGridViewColumn sortedColumnBackup = dataGridView1.SortedColumn;
                    SortOrder sortedOrderBackup = dataGridView1.SortOrder;

                    dataGridView1.Rows.Clear();
                    dataGridView1.Columns.Clear();
                    dataGridView1.RowHeadersVisible = false;
                    dataGridView1.Columns.Add("Id", "Id");
                    dataGridView1.Columns.Add("Nr", "Nr");
                    dataGridView1.Columns.Add("Player1", "Player1");
                    dataGridView1.Columns.Add("EloW", "Elo");
                    dataGridView1.Columns.Add("Player2", "Player2");
                    dataGridView1.Columns.Add("EloB", "Elo");
                    dataGridView1.Columns.Add("Moves", "Inf");
                    dataGridView1.Columns.Add("Time1", "Time1");
                    dataGridView1.Columns.Add("Time2", "Time2");
                    dataGridView1.Columns.Add("Res", "Res");
                    dataGridView1.Columns.Add("Board", "");
                    //dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 8);

                    games = readText.Split(new string[] { "[Event" }, StringSplitOptions.None);

                    int playing = 0;
                    int win = 0;
                    int draw = 0;
                    int lose = 0;
                    int gamesCnt = 0;
                    foreach (String gg in games) {
                        if(gg.Trim() == "")
                        {
                            continue;
                        }
                        String ggame = "[Event" + gg;
                        ParsePgn parsePGN = new ParsePgn(ggame);
                                                
                        if (ggame.Trim().Length > 0)
                        {                                                        
                            DataGridViewRow row = new DataGridViewRow();
                            DataGridViewCellStyle style = new DataGridViewCellStyle();
                            if (parsePGN.Pgn.WhiteOverTime || parsePGN.Pgn.BlackOverTime)
                            {
                                style.BackColor = Color.DarkViolet;                                
                            }
                            else if (parsePGN.Pgn.Result.Trim() == "*")
                            {
                                if ((parsePGN.Pgn.whiteTimeSecondsTag < 0) || (parsePGN.Pgn.blackTimeSecondsTag < 0))
                                {
                                    style.BackColor = Color.Aqua;
                                } else if ((parsePGN.Pgn.whiteTimeSecondsTag < 60) || (parsePGN.Pgn.blackTimeSecondsTag < 60))
                                {
                                    style.BackColor = Color.Red;
                                }
                                else if ((parsePGN.Pgn.whiteTimeSecondsTag < 300) || (parsePGN.Pgn.blackTimeSecondsTag < 300))
                                {
                                    style.BackColor = Color.Orange;
                                }
                            }
                            else
                            {
                                style.BackColor = Color.LightGray;
                            }

                            row.DefaultCellStyle = style;                            
                            row.CreateCells(dataGridView1);
                            int jj = 0;
                            row.Cells[jj++].Value = parsePGN.Pgn.Round;
                            row.Cells[jj++].Value = parsePGN.Pgn.Round.Split('.')[1].PadLeft(3,' ');
                            row.Cells[jj++].Value = parsePGN.Pgn.White;
                            row.Cells[jj++].Value = parsePGN.Pgn.WhiteElo;
                            row.Cells[jj++].Value = parsePGN.Pgn.Black;
                            row.Cells[jj++].Value = parsePGN.Pgn.BlackElo;
                            row.Cells[jj++].Value = parsePGN.Pgn.NrMoves.PadLeft(4, ' ');
                            row.Cells[jj++].Value = parsePGN.Pgn.WhiteTime + (parsePGN.Pgn.WhiteOverTime ? " OT" : "");
                            row.Cells[jj++].Value = parsePGN.Pgn.BlackTime + (parsePGN.Pgn.BlackOverTime ? " OT" : ""); ;
                            row.Cells[jj++].Value = parsePGN.Pgn.Result;
                            row.Cells[jj++].Value = "▶";
                            if ((!rcbOnlyPlayed.Checked) || (parsePGN.Pgn.Result.Trim() == "*")) { 
                                dataGridView1.Rows.Add(row);
                            }
                            gamesCnt++;
                            switch (parsePGN.Pgn.Result.Trim())
                            {
                                case "*": playing++; break;
                                case "1-0": win++; break;
                                case "0-1": lose++; break;
                                case "1/2-1/2": draw++; break;
                            }
                        }
                    }

                    txtPlaying.Text = playing.ToString() + " / " + gamesCnt.ToString();
                    txtWinDrawLose.Text = win.ToString() + " - " + draw.ToString() + " - " + lose.ToString();

                    this.dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 7);
                    this.dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 7);

                    this.dataGridView1.Columns["Id"].Visible = false;
                    if (!rchbBoardNr.Checked)
                    {
                        this.dataGridView1.Columns["Nr"].Visible = false;
                    }
                    if (!rchbElo.Checked)
                    {
                        this.dataGridView1.Columns["EloW"].Visible = false;
                        this.dataGridView1.Columns["EloB"].Visible = false;
                    }
                    if (!rchbMoves.Checked)
                    {
                        this.dataGridView1.Columns["Moves"].Visible = false;
                    }
                    if (!rchbTimes.Checked)
                    {
                        this.dataGridView1.Columns["Time1"].Visible = false;
                        this.dataGridView1.Columns["Time2"].Visible = false;
                    }
                    if (!rchbResult.Checked)
                    {
                        this.dataGridView1.Columns["Res"].Visible = false;
                    }                   

                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                    int width = 3;
                    foreach (DataGridViewColumn col in dataGridView1.Columns)
                    {
                        if(col.Visible) {
                            width += col.Width;
                        }
                    }

                    //width += dataGridView1.RowHeadersWidth;
                    int height = dataGridView1.Columns[0].HeaderCell.Size.Height + 3;
                    for (byte i = 0; i < dataGridView1.RowCount; i++)
                    {                        
                        height += dataGridView1.Rows[i].Height;
                    }
                    if (height > Screen.PrimaryScreen.Bounds.Height - 50 - thisFormSize.Height - rpCheckboxes.Height)
                    {
                        height = Screen.PrimaryScreen.Bounds.Height - 50 - thisFormSize.Height - rpCheckboxes.Height;
                    }

                    dataGridView1.Width = width;
                    dataGridView1.Height = height;
                    if (dataGridView1.Controls[1].Visible)
                    {
                        width += System.Windows.Forms.SystemInformation.VerticalScrollBarWidth;
                        dataGridView1.Width = width;
                    }
                    if(width < thisFormSize.Width)
                    {
                        width = thisFormSize.Width;
                        dataGridView1.Width = width;
                    }
                    this.Size = new Size(width + 20, thisFormSize.Height + rpCheckboxes.Height + dataGridView1.Height);

                    if (sortedColumnBackup != null)
                    {
                        if (sortedOrderBackup == SortOrder.Ascending)
                        {
                            dataGridView1.Sort(dataGridView1.Columns[sortedColumnBackup.Index], System.ComponentModel.ListSortDirection.Ascending);
                        }
                        else
                        {
                            dataGridView1.Sort(dataGridView1.Columns[sortedColumnBackup.Index], System.ComponentModel.ListSortDirection.Descending);
                        }
                    }
                }
            }
            if (formGameDetail!=null && !formGameDetail.IsDisposed)
            {
                ShowGame(this.lastIdent);
            }
            else
            {
                this.lastIdent = null;
            }
        }

        private void rcbOnlyPlayed_CheckedChanged(object sender, EventArgs e)
        {
            timer_Tick(sender, e);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String columnName = this.dataGridView1.Columns[e.ColumnIndex].Name;
            if (columnName == "Board")
            {
                this.lastIdent = this.dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                ShowGame(this.lastIdent);
            }
        }

        private void ShowGame(String ident)
        {
            if(ident == null)
            {
                return;
            }
            if ((formGameDetail == null) || (formGameDetail.IsDisposed))
            {
                formGameDetail = new formGameDetails();
                formGameDetail.Show(this);
                formGameDetail.Location = new Point(this.Left + this.Width, this.Top);
            }
            foreach (String gg in games)
            {
                String ggame = "[Event" + gg;
                if (ggame.Trim().Length > 0)
                {
                    string[] lines = ggame.Split(new string[] { "\n" }, StringSplitOptions.None);
                    foreach (String ll in lines)
                    {
                        if (ll.IndexOf("[Round \"") >= 0)
                        {
                            String nr = ll.Replace("[Round \"", "");
                            nr = nr.Replace("\"]", "").Replace("\n", " ").Replace("\r", " ").Replace("\t", " ").Trim();
                            if (nr == ident)
                            {
                                formGameDetail.showGame(ggame);
                            }
                        }
                    }
                }
            }           
        }
    }
}
