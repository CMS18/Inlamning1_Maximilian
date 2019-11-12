namespace AlmApp.Web.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }

        public Account(int id, decimal balance)
        {
            Id = id;
            Balance = balance;
        }
    }
}
