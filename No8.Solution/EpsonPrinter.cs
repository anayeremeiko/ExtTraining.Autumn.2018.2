using System.IO;
using System.Text;

namespace No8.Solution
{
    public class EpsonPrinter : Printer
    {
        public EpsonPrinter(string model) : base("Epson", model)
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
