using System;
using System.Collections.Generic;

namespace GlobalLogic_IRC75355_Test.Services
{
    public class SplitService : ISplitService
    {
        private string _input;
        private int _position;
        private Dictionary<string, List<int>> _words;

        public Dictionary<string, List<int>> Split(string[] lines)
        {
            _words = new Dictionary<string, List<int>>();

            for (int i = 0; i < lines.Length; i++)
            {
                AllWordsFromLine(lines[i], i + 1);
            }

            return _words;
        }

        private void AllWordsFromLine(string line, int lineNumber)
        {
            _input = line;
            _position = 0;
            
            string word = "";
            
            while (word != "_EndOfInput")
            {
                if (word != "_IsNotAWord" && word != "")
                {
                    if (!_words.ContainsKey(word))
                    {
                        _words.Add(word, new List<int>() {lineNumber});
                    }
                    else
                    {
                        _words[word].Add(lineNumber);
                    }
                }
                word = NextWord();
            }
        }

        private string NextWord()
        {
            SkipWhitespacesAndNewLines();

            if (_position < _input.Length)
            {
                char character = _input[_position];

                if (Char.IsLetter(character))
                {
                    return RecognizeWord();
                }
            
                _position += 1;
            
                return "_IsNotAWord";
            }
            return "_EndOfInput";
        }

        private string RecognizeWord()
        {
            string word = "";
            int position = _position;
            
            while (position < _input.Length)
            {
                char character = _input[position];

                if (!(Char.IsLetter(character) || Char.IsDigit(character)))
                {
                    break;
                }

                word += character;
                position += 1;
            }

            _position += word.Length;

            return word;
        }
        
        private void SkipWhitespacesAndNewLines()
        {
            while (_position < _input.Length && Char.IsWhiteSpace(_input[_position]))
            {
                _position += 1;
            }
        }
    }
}