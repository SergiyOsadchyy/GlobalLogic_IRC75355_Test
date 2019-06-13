using System;
using System.Collections.Generic;
using GlobalLogic_IRC75355_Test.Models;

namespace GlobalLogic_IRC75355_Test.Services
{
    public class SplitService : ISplitService
    {
        private string _input;
        private int _line = 1;
        private int _position = 0;
        private List<Word> _words = new List<Word>();

        public List<Word> Split(string inputString)
        {
            _input = inputString;

            allWords();

            return _words;
        }

        private void allWords()
        {
            Word word = nextWord();

            while (word.Value != "_EndOfInput")
            {
                if (word.Value != "_IsNotAWord")
                {
                    if (!_words.Exists(x => x.Value == word.Value))
                    {
                        _words.Add(word);
                    }
                    else
                    {
                        var index = _words.FindIndex(0, x => x.Value == word.Value);
                        _words[index].LineNumbers.Add(word.LineNumbers[0]);
                    }
                }
                word = nextWord();
            }
        }
        
        private Word nextWord()
        {
            if (this._position >= _input.Length)
            {
                return new Word("_EndOfInput");
            }

            skipWhitespacesAndNewLines();

            char character = _input[_position];

            if (Char.IsLetter(character))
            {
                return recognizeWord();
            }
            
            _position += 1;
            
            return new Word("_IsNotAWord");
        }

        private Word recognizeWord()
        {
            string wordValue = "";
            int position = _position;
            
            while (position < _input.Length)
            {
                char character = _input[position];

                if (!(Char.IsLetter(character) || Char.IsDigit(character)))
                {
                    break;
                }

                wordValue += character;
                position += 1;
            }

            _position += wordValue.Length;

            var word = new Word(wordValue);
            word.LineNumbers.Add(_line);
            
            return word;
        }
        
        private void skipWhitespacesAndNewLines()
        {
            while (_position < _input.Length && Char.IsWhiteSpace(_input[_position]))
            {
                _position += 1;

                if (_input[_position - 1] == '\n')
                {
                    _line += 1;
                }
            }
        }
    }
}