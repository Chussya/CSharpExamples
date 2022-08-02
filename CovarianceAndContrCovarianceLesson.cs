using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpHints
{
    class Person1
    {
        public string Name { get; set; }
    }
    class Client : Person1 { }

    class CovarianceAndContrCovarianceLesson : ILesson
    {
        delegate Person1 PersonFactory(string name);
        delegate void ClientInfo(Client client);

        public void StartLesson()
        {
            PersonFactory personDel;
            personDel = BuildClient; // ковариантность
            Person1 p = personDel("Tom");
            Console.WriteLine(p.Name);

            ClientInfo clientInfo = GetPersonInfo; // контравариантность
            Client client = new Client { Name = "Alice" };
            clientInfo(client);
        }

        private static Client BuildClient(string name)
        {
            return new Client { Name = name };
        }

        private static void GetPersonInfo(Person1 p)
        {
            Console.WriteLine(p.Name);
        }
    }
}
