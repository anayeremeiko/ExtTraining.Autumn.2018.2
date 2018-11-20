using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No8.Solution
{
    public class PrintEventArgs : EventArgs
    {
        public PrintEventArgs(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentNullException($"{nameof(message)} need to be not empty.");
            }
            
            Message = message;
        }

        /// <summary>
        /// Message of event.
        /// </summary>
        public string Message { get; }
    }
}
