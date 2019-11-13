using System;
using System.Collections.Generic;
using System.Text;
using AlmApp.Web.Data;
using AlmApp.Web.Entities;

namespace AlmApp.Test.Infrastructure
{
    public class BankContext
    {
        public static IEnumerable<Customer> GetCustomers()
        {
            return BankRepository.GetCustomers();
        }
        public static void Create()
        {
            var gabriel = new Customer {Id = 1, Name = "Gabriel",
                Account = new Account(1, 500)
            };

            var amanda = new Customer {Id = 2, Name = "Amanda",
                Account = new Account(2, 1500)
            };

            var max = new Customer {Id = 3, Name = "Max",
                Account = new Account(3, 2500)
            };

            var customers = new List<Customer> {gabriel, amanda, max};

            BankRepository.AddCustomers(customers);
        }
    }
}
