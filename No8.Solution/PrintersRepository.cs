using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No8.Solution
{
    public class PrintersRepository : IRepository<Printer>
    {
        /// <summary>
        /// Creates an instance of <see cref="PrintersRepository"/> class.
        /// </summary>
        public PrintersRepository()
        {
            Printers = new List<Printer>();
        }

        private List<Printer> Printers { get; set; }

        /// <summary>
        /// Adds printer to repository.
        /// </summary>
        /// <param name="printer">Targer printer.</param>
        public void Create(Printer printer)
        {
            Printers.Add(printer);
        }

        /// <summary>
        /// Get printers from repository.
        /// </summary>
        /// <returns>List of printers.</returns>
        public List<Printer> Read()
        {
            return Printers;
        }

        /// <summary>
        /// Find printer by it's name.
        /// </summary>
        /// <param name="name">Name of the printer.</param>
        /// <returns>Priner with specified name.</returns>
        public Printer GetByName(string name)
        {
            return Printers.Find(x => x.Name == name);
        }

        /// <summary>
        /// Find printer by it's model.
        /// </summary>
        /// <param name="model">Model of the printer.</param>
        /// <returns>Printer with specified model.</returns>
        public Printer GetByModel(string model)
        {
            return Printers.Find(x => x.Model == model);
        }

        /// <summary>
        /// Disposes.
        /// </summary>
        public void Dispose()
        {
            Printers = null;
        }
    }
}
