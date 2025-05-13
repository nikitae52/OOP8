using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace myClassLibrary
{
    public class Dormitory : ISearchable
    {
        public int DormNumber { get; set; }
        public Address Address { get; set; }

        public int MaxResidents => Rooms.Sum(room => room.Capacity);
        public int FreePlaces => Rooms.Sum(room => room.FreePlaces);
        public List<Room> Rooms { get; set; } = new List<Room>();
        public List<Person> Residents { get; set; } = new List<Person>();

        public Dormitory(int dormnumber, Address address)
        {
            DormNumber = dormnumber;
            Address = address;
        }


        public string Fullinfo()
        {
            return $"Dormitory {DormNumber}, Address: {Address}, Rooms: {Rooms.Count}, Residents: {Residents.Count}";
        }

        public List<Student> SearchStudents(string keyword)
        {
            return Residents
                .OfType<Student>() /// Фільтрує тільки Student
                .Where(s =>
                    s.Name.ToLower().Contains(keyword.ToLower()) ||
                    s.Surname.ToLower().Contains(keyword.ToLower()) ||
                    s.PhoneNumber.ToLower().Contains(keyword.ToLower()) ||
                    s.StudentCardNum.ToLower().Contains(keyword.ToLower())
                ).ToList();
        }



        public bool AddRoom(int NewRoomNumber, int capacity)
        {
            var newRoom = new Room(NewRoomNumber, capacity);
            foreach (var room in Rooms)
            {
                if (room.RoomNum==NewRoomNumber)
                {
                    Console.WriteLine("Кімната з таким номером вже існує");
                    return false;
                }
            }
            Rooms.Add(newRoom);
            return true;
        }
        public bool AddResident(Person person, int? dormRoomNumber)
        {
            if (!Residents.Contains(person))
            {
                Residents.Add(person);
                foreach (var room in Rooms)
                {
                    if (room.RoomNum == dormRoomNumber && !room.Dwellers.Contains(person) && room.FreePlaces>=1)
                    {
                        room.Dwellers.Add(person);
                        person.Dormintory = this;
                        person.DormRoomNumber = dormRoomNumber;
                        ///Console.WriteLine($"Резидент {person.Surname} {person.Name} успішно доданий до кімнати {room.RoomNum}");
                        return true;
                    }
                }
                throw new InvalidOperationException ("Такої кімнати не існує, або у ній немає вільним місць");
            }
            else
            {
                throw new InvalidOperationException("Ця особа вже проживає в гуртожитку");
            }

        }

        public bool RemoveResident(Person person)
        {
            if (Residents.Contains(person))
            {
                Residents.Remove(person);
                foreach (var room in Rooms)
                {
                    if (room.Dwellers.Contains(person))
                    {
                        room.Dwellers.Remove(person);
                        person.Dormintory = null;
                        person.DormRoomNumber = null;
                        ///Console.WriteLine($"Резидент {person.Surname} {person.Name} успішно виселений  з гуртожитку ");
                        return true;
                    }
                }

                /// Якщо не знайдено в жодній кімнаті, все одно очищаємо дані
                person.Dormintory = null;
                person.DormRoomNumber = null;
                throw new InvalidOperationException($"Резидент {person.Surname} {person.Name} видалений зі списку мешканців, але не був знайдений у жодній кімнаті.");
                ///return true;

            }
            else
            {
                throw new InvalidOperationException("Ця особа не проживає в гуртожитку");
                ///return false;
            }
        }
    }

}
