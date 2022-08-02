namespace CSharpHints
{
    class SyntaxRules : ILesson
    {
        class Messenger<T> where T : AppMessage
        {
            public void SendMessage(T message)
            {
                Console.WriteLine($"Transfer message: {message.Text}");
            }
        }

        class AppMessage
        {
            public string Text { get; } // message
            public AppMessage(string text)
            {
                try
                {
                    Text = text;
                }
                catch when (text == null)
                {
                    // code
                }
            }
        }

        class EmailMessage : AppMessage
        {
            public EmailMessage(string text) : base(text) { }
        }

        class PhoneMessage
        {
            public PhoneMessage(string text) { }
        }

        public void StartLesson()
        {
            Messenger<AppMessage> whatsApp = new Messenger<AppMessage>();
            whatsApp.SendMessage(new AppMessage("App message"));

            Messenger<EmailMessage> outlook = new Messenger<EmailMessage>();
            outlook.SendMessage(new EmailMessage("Email message"));

            // Messenger<PhoneMessage> mobileOperator = new Messenger<PhoneMessage>(); // isn't correct, because Messenger's T get only AppMessage type
        }
    }
}
