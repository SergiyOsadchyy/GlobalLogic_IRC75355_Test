using GlobalLogic_IRC75355_Test.Controllers;
using GlobalLogic_IRC75355_Test.Services;

namespace GlobalLogic_IRC75355_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var pathToFolder = @"C:\Users\Serg\RiderProjects\GlobalLogic_IRC75355_Test\GlobalLogic_IRC75355_Test\";
            var sourceFileName = "Lorem.txt";
            var resultFileName = "resultLorem.txt";

            IController ctr = new Controller(new ReadService(), new SplitService(), new WriteService());
            
            ctr.Execute(pathToFolder, sourceFileName, resultFileName);
        }
    }
}