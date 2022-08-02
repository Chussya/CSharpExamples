namespace CSharpHints
{
    internal class AnonymousTypeLesson : ILesson
    {
        public class Man
        {
            public int Age { get; set; }
            public string Name { get; set; } = string.Empty;
        }

        public void StartLesson()
        {
            var anonymousType = new
            {
                what = "what",
                the = "the",
                khm = "..."
            };

            Console.WriteLine($"{anonymousType.what} {anonymousType.the} {anonymousType.khm}");

            Man man = new Man();
            man.Name = "Albert";
            man.Age = 5;

            var user = new { man.Name, man.Age }; // projection initializers

            Console.WriteLine(user.Age);
            Console.WriteLine(user.Name);
            Console.WriteLine(user.GetType().Name);
        }
    }
}
