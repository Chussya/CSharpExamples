# CSharpHints
**In this project, you will be able to see some of the features of C# through code examples.**

## Sources
**Some examples from this project taken from the [Metanit](https://metanit.com)**

## Guide
For run some lesson just choose name of lesson in Program.cs:

```csharp
namespace CSharpHints
{
    internal class Program
    {
        public static void Main()
        {
            string lines = new string('=', 30);
            Console.WriteLine($"{lines}Start Lesson{lines}");

            ILesson lesson = new LessonName();  // <-- instead of LessonName write name from available classes, eg: AbstractClassLesson
            lesson.StartLesson();

            Console.WriteLine($"{lines}End Lesson{lines}");
        }
    }
}
```

## IDE and other settings
* This project was created on [Visual Studio 2022](https://visualstudio.microsoft.com/)
* C# version - 10
* .NET Framework version - 6.0