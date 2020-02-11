using System;
using System.Collections.Generic;

namespace httpChallenge
{
    public class Employee
    {
        public int Id { get; set; }
        public string Avatar_url { get; set; }
        public string Employee_id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public DateTime Birthday { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Phone> Phones { get; set; }
        public List<DateTime> Presence_list { get; set; }
        public int Salary { get; set; }
        public Departement Department { get; set; }
        public Position Position { get; set; }
    }

    public class Address
    {
        public string Label { get; set; }
        public string Addresses { get; set; }
        public string City { get; set; }
    }

    public class Phone
    {
        public string Label { get; set; }
        public string Phones { get; set; }
    }

    public class Departement
    {
        public string Name { get; set; }
    }

    public class Position
    {
        public string Name { get; set; }
    }
}
