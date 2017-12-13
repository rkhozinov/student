using System;
namespace student
{
    public class Student
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
    }
}
