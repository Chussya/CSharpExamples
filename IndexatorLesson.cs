﻿namespace CSharpHints
{
    class IndexatorLesson : ILesson
    {
        class Person
        {
            public string Name { get; set; }

            public Person(string name)
            {
                Name = name;
            }
        }
        class People
        {
            Person[] data;
            public People()
            {
                data = new Person[2];
            }

            public Person this[int index]
            {
                get
                {
                    return data[index];
                }
                set
                {
                    data[index] = value;
                }
            }

            public Person this[string name]
            {
                get
                {
                    return Array.Find(data, p => p.Name == name)!;
                }
                set
                {
                    int index = Array.FindIndex(data, p => p.Name == name);
                    data[index] = value;
                }
            }
        }

        public void StartLesson()
        {
            People people = new People();
            people[0] = new Person("Tom");
            people[1] = new Person("Bob");

            Person tom = people[0];
            Person bob = people["Bob"];

            Console.WriteLine(tom.Name);    // Tom
            Console.WriteLine(bob.Name);    // Bob
        }
    }
}
