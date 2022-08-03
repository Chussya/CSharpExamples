using System.Collections;

namespace CSharpHints
{
    internal class EnumeratorAndEnumerableLesson : ILesson
    {
        class EnumerableClass : IEnumerable
        {
            int[] ints = {1, 2, 3};

            public IEnumerator GetEnumerator() => ints.GetEnumerator();
        }

        class EnumeratorClass : IEnumerator
        {
            int[] ints;
            int position = -1;

            public EnumeratorClass(int[] ints) => this.ints = ints;

            public object Current
            {
                get
                {
                    if (position >= ints.Length || position <= -1)
                        throw new ArgumentOutOfRangeException();
                    return ints[position];
                }
            }

            public bool MoveNext()
            {
                if (position < ints.Length - 1)
                {
                    position++;
                    return true;
                }
                return false;
            }

            public void Reset()
            {
                position = -1;
            }
        }

        class Test
        {
            int[] ints = {9, 6, 3, 0};

            public IEnumerator GetEnumerator()
            {
                return new EnumeratorClass(ints);
            }
        }

        public void StartLesson()
        {
            EnumerableClass enumerable = new EnumerableClass();

            foreach (var num in enumerable)
            {
                Console.WriteLine($"Enumerable: {num}");
            }
            Console.WriteLine();

            Test enumerator = new Test();

            foreach (var num in enumerator)
            {
                Console.WriteLine($"Enumerator: {num}");
            }
        }
    }
}
