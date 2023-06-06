using System;
using System.Collections.Generic;

namespace Dever
{
    public class Activity
    {
        public string Name;
        public int Workload;
        public DateTime Date;
        public List<Student> Students;

        public Activity(string name, int workload, DateTime date)
        {
            Name = name;
            Workload = workload;
            Date = date;
            Students = new List<Student>();
        }

        public void RegisterStudent(Student student)
        {
            Students.Add(student);
        }
    }

    public class Lecture : Activity
    {
        public string Speaker;

        public Lecture(string speaker, string name, int workload, DateTime date) : base(name, workload, date)
        {
            Speaker = speaker;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Workload: {Workload}, Date: {Date}";
        }
    }

    public class Workshop : Activity
    {
        public string CertificateUrl;

        public Workshop(string certificateUrl, string name, int workload, DateTime date) : base(name, workload, date)
        {
            CertificateUrl = certificateUrl;
        }
    }

    public class Student
    {
        public string Name;
        public string Email;

        public Student(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }

    public class Registration
    {
        public DateTime ValidationDate;

        public void RegisterActivity(Activity activity, Student student)
        {
            if (activity.Date > ValidationDate)
            {
                activity.RegisterStudent(student);
                Console.WriteLine("Estudante registrado com sucesso!.");
            }
            else
            {
                Console.WriteLine("Cadastro inválido, favor registre seu cadastro movamente.");
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            DateTime date = DateTime.Now;
            Lecture lecture = new Lecture("Speaker 1", "Lecture 1", 10, date);
            Registration registration = new Registration();
            registration.ValidationDate = DateTime.Now; // Setting the validation date as the current date

            Student student = new Student("Richard junior", "junin.richardson@unifoa.edu.br");
            registration.RegisterActivity(lecture, student);
        }
    }
}