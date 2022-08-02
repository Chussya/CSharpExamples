using System;

namespace CSharpHints
{
    class SyntaxRules : ILesson
    {
        class Messenger<T> where T : Message
        {
            public void SendMessage(T message)
            {
                Console.WriteLine($"Отправляется сообщения: {message.Text}");
            }
        }

        class Message
        {
            public string Text { get; } // текст сообщения
            public Message(string text)
            {
                try
                {
                    Text = text;
                }
                catch when (text == null)
                {
                    // код
                }
            }
        }
        class EmailMessage : Message
        {
            public EmailMessage(string text) : base(text) { }
        }

        public void StartLesson()
        {
            Messenger<Message> telegram = new Messenger<Message>();
            telegram.SendMessage(new Message("Hello World"));

            Messenger<EmailMessage> outlook = new Messenger<EmailMessage>();
            outlook.SendMessage(new EmailMessage("Bye World"));
        }
    }
}
