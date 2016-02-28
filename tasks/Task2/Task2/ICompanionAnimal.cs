namespace Task2
{
    /// <summary>
    /// Represents a virtual animal.
    /// </summary>
    public interface ICompanionAnimal
    {
        /// <summary>
        /// Name of companion animal.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Color of companion animal.
        /// </summary>
        string Color { get; }

        /// <summary>
        /// Pets the animal.
        /// </summary>
        /// <returns></returns>
        string Pet();

        /// <summary>
        /// Orders the animal to take a nap.
        /// </summary>
        /// <returns></returns>
        string Feed();
    }
}
