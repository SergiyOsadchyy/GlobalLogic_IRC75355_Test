using System;
using GlobalLogic_IRC75355_Test.Controllers;
using GlobalLogic_IRC75355_Test.Services;

namespace GlobalLogic_IRC75355_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var pathToSource = @"C:\Users\Serg\RiderProjects\GlobalLogic_IRC75355_Test\GlobalLogic_IRC75355_Test\Lorem.txt";
            
            IController ctr = new Controller(new ReadService());
            
            ctr.Execute(pathToSource);
        }
    }
}