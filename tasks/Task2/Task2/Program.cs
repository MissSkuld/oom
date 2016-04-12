using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using System.Threading.Tasks;

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

            // Does some stuff
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

            // Json things...
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

            // Tasks
            var tasks = new List<Task<Cat>>();
            Random r = new Random();

            foreach (var cat in litter)
            {
                var task = Task.Run(() =>
                {
                    Console.WriteLine($"This is {cat.Name}");
                    cat.Feed();
                    Task.Delay(1000 + r.Next(10) * 1000);
                    Console.WriteLine($"You tried to feed {cat.Name}");
                    return cat;
                });

                tasks.Add(task);
            }

            Console.WriteLine("VERY VERY VERY IMPORTANT THINGS ARE HAPPENING HERE, UNTIL THE PROGRAMM CONTINUES... ;)");

            Thread.Sleep(10000);

            var moreTasks = new List<Task<Cat>>();

            foreach (var task in tasks.ToArray())
            {
                moreTasks.Add(task.ContinueWith(t => 
                {
                    Console.WriteLine($"Result of what you have done: '{t.Result}'");
                    return t.Result;
                }));
            }


            // Reactive Things
            var producer = new Subject<Cat>();//.Where(x => x.Age == 1).ToList(); // gleichzeitig Observable und Observer

            producer.Subscribe(cat => Console.WriteLine($"received cat: {cat}"));

            foreach (var cat in litter)
            {
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                producer.OnNext(cat); // push a cat to subscribers
            }

            Console.ReadLine();
        }
    }
}
