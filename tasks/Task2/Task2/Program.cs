using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;

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

            var settings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.Auto
            };

            var filename = "companions.json";

            File.WriteAllText(filename, JsonConvert.SerializeObject(companions, settings));

            List<ICompanionAnimal> animals = JsonConvert.DeserializeObject<List<ICompanionAnimal>>(File.ReadAllText(filename), settings);
            
            Console.WriteLine("Companions after deserializing:");
            foreach (var companion in companions)
            {
                Console.WriteLine(companion);
            }

            // Reactive Things

            var producer = new Subject<Cat>();//.Where(x => x.Age == 1).ToList();

            producer.Subscribe(cat => Console.WriteLine($"received value {cat}"));

            foreach (var cat in litter)
            {
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                producer.OnNext(cat); // push value i to subscribers
            }

            //Console.ReadLine();
        }
    }
}
