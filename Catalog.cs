using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BookStoreApp
{
    public class Catalog : IReadOnlyCollection<Book>
    {
        private readonly Dictionary<string, Book> _items = [];

        public int Count => _items.Count;

        IEnumerator IEnumerable.GetEnumerator() => (IEnumerator)GetEnumerator();
        IEnumerator<Book> IEnumerable<Book>.GetEnumerator() => (IEnumerator<Book>)GetEnumerator();

        public CatalogEnumerator GetEnumerator() => new CatalogEnumerator(_items);

        public void Add(Book book)
        {
            _items.Add(book.Isbn, book);
        }

        public bool Remove(string isbn)
        {
            return _items.Remove(isbn);
        }

        public bool Contains(string isbn)
        {
            return _items.ContainsKey(isbn);
        }

        public IEnumerable<Book> All()
        {
            return _items.Values;
        }

        public Book this[string isbn]
        {
            get
            {
            if (!Contains(isbn))
            {
                throw new KeyNotFoundException($"Book with ISBN {isbn} not found");
            }
            return _items[isbn];
            }
        }

        public Book this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException("Index is out of range");
                }
                return _items.Values.ElementAt(index);
            }
        }

        public Book this[(string author, int index) key] => _items.Values.Where(item => item.Author == key.author).ElementAt(key.index -1);
    }

    public class CatalogEnumerator(Dictionary<string, Book> items) : IEnumerator
    {
        private readonly Dictionary<string, Book> _items = items;
        int index = -1;

        public bool MoveNext()
        {
            index++;
            return index < _items.Count;
        }

        public void Reset()
        {
            index = -1;
        }

        object IEnumerator.Current => Current;

        public Book Current => _items.Values.ElementAt(index);
    }
}