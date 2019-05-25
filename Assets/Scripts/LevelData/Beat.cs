using System;

namespace LevelData
{
    public struct Beat : IEquatable<Beat>, IComparable<Beat>, IComparable
    {
        public readonly Note Note;
        public readonly double StartTime;

        public Beat(Note note, double startTime)
        {
            Note = note;
            StartTime = startTime;
        }

        #region IEquatable implementation

        public bool Equals(Beat other)
        {
            return Note == other.Note && StartTime.Equals(other.StartTime);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Beat && Equals((Beat) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((int) Note * 397) ^ StartTime.GetHashCode();
            }
        }

        public static bool operator ==(Beat left, Beat right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Beat left, Beat right)
        {
            return !left.Equals(right);
        }

        #endregion

        #region IComparable implementation

        public int CompareTo(Beat other)
        {
            var timeComparison = StartTime.CompareTo(other.StartTime);
            if (timeComparison != 0) return timeComparison;
            return Note.CompareTo(other.Note);
        }

        public int CompareTo(object obj)
        {
            if (ReferenceEquals(null, obj)) return 1;
            if (!(obj is Beat)) throw new ArgumentException("Object must be of type Beat");
            return CompareTo((Beat) obj);
        }

        public static bool operator <(Beat left, Beat right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator >(Beat left, Beat right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator <=(Beat left, Beat right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >=(Beat left, Beat right)
        {
            return left.CompareTo(right) >= 0;
        }

        #endregion
    }
}
