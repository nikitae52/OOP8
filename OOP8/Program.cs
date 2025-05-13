using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myClassLibrary;

namespace OOP8
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            ///Можливість створити групу
            Console.WriteLine("Creating 3 groups: ");
            var Groups = new List<Group>
            {
                new Group("IP-41", "Software Engeneering",1, "Juliy Polupan"),
                new Group("IP-42", "Software Engeneering",1, "Oleh Lisovichenko"),
                new Group("IP-45", "Software Engeneering",1, "Volodymyr Clichko"),
            };

            ///Можливість перегляду як списку даних груп 
            foreach (var group in Groups)
            {
                Console.WriteLine(group.GroupFullinfo());
            }


            ///Можливість видалення групи
            Console.WriteLine("\nDeleting group IP-45::");
            Groups.Remove(Groups.FirstOrDefault(g => g.Name == "IP-45"));
            Console.WriteLine("Groups after deletion:");
            foreach (var group in Groups)
            {
                Console.WriteLine(group.GroupFullinfo());
            }

            ///Можливість зміни даних групи
            Groups[0].Course = 2;
            Groups[0].StudCurator = "Oleh Lisovichenko";
            Console.WriteLine(Groups[0].GroupFullinfo());

            ///Можливість додавання даних про гуртожиток
            var dormitoryAddress = new Address("Kyiv", "Borshchahivska", 148);
            var dormitory18 = new Dormitory(20, dormitoryAddress);

            ///Можливість зміни даних про гуртожиток
            dormitory18.DormNumber = 18;


            dormitory18.AddRoom(212, 4);
            dormitory18.AddRoom(1, 4);

            ///Можливість створення студента та додавання його до групи
            Console.WriteLine("\nAdding 5 students to the first group:\n");
            Groups[0].AddStudent("Bohdan", "Sokurenko", "Vitaliiovych", 19, "+380631545159", null, null, "1R2C34B5V6");
            Groups[0].AddStudent("Mykola", "Ponomarenko", "Oleksandrovych", 18, "+380683449158", dormitory18, 212, "3T7K29M1QX");
            Groups[0].AddStudent("Artem", "Cherednichenko", "Olehovych", 17, "+380983453037", dormitory18, 212, "9P5D43L8ZN");
            Groups[0].AddStudent("Maksym", "Kolomiiets", "Oleksiiovych", 18, "+380660544379", null, null, "6A1C82V4JR");
            Groups[0].AddStudent("Mykyta", "Kozlov", "Maksymovych", 18, "+380667992569", null, null, "2B9R76F3WY");
            Groups[1].AddStudent("Vitalii", "Lazarev", "Vadymovych", 18, "+380996036304", null, null, "B9R7C2VWY8");
            Groups[1].AddStudent("Taras", "Serhiienko", "Andriiovych", 18, "+380671583065", null, null, "C8V2B1R9Y6");

            ///Можливість перегляду даних окремої групи
            Console.WriteLine(Groups[0].GetAllStudentsInfo());


            ///Можливість видалити студента з групи
            Groups[0].RemoveStudent("9P5D43L8ZN");

            ///Можливість зміни даних окремого студента
            Groups[0].Students[0].PhoneNumber = "+380660544000";

            ///Можливість перегляду даних всіх студентів
            foreach (var group in Groups)
            {
                Console.WriteLine(group.GetAllStudentsInfo());
            }

            ///Можливість виписки студента з гуртожитку
            dormitory18.RemoveResident(Groups[0].Students[1]);

            ///Можливість запису студента в гуртожиток
            dormitory18.AddResident(Groups[0].Students[3], 212);
            dormitory18.AddResident(Groups[0].Students[2], 212);
            dormitory18.AddResident(Groups[1].Students[0], 1);

            ///Можливість перегляду даних окремого студента
            Groups[0].Students[3].Fullinfo();

            ///Можливість перегляду даних проживаючих у гуртожитку
            Console.WriteLine("\nDormitory residents data:");
            foreach (var person in dormitory18.Residents)
            {
                person.Fullinfo();
            }

            ///Можливість перегляду даних про проживаючих у певній кімнаті
            foreach (var person in dormitory18.Rooms[0].Dwellers)
            {
                person.Fullinfo();
            }

            ///Можливість перегляну кількості вільних місць у гуртожитку та кімнатах
            Console.WriteLine($"\nFree places in the dormitory: {dormitory18.FreePlaces}");
            foreach (var room in dormitory18.Rooms)
            {
                Console.WriteLine($"Free places in room{room.RoomNum}: {room.FreePlaces}");
            }

            ///Можливість пошуку студента за прізвищем/ім'ям
            Console.WriteLine("\nEnter student's first or last name to search:");
            string key = Console.ReadLine();
            foreach (var group in Groups)
            {
                var result=group.SearchStudents(key);
                    foreach (var student in result)
                    {
                        Console.WriteLine(student.Fullinfo());
                    }
            }

            ///Можливість пошуку студента у певній групі
            Console.WriteLine("\nSearching for students in group IP-41:");
            var Groupresult=Groups[0].SearchStudents("nko");
            foreach (var student in Groupresult)
            {
                Console.WriteLine(student.Fullinfo());
            }

            ///Можливість пошуку студента у гуртожитку
            Console.WriteLine("\nSearching for students in dormitory:");
            var Dormresult = dormitory18.SearchStudents("o");
            foreach (var student in Dormresult)
            {
                Console.WriteLine(student.Fullinfo());
            }



        }
    }
}
