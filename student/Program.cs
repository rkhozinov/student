using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using student;

namespace program
{
    class Program
    {
        static void Main(string[] args)
        {
            var ocoll = new Students
            {
                new Student("ivan", "petrov", "a", 1),
                new Student("nikolay", "ivanov", "b", 2),
                new Student("kira", "selezneva", "c", 3),
                new Student("mary", "suzukova", "a", 1),
                new Student("ann", "dubova", "a", 1)
            };

            var coll_year = ocoll.GetByYear(1);
            foreach (Student student in coll_year)
            {
                Console.WriteLine($"coll:{student.Name} {student.Lastname} {student.Year} {student.Letter}");
            }

            foreach (Student student in ocoll.SortByYear())
            {
                Console.WriteLine($"coll:{student.Name} {student.Lastname} {student.Year} {student.Letter}");
            }

            Students.Display(ocoll.GetByYear(1));
            Students.Display(ocoll.GetByLetter("a"));
            Students.Display(ocoll.SortByYear());
            Students.Display(ocoll.SortByLetter());
            ocoll.Promote();
            Students.Display(ocoll);


            Console.WriteLine(ocoll[0] > ocoll[1]);
            Console.WriteLine(ocoll[1] > ocoll[2]);
            Console.WriteLine(ocoll[2] > ocoll[3]);
            Console.WriteLine(ocoll[3] > ocoll[4]);
            Console.WriteLine(ocoll[3] < ocoll[4]);
            Console.WriteLine(ocoll[3] == ocoll[4]);


            Students.Quicksort(ocoll);
            Students.Display(ocoll);


        }
    }

}