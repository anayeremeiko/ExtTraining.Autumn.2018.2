using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace No8.Solution.Tests
{
    [TestFixture]
    public class PrintersRepositoryTests
    {
        [Test]
        public void Create_AddPrinters()
        {
            PrintersRepository repo = new PrintersRepository();
            PrinterManager manager = new PrinterManager(repo);
            manager.Add(new CanonPrinter("1G"));
            manager.Add(new EpsonPrinter("231"));

            CollectionAssert.AreEqual(new Printer[] { new CanonPrinter("1G"), new EpsonPrinter("231") }, repo.Read(), Comparer<Printer>.Create((p1, p2) => string.Compare(p1.Name, p2.Name, StringComparison.Ordinal)));
            CollectionAssert.AreEqual(new Printer[] { new CanonPrinter("1G"), new EpsonPrinter("231") }, repo.Read(), Comparer<Printer>.Create((p1, p2) => string.Compare(p1.Model, p2.Model, StringComparison.Ordinal)));
        }

        [Test]
        public void GetByName_ReturnCanon()
        {
            PrintersRepository repo = new PrintersRepository();
            PrinterManager manager = new PrinterManager(repo);
            manager.Add(new CanonPrinter("1G"));
            manager.Add(new EpsonPrinter("231"));

            Assert.AreEqual(new CanonPrinter("1G").Name, repo.GetByName("Canon").Name);
            Assert.AreEqual(new CanonPrinter("1G").Model, repo.GetByName("Canon").Model);
        }

        [Test]
        public void GetByModel_Success()
        {
            PrintersRepository repo = new PrintersRepository();
            PrinterManager manager = new PrinterManager(repo);
            manager.Add(new CanonPrinter("1G"));
            manager.Add(new EpsonPrinter("231"));

            Assert.AreEqual(new EpsonPrinter("231").Name, repo.GetByModel("231").Name);
            Assert.AreEqual(new CanonPrinter("231").Model, repo.GetByModel("231").Model);
        }

        [Test]
        public void GetByName_NotExistingName()
        {
            PrintersRepository repo = new PrintersRepository();
            PrinterManager manager = new PrinterManager(repo);
            manager.Add(new CanonPrinter("1G"));
            manager.Add(new EpsonPrinter("231"));

            Assert.AreEqual(null, repo.GetByName("231"));
        }

        [Test]
        public void GetByModel_NotExistingModel()
        {
            PrintersRepository repo = new PrintersRepository();
            PrinterManager manager = new PrinterManager(repo);
            manager.Add(new CanonPrinter("1G"));
            manager.Add(new EpsonPrinter("231"));

            Assert.AreEqual(null, repo.GetByModel("Canon"));
        }
    }
}
