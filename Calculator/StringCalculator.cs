using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Text.RegularExpressions;
using RepositoryDb;

namespace Calculator
{
    /// <summary>
    /// Handler for calculation on sting expression
    /// </summary>
    public class StringCalculator : IStringCalculator
    {
        // Define a regular expression for supported calculation operation
        Regex rx = new Regex(@"^(?<Value1>[\-\+]?[0-9]+(\.[0-9]*)?)(?<Operator>[\-\+\*\/])(?<Value2>[\-\+]?[0-9]+(\.[0-9]*)?)$",
                       RegexOptions.IgnoreCase);

        private readonly IRepositoryService _repositoryService;
        private readonly IErrorHandler _errorHandler;

        /// <summary>
        /// String calculator 
        /// </summary>
        /// <param name="repositoryService">The history handler</param>
        /// <param name="errorHandler">The error handler</param>
        public StringCalculator(IRepositoryService repositoryService, IErrorHandler errorHandler)
        {
            _repositoryService = repositoryService;
            _errorHandler = errorHandler;
        }

        /// <summary>
        /// Calculate value from expression
        /// </summary>
        /// <param name="caluationExpression">The expression that contains two values with operation</param>
        /// <param name="integerResult">The result convert to integer value </param>
        /// <returns>Result of calcuation from expression</returns>
        public string Calculate(string caluationExpression, bool integerResult = false)
        {
            try
            {
                // Find matches.
                Match match = rx.Match(caluationExpression);

                //Calculate opearation if expression is valid
                if (match.Success)
                {
                    decimal value1, value2;
                    Operator operation;

                    value1 = Convert.ToDecimal(match.Groups["Value1"].Value, CultureInfo.InvariantCulture);
                    value2 = Convert.ToDecimal(match.Groups["Value2"].Value, CultureInfo.InvariantCulture);
                    string op = match.Groups["Operator"].Value;

                    if (op == "+")
                    {
                        operation = Operator.Addition;
                    }
                    else if (op == "-")
                    {
                        operation = Operator.Subtraction;
                    }
                    else if (op == "*")
                    {
                        operation = Operator.Multiplication;
                    }
                    else //(op == "/")
                    {
                        operation = Operator.Division;
                    }

                    //Get calculation result value
                    decimal result = Calculator.Calculate(value1, value2, operation);

                    string resultValue = integerResult ? Decimal.ToInt32(result).ToString() : result.ToString();

                    //Get calculator operation text
                    string resultText = caluationExpression + "=" + resultValue;

                    //Write calculation with resut into DB
                    _repositoryService.WriteCalculationHistory(resultText);

                    return resultValue;
                }
                else
                {
                    throw new Exception(@"Calculation expression " + caluationExpression + " is not valid.");
                }

            }
            catch (Exception e)
            {
                _errorHandler.SendError(e);
                return e.Message;
            }
        }

        /// <summary>
        /// Read specific number of last calculation operations
        /// </summary>
        /// <param name="numberOfLastOperation">The amount of history record to read</param>
        /// <returns>List of strings containing calculation operation</returns>
        public List<string> ReadCalculationHistory(int numberOfLastOperation)
        {
            var result = new List<string>();
            try
            {
                result = _repositoryService.ReadCalculationHistory(numberOfLastOperation);
            }
            catch (Exception e)
            {
                _errorHandler.SendError(e);
            }
            return result;
        }
    }
}
