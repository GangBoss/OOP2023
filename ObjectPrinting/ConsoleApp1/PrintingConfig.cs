using System.Reflection;
using System.Text;

namespace ObjectPrinting
{
    public class PrintingConfig<T>
    {
        private List<PropertyInfo> properties = new List<PropertyInfo>();
        private Func<T, string> serializer;
        public PrintingConfig()
        {
            properties.AddRange(typeof(T).GetProperties());
            serializer = this.DefaultSerializer;

        }
        private string DefaultSerializer(T obj)
        {
            var sb = new StringBuilder();
            foreach (PropertyInfo prop in properties)
            {
                sb.Append(String.Format("{1} {0} - {2}", prop.Name, prop.PropertyType, prop.GetValue(obj)));
            }
            return sb.ToString();
        }
        public string PrintToString(T obj)
        {
            return this.serializer(obj);
        }
        public  PrintingConfig<T> ExcludeType(Type type)
        {
            properties = properties.Where(prop => !prop.PropertyType.Equals(type)).ToList();
            return this;
        }
        public PrintingConfig<T> SetDifferentSerializer(Func<T, string> serializer)
        {
            this.serializer = serializer; 
            return this;
        }
    }
}