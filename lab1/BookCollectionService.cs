using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace lab1
{
    
    public class BookCollectionService
    {
        private List<Book> _bookCollection;

        public BookCollectionService()
        {
            _bookCollection = new List<Book>();
        }

        public BookCollectionService(List<Book> bookCollection)
        {
            if (bookCollection is null)
            {
                throw new ArgumentNullException(nameof(bookCollection));
            }

            _bookCollection = bookCollection;
        }

        public void Add(Book newBook)
        {
            if (newBook is null)
                throw new ArgumentNullException(nameof(newBook));

            _bookCollection.Add(newBook);
        }

        public void Remove(Book rmBook)
        {
            if (rmBook is null)
                throw new ArgumentNullException(nameof(rmBook));
            _bookCollection.Remove(rmBook);
        }

        public void Sort()
        {
            _bookCollection.Sort();
        }


        public void Sort(IComparer<Book> comparer)
        {
            if (comparer is null)
                throw new ArgumentNullException(nameof(comparer));

            _bookCollection.Sort(comparer);
        }

        public bool Contains(Book searchBook)
        {
            if (searchBook is null)
                throw new ArgumentNullException(nameof(searchBook));

            return _bookCollection.Contains(searchBook);
        }

        public bool Contains(Book searchBook, IEqualityComparer<Book> comparer)
        {
            if (searchBook is null)
                throw new ArgumentNullException(nameof(searchBook));

            if (comparer is null)
                throw new ArgumentNullException(nameof(comparer));

            return _bookCollection.Contains(searchBook, comparer);
        }


        public void Save(string fileName)
        {
            if (fileName is null)
                throw new ArgumentNullException(nameof(fileName));

            FileStream fs = new FileStream(fileName, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream parseStream = new MemoryStream();
            formatter.Serialize(parseStream, _bookCollection);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(parseStream.ToArray());
            parseStream.Dispose();
            bw.Dispose();
        }

        public void ParseBookCollectionFromFile(string fileName)
        {
            if (fileName is null)
                throw new ArgumentNullException(nameof(fileName));

            var buffer = File.ReadAllBytes(fileName);
            BinaryFormatter formatter = new BinaryFormatter();
            _bookCollection = (List<Book>)formatter.Deserialize(new MemoryStream(buffer));
        }


        public override string ToString()
        {
            if (_bookCollection.Count == 0)
                return "There is no books";

            string result = string.Empty;
            foreach (Book item in _bookCollection)
                 result += item.ToString() + Environment.NewLine;
            return result;
        }

    }
}
