﻿namespace ObjectPrinting.Tests
{
    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public Person(string name, int age) 
        { 
            Name = name;
            Age = age;
        }
        public Person()
        {
        }
    }
}