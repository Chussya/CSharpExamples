using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceExample
{
    interface IMove
    {
        void Move() => Console.WriteLine("Move: I am moving");
    }

    interface IWalk : IMove
    {
        new void Move() => Console.WriteLine("Move with new: I am walking"); // also can write without 'new' word: void Move() => ...
        void Walk() => Console.WriteLine("Walk: I am walking");
    }

    interface IDrive : IMove
    {
        new void Move() => Console.WriteLine("Move with new: I am driving");
        void Drive() => Console.WriteLine("Drive: I am driving");
    }

    class Mover : IMove
    {
    }

    class Human : IWalk
    {

    }

    class Driver : IMove, IWalk, IDrive
    {
        private bool hasCar = false;

        public Driver(bool hasCar)
        {
            this.hasCar = hasCar;
        }

        public void Move()
        {
            Console.WriteLine("Overriding IMove.Move:");
            if (hasCar) Drive();
            else Walk();
        }

        public void Walk()
        {
            Console.WriteLine("Overriding IWalk.Walk: I am walking");
        }

        public void Drive()
        {
            Console.WriteLine("Overriding IDrive.Drive: I am driving");
        }

        void IDrive.Move()
        {
            Console.WriteLine("IDrive.Move: I am driving");
        }

        void IWalk.Move()
        {
            Console.WriteLine("IWalk.Move: I am walking");
        }
    }

    internal class InterfaceLesson
    {
        public static void Start()
        {
            // Implementing Default Interfaces:
            IMove move = new Mover();
            move.Move();
            Console.WriteLine();

            // Using hiding method Move and new method Walk:
            IWalk walk = new Human();
            walk.Move();
            walk.Walk();
            Console.WriteLine();

            //
            Driver driver = new Driver(true);
            driver.Move();
            driver.Walk();
            driver.Drive();
            ((IWalk)driver).Move();
            ((IDrive)driver).Move();
        }
    }
}
