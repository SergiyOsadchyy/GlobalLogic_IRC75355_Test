using System;
using System.Collections.Generic;
using GlobalLogic_IRC75355_Test.Services;

namespace GlobalLogic_IRC75355_Test.Controllers
{
    public class Controller : IController
    {
        private string[] _lines;
        private IReadService _readService;
        private ISplitService _splitService;
        private Dictionary<string, List<int>> _words;
        private IWriteService _writeService;
        
        public Controller()
        {
            _readService = new ReadService();
            _splitService = new SplitService();
            _writeService = new WriteService();
        }
        
        public void Execute(string pathToFolder, string sourceFileName, string resultFileName)
        {
            _lines =_readService.Read(pathToFolder + sourceFileName);
            _words = _splitService.Split(_lines);
            _writeService.Write(_words, pathToFolder, resultFileName);
        }
    }
}