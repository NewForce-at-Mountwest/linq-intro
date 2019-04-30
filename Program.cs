using System;
using System.Collections.Generic;
using System.Linq;

namespace example_code
{
    class Program
    {
        static void Main(string[] args)
        {
            // List<int> cohortStudentCount = new List<int>()
            // {
            //     25, 12, 28, 22, 11, 25, 27, 24, 19
            // };

            // double avg = cohortStudentCount.Average();
            // int sum = cohortStudentCount.Sum();
            // IEnumerable<int> biggest = cohortStudentCount.OrderByDescending(count => count).Take(3);
            // int smallest = cohortStudentCount.Min();

            // List<int> doubledCohortSizes = cohortStudentCount.Select(studentCount => studentCount * 2).ToList();

            // doubledCohortSizes.ForEach(n => Console.WriteLine($"Doubled number: {n}"));

            // List<int> idealCohortSizes = cohortStudentCount.Where(count => count < 20 && count > 10).OrderBy(n => n).ToList();

            // List<int> idealCohortSizes = (from count in cohortStudentCount where count < 20 && count > 10 orderby count select count).ToList();

            // idealCohortSizes.ForEach(n => Console.WriteLine($"Ideal cohort size: {n}"));



            //  Using only a `foreach` loop and basic arithmetic:

            // 1. Find the average number of students per cohort.
            // int sum = 0;
            // int count = 0;
            // int largestCohort = 0;

            // foreach(int studentCount in cohortStudentCount){
            //     sum += studentCount;
            //     count ++;
            //     if(studentCount > largestCohort){
            //         largestCohort = studentCount;
            //     }
            // }

            // int smallestCohort = largestCohort;
            // foreach(int studentCount in cohortStudentCount){
            //     if(studentCount < smallestCohort){
            //         smallestCohort = studentCount;
            //     }
            // }

            // Console.WriteLine(sum);
            // int average = sum/count;
            // Console.WriteLine(average);
            // Console.WriteLine(smallestCohort);
            // Console.WriteLine(largestCohort);
            // 2. Find the total number of students who graduated in the past year.
            // 3. How many students were in the biggest cohort?

            // 4. How many students were in the smallest?

            // ---------- Lightning Exercise 2 -------------- //

            // Find the words in the collection that start with the letter 'L'
            List<string> fruits = new List<string>() { "Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry" };

            List<string> LFruits = (from fruit in fruits where fruit[0].ToString() == "L" select fruit).Take(2).ToList();

            // foreach(string fruit in LFruits){
            //     Console.WriteLine(fruit);
            // }

            // LFruits.ForEach(fruit => Console.WriteLine(fruit));


            // var LFruits = fruits.Where(f => f.Substring(0, 1) == "L");

            // var LFruits = fruits.Where(f => f.StartsWith("L"));


            // Which of the following numbers are multiples of 4 or 6
            List<int> numbers = new List<int>(){
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };

            IEnumerable<int> fourSixMultiples = numbers.Where(num => num % 4 == 0 || num % 6 == 0);

            IEnumerable<int> multiples = from number in numbers where number % 4 == 0 || number % 6 == 0 select number;

            // Order these student names alphabetically, in descending order (Z to A)
            List<string> names = new List<string>()
                {
                    "Heather", "James", "Xavier", "Michelle", "Brian", "Nina",
                    "Kathleen", "Sophia", "Amir", "Douglas", "Zarley", "Beatrice",
                    "Theodora", "William", "Svetlana", "Charisse", "Yolanda",
                    "Gregorio", "Jean-Paul", "Evangelina", "Viktor", "Jacqueline",
                    "Francisco", "Tre"
                };

            List<string> descend = names.OrderByDescending(n => n).ToList();

            IEnumerable<string> anotherTry = from taco in names orderby taco descending select taco;

            // Build a collection of these numbers sorted in ascending order
            List<int> nums = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };

            IEnumerable<int> ascending = nums.OrderBy(n => n);
            IEnumerable<int> ascendingTwo = from num in nums orderby num select num;





            // --------- Create some instances of our classes ---------- //
            Cohort one = new Cohort("Cohort 1");
            Cohort twentySix = new Cohort("Cohort 26");


            // Current Students
            Student David = new Student("David", "Bird", "Student at Mountwest", "JavaScript");


            Student Tommy = new Student("Tommy", "Spurlock", "Salsa Dance Instructor", "C#");


            Student Nikki = new Student("Nikki", "Ash", "Student at Mountwest", "JavaScript");



            // Previous Students
            Student Shu = new Student("Shu", "Sajid", "MRI Tech", "C#")
            {
                monthsToHire = 2,
                startingSalary = 50000
            };
            // Shu.monthsToHire = 2;
            // Shu.startingSalary = 50000;

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
            one.enrollStudent(Nikki);
            one.enrollStudent(Tommy);






            one.enrollStudent(new List<Student>() { Tommy, Nikki });

            twentySix.enrollStudent(new List<Student>() { Shu, Natasha, Leah, Seth });

            List<Cohort> allCohorts = new List<Cohort>() { one, twentySix };

            // ------- Data Questions ---------//

            // Let's get a list of the total number of students in each cohort, like the one we started out with
            // .Select() is the new .map()
            List<int> cohortSizes = allCohorts.Select(cohort => cohort.Students.Count).ToList();
            cohortSizes.ForEach(c => Console.WriteLine(c));

            // Which students in Cohort One like C# best?
            // .Where() is the new .filter()

            var cSharpStudents = one.Students.Where(singleStudent => singleStudent.FavoriteLanguage == "C#");

            IEnumerable<Student> cSharpStudents2 = from student in one.Students where student.FavoriteLanguage == "C#" select student;

            // TODO: Get all the students who like C# from all available cohorts?

            // Let's look at a report of how many students in cohort one favor different languages in cohort one
            // JavaScript - 2
            // C# - 1
            var studentReport = from student in one.Students
                                group student by student.FavoriteLanguage into
                                // languageGroup is an IGrouping<string, Student>
                                languageGroup
                                select new Dictionary<string, int>(){
                {languageGroup.Key, languageGroup.Count()}
            };



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
            foreach (ReportItem item in cohortReport)
            {
                Console.WriteLine("----------");
                Console.WriteLine(item.CohortName);
                Console.WriteLine(item.averageMonthsToHire);
                Console.WriteLine(item.averageStartingSalary);
                Console.WriteLine(item.numberOfStudents);

            }




















        }
    }
}
