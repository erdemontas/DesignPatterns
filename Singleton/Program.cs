using System;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerManager = CustomerManager.CreateAsSingleton();
            customerManager.Save();
        }
    }

    class CustomerManager
    {
        //Assume this class does only CRUD operations.

        static CustomerManager _customerManager;
        
        private CustomerManager()
        {

        }

        public static CustomerManager CreateAsSingleton()
        {
            return _customerManager ?? (_customerManager = new CustomerManager());
        }

        public void Save()
        {
            Console.WriteLine("Saved.");
        }
    }
}
