using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No8.Solution
{
    public class Logger
    {
        private string logName;

        /// <summary>
        /// Creates an instance of <see cref="Logger"/> class
        /// </summary>
        public Logger() : this("log.txt")
        {
        }

        /// <summary>
        /// Creates an instance of <see cref="Logger"/> class
        /// </summary>
        /// <param name="logName">Name of log file.</param>
        public Logger(string logName)
        {
            this.logName = logName;
            using (var file = File.CreateText(this.logName))
            {
            }
        }

        /// <summary>
        /// Registers to the specified manager.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public void Register(PrinterManager manager)
        {
            manager.StartPrint += Log;
            manager.Printed += Log;
        }

        /// <summary>
        /// Unsubscribes from the specified manager.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public void Unregister(PrinterManager manager)
        {
            manager.StartPrint += Log;
            manager.Printed += Log;
        }

        private void Log(object sender, PrintEventArgs info)
        {
            using (var file = File.AppendText(logName))
            {
                file.WriteLine(info.Message);
            }
        }
    }
}
