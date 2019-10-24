using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorDBLibrary.DataAccess;


/*
    - This class is for testing our application 
*/
namespace DoctorDBUnitTester
{
    class Program
    {
        static void Main(string[] args)
        {

            InsertQueries iq = new InsertQueries();

            string uName, uPass, email, contact;

            Console.WriteLine("What is your Username?");
            uName = Console.ReadLine();

            Console.WriteLine("What is your Password?");
            uPass = Console.ReadLine();

            Console.WriteLine("What is your Email?");
            email = Console.ReadLine();

            Console.WriteLine("What is your Contact Number?");
            contact = Console.ReadLine();

            iq.CreateUser(uName,uPass,email,contact);
            Console.WriteLine("User Has Been Saved!");

            // To keep the CONSOLE OPEN
            Console.Read();
            
        }
    }
}
