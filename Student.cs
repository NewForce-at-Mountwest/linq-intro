using System;
using System.Collections.Generic;

namespace example_code
{
    class Student
    {
        public Student(string firstNameParam, string lastNameParam, string backgroundParam, string langParam)
        {
            FirstName = firstNameParam;
            LastName = lastNameParam;
            Background = backgroundParam;
            FavoriteLanguage = langParam;
        }
        public string FirstName { get; }

        public string LastName { get; }

        public string Background { get; }

        public double startingSalary {get; set;}

        public double monthsToHire { get; set;}


        public string FavoriteLanguage {get; set;}

        public Cohort CurrentCohort { get; set; }

    }
}