using System;
using System.Collections.Generic;

namespace example_code
{
    class Cohort
    {

        public Cohort(string nameParam)
        {
            Name = nameParam;
        }
        public string Name { get; }

        //This is an example of method overloading in C#
        // Two methods have the same name, but different types of parameters (aka "arities")
        // If we call enrollStudent with a parameter of type Student, it'll execute the code in the first method

        public void enrollStudent(Student newStudent)
        {
            newStudent.CurrentCohort = this;
            Students.Add(newStudent);
        }



        // If we call enrollStudent and pass in a list of students, it will execute this code
        // This is an example of method-based polymorphism, which means "many forms"
        // Polymorphism is generally referred to the third pillar of object oriented programming, along with encapsulation and inheritance
        // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/polymorphism
        public void enrollStudent(List<Student> newStudents)
        {
            foreach (Student currentStudent in newStudents)
            {
                enrollStudent(currentStudent);
            }
        }



        public List<Student> Students { get; set; } = new List<Student>();
    }
}