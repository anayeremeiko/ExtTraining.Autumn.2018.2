using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No8.Solution
{
    public interface IPrinterManager<T>
    {
        /// <summary>
        /// Add printer to list of available printers.
        /// </summary>
        /// <param name="printer">Printer.</param>
        void Add(T printer);

        /// <summary>
        /// Prints file on the choosen printer.
        /// </summary>
        /// <param name="name">Target printer.</param>
        /// <returns>Printed file.</returns>
        string Print(Printer printer, string file);

        /// <summary>
        /// Get all available printers.
        /// </summary>
        /// <returns>List of printers.</returns>
        List<T> GetAllPrinters();
    }
}
