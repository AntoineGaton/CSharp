using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    /*
     * 📌 OBJECT-ORIENTED PROGRAMMING (OOP) IN C#
     * ------------------------------------------
     * OOP is a programming paradigm based on the concept of "objects" that interact with each other.
     * It helps in building **scalable, reusable, and organized code**.
     *
     * 🔹 The **Four Pillars of OOP**:
     * 1️⃣ Encapsulation – Protecting data using access modifiers.
     * 2️⃣ Inheritance – Creating a new class from an existing one.
     * 3️⃣ Polymorphism – Multiple forms of the same method (overriding, overloading).
     * 4️⃣ Abstraction – Hiding implementation details and exposing only what is necessary.
     */

    class Program
    {
        static void Main(string[] args)
        {
            // ✅ Creating an object of Person (Encapsulation)
            Person person = new Person("Alice", 25);
            Console.WriteLine(person.GetInfo());

            // ✅ Creating an object of Student (Inheritance)
            Student student = new Student("Bob", 22, "Computer Science");
            Console.WriteLine(student.GetInfo());

            // ✅ Demonstrating Polymorphism - Method Overriding
            Person teacher = new Teacher("Dr. Smith", 45, "Mathematics");
            Console.WriteLine(teacher.GetInfo()); // Calls overridden method in Teacher class

            // ✅ Using Interface (Abstraction)
            IAnimal dog = new Dog();
            dog.MakeSound(); // Calls method from Dog class

            Console.ReadLine(); // Keeps console open
        }
    }

    // 📌 1️⃣ ENCAPSULATION - Protecting Data Using Access Modifiers
    public class Person
    {
        // Private fields (Encapsulation: Data is hidden)
        private string _name;
        private int _age;

        // Public property with getter and setter
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        // Constructor (Encapsulation: Initializing values)
        public Person(string name, int age)
        {
            _name = name;
            _age = age;
        }

        // Public method to expose data safely
        public virtual string GetInfo()
        {
            return $"Name: {_name}, Age: {_age}";
        }
    }

    // 📌 2️⃣ INHERITANCE - Creating a New Class from an Existing Class
    public class Student : Person
    {
        // New property specific to Student
        public string Major { get; set; }

        // Constructor (calls base constructor)
        public Student(string name, int age, string major) : base(name, age)
        {
            Major = major;
        }

        // Overriding GetInfo to include Student details
        public override string GetInfo()
        {
            return base.GetInfo() + $", Major: {Major}";
        }
    }

    // 📌 3️⃣ POLYMORPHISM - Method Overloading and Overriding
    public class Teacher : Person
    {
        public string Subject { get; set; }

        // Constructor
        public Teacher(string name, int age, string subject) : base(name, age)
        {
            Subject = subject;
        }

        // Method Overriding (Polymorphism)
        public override string GetInfo()
        {
            return base.GetInfo() + $", Subject: {Subject}";
        }
    }

    // 📌 4️⃣ ABSTRACTION - Hiding Implementation and Exposing Essentials
    // ✅ Abstract Class (Cannot be instantiated directly)
    public abstract class Animal
    {
        // Abstract method (Must be implemented in derived classes)
        public abstract void MakeSound();

        // Non-abstract method (Can be used as is)
        public void Eat()
        {
            Console.WriteLine("Eating food...");
        }
    }

    // ✅ Implementing Abstract Class
    public class Dog : Animal
    {
        // Implementing abstract method
        public override void MakeSound()
        {
            Console.WriteLine("Woof! Woof!");
        }
    }

    // ✅ Using Interface for Abstraction
    public interface IAnimal
    {
        void MakeSound();
    }

    // Implementing Interface
    public class Cat : IAnimal
    {
        public void MakeSound()
        {
            Console.WriteLine("Meow! Meow!");
        }
    }
}
