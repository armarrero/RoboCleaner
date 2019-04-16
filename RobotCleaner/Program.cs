using System;

namespace RobotCleaner
{
    class Program
    {
        static void Main(string[] args)
        {
            var commandsNum = Int32.Parse(Console.ReadLine());
            var coordinatesLine = Console.ReadLine().Split(' ');
            var x = Int32.Parse(coordinatesLine[0]);
            var y = Int32.Parse(coordinatesLine[1]);

            Robot rosie = new Robot(x, y);

            for(var i = 1; i <= commandsNum; i++)
            {
                var command = Console.ReadLine().Split(' ');
                rosie.Clean(command[0], Int32.Parse(command[1]));
            }

            Console.WriteLine(rosie.DisplayCleaned());
        }
    }
}
