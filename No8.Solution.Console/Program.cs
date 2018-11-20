using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace No8.Solution.Console
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            PrintersRepository repo = new PrintersRepository();
            PrinterManager manager = new PrinterManager(repo);
            manager.Add(new CanonPrinter("123x"));
            manager.Add(new EpsonPrinter("231"));
            Logger logger = new Logger();
            logger.Register(manager);

            while (true)
            {
                System.Console.WriteLine("Select your choice:");
                System.Console.WriteLine("1:Add new printer");
                System.Console.WriteLine("2:Print on Canon");
                System.Console.WriteLine("3:Print on Epson");
                System.Console.WriteLine("4:Exit");

                var key = System.Console.ReadLine();

                switch (key)
                {
                    case ("1"):
                        System.Console.WriteLine("Enter printer name:");
                        string name = System.Console.ReadLine();
                        System.Console.WriteLine("Enter printer model:");
                        string model = System.Console.ReadLine();
                        Printer printer = null;
                        if(name == "Canon")
                        {
                            printer = new CanonPrinter(model);
                        }

                        if (name == "Epson")
                        {
                            printer = new EpsonPrinter(model);
                        }

                        try
                        {
                            manager.Add(printer);
                        }
                        catch (Exception e)
                        {
                            System.Console.WriteLine("You can't create such printer!");
                        }
                        break;

                    case ("2"):
                        Print("Canon", manager);
                        break;

                    case ("3"):
                        Print("Epson", manager);
                        break;

                    default:
                        break;
                }

                if (key == "4")
                {
                    break;
                }
            }
        }

        private static void Print(string name, PrinterManager manager)
        {
            System.Console.Clear();
            var printers = from n in manager.GetAllPrinters() where n.Name == name select n;
            foreach (var printer in printers)
            {
                System.Console.WriteLine(printer.ToString());
            }
            System.Console.WriteLine("Enter model: ");
            string model = System.Console.ReadLine();
            var o = new OpenFileDialog();
            o.ShowDialog();
            try
            {
                System.Console.WriteLine(manager.Print(manager.GetAllPrinters().Find(x => x.Name == name && x.Model == model), o.FileName));
            }
            catch (Exception e)
            {
                System.Console.WriteLine("You can't print on this printer");
            }
        }
    }
}
