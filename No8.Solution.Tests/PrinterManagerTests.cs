using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No8.Solution.Tests
{
    [TestFixture]
    public class PrinterManagerTests
    {
        [Test]
        public void AddPrinterWithExistingModel_ThrowInvalidOperationException()
        {
            PrintersRepository repo = new PrintersRepository();
            PrinterManager manager = new PrinterManager(repo);
            manager.Add(new CanonPrinter("123x"));
            Assert.Throws<InvalidOperationException>(() => manager.Add(new CanonPrinter("123x")));
        }

        [Test]
        public void Print_ThrowFileNotFoundException()
        {
            PrintersRepository repo = new PrintersRepository();
            PrinterManager manager = new PrinterManager(repo);
            var printer = new CanonPrinter("123x");
            manager.Add(printer);
            Assert.Throws<FileNotFoundException>(() => manager.Print(printer, "text.txt"));
        }
    }
}
