using System;
using System.IO;

namespace BookStoreApp
{
    public class BookStore(Catalog catalog)
    {
        // Т.к. в методах нет изменения _catalog логично сделать его readonly
        // однако так как у нас есть два readonly доступа, логично заменить их на один
        public Catalog Catalog {get; private set;} = catalog;

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