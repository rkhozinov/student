using System;
using System.Collections.Generic;

namespace student
{
    public class Student : IComparer<Student>, IComparable<Student>
    {
        private string name;
        private string lastname;
        private short year;
        private string letter;

        public string Name { get => name; set => name = Student.FirstCapital(value); }
        public string Lastname { get => lastname; set => lastname = Student.FirstCapital(value); }
        public string Letter { get => letter; set => letter = value.ToUpper(); }

        public static string FirstCapital(string value)
        {
            return value[0].ToString().ToUpper() + value.Substring(1);
        }

        public short Year
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
        public Student(string name, string lastname, string letter, short year)
        {
            Name = name;
            Lastname = lastname;
            Letter = letter;
            Year = year;
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
                char _x = x.Letter.ToCharArray()[0];
                char _y = y.Letter.ToCharArray()[0];
                if (_x < _y) return false;
                else if (_x == _y) return true;
                else return true;
            }
        }

        public static bool operator <(Student x, Student y)
        {
            if (x.Year < y.Year) return true;
            else if (x.Year > y.Year) return false;
            else
            {
                char _x = x.Letter.ToCharArray()[0];
                char _y = y.Letter.ToCharArray()[0];
                if (_x < _y) return true;
                else if (_x == _y) return false;
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
            if (x.Year < y.Year)
            {
                return -1;
            }
            if (x.Year == y.Year)
            {
                char _x = x.Letter.ToCharArray()[0];
                char _y = y.Letter.ToCharArray()[0];

                if (_x < _y)
                {
                    return -1;
                }
                else if (_x == _y)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 1;
            }

        }

        public override bool Equals(object obj)
        {
            if (this.Name == (obj as Student).Name && Lastname == (obj as Student).Lastname)
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
