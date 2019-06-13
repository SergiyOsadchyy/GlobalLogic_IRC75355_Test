using System;
using System.Collections.Generic;
using GlobalLogic_IRC75355_Test.Controllers;
using GlobalLogic_IRC75355_Test.Models;
using GlobalLogic_IRC75355_Test.Services;

namespace GlobalLogic_IRC75355_Test.Controllers
{
    public class Controller : IController
    {
        private string _inputString;
        private IReadService _readService;
        private ISplitService _splitService;
        private List<Word> _words = new List<Word>();
        
        public Controller(IReadService readService, ISplitService splitService)
        {
            _readService = readService;
            _splitService = splitService;
        }
        
        public void Execute(string pathToSource)
        {
            _inputString =_readService.Read(pathToSource);
            _words = _splitService.Split(_inputString);
            
            foreach (var word in _words)
            {
                Console.Write(word.Value);
                Console.Write(": ");
                Console.Write(String.Join(", ", word.LineNumbers.ToArray()));
                Console.WriteLine();
            }
        }
    }
}