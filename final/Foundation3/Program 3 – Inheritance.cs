using System;
using System.Collections.Generic;

// Base class for all animals
class Animal
{
    protected string _name;

    public Animal(string name)
    {
        _name = name;
    }

    public virtual void Speak()
    {
        Console.WriteLine($"{_name} makes a sound.");
    }
}

// Dog class inherits from Animal
class Dog : Animal
{
    public Dog(string name) : base(name) { }

    public override void Speak()
    {
        Console.WriteLine($"{_name} barks.");
    }
}

// Cat class inherits from Animal
class Cat : Animal
{
    public Cat(string name) : base(name) { }

    public override void Speak()
    {
        Console.WriteLine($"{_name} meows.");
    }
}

// Main program to test inheritance
class Program
{
    static void Main(string[] args)
    {
        List<Animal> animals = new List<Animal>
        {
            new Dog("Seamus"),
            new Cat("Gilly")
        };

        foreach (Animal animal in animals)
        {
            animal.Speak();
        }
    }
}
