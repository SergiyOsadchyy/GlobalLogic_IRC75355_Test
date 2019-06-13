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
                
                _inputString = File.ReadAllText(pathToSource);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return _inputString;
        }
    }
}