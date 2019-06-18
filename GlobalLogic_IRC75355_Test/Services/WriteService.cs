using System;
using System.Collections.Generic;
using System.Linq;

namespace GlobalLogic_IRC75355_Test.Services
{
    public class WriteService : IWriteService
    {
        public void Write(Dictionary<string, List<int>> words, string pathToFolder , string resultFileName)
        {
            using (System.IO.StreamWriter file = 
                new System.IO.StreamWriter(pathToFolder + resultFileName))
            {
                try
                {
                    foreach (var word in words.OrderBy(i => i.Key))
                    {
                        file.Write(word.Key.ToLower());
                        file.Write(": ");
                        file.Write(String.Join(", ", word.Value.ToArray()));
                        file.WriteLine();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
    }
}