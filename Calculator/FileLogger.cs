using System.IO;

namespace Calculator
{
    /// <summary>
    /// File logger class 
    /// </summary>
    public class FileLogger
    {
        /// <summary>
        /// Logger file path
        /// </summary>
        string file;

        public FileLogger(string filePath)
        {
            file = filePath;
        }

        /// <summary>
        /// Write log into file
        /// </summary>
        /// <param name="text">Text to log</param>
        public void WriteLog(string text)
        {
            using (FileStream fs = new FileStream(file, FileMode.Append, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine(text);
            }
        }

    }
}
