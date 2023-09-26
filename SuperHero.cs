using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class SuperHero
    {
        private string name;
        public string Name {get { return name; }}
        static private bool BatmanIsHere;
        static private bool SupermanIsHere;

        public SuperHero(string name)
        {
            this.NewHero(name);
        }

        public void NewHero(string Name) { 
            if (Name == "Batman" & !BatmanIsHere)
            {
                this.name = Name;
                BatmanIsHere = true;
            }
            else if(Name == "Superman" & !SupermanIsHere){
                this.name = Name;
                SupermanIsHere = true;
            }
            else
            {
                throw new Exception("Вы ввели неверное имя героя или героев уже максимальное количество.");
            }
        }
    }
}
