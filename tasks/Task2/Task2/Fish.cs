using Newtonsoft.Json;
using System;

namespace Task2
{
    class Fish : Animal, ICompanionAnimal
    {
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
        [JsonConstructor]
        public Fish(string color, int age, string name)
            : base(name, color, age, "blub..")
        {
            this.IsEnvironmentClean = true;
        }

        /// <summary>
        /// Gets a value indication whether the Environment of the Fish is clean or not.
        /// </summary>
        public bool IsEnvironmentClean { get; private set; }

        /// <summary>
        /// Feeds the fish.
        /// </summary>
        /// <returns></returns>
        public string Feed()
        {
            if (IsHungry)
            {
                this.IsHungry = false;
                return GetVoice();
            }
            this.IsEnvironmentClean = false;
            return "the fish is looking at you, then it swims away.";
        }

        /// <summary>
        /// Pets the fish.
        /// </summary>
        /// <returns></returns>
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
