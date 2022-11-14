using System.Collections.Generic;

namespace Calculator
{
    /// <summary>
    /// String calculator interface
    /// </summary>
    public interface IStringCalculator
    {
        /// <summary>
        /// Calculate value from expression
        /// </summary>
        /// <param name="caluationExpression">The expression that contains two values with operation</param>
        /// <param name="integerResult">The result convert to integer value </param>
        /// <returns>Result of calcuation from expression</returns>
        string Calculate(string caluationExpression, bool integerResult = false);

        /// <summary>
        /// Read specific number of last calculation operations
        /// </summary>
        /// <param name="numberOfLastOperation">The amount of history record to read</param>
        /// <returns>List of strings containing calculation operation</returns>
        List<string> ReadCalculationHistory(int numberOfLastOperation);


    }
}
