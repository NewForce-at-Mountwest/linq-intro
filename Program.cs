using System;
using System.Collections.Generic;
using System.Linq;

namespace example_code
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> cohortStudentCount = new List<int>()
            {
                25, 12, 28, 22, 11, 25, 27, 24, 19
            };

            /*
                Figure out which cohorts fell within the range
                of ideal sizes - between 15 and 25 students. Also, sort
                the new enumerable collection in ascending order.
            */

            // Smallest cohort? .Min()

            // Largest cohort? .Max()

            // Total number of students? .Sum()

            // Average? .Average()

            // .OrderBy() and .OrderByDescending()


            Cohort one = new Cohort("Cohort One");
            Cohort twentySix = new Cohort("Cohort 26");


            // Current Students
            Student David = new Student("David", "Bird", "Student at Mountwest", "JavaScript");


            Student Tommy = new Student("Tommy", "Spurlock", "Salsa Dance Instructor", "C#");


            Student Nikki = new Student("Nikki", "Ash", "Student at Mountwest", "JavaScript");



            // Previous Students
            Student Shu = new Student("Shu", "Sajid", "MRI Tech", "C#");
            Shu.monthsToHire = 2;
            Shu.startingSalary = 50000;

            Student Natasha = new Student("Natasha", "Cox", "Teacher", "JavaScript");
            Natasha.monthsToHire = 0.25;
            Natasha.startingSalary = 52000;

            Student Leah = new Student("Leah", "Gwin", "Marketing", "C#");
            Leah.monthsToHire = 0.5;
            Leah.startingSalary = 51000;

            Student Seth = new Student("Seth", "Dana", "Wine maker", "SQL");
            Seth.monthsToHire = 1;
            Seth.startingSalary = 54000;


            // We used method overriding so that the enrollStudent method can take either one student at a time, or a whole list of them
            one.enrollStudent(David);

            one.enrollStudent(new List<Student>() { Tommy, Nikki });
            twentySix.enrollStudent(new List<Student>() { Shu, Natasha, Leah, Seth });

            List<Cohort> allCohorts = new List<Cohort>() { one, twentySix };

            // ------- Data Questions ---------//

            // Let's get a list of the total number of students in each cohort, like the one we started out with
            // .Select() is the new .map()
            List<int> numberOfStudents = allCohorts.Select(c => c.Students.Count()).ToList();

            numberOfStudents.ForEach(i => Console.WriteLine(i));

            // Which students in Cohort one like C# best?

            // IEnumerable<Student> cSharpStudents = from student in one.Students where student.FavoriteLanguage=="C#" select student;

            IEnumerable<Student> cSharpStudents = one.Students.Where(s => s.FavoriteLanguage == "C#");


            // Let's look at a report of how many students in cohort one favor different languages in cohort one
            // JavaScript - 2
            // C# - 1
            IEnumerable<Dictionary<string, int>> studentReport = from student in one.Students
                                                                 group student by student.FavoriteLanguage into
                                                                 // languageGroup is an IGrouping<string, Student>
                                                                 languageGroup
                                                                 select new Dictionary<string, int>(){
                {languageGroup.Key, languageGroup.Count()}
            };

            foreach (Dictionary<string, int> reportEntry in studentReport)
            {
                foreach (KeyValuePair<string, int> reportLineItem in reportEntry)
                {
                    Console.WriteLine($"{reportLineItem.Key} - {reportLineItem.Value}");
                }
            }

            // Build a report for each cohort in the allCohorts List
            // Use the ReportItem class
            IEnumerable<ReportItem> cohortReport = from cohort in allCohorts
                                                   select new ReportItem()
                                                   {
                                                       CohortName = cohort.Name,
                                                       numberOfStudents = cohort.Students.Count(),
                                                       averageMonthsToHire = cohort.Students.Select(s => s.monthsToHire).Average(),
                                                       averageStartingSalary = cohort.Students.Select(s => s.startingSalary).Average()
                                                   };




















        }
    }
}
