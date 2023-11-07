using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ObjectPrinting_
{
    public class PrintingConfig<T>
    {
        private static readonly Type[] simpleTypes =  {
            typeof(string),
            typeof(int),
            typeof(long),
            typeof(double),
            typeof(float), 
            typeof(DateTime)
        };
        private static readonly List<Type> excludedTypes = new List<Type>();
        private readonly Dictionary<Type, Func<T>> alternativeSerializationMmethod = new Dictionary<Type, Func<T>>();


        public PrintingConfig<T> Exclude(Type type)
        {
            excludedTypes.Add(type);
            return this;
        }
        public static string PrintToString(object obj)
        {
            if (obj == null)
                return "Null";

            var sb = new StringBuilder();
            var type = obj.GetType();

            if (simpleTypes.Contains(type)) 
                return ""+obj;

            if (type.GetInterface(nameof(ICollection)) != null)
            {
                PrintIEnumerableObj((IEnumerable<object>)obj);
            }

            var propertyInfos = GetProperties(type);

            if (propertyInfos.Count == 0)
            {
                
                return " " + obj; 
            }


            foreach (var property in propertyInfos)
            {
                    sb.Append(" " + property.Name + " = " + PrintToString(property.GetValue(obj)))
            }

            return sb.ToString();
        }

        private static string PrintIEnumerableObj(IEnumerable<object> obj)
        {
            var sb = new StringBuilder();

            foreach(var item in obj)
            {
                  sb.Append(" "+ PrintToString(item));
            }
            return sb.ToString();
        }

        private static List<PropertyInfo> GetProperties(Type objType)
        {
            var propertysInfos = new List<PropertyInfo>();
            foreach (var propertyInfo in objType.GetProperties())
            {
                if (excludedTypes.Contains(propertyInfo.PropertyType))
                    continue;

                propertysInfos.Append(propertyInfo);
            }
            return propertysInfos;
        }
    }
}