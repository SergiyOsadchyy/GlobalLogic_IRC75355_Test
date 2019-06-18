using System.Collections.Generic;

namespace GlobalLogic_IRC75355_Test.Services
{
    public interface ISplitService
    {
        Dictionary<string, List<int>> Split(string[] inputString);
    }
}