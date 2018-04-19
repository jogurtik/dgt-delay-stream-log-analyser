namespace dgt_delay_stream_log_analyser
{
    partial class frmMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtWinDrawLose = new System.Windows.Forms.TextBox();
            this.txtPlaying = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtErrors = new System.Windows.Forms.TextBox();
            this.txtLoops = new System.Windows.Forms.TextBox();
            this.rlErrors = new System.Windows.Forms.Label();
            this.rlLoops = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.rbLastFileLiveChess = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.rbLastFileUpload = new System.Windows.Forms.Button();
            this.rlLastFileUpload = new System.Windows.Forms.Label();
            this.rbLastError = new System.Windows.Forms.Button();
            this.rlLastError = new System.Windows.Forms.Label();
            this.rlLastLoop = new System.Windows.Forms.Label();
            this.rbLastLoop = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.rpCheckboxes = new System.Windows.Forms.Panel();
            this.rchbTimes = new System.Windows.Forms.CheckBox();
            this.rchbMoves = new System.Windows.Forms.CheckBox();
            this.rchbResult = new System.Windows.Forms.CheckBox();
            this.rchbBoardNr = new System.Windows.Forms.CheckBox();
            this.rchbElo = new System.Windows.Forms.CheckBox();
            this.rcbOnlyPlayed = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.rpCheckboxes.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Menu;
            this.panel1.Controls.Add(this.txtWinDrawLose);
            this.panel1.Controls.Add(this.txtPlaying);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtErrors);
            this.panel1.Controls.Add(this.txtLoops);
            this.panel1.Controls.Add(this.rlErrors);
            this.panel1.Controls.Add(this.rlLoops);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(464, 59);
            this.panel1.TabIndex = 1;
            // 
            // txtWinDrawLose
            // 
            this.txtWinDrawLose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(237)))), ((int)(((byte)(248)))));
            this.txtWinDrawLose.Enabled = false;
            this.txtWinDrawLose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWinDrawLose.Location = new System.Drawing.Point(327, 32);
            this.txtWinDrawLose.Name = "txtWinDrawLose";
            this.txtWinDrawLose.Size = new System.Drawing.Size(126, 23);
            this.txtWinDrawLose.TabIndex = 7;
            this.txtWinDrawLose.Text = "3";
            this.txtWinDrawLose.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPlaying
            // 
            this.txtPlaying.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(237)))), ((int)(((byte)(248)))));
            this.txtPlaying.Enabled = false;
            this.txtPlaying.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlaying.Location = new System.Drawing.Point(327, 3);
            this.txtPlaying.Name = "txtPlaying";
            this.txtPlaying.Size = new System.Drawing.Size(126, 23);
            this.txtPlaying.TabIndex = 6;
            this.txtPlaying.Text = "4";
            this.txtPlaying.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(198, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Win-Draw-Lose:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(263, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Playing:";
            // 
            // txtErrors
            // 
            this.txtErrors.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(237)))), ((int)(((byte)(248)))));
            this.txtErrors.Enabled = false;
            this.txtErrors.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtErrors.Location = new System.Drawing.Point(69, 32);
            this.txtErrors.Name = "txtErrors";
            this.txtErrors.Size = new System.Drawing.Size(78, 23);
            this.txtErrors.TabIndex = 3;
            this.txtErrors.Text = "3";
            this.txtErrors.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLoops
            // 
            this.txtLoops.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(237)))), ((int)(((byte)(248)))));
            this.txtLoops.Enabled = false;
            this.txtLoops.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoops.Location = new System.Drawing.Point(69, 3);
            this.txtLoops.Name = "txtLoops";
            this.txtLoops.Size = new System.Drawing.Size(78, 23);
            this.txtLoops.TabIndex = 2;
            this.txtLoops.Text = "4";
            this.txtLoops.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rlErrors
            // 
            this.rlErrors.AutoSize = true;
            this.rlErrors.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rlErrors.Location = new System.Drawing.Point(5, 32);
            this.rlErrors.Name = "rlErrors";
            this.rlErrors.Size = new System.Drawing.Size(58, 17);
            this.rlErrors.TabIndex = 1;
            this.rlErrors.Text = "Errors:";
            // 
            // rlLoops
            // 
            this.rlLoops.AutoSize = true;
            this.rlLoops.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rlLoops.Location = new System.Drawing.Point(5, 3);
            this.rlLoops.Name = "rlLoops";
            this.rlLoops.Size = new System.Drawing.Size(57, 17);
            this.rlLoops.TabIndex = 0;
            this.rlLoops.Text = "Loops:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.rbLastFileLiveChess);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.rbLastFileUpload);
            this.panel2.Controls.Add(this.rlLastFileUpload);
            this.panel2.Controls.Add(this.rbLastError);
            this.panel2.Controls.Add(this.rlLastError);
            this.panel2.Controls.Add(this.rlLastLoop);
            this.panel2.Controls.Add(this.rbLastLoop);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 59);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(464, 103);
            this.panel2.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(434, 77);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(29, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "▼";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rbLastFileLiveChess
            // 
            this.rbLastFileLiveChess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(119)))), ((int)(((byte)(119)))));
            this.rbLastFileLiveChess.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbLastFileLiveChess.Location = new System.Drawing.Point(351, 30);
            this.rbLastFileLiveChess.Name = "rbLastFileLiveChess";
            this.rbLastFileLiveChess.Size = new System.Drawing.Size(90, 51);
            this.rbLastFileLiveChess.TabIndex = 10;
            this.rbLastFileLiveChess.Text = "2017-05-26\r\n05:47:11";
            this.rbLastFileLiveChess.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(355, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "LiveChess";
            // 
            // rbLastFileUpload
            // 
            this.rbLastFileUpload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(119)))), ((int)(((byte)(119)))));
            this.rbLastFileUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbLastFileUpload.Location = new System.Drawing.Point(241, 30);
            this.rbLastFileUpload.Name = "rbLastFileUpload";
            this.rbLastFileUpload.Size = new System.Drawing.Size(90, 51);
            this.rbLastFileUpload.TabIndex = 8;
            this.rbLastFileUpload.Text = "2017-05-26\r\n05:47:11";
            this.rbLastFileUpload.UseVisualStyleBackColor = false;
            // 
            // rlLastFileUpload
            // 
            this.rlLastFileUpload.AutoSize = true;
            this.rlLastFileUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rlLastFileUpload.Location = new System.Drawing.Point(241, 10);
            this.rlLastFileUpload.Name = "rlLastFileUpload";
            this.rlLastFileUpload.Size = new System.Drawing.Size(93, 17);
            this.rlLastFileUpload.TabIndex = 7;
            this.rlLastFileUpload.Text = "Last upload";
            // 
            // rbLastError
            // 
            this.rbLastError.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(221)))), ((int)(((byte)(119)))));
            this.rbLastError.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbLastError.Location = new System.Drawing.Point(131, 30);
            this.rbLastError.Name = "rbLastError";
            this.rbLastError.Size = new System.Drawing.Size(90, 51);
            this.rbLastError.TabIndex = 6;
            this.rbLastError.Text = "2017-05-26\r\n05:47:11";
            this.rbLastError.UseVisualStyleBackColor = false;
            // 
            // rlLastError
            // 
            this.rlLastError.AutoSize = true;
            this.rlLastError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rlLastError.Location = new System.Drawing.Point(134, 10);
            this.rlLastError.Name = "rlLastError";
            this.rlLastError.Size = new System.Drawing.Size(80, 17);
            this.rlLastError.TabIndex = 5;
            this.rlLastError.Text = "Last error";
            // 
            // rlLastLoop
            // 
            this.rlLastLoop.AutoSize = true;
            this.rlLastLoop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rlLastLoop.Location = new System.Drawing.Point(27, 10);
            this.rlLastLoop.Name = "rlLastLoop";
            this.rlLastLoop.Size = new System.Drawing.Size(75, 17);
            this.rlLastLoop.TabIndex = 4;
            this.rlLastLoop.Text = "Last loop";
            // 
            // rbLastLoop
            // 
            this.rbLastLoop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(221)))), ((int)(((byte)(119)))));
            this.rbLastLoop.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbLastLoop.Location = new System.Drawing.Point(21, 30);
            this.rbLastLoop.Name = "rbLastLoop";
            this.rbLastLoop.Size = new System.Drawing.Size(90, 51);
            this.rbLastLoop.TabIndex = 0;
            this.rbLastLoop.Text = "2017-05-26\r\n05:47:11";
            this.rbLastLoop.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Playbill", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Location = new System.Drawing.Point(0, 187);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(463, 49);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // rpCheckboxes
            // 
            this.rpCheckboxes.Controls.Add(this.rchbTimes);
            this.rpCheckboxes.Controls.Add(this.rchbMoves);
            this.rpCheckboxes.Controls.Add(this.rchbResult);
            this.rpCheckboxes.Controls.Add(this.rchbBoardNr);
            this.rpCheckboxes.Controls.Add(this.rchbElo);
            this.rpCheckboxes.Controls.Add(this.rcbOnlyPlayed);
            this.rpCheckboxes.Location = new System.Drawing.Point(0, 161);
            this.rpCheckboxes.Name = "rpCheckboxes";
            this.rpCheckboxes.Size = new System.Drawing.Size(459, 26);
            this.rpCheckboxes.TabIndex = 10;
            // 
            // rchbTimes
            // 
            this.rchbTimes.AutoSize = true;
            this.rchbTimes.Checked = true;
            this.rchbTimes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rchbTimes.Location = new System.Drawing.Point(319, 3);
            this.rchbTimes.Name = "rchbTimes";
            this.rchbTimes.Size = new System.Drawing.Size(68, 21);
            this.rchbTimes.TabIndex = 15;
            this.rchbTimes.Text = "Times";
            this.rchbTimes.UseVisualStyleBackColor = true;
            this.rchbTimes.CheckedChanged += new System.EventHandler(this.rcbOnlyPlayed_CheckedChanged);
            // 
            // rchbMoves
            // 
            this.rchbMoves.AutoSize = true;
            this.rchbMoves.Checked = true;
            this.rchbMoves.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rchbMoves.Location = new System.Drawing.Point(260, 3);
            this.rchbMoves.Name = "rchbMoves";
            this.rchbMoves.Size = new System.Drawing.Size(53, 21);
            this.rchbMoves.TabIndex = 14;
            this.rchbMoves.Text = "Info";
            this.rchbMoves.UseVisualStyleBackColor = true;
            this.rchbMoves.CheckedChanged += new System.EventHandler(this.rcbOnlyPlayed_CheckedChanged);
            // 
            // rchbResult
            // 
            this.rchbResult.AutoSize = true;
            this.rchbResult.Location = new System.Drawing.Point(390, 3);
            this.rchbResult.Name = "rchbResult";
            this.rchbResult.Size = new System.Drawing.Size(70, 21);
            this.rchbResult.TabIndex = 13;
            this.rchbResult.Text = "Result";
            this.rchbResult.UseVisualStyleBackColor = true;
            this.rchbResult.CheckedChanged += new System.EventHandler(this.rcbOnlyPlayed_CheckedChanged);
            // 
            // rchbBoardNr
            // 
            this.rchbBoardNr.AutoSize = true;
            this.rchbBoardNr.Checked = true;
            this.rchbBoardNr.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rchbBoardNr.Location = new System.Drawing.Point(112, 3);
            this.rchbBoardNr.Name = "rchbBoardNr";
            this.rchbBoardNr.Size = new System.Drawing.Size(91, 21);
            this.rchbBoardNr.TabIndex = 12;
            this.rchbBoardNr.Text = "Board Nr.";
            this.rchbBoardNr.UseVisualStyleBackColor = true;
            this.rchbBoardNr.CheckedChanged += new System.EventHandler(this.rcbOnlyPlayed_CheckedChanged);
            // 
            // rchbElo
            // 
            this.rchbElo.AutoSize = true;
            this.rchbElo.Checked = true;
            this.rchbElo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rchbElo.Location = new System.Drawing.Point(204, 3);
            this.rchbElo.Name = "rchbElo";
            this.rchbElo.Size = new System.Drawing.Size(50, 21);
            this.rchbElo.TabIndex = 10;
            this.rchbElo.Text = "Elo";
            this.rchbElo.UseVisualStyleBackColor = true;
            this.rchbElo.CheckedChanged += new System.EventHandler(this.rcbOnlyPlayed_CheckedChanged);
            // 
            // rcbOnlyPlayed
            // 
            this.rcbOnlyPlayed.AutoSize = true;
            this.rcbOnlyPlayed.Checked = true;
            this.rcbOnlyPlayed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rcbOnlyPlayed.Location = new System.Drawing.Point(3, 3);
            this.rcbOnlyPlayed.Name = "rcbOnlyPlayed";
            this.rcbOnlyPlayed.Size = new System.Drawing.Size(103, 21);
            this.rcbOnlyPlayed.TabIndex = 11;
            this.rcbOnlyPlayed.Text = "Played only";
            this.rcbOnlyPlayed.UseVisualStyleBackColor = true;
            this.rcbOnlyPlayed.CheckedChanged += new System.EventHandler(this.rcbOnlyPlayed_CheckedChanged);
            // 
            // frmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 161);
            this.Controls.Add(this.rpCheckboxes);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmMainForm";
            this.ShowIcon = false;
            this.Text = "DGT Delay Stream Log Analyser";
            this.Load += new System.EventHandler(this.frmMainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.rpCheckboxes.ResumeLayout(false);
            this.rpCheckboxes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtErrors;
        private System.Windows.Forms.TextBox txtLoops;
        private System.Windows.Forms.Label rlErrors;
        private System.Windows.Forms.Label rlLoops;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button rbLastFileUpload;
        private System.Windows.Forms.Label rlLastFileUpload;
        private System.Windows.Forms.Button rbLastError;
        private System.Windows.Forms.Label rlLastError;
        private System.Windows.Forms.Label rlLastLoop;
        private System.Windows.Forms.Button rbLastLoop;
        private System.Windows.Forms.TextBox txtWinDrawLose;
        private System.Windows.Forms.TextBox txtPlaying;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button rbLastFileLiveChess;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel rpCheckboxes;
        private System.Windows.Forms.CheckBox rchbTimes;
        private System.Windows.Forms.CheckBox rchbMoves;
        private System.Windows.Forms.CheckBox rchbResult;
        private System.Windows.Forms.CheckBox rchbBoardNr;
        private System.Windows.Forms.CheckBox rchbElo;
        private System.Windows.Forms.CheckBox rcbOnlyPlayed;
    }
}

