using System;
using System.Collections.Generic;

namespace student
{
    public class Student : IComparer<Student>, IComparable<Student>
    {
        private uint id;
        private string name;
        private string lastname;
        private ushort year;
        private char letter;

        public uint Id
        {
            get { return id; }
            set
            {
                id = value;
            }
        }
        public string Name { get => name; set => name = Student.FirstCapital(value); }
        public string Lastname { get => lastname; set => lastname = Student.FirstCapital(value); }
        public char Letter { get => letter; set => letter = Char.ToUpper(value); }

        public static string FirstCapital(string value)
        {

            return Char.ToUpper(value[0]) + value.Substring(1);
        }

        public ushort Year
        {
            get => year;
            set
            {
                if (value >= 1 && value <= 11)
                {
                    year = value;
                }
                else throw new Exception("Year should be a positive " +
                                         "number in range 1-11");
            }
        }
        public Student(uint id, string name, string lastname, char letter, ushort year)
        {
            Id = id;
            Name = name;
            Lastname = lastname;
            Letter = letter;
            Year = year;
        }
        public Student(string[] data)
        {
            if (data.Length < 4)
            {
                throw new Exception("Data inconsistency");
            }

            Id = uint.Parse(data[0].Trim());
            Name = data[1].Trim();
            Lastname = data[2].Trim();
            Letter = char.Parse(data[3].Trim());
            Year = ushort.Parse(data[4].Trim());
        }

        public void Promote()
        {
            Year = ++Year;
        }

        public static bool operator ==(Student x, Student y)
        {

            if (x.Name == y.Name && x.Lastname == y.Lastname)
                return true;
            else
                return false;

        }

        public static bool operator !=(Student x, Student y)
        {

            if (x.Name != y.Name || x.Lastname != y.Lastname)
                return true;
            else
                return false;
        }

        public static bool operator >(Student x, Student y)
        {
            if (x.Year < y.Year) return false;
            else if (x.Year > y.Year) return true;
            else
            {
                if (x.Letter < y.Letter) return false;
                else if (x.Letter == y.Letter) return true;
                else return true;
            }
        }

        public static bool operator <(Student x, Student y)
        {
            if (x.Year < y.Year) return true;
            else if (x.Year > y.Year) return false;
            else
            {
                if (x.Letter < y.Letter) return true;
                else if (x.Letter == y.Letter) return false;
                else return false;
            }
        }

        public static bool operator >=(Student x, Student y)
        {
            return x > y;
        }

        public static bool operator <=(Student x, Student y)
        {
            return x < y;
        }

        public int Compare(Student x, Student y)
        {
            if (x.Year < y.Year) return -1;
            if (x.Year == y.Year)
            {
                if (x.Letter < y.Letter) return -1;
                else if (x.Letter == y.Letter) return 0;
                else return 1;
            }
            else return 1;

        }

        public override bool Equals(object obj)
        {
            if (Name == (obj as Student).Name &&
                Lastname == (obj as Student).Lastname)
                return true;
            else
                return false;
        }

        public int CompareTo(Student other)
        {
            return Compare(this, other);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }



    }
}
