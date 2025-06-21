
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Hosbital_homework.Models
{
    internal class User
    {
        private string _email;
        public string name { get; set; }
        public string surname { get; set; }
        public string Email
        {
            get { return _email; }
            set
            {
                if (value.EndsWith("@gmail.com"))
                {
                    _email = value;
                }
                else
                {
                    Console.WriteLine(" ~ Email is wrong");
                }
            }
        }
        public string phoneNumber { get; set; }

        private User(string name, string surname, string email, string phoneNumber)
        {
            this.name = name;
            this.surname = surname;
            this.Email = email;
            this.phoneNumber = phoneNumber;
        }
        public static User? Create(string name, string surname, string email, string phone)
        {
            if (!email.EndsWith("@gmail.com"))
            {
                return null;
            }
            else
            {
                User newUser = new User(name, surname, email, phone);
                return newUser;
            }
        }

        public override string ToString() => $@"
Name: {name}
Surname: {surname}
Email: {Email}
Phone number: {phoneNumber}";

    }
}
