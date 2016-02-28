using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Fish : ICompanionAnimal
    {
        /// <summary>
        /// Voice of the Fish
        /// </summary>
        private string voice;

        /// <summary>
        /// Initializes a new instance of the <see cref="Fish"/> class.
        /// </summary>
        /// <param name="name">Name of the Fish.</param>
        public Fish(string name)
            : this("silver", 1, name)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Fish"/> class.
        /// </summary>
        /// <param name="color">Color of the Fish.</param>
        /// <param name="age">Age of the Fish.</param>
        /// <param name="name">Name of the Fish.</param>
        public Fish(string color, int age, string name)
        {
            this.Color = color;
            this.Age = age;
            this.Name = name;
            this.voice = "blub.. ";
            this.IsHungry = true;
            this.IsEnvironmentClean = true;
        }

        /// <summary>
        /// Gets the fur Color of the Fish.
        /// </summary>
        public string Color { get; }

        /// <summary>
        /// Gets a value indicating whether the Fish is hungry or not.
        /// </summary>
        public bool IsHungry { get; private set; }

        /// <summary>
        /// Gets a value indication whether the Environment of the Fish is clean or not.
        /// </summary>
        public bool IsEnvironmentClean { get; private set; }

        /// <summary>
        /// Gets the Age of the Fish.
        /// </summary>
        public int Age { get; private set; }

        /// <summary>
        /// Gets or sets the name of the Fish.
        /// </summary>
        public string Name { get; set; }

        public string Feed()
        {
            if (IsHungry)
            {
                this.IsHungry = false;
                return voice;
            }
            this.IsEnvironmentClean = false;
            return "the fish is looking at you, then it swims away.";
        }

        public string Pet()
        {
            return "The fish bites you!";
        }

        public override string ToString()
        {
            var returnString = $"{this.Name} is a {this.Color} fish, {this.Age} years old.{Environment.NewLine}";

            if (IsHungry)
            {
                returnString += $"{this.Name} is hungry.{Environment.NewLine}";
            }

            if(!IsEnvironmentClean)
            {
                returnString += $"You should definitly clean the Aquarium!{Environment.NewLine}";
            }

            return returnString;
        }
    }
}
