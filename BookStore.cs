using System;
using System.IO;

namespace BookStoreApp
{
    public class BookStore(Catalog catalog)
    {
        private Catalog _catalog = catalog;
        public Catalog Catalog => _catalog;

        public void Rent(string isbn)
        {
            _catalog[isbn].Rent();
        }

        public void Return(string isbn)
        {
            _catalog[isbn].Return();
        }

        public void SetPrice(string isbn, double price)
        {
            _catalog[isbn].Reprice(price);
        }

        public void PrintCatalog(TextWriter? output = null)
        {
            output ??= Console.Out;
            
            foreach (var book in _catalog)
            {
                output.WriteLine(book);
            }
        }
    }
}