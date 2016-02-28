namespace Task2
{
    public class Animal
    {
        /// <summary>
        /// Voice of the animal
        /// </summary>
        private string voice;

        public Animal(string name, string color, int age, string voice)
        {
            this.Name = name;
            this.Color = color;
            this.Age = age;
            this.voice = voice;
            this.IsHungry = true;
        }

        /// <summary>
        /// Gets the fur Color of the animal.
        /// </summary>
        public string Color { get; }

        /// <summary>
        /// Gets a value indicating whether the animal is hungry or not.
        /// </summary>
        public bool IsHungry { get; protected set; }

        /// <summary>
        /// Gets the Age of the animal.
        /// </summary>
        public int Age { get; private set; }

        /// <summary>
        /// Gets or sets the name of the animal.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the voice of the animal.
        /// </summary>
        /// <returns></returns>
        public string GetVoice()
        {
            return this.voice;
        }
    }
}
