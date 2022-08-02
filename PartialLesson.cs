namespace CSharpHints
{
    /* By default partial methods should be void and cannot has:
    * access modifier (public, private and etc.)
    * out-parameters
    * virtual, override, sealed, new and extern
    *
    * Else it should has realisation (body).
    */
    internal class PartialLesson : ILesson
    {
        public partial class PartialClass
        {
            public partial string SayFirst();
            public partial string SaySecond()
            {
                return "second";
            }
            public string SayEnd()
            {
                return "End";
            }
        }

        public partial class PartialClass
        {
            public partial string SayFirst()
            {
                return "first";
            }
            public partial string SaySecond();
        }

        public void StartLesson()
        {
            PartialClass partial = new PartialClass();
            Console.WriteLine(partial.SayFirst());
            Console.WriteLine(partial.SaySecond());
            Console.WriteLine(partial.SayEnd());
        }
    }
}
