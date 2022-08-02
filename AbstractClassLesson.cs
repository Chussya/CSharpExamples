namespace AbstractClassExample
{
    internal abstract class AbstractClass
    {
        public bool baseValue { get; set; }
        public abstract bool abstractValue { get; set; }

        public AbstractClass() { }

        public AbstractClass(bool baseValue) { }
    }

    internal class DerrivedClass : AbstractClass
    {
        public override bool abstractValue
        {
            get => abstractValue;
            set
            {
                abstractValue = value;
                baseValue = !value;
            }
        }

        public DerrivedClass() : base() { }
        public DerrivedClass(bool baseValue, bool abstractValue) : base(baseValue) { }
    }

    internal class AbstractClassLesson
    {
        public void Main()
        {

        }
    }
}
