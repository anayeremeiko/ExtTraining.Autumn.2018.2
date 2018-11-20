using System;
using System.IO;
using System.Text;

namespace No8.Solution
{
    public abstract class Printer
    {
        /// <summary>
        /// Creates an instance of <see cref="Printer"/> class.
        /// </summary>
        /// <param name="name">Name of the printer.</param>
        /// <param name="model">Model of the printer.</param>
        /// <exception cref="ArgumentNullException"><see cref="Name"/> and <see cref="Model"/> need to be not null or empty.</exception>
        public Printer(string name, string model)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException($"{nameof(name)} need to be not null or empty.");
            }

            if (string.IsNullOrWhiteSpace(model))
            {
                throw new ArgumentNullException($"{nameof(model)} need to be not null or empty.");
            }

            Name = name;
            Model = model;
        }

        /// <summary>
        /// Printer's model.
        /// </summary>
        public string Model { get; }

        /// <summary>
        /// Printer's name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Prints the file.
        /// </summary>
        /// <param name="fs">File to print.</param>
        /// <returns>Printed file.</returns>
        public abstract string Print(FileStream fs);

        public override string ToString()
        {
            return $"{Name}, {Model}";
        }
    }
}
