using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace student
{
    public class Students : Collection<Student>
    {
        public Students()
        {
        }

        public Students(List<Student> list) : base(list)
        {
        }

        public Students GetStudentsByYear(short year)
        {
            return new Students(Items.Where(student => student.Year == year).ToList());
        }

        public void RemoveStudent(string name, string lastname)
        {

            foreach (Student student in Items)
            {
                if (student.Name.Equals(name) && student.Lastname.Equals(lastname))
                {
                    Remove(student);
                }
            }

        }

        public Students SortByYear(bool descending = false)
        {
            if (descending)
            {
                return new Students(Items.OrderByDescending(x => x.Year).ToList());
            }
            else
            {
                return new Students(Items.OrderBy(x => x.Year).ToList());
            }

        }
        public Students SortByLetter(bool descending = false)
        {
            if (descending)
            {
                return new Students(Items.OrderByDescending(x => x.Letter).ToList());
            }
            else
            {
                return new Students(Items.OrderBy(x => x.Letter).ToList());
            }

        }

        public Students SortByYearAndLetter(bool descending = false)
        {
            if (descending)
            {
                return new Students(Items.OrderByDescending(x => x.Year).ThenByDescending(x => x.Letter).ToList());
            }
            else
            {
                return new Students(Items.OrderBy(x => x.Year).ThenBy(x => x.Letter).ToList());
            }
        }

        public static void Display(Students students)
        {

            foreach (Student student in students)
            {
                Console.WriteLine($"Name: {student.Name} {student.Lastname}, " +
                                         $"{student.Year}{student.Letter}");
            }
            Console.WriteLine();
        }

        public Students GetByLetter(string letter)
        {
            string upper_letter = letter.ToUpper();
            return new Students(Items.Where(student => student.Letter == upper_letter).ToList());

        }

        public Students GetByYear(short year)
        {
            return new Students(Items.Where(student => student.Year == year).ToList());
        }

        public void Promote()
        {
            foreach (Student student in Items)
            {
                student.Promote();
            }

        }

    }
}
