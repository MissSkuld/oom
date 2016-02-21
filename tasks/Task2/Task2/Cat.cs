
using System;
using System.Collections.Generic;

namespace Task2
{
    /// <summary>
    /// Possible moods for the Cat.
    /// </summary>
    public enum Mood
    {
        Alert,
        Awake,
        Happy,
        Grumpy,
        Sleepy,
    };

    /// <summary>
    /// Represents a virtual Cat. Meow.
    /// </summary>
    public class Cat
    {
        /// <summary>
        /// Actual mood of the Cat.
        /// </summary>
        private Mood mood;

        /// <summary>
        /// Voice of the cat
        /// </summary>
        private string voice;

        /// <summary>
        /// Initializes a new instance of the <see cref="Cat"/> class. All Cats are grey!! 
        /// </summary>
        /// <param name="name">
        /// Name of the Cat
        /// </param>
        public Cat(string name)
            : this("grey", 1, name, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Cat"/> class. 
        /// Creates a instance of a Cat.
        /// </summary>
        /// <param name="color">
        /// Fur color.
        /// </param>
        /// <param name="age">
        /// Age of Cat.
        /// </param>
        /// <param name="name">
        /// Name of Cat.
        /// </param>
        /// <param name="peculiarities">
        /// The peculiarities.
        /// </param>
        public Cat(string color, int age, string name, List<string> peculiarities = null)
        {
            this.Color = color;
            this.Age = age;
            this.Name = name;

            this.Peculiarities = peculiarities ?? new List<string>();

            this.IsHungry = true;
            this.mood = Mood.Awake;
            this.voice = "Meow!";
        }

        /// <summary>
        /// Gets the fur Color of the Cat.
        /// </summary>
        public string Color { get; }

        /// <summary>
        /// Gets a value indicating whether the Cat is hungry or not.
        /// </summary>
        public bool IsHungry { get; private set; }

        /// <summary>
        /// Gets the Age of the Cat.
        /// </summary>
        public int Age { get; private set; }

        /// <summary>
        /// Gets or sets the Peculiarities of the Cat.
        /// </summary>
        public List<string> Peculiarities { get; set; }

        /// <summary>
        /// Gets or sets the name of the Cat.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Feed the Cat.
        /// </summary>
        /// <returns>Meow, if everything is ok.</returns>
        public string Feed()
        {
            this.IsHungry = false;
            this.mood = Mood.Sleepy;
            return voice;
        }

        /// <summary>
        /// Pets the Cat.
        /// </summary>
        /// <returns>Meow, if everything is ok.</returns>
        public string Pet()
        {
            if (this.mood != Mood.Sleepy)
            {
                this.mood = Mood.Happy;
                return voice;
            }

            return $"{this.Name} doesn't want to be pet and scratches you instead!{Environment.NewLine}";

        }

        /// <summary>
        /// Orders the Cat to take a nap.
        /// </summary>
        /// <returns>Meow, if everything is ok.</returns>
        public string TakeANap()
        {
            if (this.mood == Mood.Sleepy)
            {
                var r = new Random();
                var sleepTime = r.Next(10);

                for (var i = 0; i < sleepTime; i++)
                {
                    Console.WriteLine($"zzzZZZzzz");
                }

                this.mood = Mood.Happy;

                return voice;
            }
            else
            {
                this.mood = Mood.Grumpy;
                return $"{this.Name} doesn't want to sleep!";
            }
        }

        public override string ToString()
        {
            var returnValue = $"{this.Name} is a {this.Color} cat, {this.Age} years old.{Environment.NewLine}";

            if (this.Peculiarities.Count > 0)
            {
                var value = $"{this.Name} has the following peculiarities:{Environment.NewLine}";

                foreach (var peculiarity in this.Peculiarities)
                {
                    value += $"\t{peculiarity}. {Environment.NewLine}";
                }

                returnValue += value;
            }

            if (IsHungry)
            {
                returnValue += $"{this.Name} is hungry.{Environment.NewLine}";
            }

            returnValue += $"{this.Name} is {this.mood}.{Environment.NewLine}";

            return returnValue;
        }
    }
}
