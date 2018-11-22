using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NUnit.Framework;

namespace No8.Solution.Tests
{
    [TestFixture]
    public class PrinterManagerTests
    {
        [Test]
        public void AddPrinterWithExistingModel_ThrowInvalidOperationException()
        {
            PrinterManager manager = new PrinterManager();
            manager.Add(new CanonPrinter("123x"));
            Assert.Throws<InvalidOperationException>(() => manager.Add(new CanonPrinter("123x")));
        }

        [Test]
        public void Print_ThrowFileNotFoundException()
        {
            PrinterManager manager = new PrinterManager();
            var printer = new CanonPrinter("123x");
            manager.Add(printer);
            Assert.Throws<FileNotFoundException>(() => manager.Print(printer, "error.txt"));
        }

        [Test]
        public void Print_PrintFile()
        {
            PrinterManager manager = new PrinterManager();
            var printer = new CanonPrinter("123x");
            manager.Add(printer);
            string text = "Some text...";
            using (var file = File.CreateText("text.txt"))
            {
                file.WriteLine(text);
            }

            var bytes = Encoding.UTF8.GetBytes(text + "\r\n");
            var expected = new List<string>(bytes.Length);
            for (int i = 0; i < bytes.Length; i++)
            {
                if (i == 0)
                {
                    expected.Add(bytes[i].ToString());
                    continue;
                }
                expected.Add("\n" + bytes[i]);
            }

            var actual = manager.Print(printer, "text.txt").Trim().Split('\r');

            CollectionAssert.AreEqual(expected.ToArray(), actual);
        }

        [Test]
        public void GetAllPrinters_ReturnAvailablePrinters()
        {
            PrinterManager manager = new PrinterManager();
            manager.Add(new CanonPrinter("1G"));
            manager.Add(new EpsonPrinter("231"));
            manager.Add(new CanonPrinter("5K"));
            manager.Add(new EpsonPrinter("K505U"));

            CollectionAssert.AreEqual(new Printer[] { new CanonPrinter("1G"), new EpsonPrinter("231"), new CanonPrinter("5K"), new EpsonPrinter("K505U") }, manager.GetAllPrinters(), Comparer<Printer>.Create((p1, p2) => string.Compare(p1.Name, p2.Name, StringComparison.Ordinal)));
            CollectionAssert.AreEqual(new Printer[] { new CanonPrinter("1G"), new EpsonPrinter("231"), new CanonPrinter("5K"), new EpsonPrinter("K505U") }, manager.GetAllPrinters(), Comparer<Printer>.Create((p1, p2) => string.Compare(p1.Model, p2.Model, StringComparison.Ordinal)));
        }

        [Test]
        public void GetByName_ReturnCanon()
        {
            PrinterManager manager = new PrinterManager();
            manager.Add(new CanonPrinter("1G"));
            manager.Add(new EpsonPrinter("231"));

            Assert.AreEqual(new CanonPrinter("1G").Name, manager.GetByName("Canon").Name);
            Assert.AreEqual(new CanonPrinter("1G").Model, manager.GetByName("Canon").Model);
        }

        [Test]
        public void GetByModel_Success()
        {
            PrinterManager manager = new PrinterManager();
            manager.Add(new CanonPrinter("1G"));
            manager.Add(new EpsonPrinter("231"));

            Assert.AreEqual(new EpsonPrinter("231").Name, manager.GetByModel("231").Name);
            Assert.AreEqual(new CanonPrinter("231").Model, manager.GetByModel("231").Model);
        }

        [Test]
        public void GetByName_NotExistingName()
        {
            PrinterManager manager = new PrinterManager();
            manager.Add(new CanonPrinter("1G"));
            manager.Add(new EpsonPrinter("231"));

            Assert.AreEqual(null, manager.GetByName("231"));
        }

        [Test]
        public void GetByModel_NotExistingModel()
        {
            PrinterManager manager = new PrinterManager();
            manager.Add(new CanonPrinter("1G"));
            manager.Add(new EpsonPrinter("231"));

            Assert.AreEqual(null, manager.GetByModel("Canon"));
        }
    }
}