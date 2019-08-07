using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer1 = new Customer
            {
                Id = 1,
                FirstName = "Erdem",
                LastName = "Ontas",
                City = "Istanbul"
            };

            Customer customer2 = (Customer)customer1.Clone();
            customer2.FirstName = "Salih";

            //These lines tries to prove that customer1 and customer2 are totaly different objects. 
            //Clone() method makes new object not copy the same
            //You reduce the cost of making new reference 
            Console.WriteLine(customer1.FirstName);
            Console.WriteLine(customer2.FirstName);


            Console.ReadLine();
        }
    }

    public abstract class Person
    {
        public abstract Person Clone();
 

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Customer : Person
    {
        public string City { get; set; }

        public override Person Clone()
        {//This helps to clone Customer object
            return (Person)MemberwiseClone();
        }

        public class Employee : Person
        {
            public decimal Salary { get; set; }

            public override Person Clone()
            {//This helps to clone Customer object
                return (Person)MemberwiseClone();
            }
        }
    }
}
