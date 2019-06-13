using System.Collections.Generic;
using GlobalLogic_IRC75355_Test.Models;

namespace GlobalLogic_IRC75355_Test.Services
{
    public interface IWriteService
    {
        void Write(List<Word> words, string pathToFolder , string resultFileName);
    }
}