using DB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.Numerics;


// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Console.WriteLine("dfdfdf");
static void AddStudent(string name)
{
    GradesDbContext db = new GradesDbContext();
    Student s = new Student
    {
        Name = name
    };
   db.Students.Add(s);
    db.SaveChanges();
}
static void AddGrade(int grade, int id)
{
    GradesDbContext db = new GradesDbContext();
    Console.WriteLine("Enter your name");
    Grade p = new Grade
    {
        Score = grade,
        StudentId = id

    };//
    db.Entry(p).State = EntityState.Added;
    db.SaveChanges();
}
static void PrintStudentByName()
{
    GradesDbContext db = new GradesDbContext();
    Console.WriteLine("Enter your name");
    string? name = Console.ReadLine();
    Student? p = db.Students.Where(pp => pp.Name == name).FirstOrDefault();

    if (p != null)
    {
        p.Name = name;
        //The belolw state is done automatically as p is already tracked!
        //db.Entry(p).State = EntityState.Modified;
        
        db.SaveChanges();
    }

}
static void PrintAllStudenyGradesById(int id)
{
    GradesDbContext db = new GradesDbContext();
    List<Grade> Grades = db.Grades.Where(g => g.StudentId == id).ToList();
    Console.WriteLine(Grades);
}
static void PrintAllStudentGradesSum()
{
    GradesDbContext db = new GradesDbContext();
    List<Grade> Grades = db.Grades.ToList();
    double Sum = 0;
    foreach (Grade grade in Grades)
    {
        Sum += grade.Score;
    }
    Console.WriteLine(Sum/Grades.Count);
}



AddStudent("shahar");
AddGrade(13,1);
PrintStudentByName();
