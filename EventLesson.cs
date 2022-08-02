namespace CSharpHints
{
    class EventLesson : ILesson
    {
        class AccountEventArgs
        {
            public string Message { get; }

            public int Sum { get; }

            public AccountEventArgs(string mes, int sum)
            {
                Message = mes;
                Sum = sum;
            }
        }

        class Account
        {
            public delegate void AccountHandler(object sender, AccountEventArgs e);
            public event AccountHandler? Notify;

            public Account(int sum)
            {
                Sum = sum;
            }

            public int Sum { get; private set; }

            public void Put(int sum)
            {
                Sum += sum;
                Notify?.Invoke(this, new AccountEventArgs($"Into your account: {sum}$", sum));
            }

            public void Take(int sum)
            {
                if (Sum >= sum)
                {
                    Sum -= sum;
                    Notify?.Invoke(this, new AccountEventArgs($"{sum}$ withdraw from your account", sum));
                }
                else
                {
                    Notify?.Invoke(this, new AccountEventArgs("Not enough money in your account", sum)); ;
                }
            }
        }
        public void StartLesson()
        {
            Account acc = new Account(100);
            acc.Notify += DisplayMessage;
            acc.Put(20);
            acc.Take(70);
            acc.Take(150);
        }

        private static void DisplayMessage(object sender, AccountEventArgs e)
        {
            Console.WriteLine($"Transaction amount: {e.Sum}");
            Console.WriteLine(e.Message);
        }
    }
}
