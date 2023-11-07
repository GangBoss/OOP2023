using System.Reflection;

namespace ObjectPrinting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var test = new Person() { Age = 15, Height = 185, Name = "павлуша", BirthDate = new DateTime(2003, 12, 31) };
            ObjectPrinter.For<Person>().Except("Age").Except<double>().Print(test);
        }
    }

    public class ObjectPrinter
    {
        public static PrintingConfig<T> For<T>()
        {
            return new PrintingConfig<T>();
        }

    }

    public class PrintingConfig<T>
    {
        private List<FieldInfo> fieldsToPrint = new List<FieldInfo>();

        public PrintingConfig<T> Except(params string[] fieldsToExcept)
        {
            if (fieldsToPrint.Count == 0)
            {
                foreach (var field in typeof(T).GetFields())
                {
                    if (!fieldsToExcept.Contains(field.Name))
                        fieldsToPrint.Add(field);
                }
            }
            else
            {
                foreach (var field in typeof(T).GetFields())
                {
                    if (fieldsToExcept.Contains(field.Name))
                        fieldsToPrint.Remove(field);
                }
            }

            return this;
        }

        public PrintingConfig<T> Except<V>()
        {
            if (fieldsToPrint.Count == 0)
            {
                foreach (var field in typeof(T).GetFields())
                {
                    if (field.GetType() != typeof(V))
                        fieldsToPrint.Add(field);
                }
            }
            else
            {
                foreach (var field in typeof(T).GetFields())
                {
                    if (field.FieldType == typeof(V))
                        fieldsToPrint.Remove(field);
                }
            }

            return this;
        }

        public void Print(T obj)
        {
            Console.WriteLine(typeof(T).Name);
            foreach (var field in fieldsToPrint)
            {
                Console.WriteLine($"{field.Name} -> {field.GetValue(obj)}");
            }
        }
    }

    public class Person
    {
        public string Name;
        public int Age;
        public double Height;
        public DateTime BirthDate;

        public Person()
        {

        }
    }
}