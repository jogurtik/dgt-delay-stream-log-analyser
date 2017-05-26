using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dgt_delay_stream_log_analyser
{
    public partial class frmMainForm : Form
    {
        public frmMainForm()
        {
            InitializeComponent();
        }

        private void frmMainForm_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Interval = (15 * 1000); // 30 secs
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
            
            timer_Tick(sender, e);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            analyses analyse = new analyses();
            AnalyseObject aobj = analyse.Refresh();

            this.rlLogFile.Text = aobj.LogFileName;
            this.rlLastRun.Text = aobj.LastRun;

            this.txtErrors.Text = aobj.CountErrors;
            this.txtLoops.Text = aobj.CountLoops;

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
        }
    }
}
