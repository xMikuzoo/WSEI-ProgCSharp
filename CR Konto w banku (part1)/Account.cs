namespace CR_Konto_w_banku__part1_
{
    public class Account : IAccount
    {
        public Account(string name, decimal balance = 0m) 
        {
            this.Name = PrepareName(name);
            this.Balance = PrepareBalance(balance);
            this.IsBlocked = false;
        }

        public string Name { get;}
        public decimal Balance { get; set; }
        public bool IsBlocked { get; private set; }

        public void Block()
        {
            this.IsBlocked = true;
        }

        public void Unblock()
        {
            this.IsBlocked = false;
        }

        public bool Deposit(decimal money)
        {
            if(money < 0 || IsBlocked)
            {
                return false;
            }
            Balance += money;
            return true;
        }

        public bool Withdrawal(decimal money)
        {
            if (money <= 0 || IsBlocked || Balance - money <  0)
            {
                return false;
            }
            Balance -= money;
            return true;
        }

        private string PrepareName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentOutOfRangeException();
            }

            name = name.Trim();

            if(name.Length < 3)
            {
                throw new ArgumentException();
            }
            return name.Trim();
        }
        private decimal PrepareBalance(decimal balance)
        {
            if(balance < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            return Math.Round(balance,4);
        }

        public override string ToString()
        {
            var accountInfo = $"Account name: {Name}, balance: {Balance:f2}";
            return IsBlocked ? $"{accountInfo}, blocked" : accountInfo; 
        }
    }
}
