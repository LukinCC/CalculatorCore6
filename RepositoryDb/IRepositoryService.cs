using System.Collections.Generic;

namespace RepositoryDb
{
    /// <summary>
    /// Repository service provide acces to data
    /// </summary>
    public interface IRepositoryService
    {
        /// <summary>
        /// Write calulation operation into DB
        /// </summary>
        /// <param name="calculationText">String representation of calculation operation</param>
        /// <returns></returns>
        bool WriteCalculationHistory(string calculationOperation);


        /// <summary>
        /// Read specific number of last calculation operations
        /// </summary>
        /// <param name="numberOfLastOperation">The amount of history record to read</param>
        /// <returns>List of strings containing calculation operation</returns>
        List<string> ReadCalculationHistory(int numberOfLastOperation);
    }
}
