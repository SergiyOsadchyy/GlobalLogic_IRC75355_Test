using System;
using System.IO;

namespace GlobalLogic_IRC75355_Test.Services
{
    public class ReadService : IReadService
    {
        private string _inputString = "";
        private int _numberOfLines = 0;
        private string[] _lines;
        
        public string[] Read(string pathToSource)
        {
            CountNumberOfLines(pathToSource);
            
            _lines = new string[_numberOfLines];

            int index = 0;
            
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
                                _lines[index] = line;
                                index++;
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
            return _lines;
        }
        
        private int CountNumberOfLines(string pathToSource)
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
                                _numberOfLines++;
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
            return _numberOfLines;
        }
    }
}