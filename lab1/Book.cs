using System;
using System.Collections.Generic;
using System.Globalization;

namespace lab1
{
    [Serializable]
    internal class Book : IEquatable<Book>, IComparable<Book>
    {
        private long _isbn;
        public long ISBN
        {
            get => _isbn;
            set
            {
                if (value.ToString().Length != 13)
                    throw new ArgumentException($"Parameter {nameof(value)} length must be 13 digits");
            }
        }
        public string Author { get; set; } = "";
        public string Name { get; set; } = "";
        public double Price { get; set; }
        public string Publisher { get; set; } = "";

        private CultureInfo culture = CultureInfo.CurrentCulture;

        public Book()
        {

        }

        public Book(string name, string author, string publisher, double price, long isbn)
        {
            if (name is null)
                throw new ArgumentNullException(nameof(name));
            if (author is null)
                throw new ArgumentNullException(nameof(author));
            if (publisher is null)
                throw new ArgumentNullException(nameof(publisher));

            Name = name;
            Publisher = publisher;
            Author = author;
            Price = price;
            ISBN = isbn;
        }

        public Book(string name, string author, string publisher, double price, long isbn, CultureInfo culture) : this(name, author, publisher, price, isbn)
        {
            if (culture is null)
                throw new ArgumentNullException(nameof(culture));

            this.culture = culture;
        }

        public Book(CultureInfo culture)
        {
            if (culture is null)
                throw new ArgumentNullException(nameof(culture));

            this.culture = culture;
        }

        /// <summary>
        /// Compares current instance with other.
        /// </summary>
        /// <param name="other">The instance of to compare with current.</param>
        /// <returns>Returns an integer that indicates whether this instance precedes, follows, or appears in the same position in the sort order.</returns>
        public int CompareTo(Book other)
        {
            if (other is null)
                return 1;

            return Name.CompareTo(other.Name);
        }

        /// <summary>
        /// Checks if this instance is equal to other.
        /// </summary>
        /// <param name="other">The instance of to compare with current.</param>
        /// <returns>Returns true if books are equal by Author, Name and Publisher.</returns>
        public bool Equals(Book other)
        {
            if (other is null)
                return false;

            return this.Author == other.Author &&
                   this.Name == other.Name &&
                   this.Publisher == other.Publisher;
        }

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="leftSide">First instance.</param>
        /// <param name="rightSide">Second instance.</param>
        /// <returns>Returns if both instances are equal.</returns>
        public static bool operator ==(Book leftSide, Book rightSide)
        {
            if (leftSide is null && rightSide is null)
                return true;

            else if (leftSide is null)
                return rightSide.Equals(leftSide);
            else
                return leftSide.Equals(rightSide);

        }

        /// <summary>
        /// Not Equality operator.
        /// </summary>
        /// <param name="leftSide">First instance.</param>
        /// <param name="rightSide">Second instance.</param>
        /// <returns>Returns if both instances are not equal.</returns>
        public static bool operator !=(Book leftSide, Book rightSide)
        {
            return !(leftSide == rightSide);
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Book);
        }

        public override string ToString()
        {
            return $"{Name}, {ISBN}, {Publisher}, {Price + culture.NumberFormat.CurrencySymbol}, {Author}";
        }

        public override int GetHashCode()
        {
            int hash = 13;
            hash = (hash * 3) + Author.GetHashCode();
            hash = (hash * 3) + Name.GetHashCode();
            hash = (hash * 3) + Publisher.GetHashCode();
            return hash;
        }
        
    }

    internal class BookPriceComparer : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            if (object.Equals(x, y))
                return 0;
            if (x is null)
                return -1;
            if (y is null)
                return 1;
            return x.Price.CompareTo(y.Price);
        }
    }
}
