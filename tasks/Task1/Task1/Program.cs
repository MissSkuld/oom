using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var hello = "Hello world!";
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"{hello}");
        }
    }
}
