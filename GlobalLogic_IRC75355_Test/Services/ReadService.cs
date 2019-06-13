using System;
using System.IO;

namespace GlobalLogic_IRC75355_Test.Services
{
    public class ReadService : IReadService
    {
        private string _inputString = "";
        
        public string Read(string pathToSource)
        {
            try
            {
                if (!File.Exists(pathToSource))
                {
                    throw new FileNotFoundException();
                }
                
                using (FileStream fs = File.Open(pathToSource, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))  
                {  
                    using (BufferedStream bs = new BufferedStream(fs))  
                    {  
                        using (StreamReader sr = new StreamReader(bs))  
                        {  
                            string line;  
                            while ((line = sr.ReadLine()) != null)
                            {
                                _inputString = _inputString + line + "'\n'";
                            }  
                        }  
                    }  
                }
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