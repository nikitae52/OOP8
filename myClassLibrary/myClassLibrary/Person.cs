using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myClassLibrary
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public Dormitory Dormintory { get; set; }
        public int? DormRoomNumber { get; set; }

        public Person(string name, string surname, string lastname, int age, string phoneNumber, Dormitory dormNumber, int? dormRoomNumb)
        {
            Name = name;
            Surname = surname;
            Lastname = lastname;
            Age = age;
            PhoneNumber = phoneNumber;
            ///bool roomFound = false;
            if (dormNumber != null)
            {
                if (dormNumber.AddResident(this, dormRoomNumb))
                {
                    Dormintory = dormNumber;
                    DormRoomNumber = dormRoomNumb;
                }
                else
                {
                    throw new InvalidOperationException("Кімната не знайдена або вже зайнята.");
                }
            }
        }

        public virtual string Fullinfo()
        {
            string namePart = $"{Surname} {Name} {Lastname}".PadRight(40);
            string agePart = $"Age: {Age}".PadRight(10);
            string phonePart = $"Phone number: {PhoneNumber}".PadRight(30);

            if (Dormintory != null && DormRoomNumber != null)
            {
                string dormPart = $"Dorm: {Dormintory.DormNumber}".PadRight(15);
                string roomPart = $"DormNumber: {DormRoomNumber}".PadRight(15);
                return $"{namePart}{agePart}{phonePart}{dormPart}{roomPart}";
            }
            else
            {
                return $"{namePart}{agePart}{phonePart}";
            }
        }


    }

}
