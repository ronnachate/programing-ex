using System;

namespace Programing.Ex.Model
{
    public class Transaction
    {

        private int _type = 0;
        private int _productId = 0;
        private int _quantity = 0;
        private double _price = 0;
        public Transaction(int type, int productId, int quantity, double price)
        {
             _type = type;
             _productId = productId;
             _quantity = quantity;
             _price = price;
        }

        public int Type
        { 
            get
            {
                return _type;
            }
        }
        public int ProductId
        { 
            get
            {
                return _productId;
            }
        }
        public int Quantity
        { 
            get
            {
                return _quantity;
            }
        }
        public double Price
        { 
            get
            {
                return _price;
            }
        }
    }
}