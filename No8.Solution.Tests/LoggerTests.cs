using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace No8.Solution.Tests
{
    [TestFixture]
    public class LoggerTests
    {
        [TestCase("logging.txt")]
        public void Logger_Log(string name)
        {
            Logger log = new Logger(name);
            PrintersRepository repo = new PrintersRepository();
            PrinterManager manager = new PrinterManager(repo);
            var printer = new CanonPrinter("1G");
            log.Register(manager);
            manager.Add(printer);
            using (File.CreateText("test1.txt"))
            {
            }
            manager.Print(printer, "test1.txt");
            string expected = "Print started\r\nPrint finished.\r\nPrinted on Canon\r\n";
            string actual;

            using (var logFile = File.OpenText(name))
            {
                actual = logFile.ReadToEnd();
            }

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Logger_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Logger(null));
        }
    }
}
