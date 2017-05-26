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
            this.rpLogFile = new System.Windows.Forms.Panel();
            this.rlLogFile = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rlLastRun = new System.Windows.Forms.Label();
            this.rlLoops = new System.Windows.Forms.Label();
            this.rlErrors = new System.Windows.Forms.Label();
            this.txtLoops = new System.Windows.Forms.TextBox();
            this.txtErrors = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbLastLoop = new System.Windows.Forms.Button();
            this.rlLastLoop = new System.Windows.Forms.Label();
            this.rlLastError = new System.Windows.Forms.Label();
            this.rbLastError = new System.Windows.Forms.Button();
            this.rlLastFileUpload = new System.Windows.Forms.Label();
            this.rbLastFileUpload = new System.Windows.Forms.Button();
            this.rpLogFile.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rpLogFile
            // 
            this.rpLogFile.BackColor = System.Drawing.SystemColors.Window;
            this.rpLogFile.Controls.Add(this.rlLastRun);
            this.rpLogFile.Controls.Add(this.rlLogFile);
            this.rpLogFile.Dock = System.Windows.Forms.DockStyle.Top;
            this.rpLogFile.Location = new System.Drawing.Point(0, 0);
            this.rpLogFile.Name = "rpLogFile";
            this.rpLogFile.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rpLogFile.Size = new System.Drawing.Size(463, 68);
            this.rpLogFile.TabIndex = 0;
            // 
            // rlLogFile
            // 
            this.rlLogFile.AutoSize = true;
            this.rlLogFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rlLogFile.Location = new System.Drawing.Point(3, 12);
            this.rlLogFile.Name = "rlLogFile";
            this.rlLogFile.Size = new System.Drawing.Size(410, 29);
            this.rlLogFile.TabIndex = 0;
            this.rlLogFile.Text = "dgt-delay-stream.2017-05-26.log";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Menu;
            this.panel1.Controls.Add(this.txtErrors);
            this.panel1.Controls.Add(this.txtLoops);
            this.panel1.Controls.Add(this.rlErrors);
            this.panel1.Controls.Add(this.rlLoops);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(463, 55);
            this.panel1.TabIndex = 1;
            // 
            // rlLastRun
            // 
            this.rlLastRun.AutoSize = true;
            this.rlLastRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rlLastRun.Location = new System.Drawing.Point(318, 48);
            this.rlLastRun.Name = "rlLastRun";
            this.rlLastRun.Size = new System.Drawing.Size(142, 17);
            this.rlLastRun.TabIndex = 1;
            this.rlLastRun.Text = "2017-05-26 08:48:11";
            // 
            // rlLoops
            // 
            this.rlLoops.AutoSize = true;
            this.rlLoops.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rlLoops.Location = new System.Drawing.Point(19, 14);
            this.rlLoops.Name = "rlLoops";
            this.rlLoops.Size = new System.Drawing.Size(66, 20);
            this.rlLoops.TabIndex = 0;
            this.rlLoops.Text = "Loops:";
            // 
            // rlErrors
            // 
            this.rlErrors.AutoSize = true;
            this.rlErrors.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rlErrors.Location = new System.Drawing.Point(259, 13);
            this.rlErrors.Name = "rlErrors";
            this.rlErrors.Size = new System.Drawing.Size(68, 20);
            this.rlErrors.TabIndex = 1;
            this.rlErrors.Text = "Errors:";
            // 
            // txtLoops
            // 
            this.txtLoops.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(237)))), ((int)(((byte)(248)))));
            this.txtLoops.Enabled = false;
            this.txtLoops.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoops.Location = new System.Drawing.Point(99, 10);
            this.txtLoops.Name = "txtLoops";
            this.txtLoops.Size = new System.Drawing.Size(100, 26);
            this.txtLoops.TabIndex = 2;
            this.txtLoops.Text = "4";
            this.txtLoops.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtErrors
            // 
            this.txtErrors.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(237)))), ((int)(((byte)(248)))));
            this.txtErrors.Enabled = false;
            this.txtErrors.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtErrors.Location = new System.Drawing.Point(343, 10);
            this.txtErrors.Name = "txtErrors";
            this.txtErrors.Size = new System.Drawing.Size(100, 26);
            this.txtErrors.TabIndex = 3;
            this.txtErrors.Text = "3";
            this.txtErrors.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbLastFileUpload);
            this.panel2.Controls.Add(this.rlLastFileUpload);
            this.panel2.Controls.Add(this.rbLastError);
            this.panel2.Controls.Add(this.rlLastError);
            this.panel2.Controls.Add(this.rlLastLoop);
            this.panel2.Controls.Add(this.rbLastLoop);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 123);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(463, 118);
            this.panel2.TabIndex = 2;
            // 
            // rbLastLoop
            // 
            this.rbLastLoop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(221)))), ((int)(((byte)(119)))));
            this.rbLastLoop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbLastLoop.Location = new System.Drawing.Point(20, 43);
            this.rbLastLoop.Name = "rbLastLoop";
            this.rbLastLoop.Size = new System.Drawing.Size(116, 51);
            this.rbLastLoop.TabIndex = 0;
            this.rbLastLoop.Text = "2017-05-26\r\n05:47:11";
            this.rbLastLoop.UseVisualStyleBackColor = false;
            // 
            // rlLastLoop
            // 
            this.rlLastLoop.AutoSize = true;
            this.rlLastLoop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rlLastLoop.Location = new System.Drawing.Point(35, 20);
            this.rlLastLoop.Name = "rlLastLoop";
            this.rlLastLoop.Size = new System.Drawing.Size(87, 20);
            this.rlLastLoop.TabIndex = 4;
            this.rlLastLoop.Text = "Last loop";
            // 
            // rlLastError
            // 
            this.rlLastError.AutoSize = true;
            this.rlLastError.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rlLastError.Location = new System.Drawing.Point(188, 20);
            this.rlLastError.Name = "rlLastError";
            this.rlLastError.Size = new System.Drawing.Size(93, 20);
            this.rlLastError.TabIndex = 5;
            this.rlLastError.Text = "Last error";
            // 
            // rbLastError
            // 
            this.rbLastError.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(221)))), ((int)(((byte)(119)))));
            this.rbLastError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbLastError.Location = new System.Drawing.Point(176, 43);
            this.rbLastError.Name = "rbLastError";
            this.rbLastError.Size = new System.Drawing.Size(116, 51);
            this.rbLastError.TabIndex = 6;
            this.rbLastError.Text = "2017-05-26\r\n05:47:11";
            this.rbLastError.UseVisualStyleBackColor = false;
            // 
            // rlLastFileUpload
            // 
            this.rlLastFileUpload.AutoSize = true;
            this.rlLastFileUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rlLastFileUpload.Location = new System.Drawing.Point(336, 20);
            this.rlLastFileUpload.Name = "rlLastFileUpload";
            this.rlLastFileUpload.Size = new System.Drawing.Size(107, 20);
            this.rlLastFileUpload.TabIndex = 7;
            this.rlLastFileUpload.Text = "Last upload";
            // 
            // rbLastFileUpload
            // 
            this.rbLastFileUpload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(119)))), ((int)(((byte)(119)))));
            this.rbLastFileUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbLastFileUpload.Location = new System.Drawing.Point(331, 43);
            this.rbLastFileUpload.Name = "rbLastFileUpload";
            this.rbLastFileUpload.Size = new System.Drawing.Size(116, 51);
            this.rbLastFileUpload.TabIndex = 8;
            this.rbLastFileUpload.Text = "2017-05-26\r\n05:47:11";
            this.rbLastFileUpload.UseVisualStyleBackColor = false;
            // 
            // frmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 238);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rpLogFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmMainForm";
            this.Text = "DGT Delay Stream Log Analyser";
            this.Load += new System.EventHandler(this.frmMainForm_Load);
            this.rpLogFile.ResumeLayout(false);
            this.rpLogFile.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel rpLogFile;
        private System.Windows.Forms.Label rlLastRun;
        private System.Windows.Forms.Label rlLogFile;
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
    }
}

