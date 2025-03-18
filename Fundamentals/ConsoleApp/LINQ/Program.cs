using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * 📌 LINQ: Language Integrated Query
             * ----------------------------------
             * What is LINQ?
             * - LINQ is a feature in C# that provides a consistent way to query collections, databases, XML, and more.
             * - It allows writing SQL-like queries **inside C# code** for better readability and efficiency.
             * - LINQ supports **two types of syntax**:
             *   1️⃣ Query Syntax (SQL-like syntax)
             *   2️⃣ Method Syntax (Lambda expressions)
             * - It is **type-safe, concise, and optimized** for performance.
             * 
             */

            // 🛠 Creating a sample list of numbers
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // ✅ 1️⃣ QUERY SYNTAX (SQL-LIKE)
            var evenNumbersQuery = from number in numbers
                                   where number % 2 == 0 // Filters even numbers
                                   orderby number descending // Sorts in descending order
                                   select number; // Selects the final result

            Console.WriteLine($"Even numbers (Query Syntax): {string.Join(", ", evenNumbersQuery)}");

            // ✅ 2️⃣ METHOD SYNTAX (LAMBDAS)
            var oddNumbersMethod = numbers
                                   .Where(number => number % 2 != 0) // Filters odd numbers
                                   .OrderByDescending(number => number) // Sorts in descending order
                                   .ToList(); // Converts to List<int>

            Console.WriteLine($"Odd numbers (Method Syntax): {string.Join(", ", oddNumbersMethod)}");

            // 🛠 Creating a list of students for complex LINQ queries
            List<Student> students = new List<Student>
            {
                new Student { Id = 1, Name = "Alice", Age = 22, Grade = 85 },
                new Student { Id = 2, Name = "Bob", Age = 25, Grade = 78 },
                new Student { Id = 3, Name = "Charlie", Age = 20, Grade = 90 },
                new Student { Id = 4, Name = "David", Age = 23, Grade = 76 },
                new Student { Id = 5, Name = "Eve", Age = 21, Grade = 95 }
            };

            // ✅ 3️⃣ FILTERING: Get students older than 21
            var olderStudents = students.Where(student => student.Age > 21).ToList();
            Console.WriteLine("\nStudents older than 21:");
            foreach (var student in olderStudents)
            {
                Console.WriteLine($"{student.Name} ({student.Age} years old)");
            }

            // ✅ 4️⃣ SORTING: Sort students by Grade (Descending)
            var sortedStudents = students.OrderByDescending(student => student.Grade).ToList();
            Console.WriteLine("\nStudents sorted by grade (Descending):");
            foreach (var student in sortedStudents)
            {
                Console.WriteLine($"{student.Name}: {student.Grade}");
            }

            // ✅ 5️⃣ PROJECTION (SELECT): Extract only student names (Projection)
            var studentNames = students.Select(student => student.Name).ToList();
            Console.WriteLine($"\nStudent Names: {string.Join(", ", studentNames)}");

            // ✅ 6️⃣ GROUPING: Group students by Age
            var groupedByAge = students.GroupBy(student => student.Age);
            Console.WriteLine("\nStudents grouped by age:");
            foreach (var group in groupedByAge)
            {
                Console.WriteLine($"Age {group.Key}: {string.Join(", ", group.Select(s => s.Name))}");
            }

            // ✅ 7️⃣ AGGREGATION: Find the average grade of students
            double averageGrade = students.Average(student => student.Grade);
            Console.WriteLine($"\nAverage Student Grade: {averageGrade}");

            // ✅ 8️⃣ FIRST, FIRSTORDEFAULT, SINGLE, SINGLEORDEFAULT
            var firstStudent = students.First(); // Gets the first student
            var firstOrDefaultStudent = students.FirstOrDefault(s => s.Grade > 100); // Returns null if no match
            var singleStudent = students.Single(s => s.Id == 3); // Returns a single student (throws error if multiple found)
            var singleOrDefaultStudent = students.SingleOrDefault(s => s.Id == 10); // Returns null if not found

            Console.WriteLine($"\nFirst student: {firstStudent.Name}");
            Console.WriteLine($"FirstOrDefault (Grade > 100): {firstOrDefaultStudent?.Name ?? "No match"}");
            Console.WriteLine($"Single (Id = 3): {singleStudent.Name}");
            Console.WriteLine($"SingleOrDefault (Id = 10): {singleOrDefaultStudent?.Name ?? "No match"}");

            // ✅ 9️⃣ CHECKING CONTAINS, ANY, ALL
            bool hasStudentsWithGradeAbove90 = students.Any(s => s.Grade > 90);
            bool allStudentsAreAdults = students.All(s => s.Age >= 18);
            bool containsStudentNamedAlice = students.Select(s => s.Name).Contains("Alice");

            Console.WriteLine($"\nAny student with grade > 90? {hasStudentsWithGradeAbove90}");
            Console.WriteLine($"All students are adults? {allStudentsAreAdults}");
            Console.WriteLine($"Does the list contain a student named Alice? {containsStudentNamedAlice}");

            Console.ReadLine(); // Keeps console open
        }
    }

    // 📌 Student Class (For Complex LINQ Queries)
    class Student
    {
        public int Id { get; set; }  // Unique ID for student
        public string Name { get; set; }  // Student name
        public int Age { get; set; }  // Student age
        public int Grade { get; set; }  // Student grade (out of 100)
    }
}
