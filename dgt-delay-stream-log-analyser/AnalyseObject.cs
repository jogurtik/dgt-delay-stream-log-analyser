using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dgt_delay_stream_log_analyser
{
    class AnalyseObject
    {
        private String lastRun;

        public String LastRun
        {
            get { return lastRun; }
            set { lastRun = value; }
        }

        private String logFileName;

        public String LogFileName
        {
            get { return logFileName; }
            set { logFileName = value; }
        }

        private String lastFileUpload;

        public String LastFileUpload
        {
            get { return lastFileUpload; }
            set { lastFileUpload = value; }
        }

        private String lastLoop;

        public String LastLoop
        {
            get { return lastLoop; }
            set { lastLoop = value; }
        }

        private String lastError;

        public String LastError
        {
            get { return lastError; }
            set { lastError = value; }
        }

        private String loopStatus;

        public String LoopStatus
        {
            get { return loopStatus; }
            set { loopStatus = value; }
        }

        private String fileUploadStatus;

        public String FileUploadStatus
        {
            get { return fileUploadStatus; }
            set { fileUploadStatus = value; }
        }

        private String errorStatus;

        public String ErrorStatus
        {
            get { return errorStatus; }
            set { errorStatus = value; }
        }

        private String countErrors;

        public String CountErrors
        {
            get { return countErrors; }
            set { countErrors = value; }
        }

        private String countLoops;

        public String CountLoops
        {
            get { return countLoops; }
            set { countLoops = value; }
        }

        private String errorMessage;

        public String ErrorMessage
        {
            get { return errorMessage; }
            set { errorMessage = value; }
        }
    }
}
