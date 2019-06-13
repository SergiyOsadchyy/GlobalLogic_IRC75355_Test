using System;
using System.Collections.Generic;
using System.Linq;
using GlobalLogic_IRC75355_Test.Models;

namespace GlobalLogic_IRC75355_Test.Services
{
    public class WriteService : IWriteService
    {
        public void Write(List<Word> words, string pathToFolder , string resultFileName)
        {
            var sortedWords = words.OrderBy(x => x.Value).ToList();

            using (System.IO.StreamWriter file = 
                new System.IO.StreamWriter(pathToFolder + resultFileName))
            {
                try
                {
                    foreach (var word in sortedWords)
                    {
                        file.Write(word.Value.ToLower());
                        file.Write(": ");
                        file.Write(String.Join(", ", word.LineNumbers.ToArray()));
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