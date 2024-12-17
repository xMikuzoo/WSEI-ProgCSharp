namespace CR_Konto_w_banku__part1_
{
    public class AccountPlus : Account, IAccountWithLimit
    {
        private decimal _oneTimeDebetLimit;
        public AccountPlus(string name, decimal initialBalance = 0, decimal initialLimit = 100):base(name, initialBalance) 
        {
            OneTimeDebetLimit = initialLimit;
        }

        public decimal OneTimeDebetLimit
        {
            get { return _oneTimeDebetLimit; }
            set
            {
                if (!IsBlocked)
                {
                    _oneTimeDebetLimit = PrepareOneTimeDebetLimit(value);
                }
            }
        }
        public decimal AvaibleFounds { get { return Math.Round(Balance + OneTimeDebetLimit, PRECISION); } }

        public new bool Withdrawal(decimal amount)
        {
            if (amount <= 0 || IsBlocked)
            {
                return false;
            }
            if (amount > AvaibleFounds)
            {
                return false;
            }

            if (amount <= Balance)
            {
                return base.Withdrawal(amount);
            }

            base.Withdrawal(Balance);
            Block();
            
            return true;
        }

        private decimal PrepareOneTimeDebetLimit(decimal debetLimit)
        {
            if(debetLimit < 0m)
            {
                return 0m;
            }
            return Math.Round(debetLimit, PRECISION);
        }

        public override string ToString() =>
        IsBlocked ? $"Account name: {Name}, balance: {Balance:F2}, blocked, avaible founds: {AvaibleFounds:F2}, limit: {OneTimeDebetLimit:F2}"
                    : $"Account name: {Name}, balance: {Balance:F2}, avaible founds: {AvaibleFounds:F2}, limit: {OneTimeDebetLimit:F2}";
    }
}
