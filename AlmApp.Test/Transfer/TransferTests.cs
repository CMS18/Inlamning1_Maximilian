using AlmApp.Test.Infrastructure;
using AlmApp.Web.Data;
using System;
using System.Linq;
using Xunit;

namespace AlmApp.Test.Transfer
{
    public class TransferTests
    {
        [Fact]
        public void SuccessfullTransfer()
        {
            BankContext.Create();
            var customers = BankContext.GetCustomers();
            var accountFrom = customers.FirstOrDefault(m => m.Id == 3)?.Account;
            var accountTo = customers.FirstOrDefault(m => m.Id == 4)?.Account;
            var transferAmount = 200M;
            var newBalanceFrom = accountFrom.Balance - transferAmount;
            var newBalanceTo = accountTo.Balance + transferAmount;
            var msg = "Successfully transferred " + transferAmount + " from account: " + accountFrom.Id + " to account: " + accountTo.Id + ". Current balance: account " + accountFrom.Id + ": ";

            var resultMsg = BankRepository.Transfer(accountFrom.Id, accountTo.Id, transferAmount);

            msg += accountFrom.Balance + ", account " + accountTo.Id + ": " + accountTo.Balance + ".";

            Assert.Equal(newBalanceFrom, accountFrom.Balance);
            Assert.Equal(newBalanceTo, accountTo.Balance);
            Assert.Equal(resultMsg, msg);
        }

        [Fact]
        public void TransferInsufficientFunds()
        {
            BankContext.Create();
            var customers = BankContext.GetCustomers();
            var accountFrom = customers.FirstOrDefault(m => m.Id == 3)?.Account;
            var accountTo = customers.FirstOrDefault(m => m.Id == 4)?.Account;
            var transferAmount = 100000M;
            var newBalanceFrom = accountFrom.Balance;
            var newBalanceTo = accountTo.Balance;
            var msg = "Insufficient funds on sender account.";

            var resultMsg = BankRepository.Transfer(accountFrom.Id, accountTo.Id, transferAmount);

            Assert.Equal(newBalanceFrom, accountFrom.Balance);
            Assert.Equal(newBalanceTo, accountTo.Balance);
            Assert.Equal(resultMsg, msg);
        }
    }
}
