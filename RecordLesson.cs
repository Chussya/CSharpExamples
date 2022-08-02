namespace CSharpHints
{
    internal class RecordLesson : ILesson
    {
        public record class PositionRecords(string first, string second, int third); // also then example under:

        /*
         * public record PositionRecords
         * {
         *     public string first { get; init; }
         *     public string second { get; init; }
         *     public string third { get; init; }
         *     public PositionRecords(string first, string second, string third)
         *     {
         *         this.first = first;
         *         this.second = second;
         *         this.third = third;
         *     }
         *     public void Deconstruct(out string first, out string second, out string third) => (first, second, third) = (this.first, this.second, this.third);
         * }
         */

        public record Person
        {
            public string Login { get; init; }
            public string Name { get; set; }
            public Person(string name, string login)
            {
                Name = name;
                Login = login;
            }
        }

        public void StartLesson()
        {
            PositionRecords pr = new PositionRecords("First", "Second", 3);
            Person person = new Person("Name1", "Login1");
            Person person1 = new Person("Name1", "Login1");

            var (first, second, third) = pr; // or pr.Deconstruct(first, second, third); 
            var prChanged = pr with { first = "changedFirst" }; // initialisation with operator 'with'; also can write '= pr with {};' and get copy of record.

            Console.WriteLine(person.Equals(person1)); // True, because records is VALUE type, not reference
            Console.WriteLine(pr);
            Console.WriteLine(prChanged);
        }
    }
}
