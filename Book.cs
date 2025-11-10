using System;

namespace BookStoreApp
{
    public class Book(string isbn, string title, string author, double price, int stock)
    {
        private double _price = price;
        private int _stock = stock;
        public string Isbn { get; } = isbn;
        public string Title { get; private set; } = title;
        public string Author { get; private set; } = author;
        public double Price { get => _price; 
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Price cannot be negative");
                }
                _price = value;
            }
        }
        public int Stock { get => _stock;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Stock cannot be negative");
                }
                _stock = value;
            }
        }
        public bool IsAvailable => Stock > 0;

        public void Rent()
        {
            if (!IsAvailable)
            {
                throw new InvalidOperationException("Not enough stock");
            }
            Stock--;
        }

        public void Return()
        {
            _stock++;
        }

        public void Reprice(double newPrice)
        {
            Price = newPrice;
        }

        public void Rename(string newTitle)
        {
            Title = newTitle;
        }

        public override string ToString()
        {
            return $"Book: {Title} by {Author} (ISBN: {Isbn})\nPrice: {Price}, Stock: {Stock}";
        }
    }
}