﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myClassLibrary
{
    public class Address
    {
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }

        public Address(string city, string street, int houseNumber)
        {
            City = city;
            Street = street;
            HouseNumber = houseNumber;
        }

        public override string ToString()
        {
            return $"{City}, {Street} {HouseNumber}";
        }
    }
}
