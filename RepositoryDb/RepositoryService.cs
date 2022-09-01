using System.Collections.Generic;
using System.Linq;
using RepositoryDb.Models;

namespace RepositoryDb
{
    public class RepositoryService : IRepositoryService
    {
        MyDbContext _myContext;

        public RepositoryService(MyDbContext myContext)
        {
            _myContext = myContext;
        }

        /// <summary>
        /// Write calulation operation into DB
        /// </summary>
        /// <param name="calculationText">String representation of calculation operation</param>
        /// <returns></returns>
        public bool WriteCalculationHistory(string calculationOperation)
        {
            var calculatorHistory = new CalculatorHistory
            {
                CalculationExpression = calculationOperation
            };

            _myContext.CalculatorHistory.Add(calculatorHistory);
            _myContext.SaveChanges();

            return true;
        }


        /// <summary>
        /// Read specific number of last calculation operations
        /// </summary>
        /// <param name="numberOfLastOperation">The amount of history record to read</param>
        /// <returns>List of strings containing calculation operation</returns>
        public List<string> ReadCalculationHistory(int numberOfLastOperation)
        {
            List<string> calculationHistory;
            calculationHistory = _myContext.CalculatorHistory.OrderByDescending(o => o.Id).Take(numberOfLastOperation).Select(s => s.CalculationExpression).ToList();
            
            return calculationHistory;
        }

    }
}
