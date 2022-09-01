using System.Collections.Generic;

namespace WebCalculator.Models
{
    /// <summary>
    /// Calculator model
    /// </summary>
    public class CalculatorModel
    {
        /// <summary>
        /// List of calculation calculate history 
        /// </summary>
        public List<string> History;

        /// <summary>
        /// Calculator expression 
        /// </summary>
        public string Expression;

        /// <summary>
        /// Only integer calculation result flag
        /// </summary>
        public bool IsOnlyInteger;
    }
}