using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No8.Solution
{
    public interface IRepository<T> : IDisposable
    {
        /// <summary>
        /// Add to repository.
        /// </summary>
        /// <param name="printer">Entity to add.</param>
        void Create(T printer);

        /// <summary>
        /// Get all entities from repository.
        /// </summary>
        /// <returns>List of entities from repository.</returns>
        List<T> Read();

        /// <summary>
        /// Find instance by name.
        /// </summary>
        /// <param name="name">Name of entity.</param>
        /// <returns>Target instance.</returns>
        T GetByName(string name);

        /// <summary>
        /// Find instance by model.
        /// </summary>
        /// <param name="model">Model of entity.</param>
        /// <returns>Target instance.</returns>
        T GetByModel(string model);
    }
}
