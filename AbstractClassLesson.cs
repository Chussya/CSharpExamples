namespace CSharpHints
{
    internal class AbstractClassLesson : ILesson
    {
        internal abstract class AbstractClass
        {
            public bool BaseValue { get; set; }
            public abstract bool DerrivedValue { get; set; }

            public AbstractClass() { }

            public AbstractClass(bool baseValue)
            {
                this.BaseValue = baseValue;
                this.DerrivedValue = baseValue;
            }
        }

        internal class DerrivedClass : AbstractClass
        {
            public new bool BaseValue { get; set; } = false;
            public override bool DerrivedValue { get; set; }

            // For use constructor of base class you should use this: ': base(arguments)'
            public DerrivedClass() : base() { }
            public DerrivedClass(bool baseValue, bool derrivedValue) : base(baseValue)
            {
                // baseValue will be init in base constructor because used ': base(baseValue)'
                // also, instead of, can write like:
                // this.baseValue = baseValue;
                this.DerrivedValue = derrivedValue;
            }
        }

        public void StartLesson()
        {
            AbstractClass correctInit = new DerrivedClass();  // Cannot use constructor of base class: = new AbstractClass() - incorrect!
            AbstractClass abstractClass = new DerrivedClass(true, false);
            DerrivedClass derrivedClass = new DerrivedClass(true, false);

            Console.WriteLine($"BaseValue of abstractClass: {abstractClass.BaseValue}");
            Console.WriteLine($"DerrivedValue of abstractClass: {abstractClass.DerrivedValue}");
            Console.WriteLine($"BaseValue of derrivedClass: {derrivedClass.BaseValue}");
            Console.WriteLine($"DerrivedValue of derrivedClass: {derrivedClass.DerrivedValue}");
        }
    }
}
