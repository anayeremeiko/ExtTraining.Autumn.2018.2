using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No8.Solution
{
    public class PrinterManager : IPrinterManager<Printer>
    {
        private IRepository<Printer> repository;

        public PrinterManager(IRepository<Printer> repo)
        {
            repository = repo ?? throw new ArgumentNullException($"{nameof(repo)} need to be not null.");
        }
        
        /// <summary>
        /// Occurs when printer finished print document.
        /// </summary>
        public event EventHandler<PrintEventArgs> Printed = delegate { };

        /// <summary>
        /// Occurs when printer starts print document.
        /// </summary>
        public event EventHandler<PrintEventArgs> StartPrint = delegate { };

        /// <summary>
        /// Adds printer to list of available printers.
        /// </summary>
        /// <param name="printer">Printer.</param>
        /// <exception cref="InvalidOperationException">Printer need to be unique.</exception>
        public void Add(Printer printer)
        {
            CheckIfExist(printer.Name, printer.Model);
            repository.Create(printer);
        }

        /// <summary>
        /// List of available printers.
        /// </summary>
        /// <returns>List of available printers.</returns>
        public List<Printer> GetAllPrinters()
        {
            return repository.Read().ToList();
        }

        /// <summary>
        /// Send file to print on printer.
        /// </summary>
        /// <param name="printer">The printer.</param>
        /// <param name="file">The file.</param>
        /// <returns>Printed document.</returns>
        /// <exception cref="ArgumentException">Printer need to be in repository of avaiable repositories.</exception>
        /// <exception cref="ArgumentNullException">Printer and file need to be not null.</exception>
        /// <exception cref="FileNotFoundException">File should exist.</exception>
        public string Print(Printer printer, string file)
        {
            if (printer == null)
            {
                throw new ArgumentNullException($"{nameof(printer)} need to be not null.");
            }

            if (repository.GetByName(printer.Name) != printer && repository.GetByModel(printer.Model) != printer)
            {
                throw new ArgumentException($"You can't work with {nameof(printer)}.");
            }

            if (string.IsNullOrWhiteSpace(file))
            {
                throw new ArgumentNullException($"{nameof(file)} need to be not null.");
            }
            
            if (!File.Exists(file))
            {
                throw new FileNotFoundException($"{nameof(file)} not found.");
            }
            
            string result;
            using (var fileStream = File.OpenRead(file))
            {
                OnStartPrint(new PrintEventArgs("Print started"));
                result = printer.Print(fileStream);
            }

            OnPrinted(new PrintEventArgs($"Print finished.{Environment.NewLine}Printed on {printer.Name}"));
            return result;
        }

        /// <summary>
        /// Raises the <see cref="E:StartPrint"/> event.
        /// </summary>
        /// <param name="e">The <see cref="PrintEventArgs"/> instance containing the event data.</param>
        protected virtual void OnStartPrint(PrintEventArgs e)
        {
            StartPrint?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:Printed"/> event.
        /// </summary>
        /// <param name="e">The <see cref="PrintEventArgs"/> instance containing the event data.</param>
        protected virtual void OnPrinted(PrintEventArgs e)
        {
            Printed?.Invoke(this, e);
        }

        private void CheckIfExist(string name, string model)
        {
            List<Printer> printers = repository.Read().ToList();

            List<string> names = printers.Where(x => x.Name == name).Select(x => x.Name).ToList();
            List<string> models = printers.Where(x => x.Model == model).Select(x => x.Model).ToList();

            if (names.Contains(name) && models.Contains(model))
            {
                throw new InvalidOperationException("You can't work with this printer!");
            }
        }
    }
}
