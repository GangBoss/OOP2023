using System.Collections.Generic;
using System.LINQ;

namespace Git
{
    public class Superhero
    {
        private static readonly Dictionary<string, bool> NameList = new Dictionary<string, bool> 
        {
            { "Superman", false },
            { "Batman", false }
        };
        public string Name { get; }

        public Superhero(string name) 
        {
            if (NameList.ContainsKey(name) && !NameList[name])
                Name = name;
            else 
                throw new ArgumentException("Нельзя создавать много героев");
        }
    }
}