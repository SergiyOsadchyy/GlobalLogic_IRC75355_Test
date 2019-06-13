using System;
using System.IO;

namespace GlobalLogic_IRC75355_Test.Services
{
    public class ReadService : IReadService
    {
        private string _inputString;
        
        public string Read(string pathToSource)
        {
            try
            {
                if (!File.Exists(pathToSource))
                {
                    throw new FileNotFoundException();
                }
                else
                {
                    _inputString = File.ReadAllText(pathToSource);
                }
            }
            catch(FileNotFoundException e)
            {
                Console.WriteLine("Error: FileNotFound");
                Environment.Exit(1);
            }

            return _inputString;
        }
    }
}