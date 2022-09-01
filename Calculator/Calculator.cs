using System;

namespace Calculator
{
    /// <summary>
    ///Define enumeration of supported calulator opearators
    /// </summary>
    public enum Operator
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }

    /// <summary>
    /// Calculator 
    /// </summary>
    public class Calculator
    {
        /// <summary>
        /// Calculate basic numeric operation on two values
        /// </summary>
        /// <param name="value1">The first value</param>
        /// <param name="value2">The second value</param>
        /// <param name="operation">The numeric operation operator</param>
        /// <returns>Calculated result</returns>
        public static decimal Calculate(decimal value1, decimal value2, Operator operation)
        {
            decimal result;

            switch (operation)
            {
                case Operator.Addition:
                    result = value1 + value2;
                    break;

                case Operator.Subtraction:
                    result = value1 - value2;
                    break;

                case Operator.Multiplication:
                    result = value1 * value2;
                    break;

                case Operator.Division:
                    result = value1 / value2;  //Zero division catch later in exception handling
                    break;

                default:
                    throw new Exception(@"{operation} is invalid");
            }

            return result;
        }
    }
}
