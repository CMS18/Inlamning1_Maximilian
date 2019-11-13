using System.Collections.Generic;
using System.Linq;
using AlmApp.Web.Entities;

namespace AlmApp.Web.Data
{
    public class BankRepository
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

        public static string Withdrawal(int accountNumber, decimal amount)
        {
            string msg = "Account number not found";

            var customer = Customers.FirstOrDefault(m => m.Account.Id == accountNumber);

            if (customer != null)
            {
                if (amount < 0)
                {
                    msg = "You can't withdraw a negative amount";
                }

                else if (amount > customer.Account.Balance)
                {
                    msg = "You have insufficient founds";
                }

                else
                {
                    customer.Account.Balance = customer.Account.Balance - amount;
                    msg = "Successfully withdrew " +amount+ " from " +accountNumber;
                }
            }

            return msg;
        }
        public static string Deposit(int accountNumber, decimal amount)
        {
            string msg = "Account number not found";

            var customer = Customers.FirstOrDefault(m => m.Account.Id == accountNumber);

            if (customer != null)
            {
                if (amount < 0)
                {
                    msg = "You can't deposit a negative amount";
                }

                else
                {
                    customer.Account.Balance += amount;
                    msg = "Successfully deposit " + amount + " to " + accountNumber;
                }
            }

            return msg;
        }

    }
}
