using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace XamarinAndroidLicao3
{
    public class Employee
    {
        public override string ToString()
        {
            return Name;
        }

        private string name;
        public string Name;
        private string position;
        public string Position;
        private string email;
        public string Email;

        public Employee(string name, string position, string email)
        {
            Name = name;
            Position = position;
            Email = email;
        }
    }

    public class EmployeeList
    {
        public Employee[] GetEmployees(int number)
        {
            Employee[] employess = new Employee[number];
            String[] positions = { "Supervisor", "Operador", "Gerente", "Diretor" };
            Random rdn = new Random();
            for (int i = 0; i < number; i++)
            {
                var name = Guid.NewGuid().ToString().Substring(0, 10);

                var newEmployee = new Employee(
                    name,
                    positions[rdn.Next(0,3)],
                    name + "@drizzlelandstudios.com"
                    );
                employess[i] = newEmployee;
            }
            return employess;
        }
    }
}