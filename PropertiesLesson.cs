namespace CSharpHints
{
    class User
    {
        private string name = string.Empty;

        // Use properties:
        public string Name
        {
            set
            {
                name = value;
            }
            get
            {
                return name;
            }
        }

        // Use custom methods:
        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return name;
        }
    }

    public class PropertiesLesson : ILesson
    {
        public void StartLesson()
        {
            User user = new User();

            // Through properties:
            user.Name = Console.ReadLine();
            Console.WriteLine("User name is: {0}", user.Name);

            // Through methods:
            user.SetName(Console.ReadLine());
            Console.WriteLine($"User name is: {user.GetName()}");
        }
    }
}
