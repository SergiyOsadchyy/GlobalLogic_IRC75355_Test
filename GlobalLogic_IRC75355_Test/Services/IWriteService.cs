using System.Collections.Generic;

namespace GlobalLogic_IRC75355_Test.Services
{
    public interface IWriteService
    {
        void Write(Dictionary<string, List<int>> words, string pathToFolder , string resultFileName);
    }
}