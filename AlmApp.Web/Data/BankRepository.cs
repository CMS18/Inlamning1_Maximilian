using System.Collections.Generic;
using AlmApp.Web.Entities;

namespace AlmApp.Web.Data
{
    public static class BankRepository
    {
        private static IEnumerable<Customer> Customers { get; set; }

        public static void AddCustomers(IEnumerable<Customer> customers)
        {
            Customers = customers;
        }

        public static IEnumerable<Customer> GetCustomers()
        {
            return Customers;
        }
    }
}
