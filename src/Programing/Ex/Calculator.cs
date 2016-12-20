using System.Collections.Generic;
using Programing.Ex.Model;

namespace Programing.Ex
{
    public class Calculator
    {

        /// <summary>
        /// Get prime number
        /// </summary>
        /// <param name="number">number of prime number to return</param>
        /// <returns>List of prime number</returns>
        public static List<int> GetPrimeNumber( int number) {

            return new List<int>();
        }

        /// <summary>
        /// Calculate fifo profit
        /// </summary>
        /// <param name="transactions">list of trransation to calculate</param>
        /// <returns>profit</returns>
        public static double GetFifoProfit( List<Transaction> transactions) {

            if( transactions.Count > 0 ) {

               return 0;
            }
            else {
                return 0;
            }
        }
    }
}