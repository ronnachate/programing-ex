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

            return new List<int>();
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
                var saleTransactions = transactions.Where( t => t.Type == SALE_TYPE ).ToList();
                foreach (var transaction in saleTransactions )
                {                    
                    var buyTransactions = transactions.Where( t => t.Type == BUY_TYPE )
                        .Where( t => t.ProductId == transaction.ProductId )
                        .ToList();
                    int quantityLeft = 0;
                    foreach (var buyTransaction in buyTransactions )
                    {
                        if( quantityLeft > 0 ) {
                            if( quantityLeft <= buyTransaction.Quantity ) {
                                profit += quantityLeft * ( transaction.Price - buyTransaction.Price );
                                buyTransaction.Quantity = buyTransaction.Quantity - quantityLeft;
                                break;
                            }
                            else {
                                profit += buyTransaction.Quantity * ( transaction.Price - buyTransaction.Price );
                                quantityLeft = quantityLeft - buyTransaction.Quantity;
                                transactions.Remove(buyTransaction);                      
                            }
                        }
                        else {
                            if( transaction.Quantity <= buyTransaction.Quantity )
                            {
                                profit +=  transaction.Quantity * ( transaction.Price - buyTransaction.Price );
                                buyTransaction.Quantity = buyTransaction.Quantity - transaction.Quantity;
                                break;
                            }
                            else {
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
    }
}