namespace CSharpHints
{
    internal class AnonymousTypeLesson : ILesson
    {
        public class Man
        {
            public int Age { get; set; }
            public string Name { get; set; }
        }

        public void StartLesson()
        {
            Man man = new Man();
            man.Name = "Albert";
            man.Age = 5;

            var user = new { man.Name, man.Age }; // projection initializers (инициализаторы с проекцией)

            Console.WriteLine(user.Age);
            Console.WriteLine(user.Name);
            Console.WriteLine(user.GetType().Name);
        }
    }
}
