using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    internal class Book : IEquatable<Book>, IComparable<Book>
    {
        public int ISBN { get; set; }
        public string Author { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Publisher { get; set; }

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

    }
}
