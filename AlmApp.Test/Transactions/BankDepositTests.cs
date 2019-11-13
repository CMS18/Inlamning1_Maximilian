using System.Linq;
using AlmApp.Test.Infrastructure;
using AlmApp.Web.Data;
using Xunit;

namespace AlmApp.Test.Transactions
{
    public class BankDepositTests
    {
        [Fact]
        public void DepositToAccount_Calculated()
        {
            // Arrange
            BankContext.Create();
            var customers = BankContext.GetCustomers();
            var account = customers.FirstOrDefault(m => m.Id == 1)?.Account;
            decimal depositAmount = 100;
            var result = account.Balance + depositAmount;

            // Act
            BankRepository.Deposit(account.Id, depositAmount);

            //Assert
            Assert.Equal(result, account.Balance);
        }
    }
}
