using System.Linq;
using System.Collections.Generic;
using Programing.Ex.Model;

namespace Programing.Ex
{
    public class Calculator
    {
        private static readonly int BUY_TYPE = 0;
        private static readonly int SALE_TYPE = 1;

        /// <summary>
        /// Get prime number
        /// </summary>
        /// <param name="number">number of prime number to return</param>
        /// <returns>List of prime number</returns>
        public static List<int> GetPrimeNumber( int number) {
            var result =  new List<int>();
            var primeNumber = 2;
            result.Add(primeNumber);
            while( result.Count < number ) {
                primeNumber = GetNextPrime(primeNumber);
                result.Add(primeNumber);
            }
            return result;
        }

        /// <summary>
        /// Calculate fifo profit
        /// </summary>
        /// <param name="transactions">list of trransation to calculate</param>
        /// <returns>profit</returns>
        public static double GetFifoProfit( List<Transaction> transactions)
        {
            double profit = 0.0;
            if( transactions.Count > 0 ) {
                //get sale transaction
                var saleTransactions = transactions.Where( t => t.Type == SALE_TYPE ).ToList();
                foreach (var transaction in saleTransactions )
                {
                    //get buy transaction for this ProductId
                    var buyTransactions = transactions.Where( t => t.Type == BUY_TYPE )
                        .Where( t => t.ProductId == transaction.ProductId )
                        .ToList();
                    int quantityLeft = 0;
                    foreach (var buyTransaction in buyTransactions )
                    {
                        if( quantityLeft > 0 ) {
                            // sale quantity overflow from last buy trasaction
                            if( quantityLeft <= buyTransaction.Quantity ) {
                                // buy transaction enought for overflow quantity
                                profit += quantityLeft * ( transaction.Price - buyTransaction.Price );
                                //update buyTransaction.Quantity
                                buyTransaction.Quantity = buyTransaction.Quantity - quantityLeft;
                                break;
                            }
                            else {
                                //overflow to next buy trasaction
                                profit += buyTransaction.Quantity * ( transaction.Price - buyTransaction.Price );
                                quantityLeft = quantityLeft - buyTransaction.Quantity;
                                transactions.Remove(buyTransaction);
                            }
                        }
                        else {
                            if( transaction.Quantity <= buyTransaction.Quantity )
                            {
                                // buy transaction enought for sale transaction
                                profit +=  transaction.Quantity * ( transaction.Price - buyTransaction.Price );
                                //update buyTransaction.Quantity
                                buyTransaction.Quantity = buyTransaction.Quantity - transaction.Quantity;
                                break;
                            }
                            else {
                                //overflow to next buy trasaction
                                profit += buyTransaction.Quantity * ( transaction.Price - buyTransaction.Price );
                                quantityLeft = transaction.Quantity - buyTransaction.Quantity;
                                transactions.Remove(buyTransaction);
                            }
                        }
                    }
                }
                return profit;
            }
            else {
                return 0;
            }
        }

        private static int GetNextPrime(int number) {
            while(true) {
                number++;
                if( IsPrime(number) ) {
                    return number;
                }
            }
        }

        private static bool IsPrime(int number) {

            if (number == 1) return false;
            //even number alway devide by 2, return false
            if (number % 2 == 0) return false;
            //only odd number
            for (int i = 3; i < number; i += 2)  {
                if (number % i == 0) return false;
            }
            return true;
        }
    }
}