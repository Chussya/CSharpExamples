namespace CSharpHints
{
    class Animal
    {
        private bool live = false;

        public Animal(bool live)
        {
            this.live = live;
        }

        public virtual void Print1()
        {
            Console.WriteLine($"Live - {live}");
        }

        public void Print2()
        {
            Console.WriteLine($"Live - {live}");
        }
    }

    class Dog : Animal
    {
        private string color = null;

        public Dog(bool live, string color) : base(live)
        {
            this.color = color;
        }

        // Overriding:
        public override void Print1()
        {
            base.Print1();
            Console.WriteLine($"Color - {color}");
        }

        // Hiding:
        public new void Print2()
        {
            base.Print2();
            Console.WriteLine($"Color - {color}");
        }
    }

    class VirtualAndHidingLesson : ILesson
    {
        public void StartLesson()
        {
            Animal dog1 = new Dog(true, "brown");
            Console.WriteLine("Print1:");
            dog1.Print1();
            Console.WriteLine("Print2:");
            dog1.Print2();                  // Doesn't show color, because of Print2 in Dog class hiding from Animal class.
            Console.WriteLine();

            Dog dog2 = new Dog(false, "yellow");
            Console.WriteLine("Print1:");
            dog2.Print1();
            Console.WriteLine("Print2:");
            dog2.Print2();
        }
    }
}
