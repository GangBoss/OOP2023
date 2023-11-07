using ObjectPrinting.Tests;
using ObjectPrinting;
using System.Globalization;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person { Name = "Alex", Age = 19};

            var printer = ObjectPrinter.For<Person>()
                .Excluding<string>();

            string s1 = printer.PrintToString(person);
            Console.WriteLine(s1);

            var printer2 = ObjectPrinter.For<Person>()
                .Using<int>(age => $"Age: {age} years");

            string s2 = printer2.PrintToString(person);
            Console.WriteLine(s2);

            var printer3 = ObjectPrinter.For<Person>()
                .Excluding<string>()
                .Using<int>(age => $"Age: {age} years");

            string s3 = printer3.PrintToString(person);
            Console.WriteLine(s3);
        }
    }
}