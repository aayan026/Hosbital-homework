
using Hosbital_homework.Models;
using System.Collections.Generic;

class Program
{
    static void ReserveHour(Doctor doctor, User user)
    {
        var ReceptionHourlist = doctor.receptionHours;
        int choiceIndex = 0;
        while (true)
        {
            Console.Clear();
            Console.WriteLine($" ~ Dr.{doctor.name}'s reception hours: ");
            for (int i = 0; i < ReceptionHourlist.Count; i++)
            {
                if (i == choiceIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(ReceptionHourlist[i]);
                    Console.ResetColor();
                }
                else
                    Console.WriteLine(ReceptionHourlist[i]);
            }
            Console.WriteLine("");
            var key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.UpArrow)
                choiceIndex = (choiceIndex == 0) ? ReceptionHourlist.Count - 1 : choiceIndex - 1;
            else if (key == ConsoleKey.DownArrow)
                choiceIndex = (choiceIndex + 1) % ReceptionHourlist.Count;
            else if (key == ConsoleKey.Enter)
            {
                if (ReceptionHourlist[choiceIndex].isReserved)
                {
                    Console.WriteLine(" ~ This hour is already reserved. Please choose another hour.");
                    Console.ReadKey();
                    continue;
                }
                if (choiceIndex >= 0 && choiceIndex <= ReceptionHourlist.Count)
                {
                    doctor.ReserveHour(choiceIndex);
                    Console.WriteLine($" Thank you, {user.name} {user.surname}. You have successfully booked an appointment with Dr.{doctor.name} at {ReceptionHourlist[choiceIndex].start.ToString("hh\\:mm")} -{ReceptionHourlist[choiceIndex].start.ToString("hh\\:mm")}");
                    Console.ReadKey();
                    break;
                }
            }
        }

    }
    static void ChoiceDoctor(Department department, User user)
    {
        int choiceIndex = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine(" ~ Doctors\n");
            for (int i = 0; i < department.doctors.Count; i++)
            {
                if (i == choiceIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(department.doctors[i]);
                    Console.ResetColor();
                }
                else
                    Console.WriteLine(department.doctors[i]);
            }
            Console.WriteLine("");
            var key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.UpArrow)
                choiceIndex = (choiceIndex == 0) ? department.doctors.Count - 1 : choiceIndex - 1;
            else if (key == ConsoleKey.DownArrow)
                choiceIndex = (choiceIndex + 1) % department.doctors.Count;
            else if (key == ConsoleKey.Enter)
            {
                if (choiceIndex >= 0 && choiceIndex <= department.doctors.Count)
                {
                    ReserveHour(department.doctors[choiceIndex], user);
                    break;
                }
            }
        }

    }
    static void MainMenu(User user, List<Department> departments)
    {
        Console.Clear();
        int choiceIndex = 0;
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"\n ~ Welcome {user.name} {user.surname}\n\n");

            Console.WriteLine(" Departments");
            for (int i = 0; i < departments.Count; i++)
            {
                if (i == choiceIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($" {departments[i]}");
                    Console.ResetColor();
                }
                else
                    Console.WriteLine($" {departments[i]}");
            }
            Console.WriteLine("");
            var key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.UpArrow)
                choiceIndex = (choiceIndex == 0) ? departments.Count - 1 : choiceIndex - 1;
            else if (key == ConsoleKey.DownArrow)
                choiceIndex = (choiceIndex + 1) % departments.Count;
            else if (key == ConsoleKey.Enter)
            {
                if (choiceIndex >= 0 && choiceIndex < departments.Count)
                {
                    ChoiceDoctor(departments[choiceIndex], user);
                    break;
                }

            }
        }

    }
    static void Main(string[] args)
    {
        Department department1 = new Department("Pediatriya");
        Department department2 = new Department("Travmatologiya");
        Department department3 = new Department("Stamotologiya");
        List<Department> departments = new List<Department> { department1, department2, department3 };
        Hosbital hosbital = new Hosbital(departments);


        Doctor doctor1 = new Doctor("Hemid", "Hemidli", 7, department1);
        Doctor doctor2 = new Doctor("Naile", "Memmedova", 5, department2);
        Doctor doctor3 = new Doctor("Nuray", "Quliyeva", 3, department2);
        Doctor doctor4 = new Doctor("Elvin", "Muradov", 7, department3);
        Doctor doctor5 = new Doctor("Nigar", "Rzayeva", 2, department1);
        Doctor doctor6 = new Doctor("Rauf", "Səlimov", 10, department2);
        Doctor doctor7 = new Doctor("Ləman", "Məmmədli", 4, department3);
        Doctor doctor8 = new Doctor("Tunar", "Əliyev", 6, department1);

        while (true)
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t\tHosbital\n");
            Console.Write(" Name: ");
            string name = Console.ReadLine();
            Console.Write("\n Surname: ");
            string surname = Console.ReadLine();
            string email;
            Console.Write("\n Phone Number: ");
            string phone = Console.ReadLine();
            User? newUser = null;
            do
            {
                Console.Write("\n Email: ");
                email = Console.ReadLine();

                newUser = User.Create(name, surname, email, phone);
                if (newUser == null)
                {
                    Console.WriteLine("\n Email is wrong..try again!");
                }

            }
            while (newUser == null);
            Console.WriteLine(" ~ Registration completed successfully.");
            MainMenu(newUser, departments);
        }
    }
}
