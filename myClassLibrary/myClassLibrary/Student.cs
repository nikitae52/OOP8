using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myClassLibrary;

namespace myClassLibrary
{
    public class Student : Person
    {
        public string StudentCardNum { get; set; }

        internal Student(string name, string surname, string lastname, int age, string phoneNumber,
               Dormitory dormNumber, int? dormRoomNumb, string studentCardNum)
        : base(name, surname, lastname, age, phoneNumber, dormNumber, dormRoomNumb)
        {
            ///Group = group ?? throw new ArgumentNullException(nameof(group));
            StudentCardNum = studentCardNum;
        }

        public override string Fullinfo()
        {
            string namePart = $"{Surname} {Name} {Lastname}".PadRight(40);
            string agePart = $"Age: {Age}".PadRight(10);
            string phonePart = $"Phone number: {PhoneNumber}".PadRight(30);
            string cardPart = $"Student Card: {StudentCardNum}".PadRight(30);

            string baseInfo = $"{namePart}{agePart}{phonePart}{cardPart}";

            if (Dormintory != null && DormRoomNumber != null)
            {
                string dormPart = $"Dorm: {Dormintory.DormNumber}".PadRight(15);
                string roomPart = $"DormNumber: {DormRoomNumber}".PadRight(15);
                return $"{baseInfo}{dormPart}{roomPart}";
            }
            else
            {
                return baseInfo;
            }
        }


    }
}
