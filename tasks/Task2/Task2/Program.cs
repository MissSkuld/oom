using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create some Cats
            var litter = new List<Cat>();
            litter.Add(new Cat("Lilu"));
            litter.Add(new Cat("black", 5, "Tapsi"));
            litter.Add(new Cat("red", 16, "Felix", new List<string> { "Needs a pillow for sleeping.", "Thinks humans can turn the rain on and off" }));
            litter.Add(new Cat("white", 5, "Karl"));

            // Create some Fishes
            var fishes = new List<Fish>();
            fishes.Add(new Fish("Gustav"));
            fishes.Add(new Fish("red-white", 2, "Nemo"));
            fishes.Add(new Fish("blue", 5, "Dora"));

            // Displays Information about all Cats
            foreach (var cat in litter)
            {
                Console.WriteLine(cat);
            }

            // Gets Felix out of all Cats
            var felix = litter.Single(cat => cat.Name == "Felix");

            // Do some stuff
            Console.WriteLine("You want Felix to take a nap:");
            Console.WriteLine(felix.TakeANap());
            Console.WriteLine();
            Console.WriteLine("How's Felix doing now?");
            Console.WriteLine(felix);
            Console.WriteLine();
            Console.WriteLine("You try to pet Felix:");
            Console.WriteLine(felix.Pet());
            Console.WriteLine("How's Felix doing now?");
            Console.WriteLine(felix);
            Console.WriteLine();
            Console.WriteLine("You want to feed Felix:");
            Console.WriteLine(felix.Feed());
            Console.WriteLine();
            felix.Name = "Jupiter";
            Console.WriteLine();
            Console.WriteLine($"Felix is now called: {felix.Name}");

            foreach (var cat in litter)
            {
                Console.WriteLine(cat);
            }

            // Create new List containing fishes and Cats
            List<ICompanionAnimal> companions = new List<ICompanionAnimal>();
            companions.AddRange(litter);
            companions.AddRange(fishes);

            foreach (var companion in companions)
            {
                Console.WriteLine(companion);
            }

            foreach (var companion in companions)
            {
                companion.Feed();
            }

            foreach (var companion in companions)
            {
                Console.WriteLine(companion);
            }

            // Console.ReadLine();
        }
    }
}
