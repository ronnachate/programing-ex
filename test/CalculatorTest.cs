using Xunit;
using System.Collections.Generic;
using Programing.Ex.Model;

namespace Programing.Ex.Test
{
    public class CalculatorTest
    {
        [Fact]
        public void GetPrimeNumberTestWithSample()
        {
            List<int> result = new List<int> {2, 3, 5, 7, 11};
            Assert.Equal(result, Calculator.GetPrimeNumber(5));
        }

        [Fact]
        public void GetPrimeNumberTestWithOther()
        {
            List<int> result = new List<int> {2, 3, 5, 7, 11, 13, 17, 19, 23, 29};
            Assert.Equal(result, Calculator.GetPrimeNumber(10));
            result = new List<int> {2};
            Assert.Equal(result, Calculator.GetPrimeNumber(1));
        }

        [Fact]
        public void GetFifoProfitWithSample()
        {
            List<Transaction> transactions = new List<Transaction>( new Transaction[] {
                new Transaction(0,123,3,50.00),
                new Transaction(1,123,2,200.00),
                new Transaction(0,124,2,100.00),
                new Transaction(1,123,1,300.00),
                new Transaction(1,124,1,200.00)
            });
            //System.Console.WriteLine(Calculator.GetFifoProfit(transactions));
            Assert.Equal(650, Calculator.GetFifoProfit(transactions));
        }

        [Fact]
        public void GetFifoProfitWithMoreComplexData()
        {
            List<Transaction> transactions = new List<Transaction>( new Transaction[] {
                new Transaction(0,123,1,50.00),
                new Transaction(0,123,2,100.00),
                new Transaction(1,123,2,200.00),
                new Transaction(0,124,2,100.00),
                new Transaction(1,123,1,300.00),
                new Transaction(1,124,1,200.00)
            });
            //System.Console.WriteLine(Calculator.GetFifoProfit(transactions));
            Assert.Equal(550, Calculator.GetFifoProfit(transactions));
        }
    }
}