using System;
using System.Collections.Generic;
using System.Reflection;

namespace ObjectPrinting
{
    public class PrintingConfig<T>
    {
        private HashSet<FieldInfo> fields; // Только которые будут выведены
        private Dictionary<Type, Func<Type, string>> specialSerialization;
        private Dictionary<Type ,IFormatProvider> formatting;
        public PrintingConfig()
        {
            this.fields = new HashSet<FieldType>();
            this.specialSerialization = new Dictionary<FieldType, Func<F, string>>();
            var fields = typeof(o).GetFields();
            foreach (var field in fields)
            {
                this.fields.Add(field);
            }
            return this;
        }

        public PrintingConfig<T> Without<F>() {
            foreach (var field in fields)
            {
                if (field.FieldType == typeof(F))
                {
                    fields.Remove(field);
                }
            }
            return this;
        }
        public PrintingConfig<T> Without<F>(string name) {
            foreach (var field in fields)
            {
                if (field.FieldType == typeof(F) && field.Name == name)
                {
                    fields.Remove(field);
                }
            }
            return this;
        }

        public PrintingConfig<T> SerializeLike<F> (Func<Type, string> func) {
            specialSerialization.Add(typeof(F), func)
            return this;
        }

        public PrintingConfig<T> Culture<F : IFormattable> (IFormatProvider format) {
            formatting.Add(typeof(F), format)
            return this;
        }

        public string Print(T o) {
            StringBuilder str = new StringBuilder();
            
            var fields = typeof(o).GetFields();
            foreach (var field in fields)
            {
                if (this.fields.Contains(field)){
                    specialSerialization.TryGetValue(field.TypeInfo, var func);
                    if (func != null) {
                        str.append(func(field));
                    } else {
                        formatting.TryGetValue(field.TypeInfo, var format)
                        var value = field.GetValue(o).ToString(null, format);
                        str.append(field.Name).append(": ").append(value);
                    }
                }
            }

            return str.ToString();
        }
    }
}