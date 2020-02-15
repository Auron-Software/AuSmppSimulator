using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace SmppSimulator
{
    /// <summary>
    ///     Use this class to write messages to a logfile.
    /// </summary>
    public class Logger
    {
        #region initializor & public methods

        private string m_strDateTimeFormat;
        private bool m_bIsEnabled;
        private string m_strLogFile;
        private int m_nIndent;

        public Logger(string strLogFile)
        {
            m_strLogFile = strLogFile;
            Initialize();
        }

        public int Initialize()
        {
            try
            {
                if (m_strLogFile == string.Empty)
                {
                    m_bIsEnabled = false;
                    return 0;
                }

                m_bIsEnabled = true;
                m_strDateTimeFormat = "MM/dd/yyyy HH:mm:ss tt";
                if (File.Exists(m_strLogFile))
                    return 0;
            }
            catch (Exception ex)
            {
                string strEx = ex.Message;
            }

            try
            {
                FileStream objStream = File.Create(m_strLogFile);
                objStream.Close();
                objStream = null;
                return 0;
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        ///     Write an entry in the logfile
        /// </summary>
        /// <param name="message">The message you'ld like to log</param>
        public int WriteLine(string strMessage, params object[] aVarargs)
        {
            if (!m_bIsEnabled) return -1;
                        
            if (strMessage.StartsWith("<<")) m_nIndent--;            
            if (m_nIndent < 0) m_nIndent = 0;
            string strIndent = new String(' ', m_nIndent * 2);
            if (strMessage.StartsWith(">>")) m_nIndent++;

            // Open the file to append
            System.IO.FileStream objStream = null;
            try
            {
                objStream = File.Open(m_strLogFile, FileMode.Append);
            }
            catch
            {
                return 1;
            }            

            // Get stack frame to get the calling method name
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);

            // Write the file
            string strToPrint = string.Format(strMessage, aVarargs);
            using (StreamWriter objWriter = new StreamWriter(objStream))
            {
                objWriter.WriteLine(string.Format("[{0}] {3}:{1}{2}", DateTime.Now.ToString(), strIndent, strToPrint, sf.GetMethod()));
                objWriter.Close();
            }

            objStream.Close();
            return 0;
        }

        #endregion

        public int SetLogFile(string strLogPath)
        {
            m_strLogFile = strLogPath;
            return 0;
        }

        public string GetLogFile()
        {
            return m_strLogFile;
        }

        /// <summary>
        ///     Gets the format the date should be written in.
        /// </summary>
        private string strDateFormatstring
        {
            get
            {
                return m_strDateTimeFormat;
            }
        }
    }
}
