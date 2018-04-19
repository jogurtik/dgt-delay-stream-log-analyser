namespace dgt_delay_stream_log_analyser
{
    partial class formGameDetails
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
            this.rlTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbAnalyse = new System.Windows.Forms.Button();
            this.rbEnd = new System.Windows.Forms.Button();
            this.rbNext = new System.Windows.Forms.Button();
            this.rbPrevious = new System.Windows.Forms.Button();
            this.rbStart = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.rpPanelBoard = new System.Windows.Forms.Panel();
            this.rpMoves = new System.Windows.Forms.Panel();
            this.txtMoves = new System.Windows.Forms.TextBox();
            this.rpAnalyse = new System.Windows.Forms.Panel();
            this.txtAnalyse = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.rpMoves.SuspendLayout();
            this.rpAnalyse.SuspendLayout();
            this.SuspendLayout();
            // 
            // rlTitle
            // 
            this.rlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.rlTitle.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rlTitle.Location = new System.Drawing.Point(0, 0);
            this.rlTitle.Name = "rlTitle";
            this.rlTitle.Size = new System.Drawing.Size(521, 30);
            this.rlTitle.TabIndex = 1;
            this.rlTitle.Text = "rlTitle";
            this.rlTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbAnalyse);
            this.panel1.Controls.Add(this.rbEnd);
            this.panel1.Controls.Add(this.rbNext);
            this.panel1.Controls.Add(this.rbPrevious);
            this.panel1.Controls.Add(this.rbStart);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 287);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(521, 30);
            this.panel1.TabIndex = 9;
            // 
            // rbAnalyse
            // 
            this.rbAnalyse.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rbAnalyse.Location = new System.Drawing.Point(381, 3);
            this.rbAnalyse.Name = "rbAnalyse";
            this.rbAnalyse.Size = new System.Drawing.Size(37, 23);
            this.rbAnalyse.TabIndex = 13;
            this.rbAnalyse.Text = "A";
            this.rbAnalyse.UseVisualStyleBackColor = true;
            this.rbAnalyse.Click += new System.EventHandler(this.rbAnalyse_Click);
            // 
            // rbEnd
            // 
            this.rbEnd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rbEnd.Location = new System.Drawing.Point(300, 3);
            this.rbEnd.Name = "rbEnd";
            this.rbEnd.Size = new System.Drawing.Size(75, 23);
            this.rbEnd.TabIndex = 12;
            this.rbEnd.Text = ">>";
            this.rbEnd.UseVisualStyleBackColor = true;
            this.rbEnd.Click += new System.EventHandler(this.rbEnd_Click);
            // 
            // rbNext
            // 
            this.rbNext.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rbNext.Location = new System.Drawing.Point(219, 3);
            this.rbNext.Name = "rbNext";
            this.rbNext.Size = new System.Drawing.Size(75, 23);
            this.rbNext.TabIndex = 11;
            this.rbNext.Text = ">";
            this.rbNext.UseVisualStyleBackColor = true;
            this.rbNext.Click += new System.EventHandler(this.rbNext_Click);
            // 
            // rbPrevious
            // 
            this.rbPrevious.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rbPrevious.Location = new System.Drawing.Point(138, 3);
            this.rbPrevious.Name = "rbPrevious";
            this.rbPrevious.Size = new System.Drawing.Size(75, 23);
            this.rbPrevious.TabIndex = 10;
            this.rbPrevious.Text = "<";
            this.rbPrevious.UseVisualStyleBackColor = true;
            this.rbPrevious.Click += new System.EventHandler(this.rbPrevious_Click);
            // 
            // rbStart
            // 
            this.rbStart.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rbStart.Location = new System.Drawing.Point(57, 3);
            this.rbStart.Name = "rbStart";
            this.rbStart.Size = new System.Drawing.Size(75, 23);
            this.rbStart.TabIndex = 9;
            this.rbStart.Text = "<<";
            this.rbStart.UseVisualStyleBackColor = true;
            this.rbStart.Click += new System.EventHandler(this.rbStart_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(521, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // rpPanelBoard
            // 
            this.rpPanelBoard.Dock = System.Windows.Forms.DockStyle.Top;
            this.rpPanelBoard.Location = new System.Drawing.Point(0, 30);
            this.rpPanelBoard.Name = "rpPanelBoard";
            this.rpPanelBoard.Size = new System.Drawing.Size(521, 257);
            this.rpPanelBoard.TabIndex = 10;
            // 
            // rpMoves
            // 
            this.rpMoves.Controls.Add(this.txtMoves);
            this.rpMoves.Dock = System.Windows.Forms.DockStyle.Top;
            this.rpMoves.Location = new System.Drawing.Point(0, 317);
            this.rpMoves.Name = "rpMoves";
            this.rpMoves.Size = new System.Drawing.Size(521, 195);
            this.rpMoves.TabIndex = 21;
            // 
            // txtMoves
            // 
            this.txtMoves.BackColor = System.Drawing.SystemColors.Control;
            this.txtMoves.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMoves.Location = new System.Drawing.Point(0, 0);
            this.txtMoves.Multiline = true;
            this.txtMoves.Name = "txtMoves";
            this.txtMoves.ReadOnly = true;
            this.txtMoves.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMoves.Size = new System.Drawing.Size(521, 195);
            this.txtMoves.TabIndex = 21;
            // 
            // rpAnalyse
            // 
            this.rpAnalyse.Controls.Add(this.txtAnalyse);
            this.rpAnalyse.Dock = System.Windows.Forms.DockStyle.Top;
            this.rpAnalyse.Location = new System.Drawing.Point(0, 512);
            this.rpAnalyse.Name = "rpAnalyse";
            this.rpAnalyse.Size = new System.Drawing.Size(521, 92);
            this.rpAnalyse.TabIndex = 22;
            // 
            // txtAnalyse
            // 
            this.txtAnalyse.BackColor = System.Drawing.SystemColors.Control;
            this.txtAnalyse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAnalyse.Location = new System.Drawing.Point(0, 0);
            this.txtAnalyse.Multiline = true;
            this.txtAnalyse.Name = "txtAnalyse";
            this.txtAnalyse.ReadOnly = true;
            this.txtAnalyse.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAnalyse.Size = new System.Drawing.Size(521, 92);
            this.txtAnalyse.TabIndex = 21;
            this.txtAnalyse.WordWrap = false;
            // 
            // formGameDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(521, 601);
            this.Controls.Add(this.rpAnalyse);
            this.Controls.Add(this.rpMoves);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rpPanelBoard);
            this.Controls.Add(this.rlTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "formGameDetails";
            this.Text = "formGameDetails";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formGameDetails_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formGameDetails_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.rpMoves.ResumeLayout(false);
            this.rpMoves.PerformLayout();
            this.rpAnalyse.ResumeLayout(false);
            this.rpAnalyse.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label rlTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button rbEnd;
        private System.Windows.Forms.Button rbNext;
        private System.Windows.Forms.Button rbPrevious;
        private System.Windows.Forms.Button rbStart;
        private System.Windows.Forms.Panel rpPanelBoard;
        private System.Windows.Forms.Panel rpMoves;
        private System.Windows.Forms.TextBox txtMoves;
        private System.Windows.Forms.Button rbAnalyse;
        private System.Windows.Forms.Panel rpAnalyse;
        private System.Windows.Forms.TextBox txtAnalyse;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}