using System;
using System.IO;

namespace BookStoreApp
{
    public class BookStore(Catalog catalog)
    {
        // Использованию публичного аксессора чтения к readonly приватному полю аналогично:
        public Catalog Catalog {get; } = catalog;

        public void Rent(string isbn)
        {
            Catalog[isbn].Rent();
        }

        public void Return(string isbn)
        {
            Catalog[isbn].Return();
        }

        public void SetPrice(string isbn, double price)
        {
            Catalog[isbn].Reprice(price);
        }

        public void PrintCatalog(TextWriter? output = null)
        {
            output ??= Console.Out;
            
            foreach (var book in Catalog)
            {
                output.WriteLine(book);
            }
        }
    }
}