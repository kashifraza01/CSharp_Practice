using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace KashifRaza
{
    class Students
    {
        public int id { get; set; }
        public string name { get; set; }
        public double gpa { get; set; }
    }

    internal class Program
    {
        static List<Students> students = new List<Students>();
        static string f = "students.json";

        static void Main(string[] args)
        {
            load();

            while (true)
            {
                Console.WriteLine("\n1. Add  2. View  3. Search  4. Save  5. Exit");
                Console.Write("Choose: ");

                int c = int.Parse(Console.ReadLine());

                if (c == 1)
                {
                    Students s = new Students();

                    Console.Write("ID: ");
                    s.id = int.Parse(Console.ReadLine());

                    Console.Write("Name: ");
                    s.name = Console.ReadLine();

                    Console.Write("GPA: ");
                    s.gpa = double.Parse(Console.ReadLine());

                    students.Add(s);
                }

                if (c == 2)
                {
                    students.ForEach(student =>
                        Console.WriteLine($"{student.id} - {student.name} - {student.gpa}"));
                }

                if (c == 3)
                {
                    Console.Write("ID: ");
                    int id = int.Parse(Console.ReadLine());

                    var student = students.FirstOrDefault(x => x.id == id);

                    Console.WriteLine(student != null
                        ? student.name
                        : "not found");
                }

                if (c == 4)
                {
                    save();
                    Console.WriteLine("Saved successfully.");
                }

                if (c == 5)
                {
                    save();
                    break;
                }
            }
        }

        static void load()
        {
            if (File.Exists(f))
            {
                string json = File.ReadAllText(f);
                students = JsonSerializer.Deserialize<List<Students>>(json)
                           ?? new List<Students>();
            }
        }

        static void save()
        {
            string json = JsonSerializer.Serialize(
                students,
                new JsonSerializerOptions { WriteIndented = true }
            );

            File.WriteAllText(f, json);
        }
    }
}
