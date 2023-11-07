using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace ObjectPrinting
{
    public class ObjectPrinter
    {
        public static PrintingConfig<T> For<T>()
        {
            return new PrintingConfig<T>();
        }
    }

    public class PrintingConfig<T>
    {
        private readonly Dictionary<Type, Func<object, string>> typeSerializers = new Dictionary<Type, Func<object, string>>();
        private readonly HashSet<Type> excludedTypes = new HashSet<Type>();

        public PrintingConfig<T> Excluding<TProperty>()
        {
            excludedTypes.Add(typeof(TProperty));
            return this;
        }

        public PrintingConfig<T> Using<TProperty>(Func<TProperty, string> serializeFunc)
        {
            typeSerializers[typeof(TProperty)] = obj => serializeFunc((TProperty)obj);
            return this;
        }

        public string PrintToString(T obj)
        {
            return PrintObject(obj, new HashSet<object>());
        }

        private string PrintObject(object obj, HashSet<object> visitedObjects)
        {
            if (obj == null)
                return "null";

            var objectType = obj.GetType();

            if (typeSerializers.TryGetValue(objectType, out var customSerializer))
                return customSerializer(obj);

            if (objectType.IsPrimitive || objectType == typeof(string))
                return obj.ToString();

            if (visitedObjects.Contains(obj))
                return "cyclic reference";

            visitedObjects.Add(obj);

            var result = new StringBuilder();

            var properties = objectType.GetProperties()
                .Where(property => !excludedTypes.Contains(property.PropertyType))
                .ToList();

            result.AppendLine($"Type: {objectType.Name}");
            foreach (var property in properties)
            {
                result.AppendLine($"{property.Name} = {PrintObject(property.GetValue(obj), visitedObjects)}");
            }

            visitedObjects.Remove(obj);
            return result.ToString();
        }
    }
}
