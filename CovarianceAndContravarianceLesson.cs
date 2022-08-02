namespace CSharpHints
{
    class CovarianceAndContravarianceLesson : ILesson
    {
        class Person
        {
            public string Name { get; set; } = string.Empty;
        }
        class Client : Person { }

        delegate Person M1(string name);
        delegate void M2(Client client);

        public void StartLesson()
        {
            M1 personDel;
            personDel = BuildClient; // Covariance: If your delegate returns BaseType, you can init it to other delegates what return DerrivedType
            Person p = personDel("Tom");
            Console.WriteLine(p.Name);

            M2 clientInfo = GetPersonInfo; // Contravariance: If your delegate has DerrivedType param(s), you can init it to other delegates what have BaseType params
            Client client = new Client { Name = "Alice" };
            clientInfo(client);
        }

        private static Client BuildClient(string name)
        {
            return new Client { Name = name };
        }

        private static void GetPersonInfo(Person p)
        {
            Console.WriteLine(p.Name);
        }
    }
}
