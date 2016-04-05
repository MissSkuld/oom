using System.Collections.Generic;
using NUnit.Framework;

namespace Task2
{
    [TestFixture]
    class Tests
    {
        [Test]
        public void CreateCatWithName()
        {
            var name = "Cat";

            Cat c = new Cat(name);

            Assert.IsTrue(c.Name == name);
            Assert.IsTrue(c.IsHungry == true);
            Assert.IsTrue(c.Color == "grey");
            Assert.IsTrue(c.Peculiarities.Count == 0);
        }

        [Test]
        public void CreateCatWithEverything()
        {
            var name = "Cat";
            var color = "black";
            var age = 5;
            var peculiarities = new List<string> { "a peculiarity" };

            Cat c = new Cat(color, age, name, peculiarities);

            Assert.IsTrue(c.Name == name);
            Assert.IsTrue(c.IsHungry == true);
            Assert.IsTrue(c.Color == color);
            Assert.IsTrue(c.Age == age);
            Assert.IsTrue(c.Peculiarities.Count == peculiarities.Count);
        }

        [Test]
        public void CreateCatWithEverythingButPeculiarities()
        {
            var name = "Cat";
            var color = "black";
            var age = 5;
            
            Cat c = new Cat(color, age, name);

            Assert.IsTrue(c.Name == name);
            Assert.IsTrue(c.IsHungry == true);
            Assert.IsTrue(c.Color == color);
            Assert.IsTrue(c.Age == age);
            Assert.IsTrue(c.Peculiarities.Count == 0);
        }

        [Test]
        public void FeedHungryCatTest()
        {
            Cat c = new Cat("Cat");
            c.Feed();

            Assert.IsTrue(c.IsHungry == false);
        }

        [Test]
        public void CreateFish()
        {
            var name = "Fisch";

            Fish f = new Fish(name);

            Assert.IsTrue(f.Name == name);
            Assert.IsTrue(f.Age == 1);
            Assert.IsTrue(f.Color == "silver");
            Assert.IsTrue(f.IsEnvironmentClean == true);
        }

        [Test]
        public void CreateFishWithEverything()
        {
            var name = "Fisch";
            var color = "orange";
            var age = 5;

            Fish f = new Fish(color, age, name);

            Assert.IsTrue(f.Name == name);
            Assert.IsTrue(f.Age == age);
            Assert.IsTrue(f.Color == color);
            Assert.IsTrue(f.IsEnvironmentClean == true);
        }

        [Test]
        public void FeedFish()
        {
            var name = "Fisch";
            var color = "orange";
            var age = 5;

            Fish f = new Fish(color, age, name);

            f.Feed();

            Assert.IsTrue(f.IsHungry == false);
        }

        [Test]
        public void FeedFish2Times()
        {
            var name = "Fisch";
            var color = "orange";
            var age = 5;

            Fish f = new Fish(color, age, name);

            f.Feed();
            f.Feed();

            Assert.IsTrue(f.IsHungry == false);
            Assert.IsTrue(f.IsEnvironmentClean == false);
        }
    }
}
