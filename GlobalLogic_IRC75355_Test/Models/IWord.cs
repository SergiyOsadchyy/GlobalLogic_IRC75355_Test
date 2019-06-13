using System.Collections.Generic;

namespace GlobalLogic_IRC75355_Test.Models
{
    public interface IWord
    {
        string Value { get; set; }
        List<int> LineNumbers { get; set; }
    }
}