using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No8.Solution
{
    public class CanonPrinter : Printer
    {
        public CanonPrinter(string model) : base("Canon", model)
        {
        }

        /// <summary>
        /// Prints specified document
        /// </summary>
        /// <param name="fs">Document to print.</param>
        /// <returns>Printed document.</returns>
        public override string Print(FileStream fs)
        {
            var result = new StringBuilder();
            for (int i = 0; i < fs.Length; i++)
            {
                result.AppendLine(fs.ReadByte().ToString());
            }

            return result.ToString();
        }
    }
}
