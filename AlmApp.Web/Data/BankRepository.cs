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
                    msg = "Successfully withdrew " +amount+ " from account " +accountNumber +". Current balance is " +customer.Account.Balance;
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
                    msg = "Successfully deposit " + amount + " to account " + accountNumber + ". Current balance is " + customer.Account.Balance;
                }
            }

            return msg;
        }

        public static string Transfer(int accountNumberFrom, int accountNumberTo, decimal amount)
        {
            var customerFrom = Customers.FirstOrDefault(a => a.Account.Id == accountNumberFrom);
            var customerTo = Customers.FirstOrDefault(a => a.Account.Id == accountNumberTo);
            if(customerFrom != null)
            {
                if(customerTo != null)
                {
                    if(amount <= 0)
                    {
                        return "Amount must be a number greater than 0.";
                    }
                    if(customerFrom.Account.Balance >= amount)
                    {
                        customerFrom.Account.Balance -= amount;
                        customerTo.Account.Balance += amount;
                        return "Successfully transferred " + amount + " from account: " + accountNumberFrom + " to account: " + accountNumberTo + ". Current balance: account " + customerFrom.Account.Id + ": " + customerFrom.Account.Balance + ", account " + customerTo.Account.Id + ": " + customerTo.Account.Balance + ".";
                    }
                    return "Insufficient funds on sender account.";
                }
                return "Receiver account not found.";
            }
            return "Sender account not found.";
        }
    }
}
