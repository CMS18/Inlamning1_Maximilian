using AlmApp.Test.Infrastructure;
using AlmApp.Web.Data;
using System.Linq;
using Xunit;

namespace AlmApp.Test.Transactions
{
    public class BankWithdrawalTests
    {
        [Fact]
        public void WithdrawalFromAccount_Calculated()
        {
            // Arrange
            BankContext.Create();
            var customers = BankContext.GetCustomers();
            var account = customers.FirstOrDefault(m => m.Id == 1)?.Account;
            decimal withdrawalAmount = 100;
            var result = account.Balance - withdrawalAmount;

            // Act
            BankRepository.Withdrawal(account.Id, withdrawalAmount);

            //Assert
            Assert.Equal(result, account.Balance);
        }
        [Fact]
        public void WithdrawalFromAccount_NotCalculated()
        {
            // Arrange
            BankContext.Create();
            var customers = BankContext.GetCustomers();
            var account = customers.FirstOrDefault(m => m.Id == 1)?.Account;
            var balanaceBeforeAttemptWithdrawal = account.Balance;
            decimal withdrawalAmount = 700;
            var result = account.Balance - withdrawalAmount;

            // Act
            BankRepository.Withdrawal(account.Id, withdrawalAmount);

            //Assert
            Assert.NotEqual(result, account.Balance);
            Assert.Equal(balanaceBeforeAttemptWithdrawal, account.Balance);
        }
    }
}