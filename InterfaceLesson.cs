namespace CSharpHints
{
    internal class InterfaceLesson : ILesson
    {
        interface IRun
        {
            void Run() => Console.WriteLine("Runner: I can run");
        }

        interface IBycicle : IRun
        {
            new void Run() => Console.WriteLine("Bycicler: I can run");
            void DriveBycicle() => Console.WriteLine("Bycicler: I can drive a bycicle");
        }

        interface IDrive : IRun
        {
            void Run() => Console.WriteLine("Driver: I can run");   // You can write method withoud 'new' key word, because it's interface and you rewrite base method
            void DriveCar() => Console.WriteLine("Driver: I can drive a car");
        }

        class Runner : IRun
        {
        }

        class Cyclist : IBycicle
        {

        }

        class Driver : IRun, IBycicle, IDrive
        {
            private bool hasCar = false;

            public Driver(bool hasCar)
            {
                this.hasCar = hasCar;
            }

            public void Run()
            {
                Console.WriteLine("DriverClass: I can run and...");
                if (hasCar) DriveCar();
                else DriveBycicle();
            }

            public void DriveBycicle()
            {
                Console.WriteLine("DriverClass: I can drive a bycicle");
            }

            public void DriveCar()
            {
                Console.WriteLine("DriverClass: I can drive a car");
            }

            void IDrive.Run()
            {
                Console.WriteLine("IDrive.Run: I can run");
            }

            void IBycicle.Run()
            {
                Console.WriteLine("IBycicle.Run: I can run");
            }
        }

        public void StartLesson()
        {
            // Implementing Default Interfaces:
            IRun runner = new Runner();
            runner.Run();
            Console.WriteLine();

            // Using hiding method Run and new method DriveBycicle:
            IBycicle cycler = new Cyclist();
            cycler.Run();
            cycler.DriveBycicle();
            Console.WriteLine();

            // Mix all :D
            Driver driver = new Driver(true);
            driver.Run();
            driver.DriveBycicle();
            driver.DriveCar();
            ((IDrive)driver).Run();
            ((IBycicle)driver).Run();
        }
    }
}
