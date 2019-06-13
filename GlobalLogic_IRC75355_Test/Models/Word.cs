using System.Collections.Generic;

namespace GlobalLogic_IRC75355_Test.Models
{
    public class Word : IWord
    {
        public string Value { get; set; }
        public List<int> LineNumbers { get; set; }

        public Word(string value)
        {
            this.Value = value;
            LineNumbers = new List<int>();
        }
    }
}